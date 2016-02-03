using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using FileHelpers;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Web;

namespace KIPS_WMS.UI.Ponude
{
    public partial class PonudaLinija : Form
    {
        public enum ItemState
        {
            New,
            Edit
        }

        private const int BsMultiline = 0x00002000;
        private const int GwlStyle = -16;

        public List<ItemQuoteModel> QuoteItems;

        private readonly MobileWMSSync _ws = WebServiceFactory.GetWebService();

        private readonly string _customerCode;
        private readonly int _isAuthenticated;
        private readonly ItemState _itemState;
        private readonly string _quoteNo;
        private readonly Object _selectedItem;
        private string _conversionCoefficient;
        private string _itemCode;
        private string _itemBarcode;
        private string _variantCode;
        private bool _fromScanner;
        private bool _quantityWatcherEnabled = true;
        private bool _convertedQuantityWatcherEnabled = true;

        public PonudaLinija()
        {
            InitializeComponent();
            MakeButtonMultiline(bUcitaj);
        }

        public PonudaLinija(string customerCode, int isAuthenticated, ItemState itemState, string quoteNo,
            object selectedItem, List<ItemQuoteModel> quoteItems, bool fromScanner)
        {
            InitializeComponent();
            MakeButtonMultiline(bUcitaj);

            _customerCode = customerCode;
            _isAuthenticated = isAuthenticated;
            _itemState = itemState;
            _quoteNo = quoteNo;
            _selectedItem = selectedItem;
            _fromScanner = fromScanner;
            QuoteItems = quoteItems;

            DisplayData();
        }

