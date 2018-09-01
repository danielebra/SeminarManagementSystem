using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_Management_System.Classes.Users
{
    public class SystemAdmin : User
    {
        public SystemAdmin(int id, string name, string email, string phoneNumber) : base(id, name, email, phoneNumber)
        {
            PrivilegeLevel = Privilege.Admin;
        }
    }
}
