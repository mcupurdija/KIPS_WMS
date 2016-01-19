using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KIPS_WMS.UI
{
    public partial class LagerLista : Form
    {
        private string _itemNo;

        public LagerLista()
        {
            InitializeComponent();
        }

        public LagerLista(string itemNo)
        {
            InitializeComponent();

            _itemNo = itemNo;
            if (_itemNo != null)
            {
                GetData();
            }
        }

        private void GetData()
        {
            
        }
    }
}