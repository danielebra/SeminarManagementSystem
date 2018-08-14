using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_Management_System.Classes.Users
{ 
    abstract public class User
    {
        public string Name { get; set; }
        public User (string name)
        {
            this.Name = name;
        }
    }
}
