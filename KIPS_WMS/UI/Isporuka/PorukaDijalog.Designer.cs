namespace KIPS_WMS.UI.Isporuka
{
    partial class PorukaDijalog
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
            this.lPoruka = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bOk
            // 
            this.bOk.Location = new System.Drawing.Point(107, 97);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(80, 20);
            this.bOk.TabIndex = 8;
            this.bOk.Text = "U redu";
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // lPoruka
            // 
            this.lPoruka.Location = new System.Drawing.Point(5, 14);
            this.lPoruka.Name = "lPoruka";
            this.lPoruka.Size = new System.Drawing.Size(182, 80);
            // 
            // PorukaDijalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CenterFormOnScreen = true;
            this.ClientSize = new System.Drawing.Size(200, 120);
            this.ControlBox = false;
            this.Controls.Add(this.lPoruka);
            this.Controls.Add(this.bOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Menu = this.mainMenu1;
            this.Name = "PorukaDijalog";
            this.Text = "Poruka";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Label lPoruka;


    }
}