using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar_Management_System
{
    // This UserControl is used to select a Date and Time for a particular day

    public partial class DatePickerSingle : UserControl
    {
        public DatePickerSingle()
        {
            InitializeComponent();
        }

        public DateTime StartDate { get { return dtpStart.Value; } }
        public DateTime EndDate { get { return dtpEnd.Value; } }
        public string DurationString { get { return lblDuration.Text; } }
        // Fire an event when the date has changed
        public event EventHandler DateUpdated;

        public void setDateTime(DateTime start, DateTime end)
        {
            monthCalander.SetDate(start);
            dtpStart.Value = start;
            dtpEnd.Value = end;
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            monthCalander.SelectionStart = this.StartDate;
            if (this.DateUpdated != null)
                this.DateUpdated(this, new EventArgs());
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            monthCalander.SelectionEnd = this.EndDate;
            if (this.DateUpdated != null)
                this.DateUpdated(this, new EventArgs());
        }

        private void monthCalendar_UpdateRanges(object sender, DateRangeEventArgs e)
        {
            // Handles updating the explicit start and end date controls
            // to reflect the current range limit.
            // Eg: Manually selecting a range greater than the allowed limit (14 days)
            // the dates will automatically adjust

            var selectionRange = monthCalander.SelectionRange;
            // Update the start and end dates with Dates from the calender and Time from the time picker
            DateTime start = new DateTime(selectionRange.Start.Year, selectionRange.Start.Month, selectionRange.Start.Day,
                dtpStart.Value.Hour, dtpStart.Value.Minute, dtpStart.Value.Second);
            DateTime end = new DateTime(selectionRange.End.Year, selectionRange.End.Month, selectionRange.End.Day,
                dtpEnd.Value.Hour, dtpEnd.Value.Minute, dtpEnd.Value.Second);

            dtpStart.Value = start;
            dtpEnd.Value = end;
        }

        private void DatePickerSingle_Load(object sender, EventArgs e)
        {
            // Put the time pickers in a desirable readable format
            dtpStart.CustomFormat = "h:mm tt";
            dtpEnd.CustomFormat = "h:mm tt";
            DateUpdated += DatePickerSingle_DateUpdated;
        }

        private void DatePickerSingle_DateUpdated(object sender, EventArgs e)
        {
            TimeSpan duration = this.EndDate.Subtract(this.StartDate);
            string hours = (duration.Hours == 00 ? "" : duration.Hours.ToString());
            if (duration.Hours != 00)
                hours += (duration.Hours > 1 || duration.Hours < -1 ? " Hours " : " Hour ");
            string minutes = (duration.Minutes == 00 ? "" : duration.Minutes.ToString());
            if (duration.Minutes != 0)
                minutes += (duration.Minutes > 1 || duration.Minutes < -1 ? " Minutes" :  " Minute");
            string status = duration.Hours < 0 || duration.Minutes < 0 ? " (Invalid)" : "";
            lblDuration.Text = string.Format("Duration: {0}{1}{2}", hours, minutes, status);
        }
    }
}
