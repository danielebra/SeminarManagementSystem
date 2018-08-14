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
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.monthCalander = new System.Windows.Forms.MonthCalendar();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cbOrganizers = new System.Windows.Forms.ComboBox();
            this.lblOrganiser = new System.Windows.Forms.Label();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Start Date";
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
            this.btnAdd.Location = new System.Drawing.Point(305, 424);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add Seminar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(119, 137);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 20);
            this.dtpStart.TabIndex = 6;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // monthCalander
            // 
            this.monthCalander.Location = new System.Drawing.Point(109, 188);
            this.monthCalander.MaxSelectionCount = 14;
            this.monthCalander.Name = "monthCalander";
            this.monthCalander.TabIndex = 7;
            this.monthCalander.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_UpdateRanges);
            this.monthCalander.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_UpdateRanges);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(119, 163);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 20);
            this.dtpEnd.TabIndex = 6;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "End Date";
            // 
            // cbOrganizers
            // 
            this.cbOrganizers.FormattingEnabled = true;
            this.cbOrganizers.Location = new System.Drawing.Point(480, 6);
            this.cbOrganizers.Name = "cbOrganizers";
            this.cbOrganizers.Size = new System.Drawing.Size(121, 21);
            this.cbOrganizers.TabIndex = 8;
            // 
            // lblOrganiser
            // 
            this.lblOrganiser.AutoSize = true;
            this.lblOrganiser.Location = new System.Drawing.Point(414, 9);
            this.lblOrganiser.Name = "lblOrganiser";
            this.lblOrganiser.Size = new System.Drawing.Size(52, 13);
            this.lblOrganiser.TabIndex = 0;
            this.lblOrganiser.Text = "Organiser";
            // 
            // AddSeminar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 459);
            this.Controls.Add(this.cbOrganizers);
            this.Controls.Add(this.monthCalander);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblOrganiser);
            this.Controls.Add(this.lblTitle);
            this.Name = "AddSeminar";
            this.Text = "AddSeminar";
            this.Load += new System.EventHandler(this.AddSeminar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.MonthCalendar monthCalander;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbOrganizers;
        private System.Windows.Forms.Label lblOrganiser;
    }
}