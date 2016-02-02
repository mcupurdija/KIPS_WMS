namespace KIPS_WMS.UI.Prijem
{
    partial class VarijabilniNormativDijalog
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
            this.bPosalji = new System.Windows.Forms.Button();
            this.tbJedinicaMere = new System.Windows.Forms.TextBox();
            this.tbZaprimljenaKolicina = new System.Windows.Forms.TextBox();
            this.tbOsnovnaJedinicaMere = new System.Windows.Forms.TextBox();
            this.tbKolicinaOsnovnaJedinicaMere = new System.Windows.Forms.TextBox();
            this.tbFaktorKonverzije = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bPosalji
            // 
            this.bPosalji.Location = new System.Drawing.Point(117, 138);
            this.bPosalji.Name = "bPosalji";
            this.bPosalji.Size = new System.Drawing.Size(80, 20);
            this.bPosalji.TabIndex = 8;
            this.bPosalji.Text = "Pošalji";
            this.bPosalji.Click += new System.EventHandler(this.bPosalji_Click);
            // 
            // tbJedinicaMere
            // 
            this.tbJedinicaMere.Location = new System.Drawing.Point(117, 3);
            this.tbJedinicaMere.Name = "tbJedinicaMere";
            this.tbJedinicaMere.Size = new System.Drawing.Size(80, 21);
            this.tbJedinicaMere.TabIndex = 9;
            // 
            // tbZaprimljenaKolicina
            // 
            this.tbZaprimljenaKolicina.Location = new System.Drawing.Point(117, 30);
            this.tbZaprimljenaKolicina.Name = "tbZaprimljenaKolicina";
            this.tbZaprimljenaKolicina.Size = new System.Drawing.Size(80, 21);
            this.tbZaprimljenaKolicina.TabIndex = 10;
            // 
            // tbOsnovnaJedinicaMere
            // 
            this.tbOsnovnaJedinicaMere.Location = new System.Drawing.Point(117, 57);
            this.tbOsnovnaJedinicaMere.Name = "tbOsnovnaJedinicaMere";
            this.tbOsnovnaJedinicaMere.Size = new System.Drawing.Size(80, 21);
            this.tbOsnovnaJedinicaMere.TabIndex = 11;
            // 
            // tbKolicinaOsnovnaJedinicaMere
            // 
            this.tbKolicinaOsnovnaJedinicaMere.Location = new System.Drawing.Point(117, 84);
            this.tbKolicinaOsnovnaJedinicaMere.Name = "tbKolicinaOsnovnaJedinicaMere";
            this.tbKolicinaOsnovnaJedinicaMere.Size = new System.Drawing.Size(80, 21);
            this.tbKolicinaOsnovnaJedinicaMere.TabIndex = 12;
            // 
            // tbFaktorKonverzije
            // 
            this.tbFaktorKonverzije.Location = new System.Drawing.Point(117, 111);
            this.tbFaktorKonverzije.Name = "tbFaktorKonverzije";
            this.tbFaktorKonverzije.Size = new System.Drawing.Size(80, 21);
            this.tbFaktorKonverzije.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.Text = "Jedinica mere:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "Zaprimljena kol.:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.Text = "Osnovna JM:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.Text = "Količina u osn. JM:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.Text = "Faktor konverzije:";
            // 
            // VarijabilniNormativDijalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CenterFormOnScreen = true;
            this.ClientSize = new System.Drawing.Size(200, 160);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFaktorKonverzije);
            this.Controls.Add(this.tbKolicinaOsnovnaJedinicaMere);
            this.Controls.Add(this.tbOsnovnaJedinicaMere);
            this.Controls.Add(this.tbZaprimljenaKolicina);
            this.Controls.Add(this.tbJedinicaMere);
            this.Controls.Add(this.bPosalji);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Menu = this.mainMenu1;
            this.Name = "VarijabilniNormativDijalog";
            this.Text = "Unos varijabilnog normativa";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bPosalji;
        private System.Windows.Forms.TextBox tbJedinicaMere;
        private System.Windows.Forms.TextBox tbZaprimljenaKolicina;
        private System.Windows.Forms.TextBox tbOsnovnaJedinicaMere;
        private System.Windows.Forms.TextBox tbKolicinaOsnovnaJedinicaMere;
        private System.Windows.Forms.TextBox tbFaktorKonverzije;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;


    }
}