namespace Seminar_Management_System
{
    partial class DatePicker
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
            this.monthCalander = new System.Windows.Forms.MonthCalendar();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // monthCalander
            // 
            this.monthCalander.Location = new System.Drawing.Point(69, 58);
            this.monthCalander.MaxSelectionCount = 14;
            this.monthCalander.Name = "monthCalander";
            this.monthCalander.TabIndex = 12;
            this.monthCalander.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_UpdateRanges);
            this.monthCalander.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_UpdateRanges);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(79, 33);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 20);
            this.dtpEnd.TabIndex = 10;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(79, 7);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 20);
            this.dtpStart.TabIndex = 11;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(8, 30);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(52, 13);
            this.lblEnd.TabIndex = 8;
            this.lblEnd.Text = "End Date";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(8, 10);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(55, 13);
            this.lblStart.TabIndex = 9;
            this.lblStart.Text = "Start Date";
            // 
            // DatePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.monthCalander);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Name = "DatePicker";
            this.Size = new System.Drawing.Size(306, 229);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalander;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblStart;
    }
}
