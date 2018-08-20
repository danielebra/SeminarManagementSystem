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
            DataInstance.seminars.CollectionChanged += ObSeminars_CollectionChanged;

            DataInstance.populateWithMockData();

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
            foreach (var seminar in DataInstance.seminars)
            {
                SeminarItem seminarItem = new SeminarItem();
                seminarItem.Location = new Point(0, seminarItem.Size.Height * seminarItems.Count);
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
            seminar.Venue = DataInstance.venues[rnum.Next(0, DataInstance.venues.Count)];
            seminar.Organiser = DataInstance.organisers[rnum.Next(0, DataInstance.organisers.Count)];


            DataInstance.seminars.Add(seminar);
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            var foo = DataInstance.seminars.FirstOrDefault();
        }
        
        private void Main_Resize(object sender, EventArgs e)
        {
            foreach (SeminarItem seminar in seminarItems)
                seminar.Resize();
        }
    }
}
