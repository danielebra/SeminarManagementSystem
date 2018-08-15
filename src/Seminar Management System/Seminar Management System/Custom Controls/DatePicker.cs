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
    public partial class DatePicker : UserControl
    {
        public DatePicker()
        {
            InitializeComponent();
        }

        public DateTime StartDate { get { return dtpStart.Value; } }
        public DateTime EndDate { get { return dtpEnd.Value; } }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            monthCalander.SelectionStart = this.StartDate;
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            monthCalander.SelectionEnd = this.EndDate;
        }

        private void monthCalendar_UpdateRanges(object sender, DateRangeEventArgs e)
        {
            // Handles updating the explicit start and end date controls
            // to reflect the current range limit.
            // Eg: Manually selecting a range greater than the allowed limit (14 days)
            // the dates will automatically adjust

            var selectionRange = monthCalander.SelectionRange;
            dtpStart.Value = selectionRange.Start;
            dtpEnd.Value = selectionRange.End;
        }
    }
}
