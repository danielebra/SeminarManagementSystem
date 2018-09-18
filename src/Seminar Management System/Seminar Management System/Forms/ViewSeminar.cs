﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seminar_Management_System.Classes;
using Seminar_Management_System.Classes.Users;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Seminar_Management_System.Forms
{
    public partial class ViewSeminar : Form
    {
        public ViewSeminar()
        {
            InitializeComponent();
        }
        public ViewSeminar(ref Seminar seminar)
        {
            InitializeComponent();
            seminarReference = seminar;
            attendeeTable1.Setup(ref seminar);
        }

        private Seminar seminarReference { get; set; }
        private const string EDIT = "Edit";
        private const string SAVE = "Save";
        
        private void ViewSeminar_Load(object sender, EventArgs e)
        {
            populateDataFields();
            attendeeTable1.Editable(false);
            DataInstance.seminarInterfaceWindows.Add(this);
        }

        private void populateDataFields()
        {
            if (seminarReference != null)
            {
                tbTitle.Text = seminarReference.Title;
                rtbDescription.Text = seminarReference.Description;
                ddOrganisers.setOrganiser(seminarReference.Organiser);
                ddRoom.setRoom(seminarReference.Room);
                selectSpeakers1.setSpeakers(seminarReference.Speakers);
                datePickerSingle.setDateTime(seminarReference.StartDate, seminarReference.EndDate);
            }
        }
        private BindingList<SeminarAttendee> attendeesBackup;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Create a deep copy of the the attendee list to remove its reference
            var cloned = Utils.ObjectCloner.Clone(seminarReference.Attendees);
            attendeesBackup = (BindingList<SeminarAttendee>)cloned;
            if (btnEdit.Text == EDIT)
            {
                enableEditing();
                btnEdit.Text = SAVE;
                btnCancel.Visible = true;
                btnDelete.Visible = true;
            }
            else if (btnEdit.Text == SAVE)
            {
                disableEditing();
                btnEdit.Text = EDIT;
                btnCancel.Visible = false;
                btnDelete.Visible = false;
                saveSeminarState();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            populateDataFields();
            disableEditing();
            btnCancel.Visible = false;
            btnDelete.Visible = false;
            btnEdit.Text = EDIT;
            seminarReference.Attendees = attendeesBackup;

            // Re connect the table to the new object reference
            var intermediary = this.seminarReference;
            attendeeTable1.Setup(ref intermediary);
        }

        private void saveSeminarState()
        {
            seminarReference.Organiser = ddOrganisers.SelectedOrganiser;
            seminarReference.Speakers = selectSpeakers1.SelectedSpeakers;
            seminarReference.Room = ddRoom.SelectedRoom;
            seminarReference.StartDate = datePickerSingle.StartDate;
            seminarReference.EndDate = datePickerSingle.EndDate;
            seminarReference.Title = tbTitle.Text;
            seminarReference.Description = rtbDescription.Text;

            // Used to fire observer event, as it is not triggered by ref updates
                // This will update the seminar list interface
            DataInstance.seminars[DataInstance.seminars.IndexOf(seminarReference)] = seminarReference;
        }

        private void _enableEditing(bool canEdit)
        {
            // param canEdit: true refers to enabling on
            //                false refers to enabling off

            // Forloop can be removed and controls be accessed
            // directly, once the complexity of the controls
            // is determined.
            foreach (var cont in this.Controls)
            {
                if (cont.GetType() == typeof(TextBox))
                {
                    ((TextBox)cont).ReadOnly = !canEdit;
                }
                else if (cont.GetType() == typeof(RichTextBox))
                {
                    ((RichTextBox)cont).ReadOnly = !canEdit;
                }
            }
            ddOrganisers.Enabled = canEdit;
            ddRoom.Enabled = canEdit;
            datePickerSingle.Enabled = canEdit;
            selectSpeakers1.Enabled = canEdit;
            attendeeTable1.Editable(canEdit);
        }

        public void enableEditing()
        {
            _enableEditing(true);
        }

        public void disableEditing()
        {
            _enableEditing(false);
        }

        private void btnEdit_TextChanged(object sender, EventArgs e)
        {
            if (btnEdit.Text == EDIT)
            {
                btnEdit.BackColor = SystemColors.ActiveCaption;
            }
            else if (btnEdit.Text == SAVE)
            {
                btnEdit.BackColor = Color.LimeGreen;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this seminar?\nThis action can't be reversed.",
                "Delete Seminar", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DataInstance.seminars.Remove(seminarReference);
                this.Close();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var intermediary = this.seminarReference;
            RegisterAttendee ra = new RegisterAttendee(ref intermediary);
            ra.Show();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            this.seminarReference.Attendees.Add(new Classes.Users.SeminarAttendee(3, "oooo", "otho", "oeo"));
        }

        private void ViewSeminar_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataInstance.seminarInterfaceWindows.Remove(this);
        }
    }
}
