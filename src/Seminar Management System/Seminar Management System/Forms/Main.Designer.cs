namespace Seminar_Management_System
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnAddSeminar = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnTest = new System.Windows.Forms.ToolStripButton();
            this.btnDebug = new System.Windows.Forms.ToolStripButton();
            this.btnLogin = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.pnlSeminarView = new System.Windows.Forms.Panel();
            this.pnlPersistantControls = new System.Windows.Forms.Panel();
            this.btnLaunchFilter = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnlUserView = new System.Windows.Forms.Panel();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.lblLoggedInRole = new System.Windows.Forms.ToolStripLabel();
            this.lblGreeting = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.pnlSeminarView.SuspendLayout();
            this.pnlPersistantControls.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.pnlUserView.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddSeminar
            // 
            this.btnAddSeminar.Location = new System.Drawing.Point(24, 20);
            this.btnAddSeminar.Name = "btnAddSeminar";
            this.btnAddSeminar.Size = new System.Drawing.Size(122, 23);
            this.btnAddSeminar.TabIndex = 0;
            this.btnAddSeminar.Text = "Launch Add Seminar";
            this.btnAddSeminar.UseVisualStyleBackColor = true;
            this.btnAddSeminar.Click += new System.EventHandler(this.btnAddSeminar_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTest,
            this.btnDebug,
            this.btnLogin,
            this.lblGreeting});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(931, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTest
            // 
            this.btnTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnTest.Image = ((System.Drawing.Image)(resources.GetObject("btnTest.Image")));
            this.btnTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(79, 22);
            this.btnTest.Text = "Add Seminar";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnDebug
            // 
            this.btnDebug.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDebug.Image = ((System.Drawing.Image)(resources.GetObject("btnDebug.Image")));
            this.btnDebug.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(46, 22);
            this.btnDebug.Text = "Debug";
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(57, 22);
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblLoggedInRole});
            this.toolStrip2.Location = new System.Drawing.Point(0, 521);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(931, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // pnlSeminarView
            // 
            this.pnlSeminarView.AutoScroll = true;
            this.pnlSeminarView.Controls.Add(this.pnlPersistantControls);
            this.pnlSeminarView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSeminarView.Location = new System.Drawing.Point(3, 3);
            this.pnlSeminarView.Name = "pnlSeminarView";
            this.pnlSeminarView.Size = new System.Drawing.Size(917, 464);
            this.pnlSeminarView.TabIndex = 3;
            // 
            // pnlPersistantControls
            // 
            this.pnlPersistantControls.BackColor = System.Drawing.Color.Salmon;
            this.pnlPersistantControls.Controls.Add(this.btnLaunchFilter);
            this.pnlPersistantControls.Controls.Add(this.btnAddSeminar);
            this.pnlPersistantControls.Location = new System.Drawing.Point(712, 3);
            this.pnlPersistantControls.Name = "pnlPersistantControls";
            this.pnlPersistantControls.Size = new System.Drawing.Size(200, 100);
            this.pnlPersistantControls.TabIndex = 1;
            // 
            // btnLaunchFilter
            // 
            this.btnLaunchFilter.Location = new System.Drawing.Point(24, 50);
            this.btnLaunchFilter.Name = "btnLaunchFilter";
            this.btnLaunchFilter.Size = new System.Drawing.Size(122, 23);
            this.btnLaunchFilter.TabIndex = 1;
            this.btnLaunchFilter.Text = "Launch Filter";
            this.btnLaunchFilter.UseVisualStyleBackColor = true;
            this.btnLaunchFilter.Click += new System.EventHandler(this.btnLaunchFilter_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 25);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(931, 496);
            this.tabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnlSeminarView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(923, 470);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Seminars";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pnlUserView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(923, 470);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Users";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnlUserView
            // 
            this.pnlUserView.AutoScroll = true;
            this.pnlUserView.Controls.Add(this.btnAddUser);
            this.pnlUserView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUserView.Location = new System.Drawing.Point(3, 3);
            this.pnlUserView.Name = "pnlUserView";
            this.pnlUserView.Size = new System.Drawing.Size(917, 464);
            this.pnlUserView.TabIndex = 1;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(828, 17);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(75, 23);
            this.btnAddUser.TabIndex = 0;
            this.btnAddUser.Text = "Add user";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // lblLoggedInRole
            // 
            this.lblLoggedInRole.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblLoggedInRole.Name = "lblLoggedInRole";
            this.lblLoggedInRole.Size = new System.Drawing.Size(291, 22);
            this.lblLoggedInRole.Text = "Viewing Seminar Management System as an Attendee";
            // 
            // lblGreeting
            // 
            this.lblGreeting.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblGreeting.Name = "lblGreeting";
            this.lblGreeting.Size = new System.Drawing.Size(95, 22);
            this.lblGreeting.Text = "Howdy Stranger!";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 546);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.pnlSeminarView.ResumeLayout(false);
            this.pnlPersistantControls.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.pnlUserView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnAddSeminar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.Panel pnlSeminarView;
        private System.Windows.Forms.ToolStripButton btnTest;
        private System.Windows.Forms.ToolStripButton btnDebug;
        private System.Windows.Forms.ToolStripButton btnLogin;
        public System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel pnlPersistantControls;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnLaunchFilter;
        private System.Windows.Forms.Panel pnlUserView;
        private System.Windows.Forms.ToolStripLabel lblGreeting;
        private System.Windows.Forms.ToolStripLabel lblLoggedInRole;
    }
}

