using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_Management_System.Classes
{
    // A Role is used to describe the position of a user and what they are authorized to view
    // Viewability is expressed through Privilege level. The Higher, the more power they have
    [Serializable()]
    public struct Role
    {
        public string Name { get; set; }
        public int Privilege { get; set; }
        public Role(string name, int privilege)
        {
            this.Name = name;
            this.Privilege = privilege;
        }

        // All the names of possible Roles are located here
        public static class Names
        {
            public const string Attendee = "Attendee";
            public const string Speaker = "Speaker";
            public const string Host = "Host";
            public const string Organiser = "Organiser";
            public const string Admin = "Admin";
        }
    }

    
}
