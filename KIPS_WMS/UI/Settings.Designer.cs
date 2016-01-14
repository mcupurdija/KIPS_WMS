namespace KIPS_WMS.UI
{
    partial class Settings
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
            this.cbPrinters = new System.Windows.Forms.ComboBox();
            this.tbPrint = new System.Windows.Forms.TextBox();
            this.lStampac = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bStampac = new System.Windows.Forms.Button();
            this.bShort = new System.Windows.Forms.Button();
            this.bLong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbPrinters
            // 
            this.cbPrinters.Location = new System.Drawing.Point(16, 43);
            this.cbPrinters.Name = "cbPrinters";
            this.cbPrinters.Size = new System.Drawing.Size(209, 22);
            this.cbPrinters.TabIndex = 0;
            this.cbPrinters.SelectedIndexChanged += new System.EventHandler(this.cbPrinters_SelectedIndexChanged);
            // 
            // tbPrint
            // 
            this.tbPrint.Enabled = false;
            this.tbPrint.Location = new System.Drawing.Point(16, 114);
            this.tbPrint.Name = "tbPrint";
            this.tbPrint.Size = new System.Drawing.Size(209, 21);
            this.tbPrint.TabIndex = 1;
            // 
            // lStampac
            // 
            this.lStampac.Location = new System.Drawing.Point(16, 17);
            this.lStampac.Name = "lStampac";
            this.lStampac.Size = new System.Drawing.Size(132, 20);
            this.lStampac.Text = "Izaberite štampač:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.Text = "Izabrani štampač:";
            // 
            // bStampac
            // 
            this.bStampac.Location = new System.Drawing.Point(148, 155);
            this.bStampac.Name = "bStampac";
            this.bStampac.Size = new System.Drawing.Size(72, 20);
            this.bStampac.TabIndex = 5;
            this.bStampac.Text = "Zapamti";
            this.bStampac.Click += new System.EventHandler(this.bStampac_Click);
            // 
            // bShort
            // 
            this.bShort.Location = new System.Drawing.Point(16, 141);
            this.bShort.Name = "bShort";
            this.bShort.Size = new System.Drawing.Size(112, 20);
            this.bShort.TabIndex = 6;
            this.bShort.Text = "TEST KRATAK";
            this.bShort.Click += new System.EventHandler(this.bShort_Click);
            // 
            // bLong
            // 
            this.bLong.Location = new System.Drawing.Point(16, 165);
            this.bLong.Name = "bLong";
            this.bLong.Size = new System.Drawing.Size(112, 20);
            this.bLong.TabIndex = 7;
            this.bLong.Text = "TEST DUGACAK";
            this.bLong.Click += new System.EventHandler(this.bLong_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.Controls.Add(this.bLong);
            this.Controls.Add(this.bShort);
            this.Controls.Add(this.bStampac);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lStampac);
            this.Controls.Add(this.tbPrint);
            this.Controls.Add(this.cbPrinters);
            this.Menu = this.mainMenu1;
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPrinters;
        private System.Windows.Forms.TextBox tbPrint;
        private System.Windows.Forms.Label lStampac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bStampac;
        private System.Windows.Forms.Button bShort;
        private System.Windows.Forms.Button bLong;
    }
}