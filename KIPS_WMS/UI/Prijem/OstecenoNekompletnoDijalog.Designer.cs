namespace KIPS_WMS.UI.Prijem
{
    partial class OstecenoNekompletnoDijalog
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
            this.tbJedinicaMere = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNekompletno = new System.Windows.Forms.TextBox();
            this.tbOsteceno = new System.Windows.Forms.TextBox();
            this.bPosalji = new System.Windows.Forms.Button();
            this.bOdustani = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.Text = "Jedinica mere:";
            // 
            // tbJedinicaMere
            // 
            this.tbJedinicaMere.Location = new System.Drawing.Point(96, 3);
            this.tbJedinicaMere.Name = "tbJedinicaMere";
            this.tbJedinicaMere.ReadOnly = true;
            this.tbJedinicaMere.Size = new System.Drawing.Size(101, 21);
            this.tbJedinicaMere.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.Text = "Oštećeno:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.Text = "Nekompletno:";
            // 
            // tbNekompletno
            // 
            this.tbNekompletno.Location = new System.Drawing.Point(96, 57);
            this.tbNekompletno.Name = "tbNekompletno";
            this.tbNekompletno.Size = new System.Drawing.Size(101, 21);
            this.tbNekompletno.TabIndex = 6;
            this.tbNekompletno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNekompletno_KeyPress);
            // 
            // tbOsteceno
            // 
            this.tbOsteceno.Location = new System.Drawing.Point(96, 30);
            this.tbOsteceno.Name = "tbOsteceno";
            this.tbOsteceno.Size = new System.Drawing.Size(101, 21);
            this.tbOsteceno.TabIndex = 7;
            this.tbOsteceno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbOsteceno_KeyPress);
            // 
            // bPosalji
            // 
            this.bPosalji.Location = new System.Drawing.Point(117, 97);
            this.bPosalji.Name = "bPosalji";
            this.bPosalji.Size = new System.Drawing.Size(80, 20);
            this.bPosalji.TabIndex = 8;
            this.bPosalji.Text = "Pošalji";
            this.bPosalji.Click += new System.EventHandler(this.bPosalji_Click);
            // 
            // bOdustani
            // 
            this.bOdustani.Location = new System.Drawing.Point(3, 97);
            this.bOdustani.Name = "bOdustani";
            this.bOdustani.Size = new System.Drawing.Size(80, 20);
            this.bOdustani.TabIndex = 12;
            this.bOdustani.Text = "Odustani";
            this.bOdustani.Click += new System.EventHandler(this.bOdustani_Click);
            // 
            // OstecenoNekompletnoDijalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CenterFormOnScreen = true;
            this.ClientSize = new System.Drawing.Size(200, 120);
            this.ControlBox = false;
            this.Controls.Add(this.bOdustani);
            this.Controls.Add(this.bPosalji);
            this.Controls.Add(this.tbOsteceno);
            this.Controls.Add(this.tbNekompletno);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbJedinicaMere);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Menu = this.mainMenu1;
            this.Name = "OstecenoNekompletnoDijalog";
            this.Text = "Oštećeno/Nekompletno";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbJedinicaMere;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNekompletno;
        private System.Windows.Forms.TextBox tbOsteceno;
        private System.Windows.Forms.Button bPosalji;
        private System.Windows.Forms.Button bOdustani;


    }
}