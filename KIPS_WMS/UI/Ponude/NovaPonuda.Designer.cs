namespace KIPS_WMS.UI.Ponude
{
    partial class NovaPonuda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NovaPonuda));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.bNoviKupci = new System.Windows.Forms.MenuItem();
            this.tbPronadji = new System.Windows.Forms.TextBox();
            this.bPronadji = new System.Windows.Forms.Button();
            this.lvKupci = new System.Windows.Forms.ListView();
            this.bNepoznatKupac = new System.Windows.Forms.Button();
            this.bKreiraj = new System.Windows.Forms.Button();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.bNoviKupci);
            // 
            // bNoviKupci
            // 
            this.bNoviKupci.Text = "Novi kupci";
            this.bNoviKupci.Click += new System.EventHandler(this.bNoviKupci_Click);
            // 
            // tbPronadji
            // 
            this.tbPronadji.Location = new System.Drawing.Point(3, 3);
            this.tbPronadji.Name = "tbPronadji";
            this.tbPronadji.Size = new System.Drawing.Size(156, 21);
            this.tbPronadji.TabIndex = 0;
            this.tbPronadji.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbPronadji_KeyUp);
            // 
            // bPronadji
            // 
            this.bPronadji.Location = new System.Drawing.Point(165, 3);
            this.bPronadji.Name = "bPronadji";
            this.bPronadji.Size = new System.Drawing.Size(72, 20);
            this.bPronadji.TabIndex = 1;
            this.bPronadji.Text = "Pronadji";
            this.bPronadji.Click += new System.EventHandler(this.bPronadji_Click);
            // 
            // lvKupci
            // 
            this.lvKupci.FullRowSelect = true;
            this.lvKupci.Location = new System.Drawing.Point(0, 30);
            this.lvKupci.Name = "lvKupci";
            this.lvKupci.Size = new System.Drawing.Size(240, 129);
            this.lvKupci.TabIndex = 4;
            this.lvKupci.View = System.Windows.Forms.View.Details;
            this.lvKupci.SelectedIndexChanged += new System.EventHandler(this.lvKupci_SelectedIndexChanged);
            this.lvKupci.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvKupci_KeyUp);
            // 
            // bNepoznatKupac
            // 
            this.bNepoznatKupac.Location = new System.Drawing.Point(3, 165);
            this.bNepoznatKupac.Name = "bNepoznatKupac";
            this.bNepoznatKupac.Size = new System.Drawing.Size(114, 20);
            this.bNepoznatKupac.TabIndex = 5;
            this.bNepoznatKupac.Text = "Nepoznat kupac";
            this.bNepoznatKupac.Click += new System.EventHandler(this.bNepoznatKupac_Click);
            // 
            // bKreiraj
            // 
            this.bKreiraj.Location = new System.Drawing.Point(123, 165);
            this.bKreiraj.Name = "bKreiraj";
            this.bKreiraj.Size = new System.Drawing.Size(114, 20);
            this.bKreiraj.TabIndex = 6;
            this.bKreiraj.Text = "Kreiraj";
            this.bKreiraj.Click += new System.EventHandler(this.bKreiraj_Click);
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.Add(this.toolBarButton1);
            this.toolBar1.Buttons.Add(this.toolBarButton2);
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.ImageIndex = 0;
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.ImageIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(80, 36);
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            // 
            // NovaPonuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.bKreiraj);
            this.Controls.Add(this.bNepoznatKupac);
            this.Controls.Add(this.lvKupci);
            this.Controls.Add(this.bPronadji);
            this.Controls.Add(this.tbPronadji);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "NovaPonuda";
            this.Text = "Nova ponuda";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NovaPonuda_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbPronadji;
        private System.Windows.Forms.Button bPronadji;
        private System.Windows.Forms.ListView lvKupci;
        private System.Windows.Forms.MenuItem bNoviKupci;
        private System.Windows.Forms.Button bNepoznatKupac;
        private System.Windows.Forms.Button bKreiraj;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ToolBarButton toolBarButton2;
        private System.Windows.Forms.ImageList imageList1;
    }
}