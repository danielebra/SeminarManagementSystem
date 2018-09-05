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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private List<SeminarItem> seminarItems = new List<SeminarItem>();

        private void btnAddSeminar_Click(object sender, EventArgs e)
        {
            AddSeminar addSeminar = new AddSeminar();
            addSeminar.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
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
                    Environment.Exit(1);
            }
            DataInstance.seminars.CollectionChanged += ObSeminars_CollectionChanged;
            try
            {
                DataInstance.populateWithData();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            

            //DataInstance.populateWithMockData();

            // Fire resize
            Main_Resize(null, null);
        }

        private void ObSeminars_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {

            //pnlSeminarView.Controls.Clear();
            for (int i = pnlSeminarView.Controls.Count - 1; i >= 0; i--)
            {
                Control control = pnlSeminarView.Controls[i];
                if (control.GetType() == typeof(SeminarItem))
                    pnlSeminarView.Controls.Remove(control);
            }
            seminarItems.Clear();
            var q = from s in DataInstance.seminars
                    where s.Room.Name == DataInstance.seminars[0].Room.Name
                    select s;
            var seminars = q.ToList<Seminar>();
            //var seminars = DataInstance.seminars.Where(x => x.Room.Name == DataInstance.seminars[0].Room.Name);
            
            foreach (var seminar in seminars)//DataInstance.seminars)
            {
                SeminarItem seminarItem = new SeminarItem();
                seminarItem.Location = new Point(0, seminarItem.Size.Height * seminarItems.Count);
                if (seminarItems.Count % 2 == 1)
                    seminarItem.BackgroundColor = SystemColors.ActiveCaption;

                var seminarInstance = seminar;
                seminarItem.Populate(ref seminarInstance);
                seminarItems.Add(seminarItem);
                pnlSeminarView.Controls.Add(seminarItem);
            }
        }

        Random rnum = new Random();
        private void btnTest_Click(object sender, EventArgs e)
        {
            Seminar seminar = new Seminar();
            seminar.Title = "Created by test button";
            seminar.Description = rnum.Next(1111111, 1111111111).ToString();
            seminar.Speakers = DataInstance.speakers;
            seminar.StartDate = DateTime.Now;
            seminar.EndDate = DateTime.Now.AddHours(1);
            seminar.Room = DataInstance.rooms[rnum.Next(0, DataInstance.rooms.Count)];
            seminar.Organiser = DataInstance.organisers[rnum.Next(0, DataInstance.organisers.Count)];


            DataInstance.seminars.Add(seminar);
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            var foo = DataInstance.seminars.FirstOrDefault();
            RegisterAttendee reg = new RegisterAttendee();
            reg.Show();
        }
        
        private void Main_Resize(object sender, EventArgs e)
        {
            foreach (SeminarItem seminar in seminarItems)
                seminar.Resize();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            CreateAccount ca = new CreateAccount();
            ca.Show();
        }

        private void btnLaunchFilter_Click(object sender, EventArgs e)
        {
            CreateFilter filt = new CreateFilter();
            filt.Show();
        }
    }
}
