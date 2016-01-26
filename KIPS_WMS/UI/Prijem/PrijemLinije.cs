using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KIPS_WMS.UI.Prijem
{
    public partial class PrijemLinije : Form
    {
        private readonly string _receiptNo;

        public PrijemLinije()
        {
            InitializeComponent();
        }

        public PrijemLinije(string receiptNo)
        {
            InitializeComponent();

//            _receiptNo = receiptNo;
            _receiptNo = "MPR16-0004";
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            Text = _receiptNo;
        }

        private void bNazad_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}