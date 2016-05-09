namespace KIPS_WMS.UI
{
    partial class Meni
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Meni));
            this.bPonude = new System.Windows.Forms.Button();
            this.bPreklasifikacija = new System.Windows.Forms.Button();
            this.bMagPrijemnice = new System.Windows.Forms.Button();
            this.bMagIsporuke = new System.Windows.Forms.Button();
            this.bSkladistenja = new System.Windows.Forms.Button();
            this.bIzdvajanja = new System.Windows.Forms.Button();
            this.bBarkodTest = new System.Windows.Forms.Button();
            this.bKontrolnaCena = new System.Windows.Forms.Button();
            this.bLagerLista = new System.Windows.Forms.Button();
            this.bPopis = new System.Windows.Forms.Button();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.cUnosBarkoda = new System.Windows.Forms.MenuItem();
            this.cCrossDocking = new System.Windows.Forms.MenuItem();
            this.cUvozPodataka = new System.Windows.Forms.MenuItem();
            this.cUcitajNoveArtikle = new System.Windows.Forms.MenuItem();
            this.cPodesavanja = new System.Windows.Forms.MenuItem();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.SuspendLayout();
            // 
            // bPonude
            // 
            this.bPonude.Location = new System.Drawing.Point(3, 3);
            this.bPonude.Name = "bPonude";
            this.bPonude.Size = new System.Drawing.Size(114, 30);
            this.bPonude.TabIndex = 0;
            this.bPonude.Text = "Ponude";
            this.bPonude.Click += new System.EventHandler(this.bPonude_Click);
            // 
            // bPreklasifikacija
            // 
            this.bPreklasifikacija.Location = new System.Drawing.Point(123, 3);
            this.bPreklasifikacija.Name = "bPreklasifikacija";
            this.bPreklasifikacija.Size = new System.Drawing.Size(114, 30);
            this.bPreklasifikacija.TabIndex = 1;
            this.bPreklasifikacija.Text = "Preklasifikacija";
            this.bPreklasifikacija.Click += new System.EventHandler(this.bPreklasifikacija_Click);
            // 
            // bMagPrijemnice
            // 
            this.bMagPrijemnice.Location = new System.Drawing.Point(3, 39);
            this.bMagPrijemnice.Name = "bMagPrijemnice";
            this.bMagPrijemnice.Size = new System.Drawing.Size(114, 30);
            this.bMagPrijemnice.TabIndex = 2;
            this.bMagPrijemnice.Text = "Mag. prijemnice";
            this.bMagPrijemnice.Click += new System.EventHandler(this.bMagPrijemnice_Click);
            // 
            // bMagIsporuke
            // 
            this.bMagIsporuke.Location = new System.Drawing.Point(123, 39);
            this.bMagIsporuke.Name = "bMagIsporuke";
            this.bMagIsporuke.Size = new System.Drawing.Size(114, 30);
            this.bMagIsporuke.TabIndex = 3;
            this.bMagIsporuke.Text = "Mag. isporuke";
            this.bMagIsporuke.Click += new System.EventHandler(this.bMagIsporuke_Click);
            // 
            // bSkladistenja
            // 
            this.bSkladistenja.Location = new System.Drawing.Point(3, 75);
            this.bSkladistenja.Name = "bSkladistenja";
            this.bSkladistenja.Size = new System.Drawing.Size(114, 30);
            this.bSkladistenja.TabIndex = 4;
            this.bSkladistenja.Text = "Skladištenja";
            this.bSkladistenja.Click += new System.EventHandler(this.bSkladistenja_Click);
            // 
            // bIzdvajanja
            // 
            this.bIzdvajanja.Location = new System.Drawing.Point(123, 75);
            this.bIzdvajanja.Name = "bIzdvajanja";
            this.bIzdvajanja.Size = new System.Drawing.Size(114, 30);
            this.bIzdvajanja.TabIndex = 5;
            this.bIzdvajanja.Text = "Izdvajanja";
            this.bIzdvajanja.Click += new System.EventHandler(this.bIzdvajanja_Click);
            // 
            // bBarkodTest
            // 
            this.bBarkodTest.Location = new System.Drawing.Point(3, 111);
            this.bBarkodTest.Name = "bBarkodTest";
            this.bBarkodTest.Size = new System.Drawing.Size(114, 30);
            this.bBarkodTest.TabIndex = 6;
            this.bBarkodTest.Text = "Barkod test";
            this.bBarkodTest.Click += new System.EventHandler(this.bBarkodTest_Click);
            // 
            // bKontrolnaCena
            // 
            this.bKontrolnaCena.Enabled = false;
            this.bKontrolnaCena.Location = new System.Drawing.Point(123, 111);
            this.bKontrolnaCena.Name = "bKontrolnaCena";
            this.bKontrolnaCena.Size = new System.Drawing.Size(114, 30);
            this.bKontrolnaCena.TabIndex = 7;
            this.bKontrolnaCena.Text = "Kontrolna cijena";
            // 
            // bLagerLista
            // 
            this.bLagerLista.Location = new System.Drawing.Point(3, 147);
            this.bLagerLista.Name = "bLagerLista";
            this.bLagerLista.Size = new System.Drawing.Size(114, 30);
            this.bLagerLista.TabIndex = 8;
            this.bLagerLista.Text = "Lager lista";
            this.bLagerLista.Click += new System.EventHandler(this.bLagerLista_Click);
            // 
            // bPopis
            // 
            this.bPopis.Enabled = false;
            this.bPopis.Location = new System.Drawing.Point(123, 147);
            this.bPopis.Name = "bPopis";
            this.bPopis.Size = new System.Drawing.Size(114, 30);
            this.bPopis.TabIndex = 9;
            this.bPopis.Text = "Popis";
            this.bPopis.Click += new System.EventHandler(this.bPopis_Click);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.Add(this.cUnosBarkoda);
            this.contextMenu1.MenuItems.Add(this.cCrossDocking);
            this.contextMenu1.MenuItems.Add(this.cUvozPodataka);
            this.contextMenu1.MenuItems.Add(this.cUcitajNoveArtikle);
            this.contextMenu1.MenuItems.Add(this.cPodesavanja);
            // 
            // cUnosBarkoda
            // 
            this.cUnosBarkoda.Text = "Unos barkoda";
            this.cUnosBarkoda.Click += new System.EventHandler(this.cUnosBarkoda_Click);
            // 
            // cCrossDocking
            // 
            this.cCrossDocking.Text = "Cross docking";
            this.cCrossDocking.Click += new System.EventHandler(this.cCrossDocking_Click);
            // 
            // cUvozPodataka
            // 
            this.cUvozPodataka.Text = "Uvoz podataka";
            this.cUvozPodataka.Click += new System.EventHandler(this.cUvozPodataka_Click);
            // 
            // cUcitajNoveArtikle
            // 
            this.cUcitajNoveArtikle.Text = "Učitaj nove artikle";
            this.cUcitajNoveArtikle.Click += new System.EventHandler(this.cUcitajNoveArtikle_Click);
            // 
            // cPodesavanja
            // 
            this.cPodesavanja.Text = "Podešavanja";
            this.cPodesavanja.Click += new System.EventHandler(this.cPodesavanja_Click);
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
            // Meni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.ControlBox = false;
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.bPopis);
            this.Controls.Add(this.bLagerLista);
            this.Controls.Add(this.bKontrolnaCena);
            this.Controls.Add(this.bBarkodTest);
            this.Controls.Add(this.bIzdvajanja);
            this.Controls.Add(this.bSkladistenja);
            this.Controls.Add(this.bMagIsporuke);
            this.Controls.Add(this.bMagPrijemnice);
            this.Controls.Add(this.bPreklasifikacija);
            this.Controls.Add(this.bPonude);
            this.MinimizeBox = false;
            this.Name = "Meni";
            this.Text = "Meni";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bPonude;
        private System.Windows.Forms.Button bPreklasifikacija;
        private System.Windows.Forms.Button bMagPrijemnice;
        private System.Windows.Forms.Button bMagIsporuke;
        private System.Windows.Forms.Button bSkladistenja;
        private System.Windows.Forms.Button bIzdvajanja;
        private System.Windows.Forms.Button bBarkodTest;
        private System.Windows.Forms.Button bKontrolnaCena;
        private System.Windows.Forms.Button bLagerLista;
        private System.Windows.Forms.Button bPopis;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem cUnosBarkoda;
        private System.Windows.Forms.MenuItem cCrossDocking;
        private System.Windows.Forms.MenuItem cUvozPodataka;
        private System.Windows.Forms.MenuItem cPodesavanja;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ToolBarButton toolBarButton2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.MenuItem cUcitajNoveArtikle;
    }
}