using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seminar_Management_System.Classes.Users;
using Seminar_Management_System.Classes;

namespace Seminar_Management_System
{
    static class DataInstance
    {
        public static List<SeminarOrganiser> organisers = new List<SeminarOrganiser>();
        public static List<Venue> venues = new List<Venue>();

        public static void populateWithMockData()
        {
            DataInstance.organisers.Add(new SeminarOrganiser(0, "Bob"));
            DataInstance.organisers.Add(new SeminarOrganiser(1, "Tim"));

            DataInstance.venues.Add(new Venue(0, "Building 11", "Ultimo", 100));
            DataInstance.venues.Add(new Venue(1, "Building 10", "Ultimo", 200));

        }
    }
}
