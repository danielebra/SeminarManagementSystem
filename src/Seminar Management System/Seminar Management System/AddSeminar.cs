using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seminar_Management_System.Classes.Users;
using Seminar_Management_System.Classes.Seminar;

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

        private void AddSeminar_Load(object sender, EventArgs e)
        {
            foreach (SeminarOrganiser organiser in DataInstance.organisers)
                cbOrganizers.Items.Add(organiser.Name);
            cbOrganizers.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // TODO: populate other seminar data
            Seminar seminar = new Seminar();
            // Grab organiser object based on selected item in combo box
            SeminarOrganiser organiser = DataInstance.organisers.Where(o => o.Name.Equals(cbOrganizers.SelectedValue)).FirstOrDefault();
            seminar.Organiser = organiser;
        }
    }
}
