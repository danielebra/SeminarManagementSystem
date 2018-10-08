namespace Seminar_Management_System.Forms
{
    partial class CreateFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateFilter));
            this.roomDropDown1 = new Seminar_Management_System.Custom_Controls.RoomDropDown();
            this.btnDone = new System.Windows.Forms.Button();
            this.cbRoom = new System.Windows.Forms.CheckBox();
            this.selectSpeakers1 = new Seminar_Management_System.Custom_Controls.SelectSpeakers();
            this.organiserDropDown1 = new Seminar_Management_System.Custom_Controls.OrganiserDropDown();
            this.cbOrganiser = new System.Windows.Forms.CheckBox();
            this.cbSpeaker = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.cbDate = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // roomDropDown1
            // 
            this.roomDropDown1.Location = new System.Drawing.Point(12, 12);
            this.roomDropDown1.Name = "roomDropDown1";
            this.roomDropDown1.Size = new System.Drawing.Size(190, 30);
            this.roomDropDown1.TabIndex = 0;
            // 
            // btnDone
            // 
            this.btnDone.BackColor = System.Drawing.Color.LimeGreen;
            this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDone.Location = new System.Drawing.Point(113, 348);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 1;
            this.btnDone.Text = "Filter";
            this.btnDone.UseVisualStyleBackColor = false;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // cbRoom
            // 
            this.cbRoom.AutoSize = true;
            this.cbRoom.Location = new System.Drawing.Point(241, 17);
            this.cbRoom.Name = "cbRoom";
            this.cbRoom.Size = new System.Drawing.Size(93, 17);
            this.cbRoom.TabIndex = 2;
            this.cbRoom.Text = "Filter by Room";
            this.cbRoom.UseVisualStyleBackColor = true;
            // 
            // selectSpeakers1
            // 
            this.selectSpeakers1.Location = new System.Drawing.Point(12, 84);
            this.selectSpeakers1.Name = "selectSpeakers1";
            this.selectSpeakers1.Size = new System.Drawing.Size(214, 147);
            this.selectSpeakers1.TabIndex = 3;
            // 
            // organiserDropDown1
            // 
            this.organiserDropDown1.Location = new System.Drawing.Point(12, 48);
            this.organiserDropDown1.Name = "organiserDropDown1";
            this.organiserDropDown1.Size = new System.Drawing.Size(190, 30);
            this.organiserDropDown1.TabIndex = 4;
            // 
            // cbOrganiser
            // 
            this.cbOrganiser.AutoSize = true;
            this.cbOrganiser.Location = new System.Drawing.Point(241, 56);
            this.cbOrganiser.Name = "cbOrganiser";
            this.cbOrganiser.Size = new System.Drawing.Size(110, 17);
            this.cbOrganiser.TabIndex = 5;
            this.cbOrganiser.Text = "Filter by Organiser";
            this.cbOrganiser.UseVisualStyleBackColor = true;
            // 
            // cbSpeaker
            // 
            this.cbSpeaker.AutoSize = true;
            this.cbSpeaker.Location = new System.Drawing.Point(241, 150);
            this.cbSpeaker.Name = "cbSpeaker";
            this.cbSpeaker.Size = new System.Drawing.Size(105, 17);
            this.cbSpeaker.TabIndex = 6;
            this.cbSpeaker.Text = "Filter by Speaker";
            this.cbSpeaker.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(194, 348);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(6, 42);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 20);
            this.dtpStart.TabIndex = 8;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(6, 68);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 20);
            this.dtpEnd.TabIndex = 9;
            // 
            // cbDate
            // 
            this.cbDate.AutoSize = true;
            this.cbDate.Location = new System.Drawing.Point(229, 57);
            this.cbDate.Name = "cbDate";
            this.cbDate.Size = new System.Drawing.Size(88, 17);
            this.cbDate.TabIndex = 10;
            this.cbDate.Text = "Filter by Date";
            this.cbDate.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.cbDate);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Location = new System.Drawing.Point(12, 237);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 105);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dates";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Filter by dates within this range";
            // 
            // CreateFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 382);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbSpeaker);
            this.Controls.Add(this.cbOrganiser);
            this.Controls.Add(this.organiserDropDown1);
            this.Controls.Add(this.selectSpeakers1);
            this.Controls.Add(this.cbRoom);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.roomDropDown1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filter Seminars";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateFilter_FormClosing);
            this.Load += new System.EventHandler(this.CreateFilter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Custom_Controls.RoomDropDown roomDropDown1;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.CheckBox cbRoom;
        private Custom_Controls.SelectSpeakers selectSpeakers1;
        private Custom_Controls.OrganiserDropDown organiserDropDown1;
        private System.Windows.Forms.CheckBox cbOrganiser;
        private System.Windows.Forms.CheckBox cbSpeaker;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.CheckBox cbDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
    }
}