namespace KIPS_WMS.UI.Prijem
{
    partial class PrekoracenaVrednostYesNoDijalog
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
            this.label1 = new System.Windows.Forms.Label();
            this.bDa = new System.Windows.Forms.Button();
            this.bNe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 85);
            this.label1.Text = "Odstupanje je prekoračeno. Da li želite da nastavite?";
            // 
            // bDa
            // 
            this.bDa.Location = new System.Drawing.Point(18, 97);
            this.bDa.Name = "bDa";
            this.bDa.Size = new System.Drawing.Size(72, 20);
            this.bDa.TabIndex = 1;
            this.bDa.Text = "Da";
            this.bDa.Click += new System.EventHandler(this.bDa_Click);
            // 
            // bNe
            // 
            this.bNe.Location = new System.Drawing.Point(111, 97);
            this.bNe.Name = "bNe";
            this.bNe.Size = new System.Drawing.Size(72, 20);
            this.bNe.TabIndex = 2;
            this.bNe.Text = "Ne";
            this.bNe.Click += new System.EventHandler(this.bNe_Click);
            // 
            // PrekoracenaVrednostYesNoDijalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.CenterFormOnScreen = true;
            this.ClientSize = new System.Drawing.Size(200, 120);
            this.ControlBox = false;
            this.Controls.Add(this.bNe);
            this.Controls.Add(this.bDa);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Menu = this.mainMenu1;
            this.Name = "PrekoracenaVrednostYesNoDijalog";
            this.Text = "Prekoračeno odstupanje";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bDa;
        private System.Windows.Forms.Button bNe;
    }
}