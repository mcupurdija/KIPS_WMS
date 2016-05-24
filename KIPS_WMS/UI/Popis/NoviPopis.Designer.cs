namespace KIPS_WMS.UI.Popis
{
    partial class NoviPopis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoviPopis));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.bObrisi = new System.Windows.Forms.MenuItem();
            this.bDalje = new System.Windows.Forms.MenuItem();
            this.lTekst = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbKolicina = new System.Windows.Forms.TextBox();
            this.tbJM = new System.Windows.Forms.TextBox();
            this.bDodaj = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.dtDatum = new System.Windows.Forms.DateTimePicker();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.tbPronadji = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRegal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPracenje = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bTrazi = new System.Windows.Forms.Button();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.cObrisiRed = new System.Windows.Forms.MenuItem();
            this.cObrisiSve = new System.Windows.Forms.MenuItem();
            this.contextMenu2 = new System.Windows.Forms.ContextMenu();
            this.cSacuvajCSV = new System.Windows.Forms.MenuItem();
            this.cPosalji = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.bObrisi);
            this.mainMenu1.MenuItems.Add(this.bDalje);
            // 
            // bObrisi
            // 
            this.bObrisi.Text = "Obriši";
            // 
            // bDalje
            // 
            this.bDalje.Text = "Dalje";
            // 
            // lTekst
            // 
            this.lTekst.Location = new System.Drawing.Point(3, 53);
            this.lTekst.Name = "lTekst";
            this.lTekst.Size = new System.Drawing.Size(57, 20);
            this.lTekst.Text = "Količina:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.Text = "JM:";
            // 
            // tbKolicina
            // 
            this.tbKolicina.Location = new System.Drawing.Point(66, 52);
            this.tbKolicina.Name = "tbKolicina";
            this.tbKolicina.Size = new System.Drawing.Size(70, 21);
            this.tbKolicina.TabIndex = 4;
            this.tbKolicina.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbKolicina_KeyUp);
            // 
            // tbJM
            // 
            this.tbJM.BackColor = System.Drawing.Color.Gainsboro;
            this.tbJM.Enabled = false;
            this.tbJM.Location = new System.Drawing.Point(66, 72);
            this.tbJM.Name = "tbJM";
            this.tbJM.Size = new System.Drawing.Size(70, 21);
            this.tbJM.TabIndex = 8;
            this.tbJM.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbKolicina_KeyUp);
            this.tbJM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbKolicina_KeyPress);
            // 
            // bDodaj
            // 
            this.bDodaj.Location = new System.Drawing.Point(142, 91);
            this.bDodaj.Name = "bDodaj";
            this.bDodaj.Size = new System.Drawing.Size(91, 21);
            this.bDodaj.TabIndex = 9;
            this.bDodaj.Text = "Dodaj";
            this.bDodaj.Click += new System.EventHandler(this.bDodaj_Click);
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(0, 118);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(240, 70);
            this.listView1.TabIndex = 11;
            // 
            // dtDatum
            // 
            this.dtDatum.CustomFormat = "dd.MM.yyyy.";
            this.dtDatum.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDatum.Location = new System.Drawing.Point(142, 71);
            this.dtDatum.Name = "dtDatum";
            this.dtDatum.Size = new System.Drawing.Size(91, 22);
            this.dtDatum.TabIndex = 16;
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.Add(this.toolBarButton1);
            this.toolBar1.Buttons.Add(this.toolBarButton2);
            this.toolBar1.Buttons.Add(this.toolBarButton3);
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
            // toolBarButton3
            // 
            this.toolBarButton3.ImageIndex = 2;
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(70, 36);
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource2"))));
            // 
            // tbPronadji
            // 
            this.tbPronadji.Location = new System.Drawing.Point(66, 28);
            this.tbPronadji.Name = "tbPronadji";
            this.tbPronadji.Size = new System.Drawing.Size(110, 21);
            this.tbPronadji.TabIndex = 21;
            this.tbPronadji.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbPronadji_KeyUp);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.Text = "Artikal:";
            // 
            // tbRegal
            // 
            this.tbRegal.Location = new System.Drawing.Point(66, 3);
            this.tbRegal.Name = "tbRegal";
            this.tbRegal.Size = new System.Drawing.Size(110, 21);
            this.tbRegal.TabIndex = 24;
            this.tbRegal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbRegal_KeyUp);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.Text = "Regal";
            // 
            // tbPracenje
            // 
            this.tbPracenje.Location = new System.Drawing.Point(66, 91);
            this.tbPracenje.Name = "tbPracenje";
            this.tbPracenje.Size = new System.Drawing.Size(70, 21);
            this.tbPracenje.TabIndex = 27;
            this.tbPracenje.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbPracenje_KeyUp);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.Text = "Praćenje:";
            // 
            // bTrazi
            // 
            this.bTrazi.Location = new System.Drawing.Point(182, 28);
            this.bTrazi.Name = "bTrazi";
            this.bTrazi.Size = new System.Drawing.Size(51, 21);
            this.bTrazi.TabIndex = 29;
            this.bTrazi.Text = "Traži";
            this.bTrazi.Click += new System.EventHandler(this.bTrazi_Click);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.Add(this.cObrisiRed);
            this.contextMenu1.MenuItems.Add(this.cObrisiSve);
            // 
            // cObrisiRed
            // 
            this.cObrisiRed.Text = "Obriši red";
            this.cObrisiRed.Click += new System.EventHandler(this.cObrisiRed_Click);
            // 
            // cObrisiSve
            // 
            this.cObrisiSve.Text = "Obriši sve";
            this.cObrisiSve.Click += new System.EventHandler(this.cObrisiSve_Click);
            // 
            // contextMenu2
            // 
            this.contextMenu2.MenuItems.Add(this.cSacuvajCSV);
            this.contextMenu2.MenuItems.Add(this.cPosalji);
            // 
            // cSacuvajCSV
            // 
            this.cSacuvajCSV.Text = "Sačuvaj kao CSV";
            this.cSacuvajCSV.Click += new System.EventHandler(this.cSacuvajCSV_Click);
            // 
            // cPosalji
            // 
            this.cPosalji.Text = "Pošalji";
            this.cPosalji.Click += new System.EventHandler(this.cPosalji_Click);
            // 
            // NoviPopis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.ControlBox = false;
            this.Controls.Add(this.bTrazi);
            this.Controls.Add(this.tbPracenje);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbRegal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPronadji);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.dtDatum);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.bDodaj);
            this.Controls.Add(this.tbJM);
            this.Controls.Add(this.tbKolicina);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lTekst);
            this.MinimizeBox = false;
            this.Name = "NoviPopis";
            this.Text = "Praćenje";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lTekst;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbKolicina;
        private System.Windows.Forms.TextBox tbJM;
        private System.Windows.Forms.MenuItem bObrisi;
        private System.Windows.Forms.MenuItem bDalje;
        private System.Windows.Forms.Button bDodaj;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.DateTimePicker dtDatum;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ToolBarButton toolBarButton2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox tbPronadji;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbRegal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPracenje;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bTrazi;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem cObrisiRed;
        private System.Windows.Forms.MenuItem cObrisiSve;
        private System.Windows.Forms.ContextMenu contextMenu2;
        private System.Windows.Forms.MenuItem cSacuvajCSV;
        private System.Windows.Forms.MenuItem cPosalji;
        private System.Windows.Forms.ToolBarButton toolBarButton3;
    }
}