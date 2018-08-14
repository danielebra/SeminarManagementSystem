using Seminar_Management_System.Classes.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_Management_System.Classes.Seminar
{
    class Seminar
    {
        public SeminarOrganiser Organiser { get; set; }
        public List<Speaker> Speakers { get; set; }
        public List<SeminarAttendee> Attendees { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
