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
using Seminar_Management_System.Custom_Controls;
using System.Collections.ObjectModel;
using Seminar_Management_System.Classes;
using Seminar_Management_System.Forms;
using System.IO;

namespace Seminar_Management_System
{
    // This is the primary interface of the program
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private const string _LOGIN = "Login";
        private const string _LOGOUT = "Logout";
        // The current Seminar items displayed in the interface
        private List<SeminarItem> seminarItems = new List<SeminarItem>();
        // The current User items displayed in the interface
        private List<UserItem> userItems = new List<UserItem>();

        private InterfaceUnlocker interfaceUnlocker = new InterfaceUnlocker();

        private void btnAddSeminar_Click(object sender, EventArgs e)
        {
            AddSeminar addSeminar = new AddSeminar();
            addSeminar.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Give the DataInstance access to the current instance of this form
            DataInstance.mainInstance = this;
            
            // Look for the connection string to connect to the AWS database
            if (File.Exists("secrets.txt"))
            {
                using (StreamReader stream = new StreamReader("secrets.txt"))
                {
                    DataInstance._connectionString = stream.ReadLine();
                }
            }
            else
            {
                if (MessageBox.Show("The \"secrets.txt\" file is missing. Make sure this file is placed along side the executable.\n\nContact the software developer to retrieve the missing file if you do not have it.",
                    "Unable to configure database connection", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                { }//Environment.Exit(1);
            }
            // Subscribe to seminar changes
            DataInstance.seminars.CollectionChanged += ObSeminars_CollectionChanged;
            // Subscribe to user changes
            DataInstance.users.CollectionChanged += Users_CollectionChanged;
            // Load data into the program
            try
            {
                DataInstance.populateWithMockData();
                DrawUserInterface();
                //DataInstance.populateWithData();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            // Fire resize
            Main_Resize(null, null);
            // Begin reacting to logged in user changes
            interfaceUnlocker.Watch();
            DataInstance.LoggedInUserChanged += DataInstance_LoggedInUserChanged;
            // Default the LoggedInUser to an Attendee
            DataInstance.LoggedInUser = new SystemAdmin();
            // Subscribe to filter changes
            DataInstance.createFilterInterface.FilterUpdated += Filt_FilterUpdated;

        }

        private void DataInstance_LoggedInUserChanged(object sender, EventArgs e)
        {
            string loggedInRoleTemplate = "Viewing Seminar Management System as an ";
            // Display Logout when someone is not an Attendee
            if (DataInstance.LoggedInUser.GetType() != typeof(SeminarAttendee))
            {
                btnLogin.Text = _LOGOUT;
                lblGreeting.Text = "Welcome, " + DataInstance.LoggedInUser.Name;
                lblLoggedInRole.Text = loggedInRoleTemplate + DataInstance.LoggedInUser.Role;
            }
            // Display Login when someone is an Attendee
            else
            {
                btnLogin.Text = _LOGIN;
                lblGreeting.Text = "Howdy Stranger!";
                lblLoggedInRole.Text = loggedInRoleTemplate + DataInstance.LoggedInUser.Role;
            }
        }

        private void Users_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            DrawUserInterface();
        }

        private void ObSeminars_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            DrawSeminarInterface();
        }

        // Create the SeminarList interface
        private void DrawSeminarInterface()
        {
            for (int i = pnlSeminarView.Controls.Count - 1; i >= 0; i--)
            {
                Control control = pnlSeminarView.Controls[i];
                if (control.GetType() == typeof(SeminarItem))
                    pnlSeminarView.Controls.Remove(control);
            }
            seminarItems.Clear();
            var seminars = PortableFilter.Execute();

            foreach (var seminar in seminars)
            {
                SeminarItem seminarItem = new SeminarItem();
                seminarItem.Location = new Point(0, seminarItem.Size.Height * seminarItems.Count);
                // Change every second Seminar's color
                if (seminarItems.Count % 2 == 1)
                    seminarItem.BackgroundColor = SystemColors.ActiveCaption;

                var seminarInstance = seminar;
                seminarItem.Populate(ref seminarInstance);
                seminarItems.Add(seminarItem);
                pnlSeminarView.Controls.Add(seminarItem);
            }
        }

        // Create the UserList interface
        private void DrawUserInterface()
        {
            for (int i = pnlUserView.Controls.Count - 1; i >= 0; i--)
            {
                Control control = pnlUserView.Controls[i];
                if (control.GetType() == typeof(UserItem))
                    pnlUserView.Controls.Remove(control);
            }
            userItems.Clear();
            foreach (var user in DataInstance.users)
            {
                UserItem userItem = new UserItem();
                userItem.Location = new Point(0, userItem.Size.Height * userItems.Count);
                var userInstance = user;
                userItem.Populate(ref userInstance);
                // Check for repeated users of the same type
                if (userItems.Count > 0 && String.Equals(userItems.Last().UserReference.Role.Name, user.Role.Name))
                {
                    // Decide if the UserItem should be displayed with a shade of the same color
                    if (!userItems.Last().isUsingAlternativeColor)
                        userItem.AlternativeColor();
                }
                userItems.Add(userItem);
                pnlUserView.Controls.Add(userItem);
            }
        }

        Random rnum = new Random();
        private void btnTest_Click(object sender, EventArgs e)
        {
            // Add a random seminar to the list
            Seminar seminar = new Seminar();
            seminar.Title = "Created by test button";
            seminar.Description = rnum.Next(1111111, 1111111111).ToString();
            seminar.Speakers = Utils.GetAllSpeakers();
            seminar.StartDate = DateTime.Now;
            seminar.EndDate = DateTime.Now.AddHours(1);
            seminar.Room = DataInstance.rooms[rnum.Next(0, DataInstance.rooms.Count)];
            seminar.Organiser = Utils.GetAllOrganisers()[rnum.Next(0, Utils.GetAllOrganisers().Count)];


            DataInstance.seminars.Add(seminar);
        }
        bool test1 = true;
        TabPage backup;
        private void btnDebug_Click(object sender, EventArgs e)
        {
            Utils.GetAllSpeakers();
            /*InterfaceUnlocker iu = new InterfaceUnlocker();
            if (test1)
            {
                test1 = false;
                backup = this.tabPage2;
                iu.test();
            }
            else
            {
                tabControl.TabPages.Add(DataInstance.mainInstance.tabPage2);
                test1 = true;
            }*/
            //var foo = DataInstance.seminars.FirstOrDefault();
            //RegisterAttendee reg = new RegisterAttendee();
            //reg.Show();
        }
        
        private void Main_Resize(object sender, EventArgs e)
        {
            // Ask each interface item to resize themselzes
            foreach (SeminarItem seminar in seminarItems)
                seminar.Resize();
            foreach (UserItem user in userItems)
                user.Resize();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Show Login screen if the program is accepting Login requests
            if (btnLogin.Text == _LOGIN)
            {
                // Show the LoginScreen
                LoginScreen loginScreen = new LoginScreen();
                loginScreen.Show();
            }
            // Logout by logging in as an Attendee
            else
                DataInstance.LoggedInUser = new SeminarAttendee();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            // Show the CreateAccount screen
            CreateAccount ca = new CreateAccount();
            ca.Show();
        }

        private void btnLaunchFilter_Click(object sender, EventArgs e)
        {            
            DataInstance.createFilterInterface.Show();
        }

        private void Filt_FilterUpdated(object sender, EventArgs e)
        {
            // Re-draw the SeminarList interface when the filter has changed
            DrawSeminarInterface();
        }
    }
}
