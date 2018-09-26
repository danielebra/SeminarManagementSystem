﻿namespace Seminar_Management_System
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.ddRoom = new Seminar_Management_System.Custom_Controls.RoomDropDown();
            this.ddOrganisers = new Seminar_Management_System.Custom_Controls.OrganiserDropDown();
            this.lblDuration = new System.Windows.Forms.Label();
            this.selectSpeakers1 = new Seminar_Management_System.Custom_Controls.SelectSpeakers();
            this.datePickerSingle = new Seminar_Management_System.DatePickerSingle();
            this.attendeeTable1 = new Seminar_Management_System.Custom_Controls.AttendeeTable();
            this.btnAddAttendee = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(91, 6);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(289, 20);
            this.tbTitle.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 35);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Description";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(91, 35);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(289, 96);
            this.rtbDescription.TabIndex = 4;
            this.rtbDescription.Text = "";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(91, 448);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add Seminar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(177, 448);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 5;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // ddRoom
            // 
            this.ddRoom.Location = new System.Drawing.Point(386, 46);
            this.ddRoom.Name = "ddRoom";
            this.ddRoom.Size = new System.Drawing.Size(190, 30);
            this.ddRoom.TabIndex = 11;
            // 
            // ddOrganisers
            // 
            this.ddOrganisers.Location = new System.Drawing.Point(386, 10);
            this.ddOrganisers.Name = "ddOrganisers";
            this.ddOrganisers.Size = new System.Drawing.Size(190, 30);
            this.ddOrganisers.TabIndex = 12;
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(88, 389);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(53, 13);
            this.lblDuration.TabIndex = 14;
            this.lblDuration.Text = "Duration: ";
            // 
            // selectSpeakers1
            // 
            this.selectSpeakers1.Location = new System.Drawing.Point(386, 91);
            this.selectSpeakers1.Name = "selectSpeakers1";
            this.selectSpeakers1.Size = new System.Drawing.Size(214, 147);
            this.selectSpeakers1.TabIndex = 15;
            // 
            // datePickerSingle
            // 
            this.datePickerSingle.Location = new System.Drawing.Point(91, 137);
            this.datePickerSingle.Name = "datePickerSingle";
            this.datePickerSingle.Size = new System.Drawing.Size(269, 249);
            this.datePickerSingle.TabIndex = 16;
            this.datePickerSingle.DateUpdated += new System.EventHandler(this.datePicker_DateUpdated);
            // 
            // attendeeTable1
            // 
            this.attendeeTable1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.attendeeTable1.AutoSize = true;
            this.attendeeTable1.Location = new System.Drawing.Point(386, 244);
            this.attendeeTable1.Name = "attendeeTable1";
            this.attendeeTable1.Size = new System.Drawing.Size(345, 202);
            this.attendeeTable1.TabIndex = 17;
            // 
            // btnAddAttendee
            // 
            this.btnAddAttendee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAttendee.Location = new System.Drawing.Point(639, 448);
            this.btnAddAttendee.Name = "btnAddAttendee";
            this.btnAddAttendee.Size = new System.Drawing.Size(90, 23);
            this.btnAddAttendee.TabIndex = 18;
            this.btnAddAttendee.Text = "Add Attendee";
            this.btnAddAttendee.UseVisualStyleBackColor = true;
            this.btnAddAttendee.Click += new System.EventHandler(this.btnAddAttendee_Click);
            // 
            // AddSeminar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 501);
            this.Controls.Add(this.btnAddAttendee);
            this.Controls.Add(this.attendeeTable1);
            this.Controls.Add(this.datePickerSingle);
            this.Controls.Add(this.selectSpeakers1);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.ddOrganisers);
            this.Controls.Add(this.ddRoom);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "AddSeminar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddSeminar";
            this.Load += new System.EventHandler(this.AddSeminar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnTest;
        private Custom_Controls.RoomDropDown ddRoom;
        private Custom_Controls.OrganiserDropDown ddOrganisers;
        private System.Windows.Forms.Label lblDuration;
        private Custom_Controls.SelectSpeakers selectSpeakers1;
        private DatePickerSingle datePickerSingle;
        private Custom_Controls.AttendeeTable attendeeTable1;
        private System.Windows.Forms.Button btnAddAttendee;
    }
}