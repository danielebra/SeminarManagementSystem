﻿namespace Seminar_Management_System.Forms
{
    partial class ViewSeminar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewSeminar));
            this.btnEdit = new System.Windows.Forms.Button();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.attendeeTable1 = new Seminar_Management_System.Custom_Controls.AttendeeTable();
            this.datePickerSingle = new Seminar_Management_System.DatePickerSingle();
            this.ddRoom = new Seminar_Management_System.Custom_Controls.RoomDropDown();
            this.ddOrganisers = new Seminar_Management_System.Custom_Controls.OrganiserDropDown();
            this.selectSpeakers1 = new Seminar_Management_System.Custom_Controls.SelectSpeakers();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnViewSpeakers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEdit.Location = new System.Drawing.Point(823, 9);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.TextChanged += new System.EventHandler(this.btnEdit_TextChanged);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // tbTitle
            // 
            this.tbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTitle.Location = new System.Drawing.Point(12, 5);
            this.tbTitle.Margin = new System.Windows.Forms.Padding(4);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.ReadOnly = true;
            this.tbTitle.Size = new System.Drawing.Size(775, 40);
            this.tbTitle.TabIndex = 2;
            this.tbTitle.Text = "Title";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDescription.Location = new System.Drawing.Point(12, 51);
            this.rtbDescription.Margin = new System.Windows.Forms.Padding(4);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.ReadOnly = true;
            this.rtbDescription.Size = new System.Drawing.Size(775, 167);
            this.rtbDescription.TabIndex = 3;
            this.rtbDescription.Text = "Description";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(823, 38);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOk.Location = new System.Drawing.Point(431, 598);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 20;
            this.btnOk.Text = "Close";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(823, 67);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRegister.Location = new System.Drawing.Point(608, 571);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 22;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Enabled = false;
            this.lblCapacity.Location = new System.Drawing.Point(301, 466);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(54, 13);
            this.lblCapacity.TabIndex = 24;
            this.lblCapacity.Text = "Capacity: ";
            // 
            // attendeeTable1
            // 
            this.attendeeTable1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.attendeeTable1.AutoSize = true;
            this.attendeeTable1.Location = new System.Drawing.Point(507, 242);
            this.attendeeTable1.Margin = new System.Windows.Forms.Padding(5);
            this.attendeeTable1.Name = "attendeeTable1";
            this.attendeeTable1.Size = new System.Drawing.Size(391, 323);
            this.attendeeTable1.TabIndex = 21;
            // 
            // datePickerSingle
            // 
            this.datePickerSingle.Enabled = false;
            this.datePickerSingle.Location = new System.Drawing.Point(12, 224);
            this.datePickerSingle.Margin = new System.Windows.Forms.Padding(5);
            this.datePickerSingle.Name = "datePickerSingle";
            this.datePickerSingle.Size = new System.Drawing.Size(269, 277);
            this.datePickerSingle.TabIndex = 19;
            // 
            // ddRoom
            // 
            this.ddRoom.Enabled = false;
            this.ddRoom.Location = new System.Drawing.Point(287, 433);
            this.ddRoom.Name = "ddRoom";
            this.ddRoom.Size = new System.Drawing.Size(190, 30);
            this.ddRoom.TabIndex = 18;
            // 
            // ddOrganisers
            // 
            this.ddOrganisers.Enabled = false;
            this.ddOrganisers.Location = new System.Drawing.Point(287, 397);
            this.ddOrganisers.Name = "ddOrganisers";
            this.ddOrganisers.Size = new System.Drawing.Size(190, 30);
            this.ddOrganisers.TabIndex = 17;
            // 
            // selectSpeakers1
            // 
            this.selectSpeakers1.Location = new System.Drawing.Point(287, 224);
            this.selectSpeakers1.Name = "selectSpeakers1";
            this.selectSpeakers1.Size = new System.Drawing.Size(214, 147);
            this.selectSpeakers1.TabIndex = 16;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrint.Location = new System.Drawing.Point(689, 571);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 24;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnViewSpeakers
            // 
            this.btnViewSpeakers.Location = new System.Drawing.Point(304, 366);
            this.btnViewSpeakers.Name = "btnViewSpeakers";
            this.btnViewSpeakers.Size = new System.Drawing.Size(173, 23);
            this.btnViewSpeakers.TabIndex = 25;
            this.btnViewSpeakers.Text = "View Speaker Details";
            this.btnViewSpeakers.UseVisualStyleBackColor = true;
            this.btnViewSpeakers.Click += new System.EventHandler(this.btnViewSpeakers_Click);
            // 
            // ViewSeminar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 633);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnViewSpeakers);
            this.Controls.Add(this.lblCapacity);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.attendeeTable1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.datePickerSingle);
            this.Controls.Add(this.ddRoom);
            this.Controls.Add(this.ddOrganisers);
            this.Controls.Add(this.selectSpeakers1);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEdit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ViewSeminar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Viewing Seminar Information for Seminar Name";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewSeminar_FormClosing);
            this.Load += new System.EventHandler(this.ViewSeminar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private Custom_Controls.SelectSpeakers selectSpeakers1;
        private Custom_Controls.OrganiserDropDown ddOrganisers;
        private Custom_Controls.RoomDropDown ddRoom;
        private DatePickerSingle datePickerSingle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnDelete;
        private Custom_Controls.AttendeeTable attendeeTable1;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.Button btnViewSpeakers;
    }
}