using OpenNETCF.Windows.Forms;

namespace KIPS_WMS.UI.Skladistenje
{
    partial class SkladistenjeDetalji
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkladistenjeDetalji));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.bNazad = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.bArtikalPoRegalima = new System.Windows.Forms.MenuItem();
            this.bPodeliRed = new System.Windows.Forms.MenuItem();
            this.bZameniRegal = new System.Windows.Forms.MenuItem();
            this.bDodaj = new System.Windows.Forms.Button();
            this.bZameni = new System.Windows.Forms.Button();
            this.tbKolicina = new System.Windows.Forms.TextBox();
            this.tbBarkod = new System.Windows.Forms.TextBox();
            this.lJedinica = new System.Windows.Forms.Label();
            this.tbJedinicaKolicina = new System.Windows.Forms.TextBox();
            this.listBox1 = new OpenNETCF.Windows.Forms.ListBox2();
            this.tbRegal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.cArtikalPoRegalima = new System.Windows.Forms.MenuItem();
            this.cPodeliRed = new System.Windows.Forms.MenuItem();
            this.cZameniRegal = new System.Windows.Forms.MenuItem();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.bNazad);
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            // 
            // bNazad
            // 
            this.bNazad.Text = "Nazad";
            this.bNazad.Click += new System.EventHandler(this.bNazad_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.MenuItems.Add(this.bArtikalPoRegalima);
            this.menuItem2.MenuItems.Add(this.bPodeliRed);
            this.menuItem2.MenuItems.Add(this.bZameniRegal);
            this.menuItem2.Text = "Opcije";
            // 
            // bArtikalPoRegalima
            // 
            this.bArtikalPoRegalima.Text = "Artikal po regalima";
            this.bArtikalPoRegalima.Click += new System.EventHandler(this.bArtikalPoRegalima_Click);
            // 
            // bPodeliRed
            // 
            this.bPodeliRed.Text = "Podeli red";
            this.bPodeliRed.Click += new System.EventHandler(this.bPodeliRed_Click);
            // 
            // bZameniRegal
            // 
            this.bZameniRegal.Text = "Zameni regal";
            this.bZameniRegal.Click += new System.EventHandler(this.bZameniRegal_Click);
            // 
            // bDodaj
            // 
            this.bDodaj.Location = new System.Drawing.Point(87, 164);
            this.bDodaj.Name = "bDodaj";
            this.bDodaj.Size = new System.Drawing.Size(72, 20);
            this.bDodaj.TabIndex = 0;
            this.bDodaj.Text = "Dodaj";
            this.bDodaj.Click += new System.EventHandler(this.bDodaj_Click);
            // 
            // bZameni
            // 
            this.bZameni.Location = new System.Drawing.Point(165, 164);
            this.bZameni.Name = "bZameni";
            this.bZameni.Size = new System.Drawing.Size(72, 20);
            this.bZameni.TabIndex = 1;
            this.bZameni.Text = "Zameni";
            this.bZameni.Click += new System.EventHandler(this.bZameni_Click);
            // 
            // tbKolicina
            // 
            this.tbKolicina.Location = new System.Drawing.Point(3, 164);
            this.tbKolicina.Name = "tbKolicina";
            this.tbKolicina.Size = new System.Drawing.Size(78, 21);
            this.tbKolicina.TabIndex = 2;
            this.tbKolicina.Text = "1";
            this.tbKolicina.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbKolicina_KeyUp);
            this.tbKolicina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbKolicina_KeyPress);
            // 
            // tbBarkod
            // 
            this.tbBarkod.Location = new System.Drawing.Point(3, 140);
            this.tbBarkod.Name = "tbBarkod";
            this.tbBarkod.Size = new System.Drawing.Size(110, 21);
            this.tbBarkod.TabIndex = 3;
            this.tbBarkod.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbBarkod_KeyUp);
            // 
            // lJedinica
            // 
            this.lJedinica.Location = new System.Drawing.Point(119, 141);
            this.lJedinica.Name = "lJedinica";
            this.lJedinica.Size = new System.Drawing.Size(52, 20);
            this.lJedinica.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbJedinicaKolicina
            // 
            this.tbJedinicaKolicina.Location = new System.Drawing.Point(177, 140);
            this.tbJedinicaKolicina.Name = "tbJedinicaKolicina";
            this.tbJedinicaKolicina.Size = new System.Drawing.Size(60, 21);
            this.tbJedinicaKolicina.TabIndex = 5;
            this.tbJedinicaKolicina.TextChanged += new System.EventHandler(this.tbJedinicaKolicina_TextChanged);
            this.tbJedinicaKolicina.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbJedinicaKolicina_KeyUp);
            this.tbJedinicaKolicina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbJedinicaKolicina_KeyPress);
            // 
            // listBox1
            // 
            this.listBox1.BackgroundImage = null;
            this.listBox1.DataSource = null;
            this.listBox1.DisplayMember = null;
            this.listBox1.EvenItemColor = System.Drawing.SystemColors.Control;
            this.listBox1.ImageList = null;
            this.listBox1.ItemHeight = 21;
            this.listBox1.LineColor = System.Drawing.SystemColors.ControlText;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectedIndex = -1;
            this.listBox1.ShowLines = true;
            this.listBox1.Size = new System.Drawing.Size(240, 111);
            this.listBox1.TabIndex = 6;
            this.listBox1.WrapText = false;
            this.listBox1.DrawItem += new OpenNETCF.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            // 
            // tbRegal
            // 
            this.tbRegal.Location = new System.Drawing.Point(99, 116);
            this.tbRegal.Name = "tbRegal";
            this.tbRegal.Size = new System.Drawing.Size(138, 21);
            this.tbRegal.TabIndex = 8;
            this.tbRegal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbRegal_KeyUp);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.Text = "Bar kod regala:";
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.Add(this.cArtikalPoRegalima);
            this.contextMenu1.MenuItems.Add(this.cPodeliRed);
            this.contextMenu1.MenuItems.Add(this.cZameniRegal);
            // 
            // cArtikalPoRegalima
            // 
            this.cArtikalPoRegalima.Text = "Artikal po regalima";
            this.cArtikalPoRegalima.Click += new System.EventHandler(this.cArtikalPoRegalima_Click);
            // 
            // cPodeliRed
            // 
            this.cPodeliRed.Text = "Podeli red";
            this.cPodeliRed.Click += new System.EventHandler(this.cPodeliRed_Click);
            // 
            // cZameniRegal
            // 
            this.cZameniRegal.Text = "Zameni regal";
            this.cZameniRegal.Click += new System.EventHandler(this.cZameniRegal_Click);
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
            this.imageList1.ImageSize = new System.Drawing.Size(70, 36);
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            // 
            // SkladistenjeDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.ControlBox = false;
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbRegal);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.tbJedinicaKolicina);
            this.Controls.Add(this.lJedinica);
            this.Controls.Add(this.tbBarkod);
            this.Controls.Add(this.tbKolicina);
            this.Controls.Add(this.bZameni);
            this.Controls.Add(this.bDodaj);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "SkladistenjeDetalji";
            this.Text = "SkladistenjeDetalji";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SkladistenjeDetalji_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem bNazad;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem bArtikalPoRegalima;
        private System.Windows.Forms.MenuItem bPodeliRed;
        private System.Windows.Forms.MenuItem bZameniRegal;
        private System.Windows.Forms.Button bDodaj;
        private System.Windows.Forms.Button bZameni;
        private System.Windows.Forms.TextBox tbKolicina;
        private System.Windows.Forms.TextBox tbBarkod;
        private System.Windows.Forms.Label lJedinica;
        private System.Windows.Forms.TextBox tbJedinicaKolicina;
        private ListBox2 listBox1;
        private System.Windows.Forms.TextBox tbRegal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem cArtikalPoRegalima;
        private System.Windows.Forms.MenuItem cPodeliRed;
        private System.Windows.Forms.MenuItem cZameniRegal;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ToolBarButton toolBarButton2;
        private System.Windows.Forms.ImageList imageList1;
    }
}