using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_Management_System.Classes.Users
{ 
    [Serializable()]
    abstract public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public User (int id, string name, string email, string phoneNumber)
        {
            this.ID = id;
            this.Name = name;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
        }
        
    }
}
