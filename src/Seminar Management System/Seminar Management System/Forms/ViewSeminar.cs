using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seminar_Management_System.Classes;

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
        }

        private void populateDataFields()
        {
            if (seminarReference != null)
            {
                tbTitle.Text = seminarReference.Title;
                rtbDescription.Text = seminarReference.Description;
                ddOrganisers.setOrganiser(seminarReference.Organiser);
                ddVenue.setVenue(seminarReference.Venue);
                selectSpeakers1.setSpeakers(seminarReference.Speakers);
                datePickerSingle.setDateTime(seminarReference.StartDate, seminarReference.EndDate);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
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
        }

        private void saveSeminarState()
        {
            seminarReference.Organiser = ddOrganisers.SelectedOrganiser;
            seminarReference.Speakers = selectSpeakers1.SelectedSpeakers;
            seminarReference.Venue = ddVenue.SelectedVenue;
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
            ddVenue.Enabled = canEdit;
            datePickerSingle.Enabled = canEdit;
            selectSpeakers1.Enabled = canEdit;
            attendeeTable1.Enabled = canEdit;
        }

        private void enableEditing()
        {
            _enableEditing(true);
        }

        private void disableEditing()
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
    }
}
