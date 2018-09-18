using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_Management_System.Classes.Users
{
    [Serializable()]
    public class SeminarAttendee : User
    {
        public SeminarAttendee()
        {
            this.Role = Authentication.GetRoleFromName(Role.Names.Attendee);
        }
        public SeminarAttendee(int id, string name, string email, string phoneNumber) : base(id, name, email, phoneNumber)
        {
            this.Role = Authentication.GetRoleFromName(Role.Names.Attendee);
        }
    }
}
