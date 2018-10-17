namespace Seminar_Management_System
{
    partial class AddSeminar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSeminar));
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAddAttendee = new System.Windows.Forms.Button();
            this.attendeeTable1 = new Seminar_Management_System.Custom_Controls.AttendeeTable();
            this.datePickerSingle = new Seminar_Management_System.DatePickerSingle();
            this.selectSpeakers1 = new Seminar_Management_System.Custom_Controls.SelectSpeakers();
            this.ddOrganisers = new Seminar_Management_System.Custom_Controls.OrganiserDropDown();
            this.ddRoom = new Seminar_Management_System.Custom_Controls.RoomDropDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pbAddAttendee = new System.Windows.Forms.PictureBox();
            this.lblCapacity = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddAttendee)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 16;
            this.lblTitle.Text = "Title";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(91, 6);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(289, 20);
            this.tbTitle.TabIndex = 0;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 35);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 17;
            this.lblDescription.Text = "Description";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(91, 35);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(289, 96);
            this.rtbDescription.TabIndex = 1;
            this.rtbDescription.Text = "";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdd.BackColor = System.Drawing.Color.LimeGreen;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(305, 466);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Create";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddAttendee
            // 
            this.btnAddAttendee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAttendee.Location = new System.Drawing.Point(609, 466);
            this.btnAddAttendee.Name = "btnAddAttendee";
            this.btnAddAttendee.Size = new System.Drawing.Size(90, 32);
            this.btnAddAttendee.TabIndex = 8;
            this.btnAddAttendee.Text = "Add Attendee";
            this.btnAddAttendee.UseVisualStyleBackColor = true;
            this.btnAddAttendee.Click += new System.EventHandler(this.btnAddAttendee_Click);
            // 
            // attendeeTable1
            // 
            this.attendeeTable1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.attendeeTable1.AutoSize = true;
            this.attendeeTable1.Location = new System.Drawing.Point(386, 244);
            this.attendeeTable1.Name = "attendeeTable1";
            this.attendeeTable1.Size = new System.Drawing.Size(345, 216);
            this.attendeeTable1.TabIndex = 7;
            // 
            // datePickerSingle
            // 
            this.datePickerSingle.Location = new System.Drawing.Point(91, 137);
            this.datePickerSingle.Name = "datePickerSingle";
            this.datePickerSingle.Size = new System.Drawing.Size(269, 270);
            this.datePickerSingle.TabIndex = 3;
            this.datePickerSingle.DateUpdated += new System.EventHandler(this.datePicker_DateUpdated);
            // 
            // selectSpeakers1
            // 
            this.selectSpeakers1.Location = new System.Drawing.Point(386, 91);
            this.selectSpeakers1.Name = "selectSpeakers1";
            this.selectSpeakers1.Size = new System.Drawing.Size(214, 147);
            this.selectSpeakers1.TabIndex = 6;
            // 
            // ddOrganisers
            // 
            this.ddOrganisers.Location = new System.Drawing.Point(386, 10);
            this.ddOrganisers.Name = "ddOrganisers";
            this.ddOrganisers.Size = new System.Drawing.Size(190, 30);
            this.ddOrganisers.TabIndex = 4;
            // 
            // ddRoom
            // 
            this.ddRoom.Location = new System.Drawing.Point(386, 46);
            this.ddRoom.Name = "ddRoom";
            this.ddRoom.Size = new System.Drawing.Size(190, 30);
            this.ddRoom.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(386, 466);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pbAddAttendee
            // 
            this.pbAddAttendee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbAddAttendee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAddAttendee.Image = global::Seminar_Management_System.Properties.Resources.if_add_user_309049;
            this.pbAddAttendee.Location = new System.Drawing.Point(699, 466);
            this.pbAddAttendee.Name = "pbAddAttendee";
            this.pbAddAttendee.Size = new System.Drawing.Size(32, 32);
            this.pbAddAttendee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAddAttendee.TabIndex = 19;
            this.pbAddAttendee.TabStop = false;
            this.pbAddAttendee.Click += new System.EventHandler(this.btnAddAttendee_Click);
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Location = new System.Drawing.Point(582, 53);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(54, 13);
            this.lblCapacity.TabIndex = 20;
            this.lblCapacity.Text = "Capacity: ";
            // 
            // AddSeminar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 501);
            this.Controls.Add(this.lblCapacity);
            this.Controls.Add(this.pbAddAttendee);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddAttendee);
            this.Controls.Add(this.attendeeTable1);
            this.Controls.Add(this.datePickerSingle);
            this.Controls.Add(this.selectSpeakers1);
            this.Controls.Add(this.ddOrganisers);
            this.Controls.Add(this.ddRoom);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.lblTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddSeminar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Seminar";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AddSeminar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbAddAttendee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Button btnAdd;
        private Custom_Controls.RoomDropDown ddRoom;
        private Custom_Controls.OrganiserDropDown ddOrganisers;
        private Custom_Controls.SelectSpeakers selectSpeakers1;
        private DatePickerSingle datePickerSingle;
        private Custom_Controls.AttendeeTable attendeeTable1;
        private System.Windows.Forms.Button btnAddAttendee;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pbAddAttendee;
        private System.Windows.Forms.Label lblCapacity;
    }
}