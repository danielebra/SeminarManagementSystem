﻿using Seminar_Management_System.Classes.Users;
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
        public Room Room { get; set; }
        public List<Speaker> Speakers { get; set; } // There can be multiple Speakers
        public BindingList<SeminarAttendee> Attendees { get; set; }

        // Basic information
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // Start and End time
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DurationString { get; set; }

        //Amount of attendees attending this seminar
        public int NumberOfAttendeesGoing { get { return this.Attendees.Where(s => s.Status == "Going").Count(); } }
        public int NumberOfAttendeesInterested { get { return this.Attendees.Where(s => s.Status == "Interested").Count(); } }

        public Seminar()
        {
            Speakers = new List<Speaker>();
            Attendees = new BindingList<SeminarAttendee>();
        }

        public Seminar(int id, SeminarOrganiser organiser, Room room, List<Speaker> speakers, BindingList<SeminarAttendee> attendees,
            string title, string description, DateTime startDate, DateTime endDate)
        {
            this.Organiser = organiser;
            this.Room = room;
            this.Speakers = speakers;
            this.Attendees = attendees;
            this.Title = title;
            this.Description = description;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.ID = id;
        }

    }
}
