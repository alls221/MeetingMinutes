using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace MeetingMinutes
{
    class Program
    {
        static void Title () // this will pring the program title
        {
            Console.WriteLine("***Meeting Minutes Management Software***\n\n\n");
        }

        static void Menu () // contians and prints the menu
        {
            string[] menu = { "1- Create Meeting", "2- View Team", "3- Exit" };
            for (int i = 0; i < menu.Length; i++)
            {
                Console.WriteLine(menu[i]);
            }
        }
        static void ViewTeam () // this will contian the "View team section of the program
        {
            Console.WriteLine("*View Team*\n\n\n");
            string[] teamMenu = { "1- Marketing Team", "2-Administration Team", "3- Sales Team", "4- View All", "5-Exit" };
            for (int i = 0; i < teamMenu.Length; i++)
            {
                Console.WriteLine(teamMenu[i]);
            }
           
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Dictionary<string, string> teamMembers = new Dictionary<string, string>();
                teamMembers.Add( "Bob Builder","Marketing Team");
                teamMembers.Add("Sally Wright","Marketing Team");
                teamMembers.Add("Franny Franks","Marketing Team");
                teamMembers.Add("Mallory Michaels","Administration Team");
                teamMembers.Add("Steve Sal","Administation Team");
                teamMembers.Add("Cindy Carson","Administration Team");
                teamMembers.Add("Amy Able","Sales Team");
                teamMembers.Add("Crystal Cambridge","Sales Team");
                teamMembers.Add("Bernie Brothers","Sales Team");
                Title();
                Menu();
                Console.WriteLine("Select an option");
                int selection;
                while (true)
                {
                    string choice = Console.ReadLine();
                    bool menuResult = int.TryParse(choice, out selection);
                    if (menuResult == true)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Not a valid option, Please try again");
                        continue;
                    }
                }

                if (selection == 3)
                {
                    Console.Clear();
                    Title();
                    Thread.Sleep(1000);
                    Console.WriteLine("Goodbye");
                    Thread.Sleep(1000);
                    break;
                }
                else
                {
                    switch (selection)
                    {
                        case 1:
                            Console.Clear();
                            Title();
                            Console.WriteLine("*Create Meeting*\n\n\n");
                            Console.WriteLine("What is the date in MMDDYY format");
                            string date = (Console.ReadLine());
                            string filename = ("minutes" + date + ".txt");
                            StreamWriter meetingWriter = new StreamWriter(filename);
                            string[] header = { "Ashley's Company", "123 Big Bird Lane \n Boulder, CO 44444 ", "\"Meeting Minutes\"" };
                            for (int i = 0; i < header.Length; i++)
                            {
                                meetingWriter.WriteLine(header[i]);
                            }
                            Console.WriteLine("Enter name of Team member creating notes");
                            string name = Console.ReadLine();
                            meetingWriter.WriteLine("Recorded by: " + name);

                            Console.WriteLine("Enter the name of the team member leading the meeting");
                            string leader = Console.ReadLine();
                            meetingWriter.WriteLine("Lead by: " + leader);

                            Console.WriteLine("What type of Meeting?");
                            string[] meetingType = { "1- Marketing Team", "2-Administration Team", "3- Sales Team", "4- All teams" };
                            for (int i = 0; i < meetingType.Length; i++)
                            {
                                Console.WriteLine(meetingType[i]);
                            }
                            int selector = int.Parse(Console.ReadLine());
                            switch (selector)// to chose what meeting type
                            {
                                case 1:
                                    meetingWriter.WriteLine("Marketing Team Meeting");
                                    break;
                                case 2:
                                    meetingWriter.WriteLine("Administration Team Meeting");
                                    break;
                                case 3:
                                    meetingWriter.WriteLine("Sales Team meeting");
                                    break;
                                case 4:
                                    meetingWriter.WriteLine("All Teams meeting");
                                    break;
                            }
                            while (true)
                            {
                                Console.WriteLine("What is the meeting Topic?");
                                string topic = Console.ReadLine();
                                meetingWriter.WriteLine("Topic:" + topic);
                                Console.WriteLine("Enter a summary of the topic");
                                string summary = Console.ReadLine();
                                meetingWriter.WriteLine("Summary:" + summary);
                                Console.WriteLine("Would you like to Enter another topic?");
                                Console.WriteLine("Enter Y for Yes or N for No");
                                string answer = Console.ReadLine();
                                if (answer == "n" || answer == "N")
                                {
                                    meetingWriter.Close();
                                    Console.WriteLine(topic);
                                    Console.WriteLine(summary);
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            Console.Clear();
                            Title();
                            break;
                        case 2:
                            Console.Clear();
                            Title();
                            ViewTeam();
                            Console.WriteLine("Enter A Team to view");
                            string team = Console.ReadLine();
                            int teamSelect;
                            bool teamResult = int.TryParse(team, out teamSelect);
                            if (teamResult == true)
                            {
                                switch (teamSelect)
                                {
                                    case 1:// marketing
                                        Console.Clear();
                                        Title();
                                        Console.WriteLine("Bob Builder");
                                        Console.WriteLine("Sally Wright");
                                        Console.WriteLine("Franny Franks");
                                        break;
                                    case 2://administration
                                        Console.Clear();
                                        Title();
                                        Console.WriteLine("Mallory Michaels");
                                        Console.WriteLine("Steve Sal");
                                        Console.WriteLine("Cindy Carson");
                                        break;
                                    case 3://sales
                                        Console.Clear();
                                        Title();
                                        Console.WriteLine("Amy Able");
                                        Console.WriteLine("Crystal Cambridge");
                                        Console.WriteLine("Bernie Brothers");
                                        break;
                                    case 4://view All
                                        Console.Clear();
                                        Title();
                                        foreach (KeyValuePair<string,string> pair in teamMembers)
                                        {
                                            Console.WriteLine(pair.Key+", "+pair.Value);
                                        }
                                        break;
                                    case 5:

                                        Console.Clear();
                                        Title();
                                        Thread.Sleep(1000);
                                        Console.WriteLine("Returning to Main Menu...");
                                        Thread.Sleep(1000);
                                        break;
                                }
                            }

                            break;
                        default:
                            Console.Clear();
                            Title();
                            Console.WriteLine("Error: Invalid option, Please try again");
                            break;

                    }
                }
            }
        }
    }
}
