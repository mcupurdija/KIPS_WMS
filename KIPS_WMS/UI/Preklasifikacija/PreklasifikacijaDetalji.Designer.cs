namespace KIPS_WMS.UI.Preklasifikacija
{
    partial class PreklasifikacijaDetalji
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreklasifikacijaDetalji));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.bNazad = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.bObrisi = new System.Windows.Forms.MenuItem();
            this.bObrisiSve = new System.Windows.Forms.MenuItem();
            this.bKnjizi = new System.Windows.Forms.MenuItem();
            this.bPonisti = new System.Windows.Forms.Button();
            this.bPronadji = new System.Windows.Forms.Button();
            this.tbPronadji = new System.Windows.Forms.TextBox();
            this.lbNaziv = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSaRegala = new System.Windows.Forms.TextBox();
            this.tbNaRegal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbKolicina = new System.Windows.Forms.TextBox();
            this.lbJM = new System.Windows.Forms.Label();
            this.bDodaj = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.bStanje = new System.Windows.Forms.Button();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.cObrisi = new System.Windows.Forms.MenuItem();
            this.cObrisiSve = new System.Windows.Forms.MenuItem();
            this.cKnjizi = new System.Windows.Forms.MenuItem();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
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
            this.menuItem2.MenuItems.Add(this.bObrisi);
            this.menuItem2.MenuItems.Add(this.bObrisiSve);
            this.menuItem2.MenuItems.Add(this.bKnjizi);
            this.menuItem2.Text = "Opcije";
            // 
            // bObrisi
            // 
            this.bObrisi.Text = "Obriši";
            this.bObrisi.Click += new System.EventHandler(this.bObrisi_Click);
            // 
            // bObrisiSve
            // 
            this.bObrisiSve.Text = "Obriši sve";
            this.bObrisiSve.Click += new System.EventHandler(this.bObrisiSve_Click);
            // 
            // bKnjizi
            // 
            this.bKnjizi.Text = "Knjiži";
            this.bKnjizi.Click += new System.EventHandler(this.bKnjizi_Click);
            // 
            // bPonisti
            // 
            this.bPonisti.Location = new System.Drawing.Point(215, 3);
            this.bPonisti.Name = "bPonisti";
            this.bPonisti.Size = new System.Drawing.Size(22, 20);
            this.bPonisti.TabIndex = 5;
            this.bPonisti.Text = "X";
            this.bPonisti.Click += new System.EventHandler(this.bPonisti_Click);
            // 
            // bPronadji
            // 
            this.bPronadji.Location = new System.Drawing.Point(137, 3);
            this.bPronadji.Name = "bPronadji";
            this.bPronadji.Size = new System.Drawing.Size(72, 20);
            this.bPronadji.TabIndex = 4;
            this.bPronadji.Text = "Pronađi";
            this.bPronadji.Click += new System.EventHandler(this.bPronadji_Click);
            // 
            // tbPronadji
            // 
            this.tbPronadji.Location = new System.Drawing.Point(3, 3);
            this.tbPronadji.Name = "tbPronadji";
            this.tbPronadji.Size = new System.Drawing.Size(128, 21);
            this.tbPronadji.TabIndex = 3;
            this.tbPronadji.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbPronadji_KeyUp);
            // 
            // lbNaziv
            // 
            this.lbNaziv.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lbNaziv.Location = new System.Drawing.Point(6, 26);
            this.lbNaziv.Name = "lbNaziv";
            this.lbNaziv.Size = new System.Drawing.Size(231, 15);
            this.lbNaziv.Text = "Naziv artikla:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.Text = "Sa regala:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.Text = "Na regal:";
            // 
            // tbSaRegala
            // 
            this.tbSaRegala.Location = new System.Drawing.Point(66, 44);
            this.tbSaRegala.Name = "tbSaRegala";
            this.tbSaRegala.Size = new System.Drawing.Size(112, 21);
            this.tbSaRegala.TabIndex = 10;
            this.tbSaRegala.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSaRegala_KeyUp);
            // 
            // tbNaRegal
            // 
            this.tbNaRegal.Location = new System.Drawing.Point(66, 62);
            this.tbNaRegal.Name = "tbNaRegal";
            this.tbNaRegal.Size = new System.Drawing.Size(112, 21);
            this.tbNaRegal.TabIndex = 11;
            this.tbNaRegal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbNaRegal_KeyUp);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(6, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.Text = "Količina:";
            // 
            // tbKolicina
            // 
            this.tbKolicina.Location = new System.Drawing.Point(66, 89);
            this.tbKolicina.Name = "tbKolicina";
            this.tbKolicina.Size = new System.Drawing.Size(32, 21);
            this.tbKolicina.TabIndex = 14;
            this.tbKolicina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbKolicina_KeyPress);
            // 
            // lbJM
            // 
            this.lbJM.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lbJM.Location = new System.Drawing.Point(104, 93);
            this.lbJM.Name = "lbJM";
            this.lbJM.Size = new System.Drawing.Size(74, 20);
            this.lbJM.Text = "JM: ";
            // 
            // bDodaj
            // 
            this.bDodaj.Location = new System.Drawing.Point(184, 92);
            this.bDodaj.Name = "bDodaj";
            this.bDodaj.Size = new System.Drawing.Size(53, 20);
            this.bDodaj.TabIndex = 16;
            this.bDodaj.Text = "Dodaj";
            this.bDodaj.Click += new System.EventHandler(this.bDodaj_Click);
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(0, 116);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(240, 72);
            this.listView1.TabIndex = 17;
            // 
            // bStanje
            // 
            this.bStanje.Location = new System.Drawing.Point(184, 45);
            this.bStanje.Name = "bStanje";
            this.bStanje.Size = new System.Drawing.Size(53, 20);
            this.bStanje.TabIndex = 23;
            this.bStanje.Text = "Stanje";
            this.bStanje.Click += new System.EventHandler(this.bStanje_Click);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.Add(this.cObrisi);
            this.contextMenu1.MenuItems.Add(this.cObrisiSve);
            this.contextMenu1.MenuItems.Add(this.cKnjizi);
            // 
            // cObrisi
            // 
            this.cObrisi.Text = "Obriši";
            this.cObrisi.Click += new System.EventHandler(this.cObrisi_Click);
            // 
            // cObrisiSve
            // 
            this.cObrisiSve.Text = "Obriši sve";
            this.cObrisiSve.Click += new System.EventHandler(this.cObrisiSve_Click);
            // 
            // cKnjizi
            // 
            this.cKnjizi.Text = "Knjiži";
            this.cKnjizi.Click += new System.EventHandler(this.cKnjizi_Click);
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.Add(this.toolBarButton1);
            this.toolBar1.Buttons.Add(this.toolBarButton2);
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(70, 36);
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.ImageIndex = 0;
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.ImageIndex = 1;
            // 
            // PreklasifikacijaDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.bStanje);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.bDodaj);
            this.Controls.Add(this.lbJM);
            this.Controls.Add(this.tbKolicina);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbNaRegal);
            this.Controls.Add(this.tbSaRegala);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbNaziv);
            this.Controls.Add(this.bPonisti);
            this.Controls.Add(this.bPronadji);
            this.Controls.Add(this.tbPronadji);
            this.MinimizeBox = false;
            this.Name = "PreklasifikacijaDetalji";
            this.Text = "Preklasifikacija";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bPonisti;
        private System.Windows.Forms.Button bPronadji;
        private System.Windows.Forms.TextBox tbPronadji;
        private System.Windows.Forms.Label lbNaziv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSaRegala;
        private System.Windows.Forms.TextBox tbNaRegal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuItem bNazad;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem bObrisi;
        private System.Windows.Forms.MenuItem bKnjizi;
        private System.Windows.Forms.TextBox tbKolicina;
        private System.Windows.Forms.Label lbJM;
        private System.Windows.Forms.Button bDodaj;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.MenuItem bObrisiSve;
        private System.Windows.Forms.Button bStanje;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem cObrisi;
        private System.Windows.Forms.MenuItem cObrisiSve;
        private System.Windows.Forms.MenuItem cKnjizi;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ToolBarButton toolBarButton2;


    }
}