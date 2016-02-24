using OpenNETCF.Windows.Forms;

namespace KIPS_WMS.UI.Ponude
{
    partial class PonudaKorpa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PonudaKorpa));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.bOpcije = new System.Windows.Forms.MenuItem();
            this.bIzmeniLiniju = new System.Windows.Forms.MenuItem();
            this.bObrisiLiniju = new System.Windows.Forms.MenuItem();
            this.bUcitajNoveArtikle = new System.Windows.Forms.MenuItem();
            this.bOdustani = new System.Windows.Forms.MenuItem();
            this.bPosalji = new System.Windows.Forms.MenuItem();
            this.tbPronadji = new System.Windows.Forms.TextBox();
            this.bPronadji = new System.Windows.Forms.Button();
            this.bResetuj = new System.Windows.Forms.Button();
            this.lKupac = new System.Windows.Forms.Label();
            this.bDodaj = new System.Windows.Forms.Button();
            this.lUkupno = new System.Windows.Forms.Label();
            this.listBox1 = new OpenNETCF.Windows.Forms.ListBox2();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.cIzmeniLiniju = new System.Windows.Forms.MenuItem();
            this.cObrisiLiniju = new System.Windows.Forms.MenuItem();
            this.cUcitajNoveArtikle = new System.Windows.Forms.MenuItem();
            this.cOdustani = new System.Windows.Forms.MenuItem();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.bOpcije);
            this.mainMenu1.MenuItems.Add(this.bPosalji);
            // 
            // bOpcije
            // 
            this.bOpcije.MenuItems.Add(this.bIzmeniLiniju);
            this.bOpcije.MenuItems.Add(this.bObrisiLiniju);
            this.bOpcije.MenuItems.Add(this.bUcitajNoveArtikle);
            this.bOpcije.MenuItems.Add(this.bOdustani);
            this.bOpcije.Text = "Opcije";
            // 
            // bIzmeniLiniju
            // 
            this.bIzmeniLiniju.Text = "Izmeni liniju";
            this.bIzmeniLiniju.Click += new System.EventHandler(this.bIzmeniLiniju_Click);
            // 
            // bObrisiLiniju
            // 
            this.bObrisiLiniju.Text = "Obriši liniju";
            this.bObrisiLiniju.Click += new System.EventHandler(this.bObrisiLiniju_Click);
            // 
            // bUcitajNoveArtikle
            // 
            this.bUcitajNoveArtikle.Text = "Učitaj nove artikle";
            this.bUcitajNoveArtikle.Click += new System.EventHandler(this.bUcitajNoveArtikle_Click);
            // 
            // bOdustani
            // 
            this.bOdustani.Text = "Odustani";
            this.bOdustani.Click += new System.EventHandler(this.bOdustani_Click);
            // 
            // bPosalji
            // 
            this.bPosalji.Text = "Pošalji";
            this.bPosalji.Click += new System.EventHandler(this.bPosalji_Click);
            // 
            // tbPronadji
            // 
            this.tbPronadji.Location = new System.Drawing.Point(3, 24);
            this.tbPronadji.Name = "tbPronadji";
            this.tbPronadji.Size = new System.Drawing.Size(125, 21);
            this.tbPronadji.TabIndex = 0;
            this.tbPronadji.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbPronadji_KeyUp);
            // 
            // bPronadji
            // 
            this.bPronadji.Location = new System.Drawing.Point(134, 24);
            this.bPronadji.Name = "bPronadji";
            this.bPronadji.Size = new System.Drawing.Size(72, 20);
            this.bPronadji.TabIndex = 1;
            this.bPronadji.Text = "Pronađi";
            this.bPronadji.Click += new System.EventHandler(this.bPronadji_Click);
            // 
            // bResetuj
            // 
            this.bResetuj.Location = new System.Drawing.Point(212, 24);
            this.bResetuj.Name = "bResetuj";
            this.bResetuj.Size = new System.Drawing.Size(25, 20);
            this.bResetuj.TabIndex = 2;
            this.bResetuj.Text = "X";
            this.bResetuj.Click += new System.EventHandler(this.bResetuj_Click);
            // 
            // lKupac
            // 
            this.lKupac.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lKupac.Location = new System.Drawing.Point(3, 4);
            this.lKupac.Name = "lKupac";
            this.lKupac.Size = new System.Drawing.Size(234, 17);
            this.lKupac.Text = "Kupac";
            // 
            // bDodaj
            // 
            this.bDodaj.Location = new System.Drawing.Point(134, 165);
            this.bDodaj.Name = "bDodaj";
            this.bDodaj.Size = new System.Drawing.Size(103, 20);
            this.bDodaj.TabIndex = 7;
            this.bDodaj.Text = "Dodaj";
            this.bDodaj.Click += new System.EventHandler(this.bDodaj_Click);
            // 
            // lUkupno
            // 
            this.lUkupno.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lUkupno.Location = new System.Drawing.Point(3, 168);
            this.lUkupno.Name = "lUkupno";
            this.lUkupno.Size = new System.Drawing.Size(124, 17);
            this.lUkupno.Text = "Ukupno: 0,00";
            // 
            // listBox1
            // 
            this.listBox1.BackgroundImage = null;
            this.listBox1.DataSource = null;
            this.listBox1.DisplayMember = null;
            this.listBox1.EvenItemColor = System.Drawing.SystemColors.Control;
            this.listBox1.ImageList = null;
            this.listBox1.ItemHeight = 40;
            this.listBox1.LineColor = System.Drawing.SystemColors.ControlText;
            this.listBox1.Location = new System.Drawing.Point(0, 50);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectedIndex = -1;
            this.listBox1.ShowLines = true;
            this.listBox1.Size = new System.Drawing.Size(240, 109);
            this.listBox1.TabIndex = 9;
            this.listBox1.WrapText = false;
            this.listBox1.DrawItem += new OpenNETCF.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyUp);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.Add(this.cIzmeniLiniju);
            this.contextMenu1.MenuItems.Add(this.cObrisiLiniju);
            this.contextMenu1.MenuItems.Add(this.cUcitajNoveArtikle);
            this.contextMenu1.MenuItems.Add(this.cOdustani);
            // 
            // cIzmeniLiniju
            // 
            this.cIzmeniLiniju.Text = "Izmeni liniju";
            this.cIzmeniLiniju.Click += new System.EventHandler(this.cIzmeniLiniju_Click);
            // 
            // cObrisiLiniju
            // 
            this.cObrisiLiniju.Text = "Obriši liniju";
            this.cObrisiLiniju.Click += new System.EventHandler(this.cObrisiLiniju_Click);
            // 
            // cUcitajNoveArtikle
            // 
            this.cUcitajNoveArtikle.Text = "Učitaj nove artikle";
            this.cUcitajNoveArtikle.Click += new System.EventHandler(this.cUcitajNoveArtikle_Click);
            // 
            // cOdustani
            // 
            this.cOdustani.Text = "Odustani";
            this.cOdustani.Click += new System.EventHandler(this.cOdustani_Click);
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
            // PonudaKorpa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lUkupno);
            this.Controls.Add(this.bDodaj);
            this.Controls.Add(this.lKupac);
            this.Controls.Add(this.bResetuj);
            this.Controls.Add(this.bPronadji);
            this.Controls.Add(this.tbPronadji);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "PonudaKorpa";
            this.Text = "Nova ponuda";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PonudaKorpa_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem bOpcije;
        private System.Windows.Forms.TextBox tbPronadji;
        private System.Windows.Forms.Button bPronadji;
        private System.Windows.Forms.Button bResetuj;
        private System.Windows.Forms.MenuItem bIzmeniLiniju;
        private System.Windows.Forms.MenuItem bObrisiLiniju;
        private System.Windows.Forms.MenuItem bUcitajNoveArtikle;
        private System.Windows.Forms.Label lKupac;
        private System.Windows.Forms.Button bDodaj;
        private System.Windows.Forms.MenuItem bPosalji;
        private System.Windows.Forms.Label lUkupno;
        private System.Windows.Forms.MenuItem bOdustani;
        private ListBox2 listBox1;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem cIzmeniLiniju;
        private System.Windows.Forms.MenuItem cObrisiLiniju;
        private System.Windows.Forms.MenuItem cUcitajNoveArtikle;
        private System.Windows.Forms.MenuItem cOdustani;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ToolBarButton toolBarButton2;
        private System.Windows.Forms.ToolBarButton toolBarButton3;
        private System.Windows.Forms.ImageList imageList1;
    }
}