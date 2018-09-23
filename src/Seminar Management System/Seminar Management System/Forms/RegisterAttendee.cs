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
using System.Reflection;
namespace Seminar_Management_System.Forms
{
    // This is used to gather the relevant information for making an Attendee
    // and creating the Attendee object
    public partial class RegisterAttendee : Form
    {
        public RegisterAttendee()
        {
            InitializeComponent();
        }
        public RegisterAttendee(ref Seminar seminar)
        {
            InitializeComponent();
            seminarReference = seminar;
        }
        private Seminar seminarReference { get; set; }
        // Event used to alert that an Attendee has been registered
        public event EventHandler AttendeeRegistered;

        private void RegisterAttendee_Load(object sender, EventArgs e)
        {
            // Create the interface on load
            CreateInterface();
        }

        public void CreateInterface()
        {
            // Create interface based on the properties of a SeminarAttendee
            // This is dynamically done inorder to make it easier to change what defines an attendee
            // from a data structure perspective
            int counter = 0;
            int x = 5;
            foreach (PropertyInfo p in typeof(SeminarAttendee).GetProperties())
            {
                if (p.Name == "ID")
                    continue;
                Label label = new Label();
                TextBox tb = new TextBox();
                label.AutoSize = true;
                label.Text = p.Name;
                label.Location = new Point(x, counter * (tb.Height + label.Height + 4));
                
                tb.Location = new Point(2, label.Location.Y + (label.Height));

                this.Controls.Add(label);
                this.Controls.Add(tb);

                counter++;

            }
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Get all the TextBoxes from the screen
            IEnumerable<Control> tbs = Utils.GetControlsFromControl(this, typeof(TextBox));
            List<string> vals = new List<string>();
            foreach (var cont in tbs)
                vals.Add(((TextBox)cont).Text);
            // Add the new Attendee to the Seminar's list of Attendees
            seminarReference.Attendees.Add(new SeminarAttendee(seminarReference.Attendees.Count,vals[0], vals[1], vals[2]));

            if (this.AttendeeRegistered != null)
            {
                // Fire an event to alert subscribers that a change has occured in the AttendeeList
                this.AttendeeRegistered(this, new EventArgs());
            }
            // Close this interface
            this.Close();

        }
    }
}
