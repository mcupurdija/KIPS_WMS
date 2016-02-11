using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FileHelpers;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Properties;
using KIPS_WMS.Web;
using OpenNETCF.Windows.Forms;

namespace KIPS_WMS.UI.Isporuka
{
    public partial class IsporukaPretragaPoDokumentu : Form
    {
        private readonly MobileWMSSync _ws = WebServiceFactory.GetWebService();
        private List<WarehouseShipmentModel> _filteredList;
        private WarehouseShipmentModel _selectedShipment;
        private List<WarehouseShipmentModel> _warehouseShipments;

        public IsporukaPretragaPoDokumentu()
        {
            InitializeComponent();

            listBox1.DrawMode = DrawMode.OwnerDrawFixed;

//            new Thread(GetData).Start();
            GetData();
        }

        private void GetData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string warehouseShipmentsCsv = String.Empty;

                var loginData = RegistryUtils.GetLoginData();
                _ws.GetWarehouseShipments(RegistryUtils.GetLastUsername(), loginData.Magacin, loginData.Podmagacin, "", ref warehouseShipmentsCsv);

                var engine = new FileHelperEngine(typeof (WarehouseShipmentModel));
                _warehouseShipments = ((WarehouseShipmentModel[])engine.ReadString(warehouseShipmentsCsv)).ToList();
                _warehouseShipments.Sort((x, y) => String.Compare(x.SourceDescription, y.SourceDescription, StringComparison.Ordinal));
                _filteredList = _warehouseShipments;

//                Invoke(new EventHandler((sender, e) => DisplayData(null)));
                DisplayData(null);
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

        private void DisplayData(string documentNo)
        {
            listBox1.Items.Clear();

            _selectedShipment = null;
            _filteredList = documentNo != null
                ? _warehouseShipments.FindAll(x => x.ShipmentCode.Contains(documentNo))
                : _warehouseShipments;

            var listItem = new ListItem();
            for (int i = 0; i < _filteredList.Count; i++)
            {
                listBox1.Items.Add(listItem);
            }
            if (listBox1.Items.Count > 5)
            {
                listBox1.Items.Add(new ListItem {Tag = 0});
            }

            tbPronadji.Focus();
            if (_filteredList.Count == 1)
            {
                _selectedShipment = _filteredList[0];
                new IsporukaLinije(_selectedShipment.ShipmentCode).Show();
            }
        }

        private void bPronadji_Click(object sender, EventArgs e)
        {
            string searchQuery = tbPronadji.Text.Trim();
            if (searchQuery.Length == 0) return;

            DisplayData(searchQuery);
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            DisplayData(null);
            tbPronadji.Text = String.Empty;
            tbPronadji.Focus();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index == -1 || index >= listBox1.Items.Count || listBox1.Items[index].Tag != null)
            {
                _selectedShipment = null;
                return;
            }

            _selectedShipment = _filteredList[index];
        }

        private void bNazad_Click(object sender, EventArgs e)
        {
            listBox1.Dispose();
            Close();
        }

        private void bDalje_Click(object sender, EventArgs e)
        {
            if (_selectedShipment != null)
            {
                new IsporukaLinije(_selectedShipment.ShipmentCode).Show();
            }
            else
            {
                MessageBox.Show(Resources.OdaberiteDokument, Resources.Greska);
            }
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            int index = e.Index;
            if (index >= listBox1.Items.Count || listBox1.Items[index].Tag != null) return;

            SolidBrush brush;
            if (e.State == DrawItemState.Selected)
            {
                e.DrawBackground(Color.Blue);
                brush = new SolidBrush(Color.White);
            }
            else
            {
                e.DrawBackground(index%2 == 0 ? SystemColors.Control : Color.White);
                brush = new SolidBrush(Color.Black);
            }

            WarehouseShipmentModel line = _filteredList[index];

            string firstLine = line.SourceDescription;
            string secondLine = string.Format("{0} - {1}", line.ShipmentCode, line.ShipmentDate);

            e.Graphics.DrawString(firstLine,
                new Font(FontFamily.GenericSansSerif, 8F, FontStyle.Bold), brush, e.Bounds.Left + 3, e.Bounds.Top,
                new StringFormat {FormatFlags = StringFormatFlags.NoWrap});
            e.Graphics.DrawString(secondLine,
                new Font(FontFamily.GenericSansSerif, 8F, FontStyle.Regular), brush, e.Bounds.Left + 3,
                e.Bounds.Top + 20, new StringFormat {FormatFlags = StringFormatFlags.NoWrap});
        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (toolBar1.Buttons.IndexOf(e.Button))
            {
                case 0:
                    listBox1.Dispose();
                    Close();
                    break;
                case 1:
                    if (_selectedShipment != null)
                    {
                        new IsporukaLinije(_selectedShipment.ShipmentCode).Show();
                    }
                    else
                    {
                        MessageBox.Show(Resources.OdaberiteDokument, Resources.Greska);
                    }
                    break;
            }
        }
    }
}