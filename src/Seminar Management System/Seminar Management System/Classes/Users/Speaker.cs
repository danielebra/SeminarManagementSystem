using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_Management_System.Classes.Users
{
    public class Speaker : User
    {
        public string Biography { get; set; }

        public Speaker(int id, string name, string biography) : base(id, name)
        {
            this.Biography = biography;
        }
    }
}
