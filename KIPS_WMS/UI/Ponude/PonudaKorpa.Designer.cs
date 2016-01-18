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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.bOpcije = new System.Windows.Forms.MenuItem();
            this.bIzmeniLiniju = new System.Windows.Forms.MenuItem();
            this.bObrisiLiniju = new System.Windows.Forms.MenuItem();
            this.bUcitajNoveArtikle = new System.Windows.Forms.MenuItem();
            this.bPosalji = new System.Windows.Forms.MenuItem();
            this.tbPronadji = new System.Windows.Forms.TextBox();
            this.bPronadji = new System.Windows.Forms.Button();
            this.bResetuj = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.lKupac = new System.Windows.Forms.Label();
            this.bDodaj = new System.Windows.Forms.Button();
            this.lUkupno = new System.Windows.Forms.Label();
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
            // bPosalji
            // 
            this.bPosalji.Text = "Pošalji";
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
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(0, 50);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(240, 112);
            this.listView1.TabIndex = 5;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
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
            // PonudaKorpa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.Controls.Add(this.lUkupno);
            this.Controls.Add(this.bDodaj);
            this.Controls.Add(this.lKupac);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.bResetuj);
            this.Controls.Add(this.bPronadji);
            this.Controls.Add(this.tbPronadji);
            this.Menu = this.mainMenu1;
            this.Name = "PonudaKorpa";
            this.Text = "Nova ponuda";
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
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label lKupac;
        private System.Windows.Forms.Button bDodaj;
        private System.Windows.Forms.MenuItem bPosalji;
        private System.Windows.Forms.Label lUkupno;
    }
}