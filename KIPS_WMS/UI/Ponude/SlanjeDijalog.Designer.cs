namespace KIPS_WMS.UI.Ponude
{
    partial class SlanjeDijalog
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
            this.bOk = new System.Windows.Forms.Button();
            this.bPonovi = new System.Windows.Forms.Button();
            this.lStatus = new System.Windows.Forms.Label();
            this.lKreditniLimit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bOk
            // 
            this.bOk.Location = new System.Drawing.Point(3, 97);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(72, 20);
            this.bOk.TabIndex = 0;
            this.bOk.Text = "OK";
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // bPonovi
            // 
            this.bPonovi.Location = new System.Drawing.Point(125, 97);
            this.bPonovi.Name = "bPonovi";
            this.bPonovi.Size = new System.Drawing.Size(72, 20);
            this.bPonovi.TabIndex = 1;
            this.bPonovi.Text = "Ponovi";
            this.bPonovi.Click += new System.EventHandler(this.bPonovi_Click);
            // 
            // lStatus
            // 
            this.lStatus.Location = new System.Drawing.Point(3, 4);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(194, 50);
            this.lStatus.Text = "Ponuda je uspešno kreirana/ažurirana. Broj ponude u NAV-u:";
            // 
            // lKreditniLimit
            // 
            this.lKreditniLimit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lKreditniLimit.Location = new System.Drawing.Point(3, 60);
            this.lKreditniLimit.Name = "lKreditniLimit";
            this.lKreditniLimit.Size = new System.Drawing.Size(194, 20);
            this.lKreditniLimit.Text = "Kreditni limit je prekoračen!";
            // 
            // SlanjeDijalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CenterFormOnScreen = true;
            this.ClientSize = new System.Drawing.Size(200, 120);
            this.ControlBox = false;
            this.Controls.Add(this.lKreditniLimit);
            this.Controls.Add(this.lStatus);
            this.Controls.Add(this.bPonovi);
            this.Controls.Add(this.bOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Menu = this.mainMenu1;
            this.Name = "SlanjeDijalog";
            this.Text = "Status";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Button bPonovi;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.Label lKreditniLimit;
    }
}