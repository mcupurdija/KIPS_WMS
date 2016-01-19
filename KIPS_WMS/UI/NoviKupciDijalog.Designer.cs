namespace KIPS_WMS.UI
{
    partial class Loading
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
            this.pNewCustomer = new System.Windows.Forms.Panel();
            this.lText = new System.Windows.Forms.Label();
            this.lTitle = new System.Windows.Forms.Label();
            this.pNewCustomer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pNewCustomer
            // 
            this.pNewCustomer.Controls.Add(this.lText);
            this.pNewCustomer.Location = new System.Drawing.Point(0, 24);
            this.pNewCustomer.Name = "pNewCustomer";
            this.pNewCustomer.Size = new System.Drawing.Size(180, 76);
            this.pNewCustomer.Paint += new System.Windows.Forms.PaintEventHandler(this.pNewCustomer_Paint);
            // 
            // lText
            // 
            this.lText.Location = new System.Drawing.Point(3, 20);
            this.lText.Name = "lText";
            this.lText.Size = new System.Drawing.Size(174, 35);
            this.lText.Text = "Učitavanje kupaca u toku. Molimo sačekajte...";
            this.lText.ParentChanged += new System.EventHandler(this.label1_ParentChanged);
            // 
            // lTitle
            // 
            this.lTitle.BackColor = System.Drawing.Color.Silver;
            this.lTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lTitle.Location = new System.Drawing.Point(0, 0);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(180, 21);
            this.lTitle.Text = "Učitavanje";
            this.lTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(180, 100);
            this.ControlBox = false;
            this.Controls.Add(this.lTitle);
            this.Controls.Add(this.pNewCustomer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(40, 40);
            this.MinimizeBox = false;
            this.Name = "Loading";
            this.Text = "Molimo sačekajte";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.Loading_Activated);
            this.pNewCustomer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pNewCustomer;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Label lText;
    }
}