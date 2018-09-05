using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_Management_System.Classes
{
    static class Authentication
    {
        public static List<Role> Roles = new List<Role>()
        {
            { new Role(Role.Names.Attendee, 0) },
            { new Role(Role.Names.Speaker, 1) },
            { new Role(Role.Names.Host, 2) },
            { new Role(Role.Names.Organiser, 3) },
            { new Role(Role.Names.Admin, 5) }
        };
        public static Role GetRoleFromName(string name)
        {
            return Roles.Where(r => r.Name == name).First();
        }
        public static Role GetRoleFromPrivilegeLevel(int privilege)
        {
            return Roles.Where(r => r.Privilege == privilege).First();
        }
        public static int GetPrivilegeFromRoleName(string name)
        {
            return Roles.Where(r => r.Name == name).First().Privilege;
        }
    }
}
