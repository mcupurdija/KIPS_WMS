namespace KIPS_WMS.UI.Ostalo
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.bIzlaz = new System.Windows.Forms.MenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.bLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.bIzlaz);
            // 
            // bIzlaz
            // 
            this.bIzlaz.Text = "Izlaz";
            this.bIzlaz.Click += new System.EventHandler(this.bIzlaz_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(113, 90);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(107, 21);
            this.tbUsername.TabIndex = 1;
            this.tbUsername.Text = "k1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.Text = "Korisničko ime:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.Text = "Lozinka:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(113, 117);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(107, 21);
            this.tbPassword.TabIndex = 4;
            this.tbPassword.Text = "123456";
            // 
            // bLogin
            // 
            this.bLogin.Location = new System.Drawing.Point(113, 145);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(107, 20);
            this.bLogin.TabIndex = 6;
            this.bLogin.Text = "Prijavi se";
            this.bLogin.Click += new System.EventHandler(this.bLogin_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.Controls.Add(this.bLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.pictureBox1);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.Text = "Prijava";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button bLogin;
        private System.Windows.Forms.MenuItem bIzlaz;

    }
}