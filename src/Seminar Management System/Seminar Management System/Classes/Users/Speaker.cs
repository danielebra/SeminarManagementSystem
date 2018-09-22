using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_Management_System.Classes.Users
{
    public class Speaker : User
    {
        // A Speaker has an additional property, Biograhy
        public string Biography { get; set; }

        public Speaker()
        {
            this.Role = Authentication.GetRoleFromName(Role.Names.Speaker);
        }
        public Speaker(int id, string name, string email, string phoneNumber, string biography) : base(id, name, email, phoneNumber)
        {
            this.Biography = biography;
            this.Role = Authentication.GetRoleFromName(Role.Names.Speaker);
        }
    }
}
