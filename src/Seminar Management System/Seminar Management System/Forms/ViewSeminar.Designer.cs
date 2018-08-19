namespace Seminar_Management_System.Forms
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.selectSpeakers1 = new Seminar_Management_System.Custom_Controls.SelectSpeakers();
            this.ddOrganisers = new Seminar_Management_System.Custom_Controls.OrganiserDropDown();
            this.ddVenue = new Seminar_Management_System.Custom_Controls.VenueDropDown();
            this.datePickerSingle = new Seminar_Management_System.DatePickerSingle();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEdit.Location = new System.Drawing.Point(823, 9);
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
            this.tbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTitle.Location = new System.Drawing.Point(12, 5);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.ReadOnly = true;
            this.tbTitle.Size = new System.Drawing.Size(775, 40);
            this.tbTitle.TabIndex = 2;
            this.tbTitle.Text = "Title";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDescription.Location = new System.Drawing.Point(12, 51);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.ReadOnly = true;
            this.rtbDescription.Size = new System.Drawing.Size(775, 167);
            this.rtbDescription.TabIndex = 3;
            this.rtbDescription.Text = "Description";
            // 
            // selectSpeakers1
            // 
            this.selectSpeakers1.Enabled = false;
            this.selectSpeakers1.Location = new System.Drawing.Point(287, 224);
            this.selectSpeakers1.Name = "selectSpeakers1";
            this.selectSpeakers1.Size = new System.Drawing.Size(214, 147);
            this.selectSpeakers1.TabIndex = 16;
            // 
            // ddOrganisers
            // 
            this.ddOrganisers.Enabled = false;
            this.ddOrganisers.Location = new System.Drawing.Point(287, 377);
            this.ddOrganisers.Name = "ddOrganisers";
            this.ddOrganisers.Size = new System.Drawing.Size(190, 30);
            this.ddOrganisers.TabIndex = 17;
            // 
            // ddVenue
            // 
            this.ddVenue.Enabled = false;
            this.ddVenue.Location = new System.Drawing.Point(287, 413);
            this.ddVenue.Name = "ddVenue";
            this.ddVenue.Size = new System.Drawing.Size(190, 30);
            this.ddVenue.TabIndex = 18;
            // 
            // datePickerSingle
            // 
            this.datePickerSingle.Enabled = false;
            this.datePickerSingle.Location = new System.Drawing.Point(12, 224);
            this.datePickerSingle.Name = "datePickerSingle";
            this.datePickerSingle.Size = new System.Drawing.Size(269, 249);
            this.datePickerSingle.TabIndex = 19;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(823, 38);
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
            this.btnOk.Location = new System.Drawing.Point(431, 598);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 20;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(823, 67);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ViewSeminar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 633);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.datePickerSingle);
            this.Controls.Add(this.ddVenue);
            this.Controls.Add(this.ddOrganisers);
            this.Controls.Add(this.selectSpeakers1);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEdit);
            this.Name = "ViewSeminar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewSeminar";
            this.Load += new System.EventHandler(this.ViewSeminar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private Custom_Controls.SelectSpeakers selectSpeakers1;
        private Custom_Controls.OrganiserDropDown ddOrganisers;
        private Custom_Controls.VenueDropDown ddVenue;
        private DatePickerSingle datePickerSingle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnDelete;
    }
}