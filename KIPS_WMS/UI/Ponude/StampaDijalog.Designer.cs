namespace KIPS_WMS.UI.Ponude
{
    partial class StampaDijalog
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbBezStampe = new System.Windows.Forms.RadioButton();
            this.rbDugaStampa = new System.Windows.Forms.RadioButton();
            this.rbKratkaStampa = new System.Windows.Forms.RadioButton();
            this.bPotvrdi = new System.Windows.Forms.Button();
            this.bOdustani = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbBezStampe);
            this.panel1.Controls.Add(this.rbDugaStampa);
            this.panel1.Controls.Add(this.rbKratkaStampa);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 87);
            // 
            // rbBezStampe
            // 
            this.rbBezStampe.Location = new System.Drawing.Point(4, 58);
            this.rbBezStampe.Name = "rbBezStampe";
            this.rbBezStampe.Size = new System.Drawing.Size(166, 20);
            this.rbBezStampe.TabIndex = 2;
            this.rbBezStampe.TabStop = false;
            this.rbBezStampe.Text = "Bez štampe";
            // 
            // rbDugaStampa
            // 
            this.rbDugaStampa.Location = new System.Drawing.Point(4, 31);
            this.rbDugaStampa.Name = "rbDugaStampa";
            this.rbDugaStampa.Size = new System.Drawing.Size(166, 20);
            this.rbDugaStampa.TabIndex = 1;
            this.rbDugaStampa.TabStop = false;
            this.rbDugaStampa.Text = "Duga štampa";
            // 
            // rbKratkaStampa
            // 
            this.rbKratkaStampa.Checked = true;
            this.rbKratkaStampa.Location = new System.Drawing.Point(4, 4);
            this.rbKratkaStampa.Name = "rbKratkaStampa";
            this.rbKratkaStampa.Size = new System.Drawing.Size(166, 20);
            this.rbKratkaStampa.TabIndex = 0;
            this.rbKratkaStampa.Text = "Kratka štampa";
            // 
            // bPotvrdi
            // 
            this.bPotvrdi.Location = new System.Drawing.Point(105, 97);
            this.bPotvrdi.Name = "bPotvrdi";
            this.bPotvrdi.Size = new System.Drawing.Size(72, 20);
            this.bPotvrdi.TabIndex = 1;
            this.bPotvrdi.Text = "Potvrdi";
            this.bPotvrdi.Click += new System.EventHandler(this.bPotvrdi_Click);
            // 
            // bOdustani
            // 
            this.bOdustani.Location = new System.Drawing.Point(3, 97);
            this.bOdustani.Name = "bOdustani";
            this.bOdustani.Size = new System.Drawing.Size(72, 20);
            this.bOdustani.TabIndex = 3;
            this.bOdustani.Text = "Otkaži";
            this.bOdustani.Click += new System.EventHandler(this.bOdustani_Click);
            // 
            // StampaDijalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CenterFormOnScreen = true;
            this.ClientSize = new System.Drawing.Size(180, 120);
            this.ControlBox = false;
            this.Controls.Add(this.bOdustani);
            this.Controls.Add(this.bPotvrdi);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Menu = this.mainMenu1;
            this.Name = "StampaDijalog";
            this.Text = "Izbor štampe";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bPotvrdi;
        private System.Windows.Forms.RadioButton rbBezStampe;
        private System.Windows.Forms.RadioButton rbDugaStampa;
        private System.Windows.Forms.RadioButton rbKratkaStampa;
        private System.Windows.Forms.Button bOdustani;
    }
}