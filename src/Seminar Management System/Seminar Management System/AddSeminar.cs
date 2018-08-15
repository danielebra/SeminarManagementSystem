﻿using System;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // TODO: populate other seminar data
            Seminar seminar = new Seminar();
            seminar.Organiser = ddOrganisers.SelectedOrganiser;
            seminar.Venue = ddVenue.SelectedVenue;
            seminar.StartDate = datePicker.StartDate;
            seminar.EndDate = datePicker.EndDate;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            var foo = ddOrganisers.SelectedOrganiser;
            var bar = ddVenue.SelectedVenue;
            var start = datePicker.StartDate;
            var end = datePicker.EndDate;
        }

        private void datePicker_DateUpdated(object sender, EventArgs e)
        {
            // TODO
            // Cleanup code and make the display optional for hours and minutes
            // Confirm with customer that seminars can run for multiple days
            TimeSpan durr = datePicker.EndDate.Subtract(datePicker.StartDate);
            lblDuration.Text = string.Format("Duration: {0} {1} Hours {2} Minutes", 
                durr.ToString("dd") == "00" ? "" : durr.ToString("dd") + " Days",
                durr.Hours, durr.Minutes);
        }
    }
}
