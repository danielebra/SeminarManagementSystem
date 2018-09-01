using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_Management_System.Classes.Users
{
    public class SeminarOrganiser : User
    {
        public SeminarOrganiser(int id, string name, string email, string phoneNumber) : base(id, name, email, phoneNumber)
        {
            this.PrivilegeLevel = Privilege.Organiser;
        }
    }
}
