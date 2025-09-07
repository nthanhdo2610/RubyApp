using RubyApp.Data;
using RubyApp.Security;
using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace RubyApp
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;

        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox cboLanguage;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Icon = Properties.Resources.ruby;
            components = new System.ComponentModel.Container();
            lblTitle = new System.Windows.Forms.Label();
            lblUser = new System.Windows.Forms.Label();
            lblPassword = new System.Windows.Forms.Label();
            txtUser = new System.Windows.Forms.TextBox();
            txtPassword = new System.Windows.Forms.TextBox();
            btnLogin = new System.Windows.Forms.Button();

            // NEW
            lblLanguage = new System.Windows.Forms.Label();
            cboLanguage = new System.Windows.Forms.ComboBox();

            SuspendLayout();
            // 
            // Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 260);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RubyApp - Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTitle.Location = new System.Drawing.Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(148, 21);
            lblTitle.Text = "Sign in to RubyApp";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new System.Drawing.Point(22, 70);
            lblUser.Text = "Username";
            // 
            // txtUser
            // 
            txtUser.Location = new System.Drawing.Point(140, 66);
            txtUser.PlaceholderText = "admin";
            txtUser.Size = new System.Drawing.Size(290, 23);
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new System.Drawing.Point(22, 110);
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new System.Drawing.Point(140, 106);
            txtPassword.Size = new System.Drawing.Size(290, 23);
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Location = new System.Drawing.Point(140, 190);
            btnLogin.Size = new System.Drawing.Size(130, 32);
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblLanguage (NEW)
            // 
            lblLanguage.AutoSize = true;
            lblLanguage.Location = new System.Drawing.Point(22, 150);
            lblLanguage.Text = "Language";
            // 
            // cboLanguage (NEW)
            // 
            cboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboLanguage.Location = new System.Drawing.Point(140, 146);
            cboLanguage.Size = new System.Drawing.Size(180, 23);
            cboLanguage.SelectedIndexChanged += new System.EventHandler(this.cboLanguage_SelectedIndexChanged);

            // add controls
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblUser);
            this.Controls.Add(txtUser);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(lblLanguage);
            this.Controls.Add(cboLanguage);
            this.Controls.Add(btnLogin);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
