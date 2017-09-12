using ParseCSV.Console.Classes;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseCSV.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TextFieldParser parser = new TextFieldParser(@"c:\users\daniel\documents\visual studio 2017\Projects\ParseCSV Coding Test\ParseCSV.Console\CSV\SocialNetwork.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                var headers = parser.ReadLine(); //Read First Line
                List<User> users = new List<User>();

                //Parsing excel sheet minus the top row and storing it into users List
                while (!parser.EndOfData)
                {
                    //Process row
                    var line = parser.ReadLine();
                    var values = line.Split(',');
                    User user = new User();
                    user.Id = values[0];
                    user.FirstName = values[1];
                    user.LastName = values[2];
                    var friendValues = values[3].Split(';');
                    List<string> friends = new List<string>();
                    foreach (var friend in friendValues)
                    {
                        friends.Add(friend);
                    }
                    user.Friends = friends;

                    users.Add(user);
                }

                //Instantiating the Alison User
                User userAlison = new User();

                //Finding the Alison User in the List of Parsed Users
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].FirstName == "Alison" && users[i].LastName == "Hodges")
                    {
                        userAlison = users[i];
                    }

                }

                //User Input
                System.Console.WriteLine("What degree of friendship do you want to look up for Alison Hodges? (1 or 2)");
                var degree = System.Console.ReadLine();

                //Suffix Logic 
                string degreeSuffix = "th";
                if (Int32.Parse(degree) == 1)
                {
                    degreeSuffix = "st";
                }
                if (Int32.Parse(degree) == 2)
                {
                    degreeSuffix = "nd";
                }

                //Implementation of Method to find users with Nth Relationship
                var product = userAlison.FindUsersWithNthRelationship(Int32.Parse(degree), users);


                //Consolidating List to a string and outputting to console
                string output = string.Join(",", product);
                System.Console.WriteLine("This is Alison Hodges " + degree + degreeSuffix + " degree of friends with duplicates");
                System.Console.WriteLine(output);

            }
        }
    }
}
