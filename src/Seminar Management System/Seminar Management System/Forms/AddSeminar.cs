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
using Seminar_Management_System.Classes;

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
            Seminar seminar = new Seminar();
            seminar.Organiser = ddOrganisers.SelectedOrganiser;
            seminar.Speakers = selectSpeakers1.SelectedSpeakers;
            seminar.Venue = ddVenue.SelectedVenue;
            seminar.StartDate = datePickerSingle.StartDate;
            seminar.EndDate = datePickerSingle.EndDate;
            seminar.Title = tbTitle.Text;
            seminar.Description = rtbDescription.Text;
            DataInstance.seminars.Add(seminar);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            var foo = ddOrganisers.SelectedOrganiser;
            var bar = ddVenue.SelectedVenue;
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
    }
}