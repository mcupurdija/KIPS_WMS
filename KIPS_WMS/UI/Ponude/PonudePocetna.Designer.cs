namespace KIPS_WMS.UI.Ponude
{
    partial class PonudePocetna
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
            this.tbUcitaj = new System.Windows.Forms.TextBox();
            this.bUcitaj = new System.Windows.Forms.Button();
            this.bNova = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbUcitaj
            // 
            this.tbUcitaj.Location = new System.Drawing.Point(3, 3);
            this.tbUcitaj.Name = "tbUcitaj";
            this.tbUcitaj.Size = new System.Drawing.Size(156, 21);
            this.tbUcitaj.TabIndex = 0;
            this.tbUcitaj.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbUcitaj_KeyUp);
            // 
            // bUcitaj
            // 
            this.bUcitaj.Location = new System.Drawing.Point(165, 3);
            this.bUcitaj.Name = "bUcitaj";
            this.bUcitaj.Size = new System.Drawing.Size(72, 20);
            this.bUcitaj.TabIndex = 1;
            this.bUcitaj.Text = "Učitaj";
            this.bUcitaj.Click += new System.EventHandler(this.bUcitaj_Click);
            // 
            // bNova
            // 
            this.bNova.Location = new System.Drawing.Point(3, 30);
            this.bNova.Name = "bNova";
            this.bNova.Size = new System.Drawing.Size(110, 40);
            this.bNova.TabIndex = 2;
            this.bNova.Text = "Nova";
            this.bNova.Click += new System.EventHandler(this.bNova_Click);
            // 
            // PonudePocetna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.Controls.Add(this.bNova);
            this.Controls.Add(this.bUcitaj);
            this.Controls.Add(this.tbUcitaj);
            this.Menu = this.mainMenu1;
            this.Name = "PonudePocetna";
            this.Text = "Ponude";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbUcitaj;
        private System.Windows.Forms.Button bUcitaj;
        private System.Windows.Forms.Button bNova;
    }
}