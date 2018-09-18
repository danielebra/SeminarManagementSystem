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
            populateDataFields();
        }
        private void populateDataFields()
        {
            if (userReference != null)
            {
                tbName.Text = userReference.Name;
                roleDropDown1.LoadFromUser(userReference);
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
                saveUserState();
            }
        }

        private void saveUserState()
        {
            userReference.Name = tbName.Text;
            userReference.Role = roleDropDown1.SelectedRole;
            // Used to fire observer event, as it is not triggered by ref updates
            // This will update the user list interface
            DataInstance.users[DataInstance.users.IndexOf(userReference)] = userReference;
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
            if (MessageBox.Show("Are you sure you want to delete this user?\nThis action can't be reversed.",
                "Delete User",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DataInstance.users.Remove(userReference);
                this.Close();
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

        private void btnTest_Click(object sender, EventArgs e)
        {
            var foo = roleDropDown1.SelectedRole;
        }
    }
}
