using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseCSV.Console.Classes
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Friends { get; set; }


        public List<string> FindUsersWithNthRelationship(int degree, List<User> list)
        {
            /*
            * degree [type int] - if all second degree relationships are desired a 2 will
            be passed in
            * return string[] - an array of type string which contains all Id's of users
            who are related to this user based on the given degree
             */
            List<string> friends = new List<string>();
            if (degree == 1)
            {
                friends = Friends;
                return friends;
            }
            else if (degree == 2)
            {
                for (int j = 0; j < Friends.Count; j++)
                {
                    var friend = Friends[j];
                    var user = list.Find(u => u.Id == friend);
                    for (int l = 0; l < user.Friends.Count; l++)
                    {
                        friends.Add(user.Friends[l]);
                    }
                }
                return friends;

            }
            else
            {
                return friends;
            }
        }
    }
}
