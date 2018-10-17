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
using Seminar_Management_System.Classes.Users;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using IronPdf;
using iText;

namespace Seminar_Management_System.Forms
{
    // This is user to view a Seminar in more detail, edit it, register attendee, delete it
    public partial class ViewSeminar : Form
    {
        public ViewSeminar()
        {
            InitializeComponent();
        }
        public ViewSeminar(ref Seminar seminar)
        {
            InitializeComponent();
            // Connect to a Seminar reference
            seminarReference = seminar;
            attendeeTable1.Setup(ref seminar);
        }

        private Seminar seminarReference { get; set; }
        private const string EDIT = "Edit";
        private const string SAVE = "Save";
        
        private void ViewSeminar_Load(object sender, EventArgs e)
        {
            this.Text = "Viewing Seminar Information for " + seminarReference.Title;
            // Load information
            populateDataFields();
            // Disable editing
            attendeeTable1.Editable(false);
            // Add this instance to the list of open ViewSeminar interfaces
            DataInstance.seminarInterfaceWindows.Add(this);
        }

        private void populateDataFields()
        {
            if (seminarReference != null)
            {
                // Load the Seminar information onto the screen
                tbTitle.Text = seminarReference.Title;
                rtbDescription.Text = seminarReference.Description;
                ddOrganisers.setOrganiser(seminarReference.Organiser);
                ddRoom.setRoom(seminarReference.Room);
                selectSpeakers1.setSpeakers(seminarReference.Speakers);
                datePickerSingle.setDateTime(seminarReference.StartDate, seminarReference.EndDate);
            }
        }
        private BindingList<SeminarAttendee> attendeesBackup;

        // The Edit button can either be 'Save' or 'Edit'
        // It will have different functionality based on which one it is currently set to
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Create a deep copy of the the attendee list to remove its reference
            var cloned = Utils.ObjectCloner.Clone(seminarReference.Attendees);
            attendeesBackup = (BindingList<SeminarAttendee>)cloned;
            if (btnEdit.Text == EDIT) // Handle editing functionality
            {
                btnEdit.Text = SAVE;
                btnCancel.Visible = true;
                
                if (DataInstance.LoggedInUser.Role.Privilege >= Authentication.GetPrivilegeFromRoleName(Role.Names.Organiser))
                {
                    FullEdit(); // Allow whole interface to be changed
                    btnDelete.Visible = true; // If the user is an organizer and above, show delete
                }
                else
                    AttendeeEdit(); // Allow only the attendee list to be changed
            }
            else if (btnEdit.Text == SAVE) // Handle saving functionality
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
            this.RestoreState();
        }

