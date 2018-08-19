using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seminar_Management_System.Classes.Users;
using Seminar_Management_System.Classes;
using System.Collections.ObjectModel;


namespace Seminar_Management_System
{
    static class DataInstance
    {
        public static List<SeminarOrganiser> organisers = new List<SeminarOrganiser>();
        public static List<Venue> venues = new List<Venue>();
        public static List<Speaker> speakers = new List<Speaker>();
        public static List<Seminar> seminars = new List<Seminar>();
        public static ObservableCollection<Seminar> obSeminars = new ObservableCollection<Seminar>();

        public static void populateWithMockData()
        {
            DataInstance.organisers.Add(new SeminarOrganiser(0, "Bob", "bob@staff.com", "111"));
            DataInstance.organisers.Add(new SeminarOrganiser(1, "Tim", "tim@staff.com", "222"));

            DataInstance.venues.Add(new Venue(0, "Building 11", "Ultimo", 100));
            DataInstance.venues.Add(new Venue(1, "Building 10", "Ultimo", 200));

            DataInstance.speakers.Add(new Speaker(0, "Dr James", "james@speakers.com", String.Empty, "This is a biography..."));
            DataInstance.speakers.Add(new Speaker(1, "Dr Paul", "paul@speakers.com", String.Empty, "This is a biography..."));

            DataInstance.obSeminars.Add(new Seminar(DataInstance.organisers[0], DataInstance.venues[0], DataInstance.speakers,
                new List<SeminarAttendee>(), "Learning Python", "The Zen of Python", DateTime.Now, DateTime.Today));
            DataInstance.obSeminars.Add(new Seminar(DataInstance.organisers[0], DataInstance.venues[0], DataInstance.speakers,
                new List<SeminarAttendee>(), "Learning C#", "Java developers wear glasses because they can't see sharp", DateTime.Now, DateTime.Today));

        }
    }
}
