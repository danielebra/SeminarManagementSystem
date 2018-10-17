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
                SqlCommand cmdGetAdmins = new SqlCommand("SELECT * FROM Person p WHERE p.IsAdmin =1", conn);


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

                        seminars.Add(new Seminar(organiser[0], room[0], Utils.GetAllSpeakers(), attendeeList, reader["Title"].ToString(), reader["Description"].ToString(), DateTime.Now, DateTime.Today));
                    }
                }

                //Populate System Admin List
                using (SqlDataReader reader = cmdGetAdmins.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new SystemAdmin((int)reader["ID"], reader["Name"].ToString(), reader["Email"].ToString(), reader["PhoneNumber"].ToString()));
                    }
                }
            }
        }

        /// <summary>
        /// Adds seminar to DB
        /// </summary>
        /// <param name="seminar"></param>
        public static void addSeminar(Seminar seminar)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //instantiate and open new connection using DB Connection string
                conn.ConnectionString = _connectionString;
                conn.Open();

                //Create sql command to insert new seminar into db
                SqlCommand cmdAddSeminar = new SqlCommand("INSERT INTO Seminar(Title, Description, StartDate, EndDate, HostPersonID, OrganiserPersonID, VenueID) VALUES(@title, @description, @startDate, @endDate, null, @organiserPersonId, @venueId);");
                
                using (cmdAddSeminar)
                {
                    //Adds parameter values for above statement
                    cmdAddSeminar.Parameters.AddWithValue("@title", seminar.Title);
                    cmdAddSeminar.Parameters.AddWithValue("@description", seminar.Description);
                    cmdAddSeminar.Parameters.AddWithValue("@startDate", seminar.StartDate);
                    cmdAddSeminar.Parameters.AddWithValue("@endDate", seminar.EndDate);
                    cmdAddSeminar.Parameters.AddWithValue("@organiserPersonId", seminar.Organiser.ID);
                    cmdAddSeminar.Parameters.AddWithValue("@venueId", seminar.Room.ID);
                    cmdAddSeminar.Connection = conn;
                    //Execute query
                    cmdAddSeminar.ExecuteNonQuery();
                }
            }
                seminars.Add(seminar);
        }

        /// <summary>
        /// Adds attendee to DB
        /// </summary>
        public static void addAttendee(SeminarAttendee attendee)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //instantiate and open new connection using DB Connection string
                conn.ConnectionString = _connectionString;
                conn.Open();

                //Create sql command to insert new seminar into db
                SqlCommand cmdAddAttendee = new SqlCommand("INSERT INTO Person(Name, Email, PhoneNumber, IsAdmin, IsHost, IsAttendee, IsSpeaker, IsOrganiser) VALUES(@name, @email, @phoneNumber, 0, 0, 1, 0, 0);");

                using (cmdAddAttendee)
                {
                    //Adds parameter values for above statement
                    cmdAddAttendee.Parameters.AddWithValue("@name", attendee.Name);
                    cmdAddAttendee.Parameters.AddWithValue("@email", attendee.Email);
                    cmdAddAttendee.Parameters.AddWithValue("@phoneNumber", attendee.PhoneNumber);
                    cmdAddAttendee.Connection = conn;
                    //Execute query
                    cmdAddAttendee.ExecuteNonQuery();
                }
            }
            attendee.Role = Authentication.GetRoleFromName(Role.Names.Attendee);
            users.Add(attendee);
        }

        public static void addOrganiser(User seminarOrganiser)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //instantiate and open new connection using DB Connection string
                conn.ConnectionString = _connectionString;
                conn.Open();

                //Create sql command to insert new seminar into db
                SqlCommand cmdAddOrganiser = new SqlCommand("INSERT INTO Person(Name, Email, PhoneNumber, IsAdmin, IsHost, IsAttendee, IsSpeaker, IsOrganiser) VALUES(@name, @email, @phoneNumber, 0, 0, 0, 0, 1);");

                using (cmdAddOrganiser)
                {
                    //Adds parameter values for above statement
                    cmdAddOrganiser.Parameters.AddWithValue("@name", seminarOrganiser.Name);
                    cmdAddOrganiser.Parameters.AddWithValue("@email", seminarOrganiser.Email);
                    cmdAddOrganiser.Parameters.AddWithValue("@phoneNumber", seminarOrganiser.PhoneNumber);
                    cmdAddOrganiser.Connection = conn;
                    //Execute query
                    cmdAddOrganiser.ExecuteNonQuery();
                }
            }
            seminarOrganiser.Role = Authentication.GetRoleFromName(Role.Names.Organiser);
            
        }

        public static void addSpeaker(Speaker seminarSpeaker)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //instantiate and open new connection using DB Connection string
                conn.ConnectionString = _connectionString;
                conn.Open();

                //Create sql command to insert new seminar into db
                SqlCommand cmdAddOrganiser = new SqlCommand("INSERT INTO Person(Name, Email, PhoneNumber, Biography, IsAdmin, IsHost, IsAttendee, IsSpeaker, IsOrganiser) VALUES(@name, @email, @phoneNumber, @biography, 0, 0, 0, 1, 0);");

                using (cmdAddOrganiser)
                {
                    //Adds parameter values for above statement
                    cmdAddOrganiser.Parameters.AddWithValue("@name", seminarSpeaker.Name);
                    cmdAddOrganiser.Parameters.AddWithValue("@email", seminarSpeaker.Email);
                    cmdAddOrganiser.Parameters.AddWithValue("@phoneNumber", seminarSpeaker.PhoneNumber);
                    cmdAddOrganiser.Parameters.AddWithValue("@biography", seminarSpeaker.Biography);
                    cmdAddOrganiser.Connection = conn;
                    //Execute query
                    cmdAddOrganiser.ExecuteNonQuery();
                }
            }
            seminarSpeaker.Role = Authentication.GetRoleFromName(Role.Names.Speaker);
        }

        public static void addAdmin()
        {

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
            var today = DateTime.Now;
            var tomorrow = today.AddDays(1);
            var nextWeek = today.AddDays(7);
            DataInstance.seminars.Add(new Seminar(Utils.GetAllOrganisers()[0], DataInstance.rooms[0], Utils.GetAllSpeakers(),
                attendeeList, "Learning Python", "The Zen of Python", nextWeek, nextWeek.AddHours(3)));
            DataInstance.seminars.Add(new Seminar(Utils.GetAllOrganisers()[0], DataInstance.rooms[0], Utils.GetAllSpeakers(),
                attendeeList, "Learning C#", "Java developers wear glasses because they can't see sharp", tomorrow, tomorrow.AddHours(1)));
            DataInstance.users.Add(new SystemAdmin(0, "Derrick", "derrick@dev.org", "111"));
            DataInstance.users.Add(new Speaker(2, "Mr Paul", "paul@speakers.com", String.Empty, "Biography"));
        }
    }
}
