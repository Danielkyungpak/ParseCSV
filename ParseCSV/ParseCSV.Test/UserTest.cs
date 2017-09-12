using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParseCSV.Console.Classes;
using System.Collections.Generic;

namespace ParseCSV.Test
{
    [TestClass]
    public class UserTest
    {
        //Not sure on what to unit test - not much experience with unit testing
        [TestMethod]
        public void TestFindUsersWithNthRelationshipFirstDegree()
        {
            //Assemble
            User user = new User();
            List<string> friends = new List<string>();
            user.Friends.Add("a001");
            List<User> list = new List<User>();
            list.Add(user);

            List<string> expected = new List<string>();
            expected.Add("a001");

            //Act
            List<string> actualResult = new List<string>();
            actualResult = user.FindUsersWithNthRelationship(1, list);

            //Assert
            Assert.AreEqual(expected, actualResult);

        }
    }
}
