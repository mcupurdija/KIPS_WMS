using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KIPS_WMS.Data;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Web;
using FileHelpers;

namespace KIPS_WMS.UI
{
    public partial class Loading : Form
    {

        private readonly KIPS_wms _ws = WebServiceFactory.GetWebService();
        public Loading()
        {
            InitializeComponent();
        }

        private void label1_ParentChanged(object sender, EventArgs e)
        {

        }

        private void pNewCustomer_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Black), 0, 0,
                         e.ClipRectangle.Width - 1,
                         e.ClipRectangle.Height - 1
                        );

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Loading_Activated(object sender, EventArgs e)
        {

           
        }

    }
}