using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_Management_System.Classes.Users
{
    public class SeminarAttendee : User
    {
        public string Email { get; set; }

        public SeminarAttendee(int id, string name, string email) : base(id, name)
        {         
            this.Email = email;
        }
    }
}
