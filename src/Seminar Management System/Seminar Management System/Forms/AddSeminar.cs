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
using Seminar_Management_System.Classes;
using Seminar_Management_System.Forms;

namespace Seminar_Management_System
{
    public partial class AddSeminar : Form
    {
        public AddSeminar()
        {
            InitializeComponent();
        }
        private Seminar seminar { get; set; }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Grab all the current information populate it into the Seminar object
            seminar.Organiser = ddOrganisers.SelectedOrganiser;
            seminar.Speakers = selectSpeakers1.SelectedSpeakers;
            seminar.Room = ddRoom.SelectedRoom;
            seminar.StartDate = datePickerSingle.StartDate;
            seminar.EndDate = datePickerSingle.EndDate;
            seminar.Title = tbTitle.Text;
            seminar.Description = rtbDescription.Text;
            // Add the seminar into list of Seminars
            DataInstance.seminars.Add(seminar);
            // Close this screen
            this.Close();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            var foo = ddOrganisers.SelectedOrganiser;
            var bar = ddRoom.SelectedRoom;
            var start = datePickerSingle.StartDate;
            var end = datePickerSingle.EndDate;

            var selectedSpeakers = selectSpeakers1.SelectedSpeakers;
        }

        private void datePicker_DateUpdated(object sender, EventArgs e)
        {
            // In the future, detection for adding (s) after hour or minutes can be added
            TimeSpan duration = datePickerSingle.EndDate.Subtract(datePickerSingle.StartDate);
            lblDuration.Text = string.Format("Duration: {0}{1}",
                duration.Hours == 00 ? "" : duration.Hours.ToString() + " Hours ",
                duration.Minutes == 00 ? "" : duration.Minutes.ToString() + " Minutes");
        }

        private void btnAddAttendee_Click(object sender, EventArgs e)
        {
            // Pass the current seminar as reference to RegisterAttendee screen
            // This is so that the changes can automatically be reflected back
            var intermediary = this.seminar;
            RegisterAttendee ra = new RegisterAttendee(ref intermediary);
            ra.Show();
        }

        private void AddSeminar_Load(object sender, EventArgs e)
        {
            // Create a new Seminar on load
            Seminar intermediary = new Seminar();
            this.seminar = intermediary;
            // Connect the AttendeeTable to the Seminar object
            attendeeTable1.Setup(ref intermediary);
            attendeeTable1.Editable(false);
        }
    }
}