        private void saveSeminarState()
        {
            // Gather the information from interface and save it in the Seminar object
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
        // Full user editing (eg: an Admin)
        public void FullEdit()
        {
            _enableEditing(true);
        }
        // Attendee only editing
        public void AttendeeEdit()
        {
            disableEditing();
            attendeeTable1.Editable(true);
        }
        public void RestoreState()
        {
            // Reload the information that was available when this interface first opened
            populateDataFields();
            disableEditing();
            btnCancel.Visible = false;
            btnDelete.Visible = false;
            btnEdit.Text = EDIT;
            seminarReference.Attendees = attendeesBackup;

            // Re-connect the table to the new object reference
            var intermediary = this.seminarReference;
            attendeeTable1.Setup(ref intermediary);
        }
        private void btnEdit_TextChanged(object sender, EventArgs e)
        {
            // Change the color of Edit button
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
            // Get confirmation before deleting this Seminar
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
            // Create RegisterAttendee interface with reference to this Seminar interface
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
            // Remove this instance from the list of open ViewSeminar interfaces
            DataInstance.seminarInterfaceWindows.Remove(this);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == SAVE)
            {
                if (MessageBox.Show("You have some unsaved changes.\nAre you sure you want to close this seminar?", "Potential loss of data", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
                this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Bitmap nameTag = new Bitmap(723, 962);
            // the url need to be changed before using
            string pdf = seminarReference.Title + "-template.pdf";
            // store the attendee whose status is going
            List<SeminarAttendee> goingAttendees = new List<SeminarAttendee>();
            // store the list of pdf, ready for merging
            List<PdfDocument> PDFs = new List<PdfDocument>();

            float width = 200.0F;
            float height = 65.0F;
            // set up for handling align
            int counter = 0;
            // background file ( need to be download before using)
            Image background = Image.FromFile("Background.png");

            //put attendees who with "going" into a list, ready for printing nametags
            foreach(var attendee in seminarReference.Attendees)
            {
                if(attendee.Status == "Going")
                {
                    goingAttendees.Add(attendee);
                }
            }
            // draw the background of first page
            using (Graphics g = Graphics.FromImage(nameTag))
            {
                g.DrawImage(background, 0, 0, 723, 962);
            }

            foreach (var attendee in goingAttendees)
            {
                //drawing the first page of name tags 
                if (goingAttendees.IndexOf(attendee) % 14 != 0 || goingAttendees.IndexOf(attendee) == 0)
                {
                    using (Graphics graphics = Graphics.FromImage(nameTag))
                    {
                        using (Font arialFont = new Font("Arial", 20))
                        {
                            // drawing the first column of name tags
                            if (IsOdd(goingAttendees.IndexOf(attendee)))
                            {
                                graphics.DrawString(attendee.Name + "   " + attendee.PhoneNumber, arialFont, Brushes.Black,
                                    new RectangleF(100, 55 + counter, width, height));
                            }
                            else // drawing the second column of name tags
                            {
                                graphics.DrawString(attendee.Name + "   " + attendee.PhoneNumber, arialFont, Brushes.Black,
                                    new RectangleF(400, 55 + counter, width, height));
                                counter += 135;
                            }
                        }
                     //   nameTag.Save(url);
                        ImageToPdfConvetrer.ImageToPdf(nameTag).SaveAs(pdf);  
                    }
                    if (goingAttendees.IndexOf(attendee) == goingAttendees.Count - 1)
                    {  PDFs.Add(PdfDocument.FromFile(pdf)); }
                }
                else
                {
                    // adding the pdf into pdf list, ready for merging
                    PDFs.Add(PdfDocument.FromFile(pdf));
                    counter = 0;

                    using (Graphics graphics = Graphics.FromImage(nameTag))
                    {
                        graphics.Clear(Color.White);
                        graphics.DrawImage(background, 0, 0, 723, 962);
                        using (Font arialFont = new Font("Arial", 20))
                        {
                            if (IsOdd(goingAttendees.IndexOf(attendee)))
                            {
                                graphics.DrawString(attendee.Name + "   " + attendee.PhoneNumber, arialFont, Brushes.Black,
                                    new RectangleF(100, 55 + counter, width, height));
                            }
                            else // drawing the second column of name tags
                            {
                                graphics.DrawString(attendee.Name + "   " + attendee.PhoneNumber, arialFont, Brushes.Black,
                                    new RectangleF(400, 55 + counter, width, height));
                                counter += 135;
                            }
                        }
                    }
                    ImageToPdfConvetrer.ImageToPdf(nameTag).SaveAs(pdf);
                    // print the next page if there is only one attendee 
                    if ( (goingAttendees.Count - 1) % 14 == 0) { PDFs.Add(PdfDocument.FromFile(pdf)); }
                }
            }
            // merge multiple pdf files
            if (PDFs.Count != 0)
            {
                PdfDocument result = PdfDocument.Merge(PDFs);
                // save merged pdf in this location, need to be changed before use
                SaveFileDialog printFile = new SaveFileDialog();
                printFile.Filter = "Pdf Files (*.pdf) | *.pdf | All Files(*.*) | *.*";
                printFile.Title = "Save as";
                DialogResult dr = printFile.ShowDialog();

                if ( dr == DialogResult.OK)
                {
                    result.SaveAs(printFile.FileName); 
                }
                MessageBox.Show("The nametag saved!", "Information", MessageBoxButtons.OK);
               
            }
        }

        public Boolean IsOdd(int num)
        {
            if (num % 2 == 0)
            { return true; }
            else { return false; }
        }


    }
}
