using Seminar_Management_System.Classes;
using Seminar_Management_System.Classes.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar_Management_System.Forms
{
    // This is used to do the following to a User: view, edit, delete
    public partial class ViewUser : Form
    {
        public ViewUser()
        {
            InitializeComponent();
        }
        public ViewUser(ref User user)
        {
            InitializeComponent();
            userReference = user;
        }
        private User userReference { get; set; }
        private const string EDIT = "Edit";
        private const string SAVE = "Save";

        private void ViewUser_Load(object sender, EventArgs e)
        {
            //roleDropDown1.Select
            roleDropDown1.SelectedRoleChanged += RoleDropDown1_SelectedRoleChanged;
            populateDataFields();
            disableEditing();
            this.Text = "Viewing User Information for " + userReference.Name;
        }

        private void RoleDropDown1_SelectedRoleChanged(object sender, EventArgs e)
        {
            if (roleDropDown1.SelectedRole.Name == Role.Names.Speaker)
            {
                this.lblBiography.Visible = true;
                this.rtbBiography.Visible = true;
            }
            else
            {
                this.lblBiography.Visible = false;
                this.rtbBiography.Visible = false;
            }

        }

        private void populateDataFields()
        {
            if (userReference != null)
            {
                tbName.Text = userReference.Name;
                roleDropDown1.LoadFromUser(userReference);
                tbEmail.Text = userReference.Email;
                tbPhone.Text = userReference.PhoneNumber;
                if (userReference.Role.Name == Role.Names.Speaker)
                {
                    rtbBiography.Text = ((Speaker)userReference).Biography;
                }
            }
        }

        // The Edit button can either be 'Save' or 'Edit'
        // It will have different functionality based on which one it is currently set to
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == EDIT) // Handle editing functionality
            {
                enableEditing();
                btnEdit.Text = SAVE;
                btnCancel.Visible = true;
                btnDelete.Visible = true;

            }
            else if (btnEdit.Text == SAVE) // Handle saving functionality
            {
                disableEditing();
                btnEdit.Text = EDIT;
                btnCancel.Visible = false;
                btnDelete.Visible = false;
                rtbBiography.ReadOnly = roleDropDown1.SelectedRole.Name != Role.Names.Speaker;
                lblBiography.Enabled = roleDropDown1.SelectedRole.Name != Role.Names.Speaker;
                saveUserState();
            }
        }

        private void saveUserState()
        {
            // Gather the information from the interface and save it in the User object
            userReference.Name = tbName.Text;
            userReference.Role = roleDropDown1.SelectedRole;
            userReference.PhoneNumber = tbPhone.Text;
            userReference.Email = tbEmail.Text;
            if (roleDropDown1.SelectedRole.Name == Role.Names.Speaker)
            {
                // Create a new user object that is a user, based on previous values
                Speaker userAsSpeaker = new Speaker(userReference.ID, userReference.Name, userReference.Email, userReference.PhoneNumber, rtbBiography.Text);
                DataInstance.users[DataInstance.users.IndexOf(userReference)] = userAsSpeaker;
                DataInstance.editSpeaker(userAsSpeaker);
            }
            else
            {
                // Used to fire observer event, as it is not triggered by ref updates
                // This will update the user list interface
                DataInstance.users[DataInstance.users.IndexOf(this.userReference)] = this.userReference;
                //Update changes to user to DB
                switch (userReference.Role.Name)
                {
                    case Role.Names.Organiser:
                        DataInstance.editOrganiser(userReference);
                        break;
                    case Role.Names.Admin:
                        DataInstance.editAdmin(userReference);
                        break;
                    case Role.Names.Host:
                        DataInstance.editHost(userReference);
                        break;
                }
            }
        }

        private void _enableEditing(bool canEdit)
        {
            // param canEdit: true refers to enabling on
            //                false refers to enabling off
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
            roleDropDown1.Enabled = canEdit;
            lblBiography.Enabled = canEdit;
            rtbBiography.ReadOnly = canEdit;
        }

        private void enableEditing()
        {
            _enableEditing(true);
        }

        private void disableEditing()
        {
            _enableEditing(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Get confirmation from the user before deleting this User
            if (MessageBox.Show("Are you sure you want to delete this user?\nThis action can't be reversed.",
                "Delete User",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DataInstance.users.Remove(this.userReference); 
                switch (userReference.Role.Name)
                {
                    case Role.Names.Attendee:
                        DataInstance.deleteAttendee((SeminarAttendee)userReference);
                        break;
                    case Role.Names.Organiser:
                        DataInstance.deleteOrganiser((SeminarOrganiser)userReference);
                        break;
                    case Role.Names.Speaker:
                        DataInstance.deleteSpeaker((Speaker)userReference);
                        break;
                    case Role.Names.Admin:
                        DataInstance.deleteAdmin((SystemAdmin)userReference);
                        break;
                    case Role.Names.Host:
                        DataInstance.deleteHost((SeminarHost)userReference);
                        break;
                }
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Cancel all changes and load the defaults for this User into the interface
            populateDataFields();
            disableEditing();
            btnCancel.Visible = false;
            btnDelete.Visible = false;
            btnEdit.Text = EDIT;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == SAVE)
            {
                if (MessageBox.Show("You have some unsaved changes.\nAre you sure you want to close this?", "Potential loss of data", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
                this.Close();
        }
    }
}
