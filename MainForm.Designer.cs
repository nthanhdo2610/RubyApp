using RubyApp.Data;

namespace RubyApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.Label lblWelcome;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            sessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            lblWelcome = new System.Windows.Forms.Label();

            menuStrip1.SuspendLayout();
            SuspendLayout();

            // form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 360);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RubyApp";

            // menuStrip1
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                adminToolStripMenuItem,
                sessionToolStripMenuItem
            });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(640, 24);

            // adminToolStripMenuItem
            adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                usersToolStripMenuItem
            });
            adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            adminToolStripMenuItem.Text = "Admin";

            // usersToolStripMenuItem
            usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            usersToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            usersToolStripMenuItem.Text = "Users";
            usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);

            // sessionToolStripMenuItem
            sessionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                logoutToolStripMenuItem
            });
            sessionToolStripMenuItem.Name = "sessionToolStripMenuItem";
            sessionToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            sessionToolStripMenuItem.Text = "Session";

            // logoutToolStripMenuItem
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            logoutToolStripMenuItem.Text = "Logout";
            logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);

            // lblWelcome
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new System.Drawing.Point(20, 50);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new System.Drawing.Size(65, 15);
            lblWelcome.Text = "Welcome...";

            // add controls
            this.Controls.Add(menuStrip1);
            this.Controls.Add(lblWelcome);
            this.MainMenuStrip = menuStrip1;

            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}