namespace KIPS_WMS.UI.BarkodTest
{
    partial class BarkodTest
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
            this.tbBarkod = new System.Windows.Forms.TextBox();
            this.bPronadji = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lBarkod = new System.Windows.Forms.Label();
            this.lSifra = new System.Windows.Forms.Label();
            this.lNaziv = new System.Windows.Forms.Label();
            this.lJm = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbBarkod
            // 
            this.tbBarkod.Location = new System.Drawing.Point(4, 4);
            this.tbBarkod.Name = "tbBarkod";
            this.tbBarkod.Size = new System.Drawing.Size(153, 21);
            this.tbBarkod.TabIndex = 0;
            this.tbBarkod.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbBarkod_KeyUp);
            // 
            // bPronadji
            // 
            this.bPronadji.Location = new System.Drawing.Point(164, 4);
            this.bPronadji.Name = "bPronadji";
            this.bPronadji.Size = new System.Drawing.Size(72, 20);
            this.bPronadji.TabIndex = 1;
            this.bPronadji.Text = "Pronadji";
            this.bPronadji.Click += new System.EventHandler(this.bPronadji_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
            this.label1.Location = new System.Drawing.Point(15, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "Barkod:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
            this.label2.Location = new System.Drawing.Point(15, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "Šifra:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
            this.label3.Location = new System.Drawing.Point(15, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "Naziv:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
            this.label4.Location = new System.Drawing.Point(15, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "Jedinica mere:";
            // 
            // lBarkod
            // 
            this.lBarkod.Location = new System.Drawing.Point(103, 47);
            this.lBarkod.Name = "lBarkod";
            this.lBarkod.Size = new System.Drawing.Size(119, 20);
            this.lBarkod.Text = "-";
            // 
            // lSifra
            // 
            this.lSifra.Location = new System.Drawing.Point(103, 77);
            this.lSifra.Name = "lSifra";
            this.lSifra.Size = new System.Drawing.Size(119, 20);
            this.lSifra.Text = "-";
            // 
            // lNaziv
            // 
            this.lNaziv.Location = new System.Drawing.Point(103, 107);
            this.lNaziv.Name = "lNaziv";
            this.lNaziv.Size = new System.Drawing.Size(118, 42);
            this.lNaziv.Text = "-";
            // 
            // lJm
            // 
            this.lJm.Location = new System.Drawing.Point(103, 158);
            this.lJm.Name = "lJm";
            this.lJm.Size = new System.Drawing.Size(118, 20);
            this.lJm.Text = "-";
            // 
            // BarkodTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.Controls.Add(this.lJm);
            this.Controls.Add(this.lNaziv);
            this.Controls.Add(this.lSifra);
            this.Controls.Add(this.lBarkod);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bPronadji);
            this.Controls.Add(this.tbBarkod);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
            this.Menu = this.mainMenu1;
            this.Name = "BarkodTest";
            this.Text = "BarkodTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbBarkod;
        private System.Windows.Forms.Button bPronadji;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lBarkod;
        private System.Windows.Forms.Label lSifra;
        private System.Windows.Forms.Label lNaziv;
        private System.Windows.Forms.Label lJm;
    }
}