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
    public partial class DatePickerSingle : UserControl
    {
        public DatePickerSingle()
        {
            InitializeComponent();
        }

        public DateTime StartDate { get { return dtpStart.Value; } }
        public DateTime EndDate { get { return dtpEnd.Value; } }

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

            DateTime start = new DateTime(selectionRange.Start.Year, selectionRange.Start.Month, selectionRange.Start.Day,
                dtpStart.Value.Hour, dtpStart.Value.Minute, dtpStart.Value.Second);
            DateTime end = new DateTime(selectionRange.End.Year, selectionRange.End.Month, selectionRange.End.Day,
                dtpEnd.Value.Hour, dtpEnd.Value.Minute, dtpEnd.Value.Second);

            dtpStart.Value = start;
            dtpEnd.Value = end;
        }

        private void DatePickerSingle_Load(object sender, EventArgs e)
        {
            dtpStart.CustomFormat = "h:mm tt";
            dtpEnd.CustomFormat = "h:mm tt";
        }
    }
}