        [DllImport("coredll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("coredll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            Text = _quoteNo;
        }

        public static void MakeButtonMultiline(Button b)
        {
            IntPtr hwnd = b.Handle;
            int currentStyle = GetWindowLong(hwnd, GwlStyle);
            SetWindowLong(hwnd, GwlStyle, currentStyle | BsMultiline);
        }

        private void DisplayData()
        {
            switch (_itemState)
            {
                case ItemState.New:

                    var modelNew = ((Object[]) _selectedItem);
                    _itemCode = modelNew[DatabaseModel.ItemDbModel.ItemCode].ToString();
                    _itemBarcode = modelNew[DatabaseModel.ItemDbModel.ItemBarcode].ToString();
                    _variantCode = (modelNew[DatabaseModel.ItemDbModel.ItemVariant] ?? String.Empty).ToString();

                    new Thread(() => GetItemInformation(_itemCode, _variantCode)).Start();

                    break;
                case ItemState.Edit:

                    var modelEdit = ((ItemQuoteModel) _selectedItem);
                    _itemCode = modelEdit.ItemCode;
                    _variantCode = (modelEdit.VariantCode ?? String.Empty);
                    _conversionCoefficient = modelEdit.ConversionCoeficient;
                    tbSifra.Text = _itemCode;
                    tbNaziv.Text = modelEdit.ItemDescription;
                    bJedinicaMere.Text = modelEdit.UnitOfMeasureCode;
                    tbJedinicaKonverzija.Text = modelEdit.UnitOfMeasureForConversion;
                    tbKolicina.Text = modelEdit.Quantity;

                    tbCena.Text = modelEdit.UnitPrice;
                    tbCenaPopust.Text = modelEdit.UnitPriceWithDiscount;

                    tbKolicinaLokacija.Text = modelEdit.TotalWarehouseQuantity;
                    tbKolicinaVezanaLokacija.Text = modelEdit.TotalLinkedWarehouseQuantity;
                    tbRaspolozivoLokacija.Text = modelEdit.AvailableWarehouseQuantity;
                    tbRaspolozivoVezanaLokacija.Text = modelEdit.AvailableLinkedWarehouseQuantity;

                    FocusQuantity();

                    break;
            }
        }

        private void GetItemInformation(string itemNo, string itemVariant)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string itemInformationCsv = String.Empty;

                _ws.GetItemInformation(_fromScanner ? _itemBarcode : itemNo, itemVariant, _customerCode, _isAuthenticated, RegistryUtils.GetLoginData().Magacin, RegistryUtils.GetLastUsername(),
                    ref itemInformationCsv);

                var engine = new FileHelperEngine(typeof (ItemInformationModel));
                var itemInformation = (ItemInformationModel[]) engine.ReadString(itemInformationCsv);
                if (itemInformation.Length > 0)
                {
                    Invoke(new EventHandler((sender, e) => UpdateData(itemInformation[0])));
                }
            }
            catch (Exception ex)
            {
                Utils.GeneralExceptionProcessing(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void UpdateData(ItemInformationModel model)
        {
            _conversionCoefficient = model.ConversionCoeficient;

            tbSifra.Text = model.ItemCode;
            tbNaziv.Text = model.ItemDescription;
            bJedinicaMere.Text = model.UnitOfMeasureCode;
            tbJedinicaKonverzija.Text = model.UnitOfMeasureForConversion;
            tbKolicina.Text = model.BaseQuantityForSale;

            tbCena.Text = model.UnitPrice;
            tbCenaPopust.Text = model.UnitPriceWithDiscount;

            tbKolicinaLokacija.Text = model.TotalWarehouseQuantity;
            tbKolicinaVezanaLokacija.Text = model.TotalLinkedWarehouseQuantity;
            tbRaspolozivoLokacija.Text = model.AvailableWarehouseQuantity;
            tbRaspolozivoVezanaLokacija.Text = model.AvailableLinkedWarehouseQuantity;

            FocusQuantity();
        }

        private void FocusQuantity()
        {
            tbKolicina.Focus();
            if (tbKolicina.Text.Length > 0)
            {
                tbKolicina.SelectionStart = 0;
                tbKolicina.SelectionLength = tbKolicina.Text.Length;
            }
        }

        private void bOdustani_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void bPrihvati_Click(object sender, EventArgs e)
        {
            switch (_itemState)
            {
                case ItemState.New:

                    var modelNew = new ItemQuoteModel
                    {
                        ItemCode = _itemCode,
                        ItemDescription = tbNaziv.Text,
                        VariantCode = _variantCode,
                        UnitOfMeasureCode = bJedinicaMere.Text,
                        LocationCode = "001",
                        Quantity = tbKolicina.Text,
                        UnitPrice = tbCena.Text,
                        UnitPriceWithDiscount = tbCenaPopust.Text,
                        UnitOfMeasureForConversion = tbJedinicaKonverzija.Text,
                        ConversionCoeficient = _conversionCoefficient,
                        TotalWarehouseQuantity = tbKolicinaLokacija.Text,
                        TotalLinkedWarehouseQuantity = tbKolicinaVezanaLokacija.Text,
                        AvailableWarehouseQuantity = tbRaspolozivoLokacija.Text,
                        AvailableLinkedWarehouseQuantity = tbRaspolozivoVezanaLokacija.Text
                    };
                    QuoteItems.Add(modelNew);

                    break;
                case ItemState.Edit:

                    var modelEdit = ((ItemQuoteModel) _selectedItem);
                    int index = QuoteItems.IndexOf(modelEdit);

                    modelEdit.Quantity = tbKolicina.Text;
                    QuoteItems[index] = modelEdit;

                    break;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void tbKolicina_TextChanged(object sender, EventArgs e)
        {
            if (!_quantityWatcherEnabled) return;
            CalculatePrice();
            CalculateConvertedQuantity();
        }

        private void tbKolicinaKonverzija_TextChanged(object sender, EventArgs e)
        {
            if (!_convertedQuantityWatcherEnabled) return;
            CalculateQuantity();
            CalculatePrice();
        }

        private void CalculatePrice()
        {
            CultureInfo culture = Utils.GetLocalCulture();
            try
            {
                decimal priceWithDiscount = decimal.Parse(tbCenaPopust.Text, culture);
                decimal quantity = decimal.Parse(tbKolicina.Text, culture);
                tbCenaUkupno.Text = (priceWithDiscount * quantity).ToString("N", culture.NumberFormat);
            }
            catch (Exception)
            {
                tbCenaUkupno.Text = "0";
            }
        }

        private void CalculateQuantity()
        {
            CultureInfo culture = Utils.GetLocalCulture();
            try
            {
                _quantityWatcherEnabled = false;
                decimal conversionCoefficient = decimal.Parse(_conversionCoefficient, culture);
                decimal convertedQuantity = decimal.Parse(tbKolicinaKonverzija.Text, culture);
                tbKolicina.Text = (convertedQuantity/conversionCoefficient).ToString("N", culture.NumberFormat);
                
            }
            catch (Exception)
            {
                tbKolicina.Text = "0,00";
            }
            finally
            {
                _quantityWatcherEnabled = true;
            }
        }

        private void CalculateConvertedQuantity()
        {
            CultureInfo culture = Utils.GetLocalCulture();
            try
            {
                _convertedQuantityWatcherEnabled = false;
                decimal conversionCoefficient = decimal.Parse(_conversionCoefficient, culture);
                decimal quantity = decimal.Parse(tbKolicina.Text, culture);
                tbKolicinaKonverzija.Text = (conversionCoefficient*quantity).ToString("N", culture.NumberFormat);
            }
            catch (Exception)
            {
                tbKolicinaKonverzija.Text = "0,00";
            }
            finally
            {
                _convertedQuantityWatcherEnabled = true;
            }
        }

        private void bJedinicaMere_Click(object sender, EventArgs e)
        {
            var odabirJediniceDijalog = new OdabirJediniceDijalog(_itemCode);
            DialogResult result = odabirJediniceDijalog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var selectedUnitOfMeasure = odabirJediniceDijalog.SelectedUnitOfMeasure;

                bJedinicaMere.Text = selectedUnitOfMeasure.UnitOfMeasureCode;
                tbJedinicaKonverzija.Text = selectedUnitOfMeasure.UnitOfMeasureForConversion;

                tbKolicinaLokacija.Text = selectedUnitOfMeasure.TotalQuantity;
                tbKolicinaVezanaLokacija.Text = selectedUnitOfMeasure.TotalQuantityConnected;
                tbRaspolozivoLokacija.Text = selectedUnitOfMeasure.AvailableQuantity;
                tbRaspolozivoVezanaLokacija.Text = selectedUnitOfMeasure.AvailableQuantityConnected;

                _conversionCoefficient = selectedUnitOfMeasure.ConversionCoeficient;
                CalculateConvertedQuantity();
            }
        }

        private void bUcitaj_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string itemPriceInventoryCsv = String.Empty;
                _ws.GetItemPriceAndInventory(_itemCode, _variantCode, bJedinicaMere.Text, tbKolicina.Text, _customerCode,
                    _isAuthenticated, RegistryUtils.GetLoginData().Magacin, RegistryUtils.GetLastUsername(), ref itemPriceInventoryCsv);

                var engine = new FileHelperEngine(typeof (ItemPriceInventoryModel));
                var itemPriceInventory = (ItemPriceInventoryModel[]) engine.ReadString(itemPriceInventoryCsv);
                if (itemPriceInventory.Length > 0)
                {
                    ItemPriceInventoryModel model = itemPriceInventory[0];

                    tbCena.Text = model.UnitPrice;
                    tbCenaPopust.Text = model.UnitPriceWithDiscount;

                    tbKolicinaLokacija.Text = model.TotalWarehouseQuantity;
                    tbKolicinaVezanaLokacija.Text = model.TotalLinkedWarehouseQuantity;
                    tbRaspolozivoLokacija.Text = model.AvailableWarehouseQuantity;
                    tbRaspolozivoVezanaLokacija.Text = model.AvailableLinkedWarehouseQuantity;
                }
            }
            catch (Exception ex)
            {
                Utils.GeneralExceptionProcessing(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void bLagerLista_Click(object sender, EventArgs e)
        {
            new LagerLista(_itemCode).ShowDialog();
        }

    }
}