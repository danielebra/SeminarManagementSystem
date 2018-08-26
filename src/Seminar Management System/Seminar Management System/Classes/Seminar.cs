using Seminar_Management_System.Classes.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_Management_System.Classes
{
    public class Seminar
    {
        public SeminarOrganiser Organiser { get; set; }
        public Venue Venue { get; set; }
        public List<Speaker> Speakers { get; set; }
        public BindingList<SeminarAttendee> Attendees { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public Seminar()
        {

        }

        public Seminar(SeminarOrganiser organiser, Venue venue, List<Speaker> speakers, BindingList<SeminarAttendee> attendees,
            string title, string description, DateTime startDate, DateTime endDate)
        {
            this.Organiser = organiser;
            this.Venue = venue;
            this.Speakers = speakers;
            this.Attendees = attendees;
            this.Title = title;
            this.Description = description;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

    }
}
