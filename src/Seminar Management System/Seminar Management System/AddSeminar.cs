using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar_Management_System
{
    public partial class AddSeminar : Form
    {
        public AddSeminar()
        {
            InitializeComponent();
        }
        private DateTime startDate { get { return dtpStart.Value; } }
        private DateTime endDate { get { return dtpEnd.Value; } }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            monthCalander.SelectionStart = this.startDate;
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            monthCalander.SelectionEnd = this.endDate;
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
