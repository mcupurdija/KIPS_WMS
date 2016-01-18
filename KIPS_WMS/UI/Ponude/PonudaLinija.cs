using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using KIPS_WMS.Model;

namespace KIPS_WMS.UI.Ponude
{
    public partial class PonudaLinija : Form
    {
        private const int BsMultiline = 0x00002000;
        private const int GwlStyle = -16;

        private readonly string _quoteNo;
        private readonly Object _selectedItem;
        public ItemQuoteModel[] QuoteItems;

        public PonudaLinija()
        {
            InitializeComponent();
            MakeButtonMultiline(bUcitaj);
        }

        public PonudaLinija(string quoteNo, ItemQuoteModel[] quoteItems, object selectedItem)
        {
            InitializeComponent();
            MakeButtonMultiline(bUcitaj);

            _quoteNo = quoteNo;
            QuoteItems = quoteItems;
            _selectedItem = selectedItem;

            if (_selectedItem is ItemQuoteModel)
            {
                tbSifra.Text = ((ItemQuoteModel) _selectedItem).ItemCode;
            }
            else
            {
                tbSifra.Text = ((Object[]) _selectedItem)[DatabaseModel.ItemDbModel.ItemCode].ToString();
            }
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

        private void bOdustani_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void bPrihvati_Click(object sender, EventArgs e)
        {
            if (_selectedItem is ItemQuoteModel)
            {
            }


            DialogResult = DialogResult.OK;
            Close();
        }
    }
}