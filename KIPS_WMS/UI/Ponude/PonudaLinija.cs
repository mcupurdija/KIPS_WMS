using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KIPS_WMS.UI.Ponude
{
    public partial class PonudaLinija : Form
    {
        [DllImport("coredll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("coredll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private const int BsMultiline = 0x00002000;
        private const int GwlStyle = -16;

        public PonudaLinija()
        {
            InitializeComponent();

            MakeButtonMultiline(bUcitaj);

        }

        public static void MakeButtonMultiline(Button b)
        {
            IntPtr hwnd = b.Handle;
            int currentStyle = GetWindowLong(hwnd, GwlStyle);
            SetWindowLong(hwnd, GwlStyle, currentStyle | BsMultiline);
        }
    }
}