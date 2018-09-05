using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_Management_System.Classes
{
    public struct Role
    {
        public string Name { get; set; }
        public int Privilege { get; set; }
        public Role(string name, int privilege)
        {
            this.Name = name;
            this.Privilege = privilege;
        }
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
