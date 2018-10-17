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
                SqlCommand cmdGetSeminars = new SqlCommand("select Seminar.ID, Seminar.Title, Seminar.Description, Seminar.StartDate, Seminar.EndDate, Seminar.HostPersonID, Seminar.OrganiserPersonID, Seminar.VenueID, sum(CASE WHEN SeminarAttendees.Status = 'Going' THEN 1 ELSE 0 END) as 'AttendeesGoing', sum(CASE WHEN SeminarAttendees.Status = 'Interested' THEN 1 ELSE 0 END) as 'AttendeesInterested' from Seminar left join SeminarAttendees on Seminar.ID = SeminarAttendees.SeminarID group by Seminar.ID, Seminar.Title, Seminar.Description, Seminar.StartDate, Seminar.EndDate, Seminar.HostPersonID, Seminar.OrganiserPersonID, Seminar.VenueID; ", conn);
                SqlCommand cmdGetAdmins = new SqlCommand("SELECT * FROM Person p WHERE p.IsAdmin =1", conn);
                SqlCommand cmdGetHosts = new SqlCommand("SELECT * FROM Person p WHERE p.IsHost =1", conn);
                


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

                        seminars.Add(new Seminar((int)reader["ID"], organiser[0], room[0], Utils.GetAllSpeakers(), attendeeList, reader["Title"].ToString(), reader["Description"].ToString(), (DateTime)reader["StartDate"], (DateTime)reader["EndDate"], (int)reader["AttendeesGoing"], (int)reader["AttendeesInterested"]));
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

                //Populate Seminar Host List
                using (SqlDataReader reader = cmdGetHosts.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new SeminarHost((int)reader["ID"], reader["Name"].ToString(), reader["Email"].ToString(), reader["PhoneNumber"].ToString()));
                    }
                }
            }
        }

        public static BindingList<SeminarAttendee> getSeminarAttendees(Seminar seminar)
        {
            BindingList<SeminarAttendee> seminarAttendees = new BindingList<SeminarAttendee>();
            using (SqlConnection conn = new SqlConnection())
            {
                //instantiate and open new connection using DB Connection string
                conn.ConnectionString = _connectionString;
                conn.Open();

                SqlCommand cmdGetSeminarAttendees = new SqlCommand("select Person.ID, Person.Name, Person.Email, Person.PhoneNumber, SeminarAttendees.Status from Person left join SeminarAttendees on Person.ID = SeminarAttendees.AttendeePersonID where SeminarAttendees.SeminarID = " + seminar.ID, conn);

                using (SqlDataReader reader = cmdGetSeminarAttendees.ExecuteReader())
                    while (reader.Read())
                        seminarAttendees.Add(new SeminarAttendee((int)reader["ID"], reader["Name"].ToString(), reader["Email"].ToString(), reader["PhoneNumber"].ToString(), reader["Status"].ToString()));
                return seminarAttendees;
            }
        }


        #region Add to Database
        /// <summary>
        /// Adds a seminar
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

        public static void addSeminarAttendees(Seminar seminar, SeminarAttendee attendee)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //instantiate and open new connection using DB Connection string
                conn.ConnectionString = _connectionString;
                conn.Open();

                //Create sql command to insert new seminar into db
                SqlCommand cmdAddSeminarAttendee = new SqlCommand("insert into SeminarAttendees(SeminarID, AttendeePersonID, Status) values(@seminarId, @attendeeId, @attendeeStatus)");

                using (cmdAddSeminarAttendee)
                {
                    //Adds parameter values for above statement
                    cmdAddSeminarAttendee.Parameters.AddWithValue("@seminarId", seminar.ID);
                    cmdAddSeminarAttendee.Parameters.AddWithValue("@attendeeId", attendee.ID);
                    cmdAddSeminarAttendee.Parameters.AddWithValue("@attendeeStatus", attendee.Status);
                    cmdAddSeminarAttendee.Connection = conn;
                    //Execute query
                    cmdAddSeminarAttendee.ExecuteNonQuery();
                }
            }
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

        /// <summary>
        /// Adds a seminar organiser
        /// </summary>
        /// <param name="seminarOrganiser"></param>
        public static void addOrganiser(SeminarOrganiser seminarOrganiser)
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

        /// <summary>
        /// Adds a seminar speaker
        /// </summary>
        /// <param name="seminarSpeaker"></param>
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

        /// <summary>
        /// Adds a system admin
        /// </summary>
        /// <param name="systemAdmin"></param>
        public static void addAdmin(SystemAdmin systemAdmin)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //instantiate and open new connection using DB Connection string
                conn.ConnectionString = _connectionString;
                conn.Open();

                //Create sql command to insert new seminar into db
                SqlCommand cmdAddOrganiser = new SqlCommand("INSERT INTO Person(Name, Email, PhoneNumber, IsAdmin, IsHost, IsAttendee, IsSpeaker, IsOrganiser) VALUES(@name, @email, @phoneNumber, 1, 0, 0, 0, 0);");

                using (cmdAddOrganiser)
                {
                    //Adds parameter values for above statement
                    cmdAddOrganiser.Parameters.AddWithValue("@name", systemAdmin.Name);
                    cmdAddOrganiser.Parameters.AddWithValue("@email", systemAdmin.Email);
                    cmdAddOrganiser.Parameters.AddWithValue("@phoneNumber", systemAdmin.PhoneNumber);
                    cmdAddOrganiser.Connection = conn;
                    //Execute query
                    cmdAddOrganiser.ExecuteNonQuery();
                }
            }
            systemAdmin.Role = Authentication.GetRoleFromName(Role.Names.Admin);
        }

        /// <summary>
        /// Adds a seminar host
        /// </summary>
        /// <param name="seminarHost"></param>
        public static void addHost(SeminarHost seminarHost)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //instantiate and open new connection using DB Connection string
                conn.ConnectionString = _connectionString;
                conn.Open();

                //Create sql command to insert new seminar into db
                SqlCommand cmdAddOrganiser = new SqlCommand("INSERT INTO Person(Name, Email, PhoneNumber, IsAdmin, IsHost, IsAttendee, IsSpeaker, IsOrganiser) VALUES(@name, @email, @phoneNumber, 0, 1, 0, 0, 0);");

                using (cmdAddOrganiser)
                {
                    //Adds parameter values for above statement
                    cmdAddOrganiser.Parameters.AddWithValue("@name", seminarHost.Name);
                    cmdAddOrganiser.Parameters.AddWithValue("@email", seminarHost.Email);
                    cmdAddOrganiser.Parameters.AddWithValue("@phoneNumber", seminarHost.PhoneNumber);
                    cmdAddOrganiser.Connection = conn;
                    //Execute query
                    cmdAddOrganiser.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region Edit in Database
        public static void editSeminar(Seminar seminar)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //instantiate and open new connection using DB Connection string
                conn.ConnectionString = _connectionString;
                conn.Open();

                //Create sql command to insert new seminar into db
                SqlCommand cmdEditSeminar = new SqlCommand("UPDATE Seminar SET Title = @title, Description = @description, StartDate = @startDate, EndDate=@endDate, HostPersonID=null, OrganiserPersonID=@organiserPersonId, VenueID=@venueId WHERE ID = @seminarId");

                using (cmdEditSeminar)
                {
                    //Adds parameter values for above statement
                    cmdEditSeminar.Parameters.AddWithValue("@seminarId", seminar.ID);
                    cmdEditSeminar.Parameters.AddWithValue("@title", seminar.Title);
                    cmdEditSeminar.Parameters.AddWithValue("@description", seminar.Description);
                    cmdEditSeminar.Parameters.AddWithValue("@startDate", seminar.StartDate);
                    cmdEditSeminar.Parameters.AddWithValue("@endDate", seminar.EndDate);
                    cmdEditSeminar.Parameters.AddWithValue("@organiserPersonId", seminar.Organiser.ID);
                    cmdEditSeminar.Parameters.AddWithValue("@venueId", seminar.Room.ID);
                    cmdEditSeminar.Connection = conn;
                    //Execute query
                    cmdEditSeminar.ExecuteNonQuery();
                }
            }
        }

        public static void editAttendee(User attendee)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //instantiate and open new connection using DB Connection string
                conn.ConnectionString = _connectionString;
                conn.Open();

                //Create sql command to insert new seminar into db
                SqlCommand cmdEditAttendee = new SqlCommand("UPDATE Person SET Name= @name, Email=@email, PhoneNumber=@phoneNumber, IsAdmin=0, IsHost=0, IsAttendee=1, IsSpeaker=0, IsOrganiser=0 WHERE ID = @Id");

                using (cmdEditAttendee)
                {
                    //Adds parameter values for above statement
                    cmdEditAttendee.Parameters.AddWithValue("@Id", attendee.ID);
                    cmdEditAttendee.Parameters.AddWithValue("@name", attendee.Name);
                    cmdEditAttendee.Parameters.AddWithValue("@email", attendee.Email);
                    cmdEditAttendee.Parameters.AddWithValue("@phoneNumber", attendee.PhoneNumber);
                    cmdEditAttendee.Connection = conn;
                    //Execute query
                    cmdEditAttendee.ExecuteNonQuery();
                }
            }
        }

        public static void editOrganiser(User seminarOrganiser)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //instantiate and open new connection using DB Connection string
                conn.ConnectionString = _connectionString;
                conn.Open();

                //Create sql command to insert new seminar into db
                SqlCommand cmdEditOrganiser = new SqlCommand("UPDATE Person SET Name= @name, Email=@email, PhoneNumber=@phoneNumber, IsAdmin=0, IsHost=0, IsAttendee=0, IsSpeaker=0, IsOrganiser=1 WHERE ID = @Id");

                using (cmdEditOrganiser)
                {
                    //Adds parameter values for above statement
                    cmdEditOrganiser.Parameters.AddWithValue("@Id", seminarOrganiser.ID);
                    cmdEditOrganiser.Parameters.AddWithValue("@name", seminarOrganiser.Name);
                    cmdEditOrganiser.Parameters.AddWithValue("@email", seminarOrganiser.Email);
                    cmdEditOrganiser.Parameters.AddWithValue("@phoneNumber", seminarOrganiser.PhoneNumber);
                    cmdEditOrganiser.Connection = conn;
                    //Execute query
                    cmdEditOrganiser.ExecuteNonQuery();
                }
            }
        }

        public static void editSpeaker(Speaker speaker)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //instantiate and open new connection using DB Connection string
                conn.ConnectionString = _connectionString;
                conn.Open();

                //Create sql command to insert new seminar into db
                SqlCommand cmdEditSpeaker = new SqlCommand("UPDATE Person SET Name= @name, Email=@email, PhoneNumber=@phoneNumber, Biography=@biography, IsAdmin=0, IsHost=0, IsAttendee=0, IsSpeaker=1, IsOrganiser=0 WHERE ID = @Id");

                using (cmdEditSpeaker)
                {
                    //Adds parameter values for above statement
                    cmdEditSpeaker.Parameters.AddWithValue("@Id", speaker.ID);
                    cmdEditSpeaker.Parameters.AddWithValue("@name", speaker.Name);
                    cmdEditSpeaker.Parameters.AddWithValue("@email", speaker.Email);
                    cmdEditSpeaker.Parameters.AddWithValue("@phoneNumber", speaker.PhoneNumber);
                    cmdEditSpeaker.Parameters.AddWithValue("@biography", speaker.Biography);
                    cmdEditSpeaker.Connection = conn;
                    //Execute query
                    cmdEditSpeaker.ExecuteNonQuery();
                }
            }
        }

        public static void editAdmin(User admin)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //instantiate and open new connection using DB Connection string
                conn.ConnectionString = _connectionString;
                conn.Open();

                //Create sql command to insert new seminar into db
                SqlCommand cmdEditAdmin = new SqlCommand("UPDATE Person SET Name= @name, Email=@email, PhoneNumber=@phoneNumber, IsAdmin=1, IsHost=0, IsAttendee=0, IsSpeaker=0, IsOrganiser=0 WHERE ID = @Id");

                using (cmdEditAdmin)
                {
                    //Adds parameter values for above statement
                    cmdEditAdmin.Parameters.AddWithValue("@Id", admin.ID);
                    cmdEditAdmin.Parameters.AddWithValue("@name", admin.Name);
                    cmdEditAdmin.Parameters.AddWithValue("@email", admin.Email);
                    cmdEditAdmin.Parameters.AddWithValue("@phoneNumber", admin.PhoneNumber);
                    cmdEditAdmin.Connection = conn;
                    //Execute query
                    cmdEditAdmin.ExecuteNonQuery();
                }
            }
        }

        public static void editHost(User host)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //instantiate and open new connection using DB Connection string
                conn.ConnectionString = _connectionString;
                conn.Open();

                //Create sql command to insert new seminar into db
                SqlCommand cmdEditHost = new SqlCommand("UPDATE Person SET Name= @name, Email=@email, PhoneNumber=@phoneNumber, IsAdmin=0, IsHost=1, IsAttendee=0, IsSpeaker=0, IsOrganiser=0 WHERE ID = @Id");

                using (cmdEditHost)
                {
                    //Adds parameter values for above statement
                    cmdEditHost.Parameters.AddWithValue("@Id", host.ID);
                    cmdEditHost.Parameters.AddWithValue("@name", host.Name);
                    cmdEditHost.Parameters.AddWithValue("@email", host.Email);
                    cmdEditHost.Parameters.AddWithValue("@phoneNumber", host.PhoneNumber);
                    cmdEditHost.Connection = conn;
                    //Execute query
                    cmdEditHost.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region Delete in Database

        /// <summary>
        /// Deletes a seminar
        /// </summary>
        /// <param name="seminar"></param>
        public static void deleteSeminar(Seminar seminar)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //instantiate and open new connection using DB Connection string
                conn.ConnectionString = _connectionString;
                conn.Open();

                //Create sql command to insert new seminar into db
                SqlCommand cmdDeleteSeminar = new SqlCommand("DELETE FROM Seminar WHERE ID = @seminarId;");

                using (cmdDeleteSeminar)
                {
                    cmdDeleteSeminar.Parameters.AddWithValue("@seminarId", seminar.ID);
                    cmdDeleteSeminar.Connection = conn;
                    //Execute query
                    cmdDeleteSeminar.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletes an attendee
        /// </summary>
        /// <param name="attendee"></param>
        public static void deleteAttendee(SeminarAttendee attendee)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //instantiate and open new connection using DB Connection string
                conn.ConnectionString = _connectionString;
                conn.Open();

                //Create sql command to insert new seminar into db
                SqlCommand cmdDeleteAttendee = new SqlCommand("DELETE FROM Person WHERE ID = @attendeeId;");

                using (cmdDeleteAttendee)
                {
                    cmdDeleteAttendee.Parameters.AddWithValue("@attendeeId", attendee.ID);
                    cmdDeleteAttendee.Connection = conn;
                    //Execute query
                    cmdDeleteAttendee.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletes a seminar organiser
        /// </summary>
        /// <param name="organiser"></param>
        public static void deleteOrganiser(SeminarOrganiser organiser)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //instantiate and open new connection using DB Connection string
                conn.ConnectionString = _connectionString;
                conn.Open();

                //Create sql command to insert new seminar into db
                SqlCommand cmdDeleteOrganiser = new SqlCommand("DELETE FROM Person WHERE ID = @organiserId;");

                using (cmdDeleteOrganiser)
                {
                    cmdDeleteOrganiser.Parameters.AddWithValue("@organiserId", organiser.ID);
                    cmdDeleteOrganiser.Connection = conn;
                    //Execute query
                    cmdDeleteOrganiser.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletes a seminar speaker
        /// </summary>
        /// <param name="speaker"></param>
        public static void deleteSpeaker(Speaker speaker)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //instantiate and open new connection using DB Connection string
                conn.ConnectionString = _connectionString;
                conn.Open();

                //Create sql command to insert new seminar into db
                SqlCommand cmdDeleteSpeaker = new SqlCommand("DELETE FROM Person WHERE ID = @speakerId;");

                using (cmdDeleteSpeaker)
                {
                    cmdDeleteSpeaker.Parameters.AddWithValue("@speakerId", speaker.ID);
                    cmdDeleteSpeaker.Connection = conn;
                    //Execute query
                    cmdDeleteSpeaker.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletes a system admin
        /// </summary>
        /// <param name="systemAdmin"></param>
        public static void deleteAdmin(SystemAdmin systemAdmin)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //instantiate and open new connection using DB Connection string
                conn.ConnectionString = _connectionString;
                conn.Open();

                //Create sql command to insert new seminar into db
                SqlCommand cmdDeleteAdmin = new SqlCommand("DELETE FROM Person WHERE ID = @adminId;");

                using (cmdDeleteAdmin)
                {
                    cmdDeleteAdmin.Parameters.AddWithValue("@adminId", systemAdmin.ID);
                    cmdDeleteAdmin.Connection = conn;
                    //Execute query
                    cmdDeleteAdmin.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletes a seminar host
        /// </summary>
        /// <param name="host"></param>
        public static void deleteHost(SeminarHost host)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //instantiate and open new connection using DB Connection string
                conn.ConnectionString = _connectionString;
                conn.Open();

                //Create sql command to insert new seminar into db
                SqlCommand cmdDeleteHost = new SqlCommand("DELETE FROM Person WHERE ID = @hostId;");

                using (cmdDeleteHost)
                {
                    cmdDeleteHost.Parameters.AddWithValue("@hostId", host.ID);
                    cmdDeleteHost.Connection = conn;
                    //Execute query
                    cmdDeleteHost.ExecuteNonQuery();
                }
            }
        }
        #endregion

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
            DataInstance.seminars.Add(new Seminar(0, Utils.GetAllOrganisers()[0], DataInstance.rooms[0], Utils.GetAllSpeakers(),
                attendeeList, "Learning Python", "The Zen of Python", nextWeek, nextWeek.AddHours(3),attendeeList.Count(), attendeeList.Count()));
            DataInstance.seminars.Add(new Seminar(1, Utils.GetAllOrganisers()[0], DataInstance.rooms[0], Utils.GetAllSpeakers(),
                attendeeList, "Learning C#", "Java developers wear glasses because they can't see sharp", tomorrow, tomorrow.AddHours(1), attendeeList.Count(), attendeeList.Count()));
            DataInstance.users.Add(new SystemAdmin(0, "Derrick", "derrick@dev.org", "111"));
            DataInstance.users.Add(new Speaker(2, "Mr Paul", "paul@speakers.com", String.Empty, "Biography"));
        }
    }
}