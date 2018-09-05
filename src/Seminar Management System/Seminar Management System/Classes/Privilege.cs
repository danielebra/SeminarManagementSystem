using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_Management_System.Classes
{
    struct Privilege
    {
        /*public static List<Role> roles = new List<Role>()
        {
            { new Role("Attendee", 0) }
        };*/
        //public static Role Attendee = new Role("Attendee", 0);
        // These values need to be further investigated
        public const int Attendee = 0;
        public const int Speaker = 1;
        public const int Host = 2;
        public const int Organiser = 3;
        public const int Admin = 5;
       
    }
}
