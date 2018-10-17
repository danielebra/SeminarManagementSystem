namespace Seminar_Management_System.Custom_Controls
{
    partial class SeminarItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.LinkLabel();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblAttendeeInterested = new System.Windows.Forms.Label();
            this.lblGoing = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(14, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(568, 18);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title";
            this.lblTitle.Click += new System.EventHandler(this.form_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Location = new System.Drawing.Point(14, 45);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(568, 47);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description";
            this.lblDescription.Click += new System.EventHandler(this.form_Click);
            // 
            // btnView
            // 
            this.btnView.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnView.Location = new System.Drawing.Point(713, 84);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(30, 13);
            this.btnView.TabIndex = 1;
            this.btnView.TabStop = true;
            this.btnView.Text = "View";
            this.btnView.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnView_LinkClicked);
            // 
            // lblDuration
            // 
            this.lblDuration.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(696, 45);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(47, 13);
            this.lblDuration.TabIndex = 2;
            this.lblDuration.Text = "Duration";
            this.lblDuration.Visible = false;
            this.lblDuration.Click += new System.EventHandler(this.form_Click);
            // 
            // lblAttendeeInterested
            // 
            this.lblAttendeeInterested.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAttendeeInterested.AutoSize = true;
            this.lblAttendeeInterested.Location = new System.Drawing.Point(618, 22);
            this.lblAttendeeInterested.Name = "lblAttendeeInterested";
            this.lblAttendeeInterested.Size = new System.Drawing.Size(57, 13);
            this.lblAttendeeInterested.TabIndex = 3;
            this.lblAttendeeInterested.Text = "Interested:";
            this.lblAttendeeInterested.Click += new System.EventHandler(this.form_Click);
            // 
            // lblGoing
            // 
            this.lblGoing.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGoing.AutoSize = true;
            this.lblGoing.Location = new System.Drawing.Point(618, 45);
            this.lblGoing.Name = "lblGoing";
            this.lblGoing.Size = new System.Drawing.Size(38, 13);
            this.lblGoing.TabIndex = 4;
            this.lblGoing.Text = "Going:";
            this.lblGoing.Click += new System.EventHandler(this.form_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox1.Image = global::Seminar_Management_System.Properties.Resources.divider1;
            this.pictureBox1.Location = new System.Drawing.Point(600, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(12, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(618, 70);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 13);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Date: ";
            this.lblDate.Click += new System.EventHandler(this.form_Click);
            // 
            // SeminarItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblGoing);
            this.Controls.Add(this.lblAttendeeInterested);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "SeminarItem";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Size = new System.Drawing.Size(756, 110);
            this.Load += new System.EventHandler(this.SeminarItem_Load);
            this.Click += new System.EventHandler(this.form_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.LinkLabel btnView;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblAttendeeInterested;
        private System.Windows.Forms.Label lblGoing;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDate;
    }
}
