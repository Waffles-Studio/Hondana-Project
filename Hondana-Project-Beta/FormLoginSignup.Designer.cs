
namespace Hondana_Project_Beta
{
    partial class FormLoginSignup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoginSignup));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtLoginEmail = new System.Windows.Forms.TextBox();
            this.TxtLoginPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.LblLoginForgot = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtSignupEmail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtSignupName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtSignupConfirm = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtSignupPassword = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.BtnSignup = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.NotificacionWaffle = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(662, 50);
            this.panel1.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(46, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Waffles Studio™";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(0, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(680, 2);
            this.label2.TabIndex = 12;
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 36);
            this.label3.TabIndex = 13;
            this.label3.Text = "Let\'s log in!";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(223, 38);
            this.label4.TabIndex = 14;
            this.label4.Text = "❖  Log into your account and start\r\ndiscovering new books!";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 19);
            this.label5.TabIndex = 15;
            this.label5.Text = "✉  E-mail:";
            // 
            // TxtLoginEmail
            // 
            this.TxtLoginEmail.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TxtLoginEmail.Location = new System.Drawing.Point(12, 168);
            this.TxtLoginEmail.Name = "TxtLoginEmail";
            this.TxtLoginEmail.Size = new System.Drawing.Size(275, 26);
            this.TxtLoginEmail.TabIndex = 16;
            this.TxtLoginEmail.Text = "someone@example.com";
            this.TxtLoginEmail.Click += new System.EventHandler(this.TxtLoginEmail_Click);
            // 
            // TxtLoginPassword
            // 
            this.TxtLoginPassword.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TxtLoginPassword.Location = new System.Drawing.Point(12, 226);
            this.TxtLoginPassword.Name = "TxtLoginPassword";
            this.TxtLoginPassword.PasswordChar = '*';
            this.TxtLoginPassword.Size = new System.Drawing.Size(275, 26);
            this.TxtLoginPassword.TabIndex = 18;
            this.TxtLoginPassword.Text = "• •••••••••";
            this.TxtLoginPassword.Click += new System.EventHandler(this.TxtLoginPassword_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 19);
            this.label6.TabIndex = 17;
            this.label6.Text = "✎  Password:";
            // 
            // BtnLogin
            // 
            this.BtnLogin.BackColor = System.Drawing.Color.DarkOrange;
            this.BtnLogin.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLogin.ForeColor = System.Drawing.Color.White;
            this.BtnLogin.Location = new System.Drawing.Point(12, 334);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(120, 40);
            this.BtnLogin.TabIndex = 19;
            this.BtnLogin.Text = "Log in";
            this.BtnLogin.UseVisualStyleBackColor = false;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(339, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(2, 380);
            this.label7.TabIndex = 20;
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LblLoginForgot
            // 
            this.LblLoginForgot.AutoSize = true;
            this.LblLoginForgot.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLoginForgot.ForeColor = System.Drawing.Color.DarkOrange;
            this.LblLoginForgot.Location = new System.Drawing.Point(12, 377);
            this.LblLoginForgot.Name = "LblLoginForgot";
            this.LblLoginForgot.Size = new System.Drawing.Size(211, 19);
            this.LblLoginForgot.TabIndex = 21;
            this.LblLoginForgot.Text = "Did you forget your password?";
            this.LblLoginForgot.Click += new System.EventHandler(this.LblLoginForgot_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(347, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(235, 36);
            this.label9.TabIndex = 22;
            this.label9.Text = "Create an account";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtSignupEmail
            // 
            this.TxtSignupEmail.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TxtSignupEmail.Location = new System.Drawing.Point(347, 182);
            this.TxtSignupEmail.Name = "TxtSignupEmail";
            this.TxtSignupEmail.Size = new System.Drawing.Size(275, 26);
            this.TxtSignupEmail.TabIndex = 26;
            this.TxtSignupEmail.Text = "someone@example.com";
            this.TxtSignupEmail.Click += new System.EventHandler(this.TxtSignupEmail_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(347, 157);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 19);
            this.label10.TabIndex = 25;
            this.label10.Text = "✉  E-mail:";
            // 
            // TxtSignupName
            // 
            this.TxtSignupName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TxtSignupName.Location = new System.Drawing.Point(347, 124);
            this.TxtSignupName.Name = "TxtSignupName";
            this.TxtSignupName.Size = new System.Drawing.Size(275, 26);
            this.TxtSignupName.TabIndex = 24;
            this.TxtSignupName.Text = "Your name";
            this.TxtSignupName.Click += new System.EventHandler(this.TxtSignupName_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(347, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 19);
            this.label11.TabIndex = 23;
            this.label11.Text = "☺  Name:";
            // 
            // TxtSignupConfirm
            // 
            this.TxtSignupConfirm.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TxtSignupConfirm.Location = new System.Drawing.Point(347, 298);
            this.TxtSignupConfirm.Name = "TxtSignupConfirm";
            this.TxtSignupConfirm.PasswordChar = '*';
            this.TxtSignupConfirm.Size = new System.Drawing.Size(275, 26);
            this.TxtSignupConfirm.TabIndex = 30;
            this.TxtSignupConfirm.Text = "•••";
            this.TxtSignupConfirm.Click += new System.EventHandler(this.TxtSignupConfirm_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(347, 273);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(149, 19);
            this.label12.TabIndex = 29;
            this.label12.Text = "✎  Confirm Password:";
            // 
            // TxtSignupPassword
            // 
            this.TxtSignupPassword.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TxtSignupPassword.Location = new System.Drawing.Point(347, 240);
            this.TxtSignupPassword.Name = "TxtSignupPassword";
            this.TxtSignupPassword.PasswordChar = '*';
            this.TxtSignupPassword.Size = new System.Drawing.Size(275, 26);
            this.TxtSignupPassword.TabIndex = 28;
            this.TxtSignupPassword.Text = "•••";
            this.TxtSignupPassword.Click += new System.EventHandler(this.TxtSignupPassword_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(347, 215);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 19);
            this.label13.TabIndex = 27;
            this.label13.Text = "✎  Password:";
            // 
            // BtnSignup
            // 
            this.BtnSignup.BackColor = System.Drawing.Color.White;
            this.BtnSignup.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSignup.ForeColor = System.Drawing.Color.DarkOrange;
            this.BtnSignup.Location = new System.Drawing.Point(347, 334);
            this.BtnSignup.Name = "BtnSignup";
            this.BtnSignup.Size = new System.Drawing.Size(120, 40);
            this.BtnSignup.TabIndex = 31;
            this.BtnSignup.Text = "Sign up";
            this.BtnSignup.UseVisualStyleBackColor = false;
            this.BtnSignup.Click += new System.EventHandler(this.BtnSignup_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Variable Text", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(347, 377);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(193, 30);
            this.label14.TabIndex = 32;
            this.label14.Text = "By continuing, you agree to Hondana\'s\r\nTerms of Service";
            // 
            // NotificacionWaffle
            // 
            this.NotificacionWaffle.Icon = ((System.Drawing.Icon)(resources.GetObject("NotificacionWaffle.Icon")));
            this.NotificacionWaffle.Text = "Hondana 本棚 Project";
            this.NotificacionWaffle.Visible = true;
            // 
            // FormLoginSignup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(662, 433);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.BtnSignup);
            this.Controls.Add(this.TxtSignupConfirm);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.TxtSignupPassword);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.TxtSignupEmail);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TxtSignupName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.LblLoginForgot);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.TxtLoginPassword);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtLoginEmail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Variable Text", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FormLoginSignup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hondana 本棚 Project";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtLoginEmail;
        private System.Windows.Forms.TextBox TxtLoginPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblLoginForgot;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtSignupEmail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtSignupName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtSignupConfirm;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtSignupPassword;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button BtnSignup;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NotifyIcon NotificacionWaffle;
    }
}