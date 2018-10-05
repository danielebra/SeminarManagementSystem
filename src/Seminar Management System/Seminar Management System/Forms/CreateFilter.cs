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
using System.Linq.Expressions;
using Seminar_Management_System.Classes.Users;

namespace Seminar_Management_System.Forms
{
    // This is used to filter the Seminar list
    public partial class CreateFilter : Form
    {
        public CreateFilter()
        {
            InitializeComponent();
        }
        // Fire an event when the filter has been updated
        public event EventHandler FilterUpdated;

        private void btnDone_Click(object sender, EventArgs e)
        {
            // Uses the filter when a user checks the checkbox
            PortableFilter.ByRoom = cbRoom.Checked;
            PortableFilter.Room = cbRoom.Checked ? roomDropDown1.SelectedRoom : null;

            PortableFilter.ByOrganiser = cbOrganiser.Checked;
            PortableFilter.Organiser = cbOrganiser.Checked ? organiserDropDown1.SelectedOrganiser : null;

            PortableFilter.BySpeaker = cbSpeaker.Checked;
            PortableFilter.Speakers = cbSpeaker.Checked ? selectSpeakers1.SelectedSpeakers : null;
            if (FilterUpdated != null)
                FilterUpdated(this, new EventArgs());
            this.Hide();
        }

        private void CreateFilter_Load(object sender, EventArgs e)
        {
            selectSpeakers1.setText("Select Speakers to search by");
        }

        private void CreateFilter_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // This will be moved to its own file in the future
    public static class PortableFilter
    {
        // Each section will have a flag followed by a value

        // Search by room
        public static bool ByRoom { get; set; } // Enable or Disable searching by Room
        public static Room Room { get; set; } // Which Room to search for

        public static bool ByOrganiser { get; set; }
        public static SeminarOrganiser Organiser { get; set; }

        public static bool BySpeaker { get; set; }
        public static List<Speaker> Speakers { get; set; }
        // Returns a list of Seminars that matches the search conditions defined by the properties above
        public static List<Seminar> Execute()
        {
            var query = from s in DataInstance.seminars
                        where (ByRoom == false || s.Room == Room)
                        where (ByOrganiser == false || s.Organiser == Organiser)
                        where (BySpeaker == false || s.Speakers.Any(iter => Speakers.Any(speaker => speaker.Name == iter.Name)))//.Contains(Speakers))
                        select s;
            return query.ToList<Seminar>();
        }
    }
}
