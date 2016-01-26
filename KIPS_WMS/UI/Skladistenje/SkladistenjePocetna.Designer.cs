namespace KIPS_WMS.UI.Skladistenje
{
    partial class SkladistenjePocetna
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
            this.bDokument = new System.Windows.Forms.Button();
            this.bArtikal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bDokument
            // 
            this.bDokument.Location = new System.Drawing.Point(3, 4);
            this.bDokument.Name = "bDokument";
            this.bDokument.Size = new System.Drawing.Size(234, 40);
            this.bDokument.TabIndex = 0;
            this.bDokument.Text = "Pretraga po dokumentu";
            this.bDokument.Click += new System.EventHandler(this.bDokument_Click);
            // 
            // bArtikal
            // 
            this.bArtikal.Location = new System.Drawing.Point(3, 50);
            this.bArtikal.Name = "bArtikal";
            this.bArtikal.Size = new System.Drawing.Size(234, 40);
            this.bArtikal.TabIndex = 1;
            this.bArtikal.Text = "Pretraga po artiklu";
            this.bArtikal.Click += new System.EventHandler(this.bArtikal_Click);
            // 
            // PrijemPocetna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.Controls.Add(this.bArtikal);
            this.Controls.Add(this.bDokument);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "PrijemPocetna";
            this.Text = "Skladištenje";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bDokument;
        private System.Windows.Forms.Button bArtikal;
    }
}