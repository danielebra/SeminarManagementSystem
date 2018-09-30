using System;
using System.Collections.Generic;
using System.Data;
using Seminar_Management_System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seminar_Management_System.Classes.Users;
using Seminar_Management_System.Classes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using Seminar_Management_System.Forms;

namespace Seminar_Management_System
{
    // This is used to manage the state of the program
    static class DataInstance
    {
        public static CreateFilter createFilterInterface = new CreateFilter();
        // All the currently open ViewSeminar windows
        public static List<ViewSeminar> seminarInterfaceWindows = new List<ViewSeminar>();
        // All the rooms
        public static List<Room> rooms = new List<Room>();
        // All the users
        public static ObservableCollection<User> users = new ObservableCollection<User>();
        // All the seminars
        public static ObservableCollection<Seminar> seminars = new ObservableCollection<Seminar>();
        // Connection string for connecting to AWS database
        public static string _connectionString;
        // Event that fires when the logged in user changes
        public static event EventHandler LoggedInUserChanged;
        private static User _loggedInUser;
        public static User LoggedInUser
        {
            get { return _loggedInUser; }
            set
            {
                _loggedInUser = value;
                if (LoggedInUserChanged != null)
                    LoggedInUserChanged(null, EventArgs.Empty);
            }
        }

        // Instance of the Main interface
        public static Main mainInstance;

        // Load data from AWS database
        public static void populateWithData()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //instantiate and open new connection using DB Connection string
                conn.ConnectionString = _connectionString;
                conn.Open();

                //Create commands
                SqlCommand cmdGetOrganisers = new SqlCommand("SELECT * FROM Person p WHERE p.IsOrganiser = 1", conn);
                SqlCommand cmdGetRooms = new SqlCommand("SELECT * FROM Venue", conn);
                SqlCommand cmdGetSpeakers = new SqlCommand("SELECT * FROM Person p WHERE p.IsSpeaker = 1", conn);
                SqlCommand cmdGetAttendees = new SqlCommand("SELECT * FROM Person p WHERE p.IsAttendee = 1", conn);
                SqlCommand cmdGetSeminars = new SqlCommand("SELECT * FROM Seminar", conn);


                //Populate Organiser List
                using (SqlDataReader reader = cmdGetOrganisers.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new SeminarOrganiser((int)reader["ID"], reader["Name"].ToString(), reader["Email"].ToString(), reader["PhoneNumber"].ToString()));
                    }
                }

                //Populate Rooms List
                using (SqlDataReader reader = cmdGetRooms.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rooms.Add(new Room((int)reader["ID"], reader["Name"].ToString(), reader["Location"].ToString(), (int)reader["Capacity"]));
                    }
                }

                //Populate Speakers List
                using (SqlDataReader reader = cmdGetSpeakers.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new Speaker((int)reader["ID"], reader["Name"].ToString(), reader["Email"].ToString(), reader["PhoneNumber"].ToString(), reader["Biography"].ToString()));
                    }
                }

                //Populate Attendees List
                BindingList<SeminarAttendee> attendeeList = new BindingList<SeminarAttendee>();
                using (SqlDataReader reader = cmdGetAttendees.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        attendeeList.Add(new SeminarAttendee((int)reader["ID"], reader["Name"].ToString(), reader["Email"].ToString(), reader["PhoneNumber"].ToString()));
                    }
                }

                //Populate Seminars List
                using (SqlDataReader reader = cmdGetSeminars.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var organiser = Utils.GetAllOrganisers().Where(o => o.ID == (int)reader["OrganiserPersonID"]).ToList();
                        var room = rooms.Where(r => r.ID == (int)reader["VenueID"]).ToList();

                        seminars.Add(new Seminar(organiser[0], room[0], Utils.GetAllSpeakers(), attendeeList, reader["Label"].ToString(), reader["Description"].ToString(), DateTime.Now, DateTime.Today));
                    }
                }
            }
        }

        // Load mock data into memory
        public static void populateWithMockData()
        {
            DataInstance.users.Add(new SeminarOrganiser(0, "Bob", "bob@staff.com", "111"));
            DataInstance.users.Add(new SeminarOrganiser(1, "Tim", "tim@staff.com", "222"));


            DataInstance.rooms.Add(new Room(0, "Building 11", "Ultimo", 100));
            DataInstance.rooms.Add(new Room(1, "Building 10", "Ultimo", 200));
            
            DataInstance.users.Add(new Speaker(0, "Dr James", "james@speakers.com", String.Empty, "This is a biography..."));
            DataInstance.users.Add(new Speaker(1, "Dr Paul", "paul@speakers.com", String.Empty, "This is a biography..."));


            BindingList<SeminarAttendee> attendeeList = new BindingList<SeminarAttendee>();
            attendeeList.Add(new SeminarAttendee(0, "Jason", "jason@attendee.com", "911"));
            attendeeList.Add(new SeminarAttendee(1, "Tyrone", "tyrone@attendee.com", "912"));

            DataInstance.seminars.Add(new Seminar(Utils.GetAllOrganisers()[0], DataInstance.rooms[0], Utils.GetAllSpeakers(),
                attendeeList, "Learning Python", "The Zen of Python", DateTime.Now, DateTime.Today));
            DataInstance.seminars.Add(new Seminar(Utils.GetAllOrganisers()[0], DataInstance.rooms[0], Utils.GetAllSpeakers(),
                attendeeList, "Learning C#", "Java developers wear glasses because they can't see sharp", DateTime.Now, DateTime.Today));

            DataInstance.users.Add(new SystemAdmin(0, "Derrick", "derrick@dev.org", "111"));
            DataInstance.users.Add(new Speaker(2, "Mr Paul", "paul@speakers.com", String.Empty, "Biography"));
        }
    }
}
