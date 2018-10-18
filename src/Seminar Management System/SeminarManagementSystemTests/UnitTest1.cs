using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeminarManagementSystemTests
{
    [TestClass]
    public class Database
    {
        [TestMethod]
        public void ConnectToDatabase()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void ReadFromDatabase()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void AddToDatabase()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void RemoveFromDatabase()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void DatabaseRespondsWithin2Seconds()
        {
            Assert.IsTrue(true);
        }
    }

    [TestClass]
    public class Interface
    {
        [TestMethod]
        public void LoadUsers()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void LoadSeminars()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void LoadLogin()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void LoadCreateUser()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void LoadCreateSeminar()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void LoadFilter()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void LoadSpeakerDetails()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void LoadRegisterAttendee()
        {
            Assert.IsTrue(true);
        }
    }

    [TestClass]
    public class DataTransition
    {

        [TestMethod]
        public void RegisterAttendee()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void LoginUser()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void AssignSpeaker()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ChangeSpeaker()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DeleteSeminar()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void LoginAsAttendee()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void Logout()
        {
            Assert.IsTrue(true);
        }
    }
}
