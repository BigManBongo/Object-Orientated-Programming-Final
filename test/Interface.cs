using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicSwimming
{
    public class Interface
    {
        Competition competition = new Competition();
        public void DisplayMenu()
        {
            competition.LoadFromFile(); //calls loadfromfile on boot
            while (true)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Add A New Competitor");
                Console.WriteLine("2. Delete A Competitor");
                Console.WriteLine("3. Clear All Competitors");
                Console.WriteLine("4. Print Competitors");
                Console.WriteLine("5. Show All Competitors By Event");
                Console.WriteLine("6. Load From File");
                Console.WriteLine("7. Save To File");
                Console.WriteLine("8. Display Competitor Index");
                Console.WriteLine("9. Sort Competitors By Age");
                Console.WriteLine("10. Display Winners");
                Console.WriteLine("11. Display Qualifiers");
                Console.WriteLine("12. Exit");

                Console.WriteLine("\r\nPlease select one of the above options: ");
                string choice = Console.ReadLine();

                switch (choice) //acts according to the number input by the user
                {
                    case "1":
                        AddCompetitor();
                        break;
                    case "2":
                        Console.WriteLine("Enter the number of the competitor you wish to have deleted");
                        int CompNo = Convert.ToInt32(Console.ReadLine());
                        competition.DeleteCompetitor(CompNo);
                        break;
                    case "3":
                        competition.ClearAll();
                        break;
                    case "4":
                        competition.printComp();
                        break;
                    case "5":
                        Console.WriteLine("Enter an event number: ");
                        int Event = Convert.ToInt32(Console.ReadLine());
                        competition.GetAllByEvent(Event);
                        break;
                    case "6":
                        competition.LoadFromFile();
                        break;
                    case "7":
                        competition.SaveToFile();
                        break;
                    case "8":
                        competition.CompIndex();
                        break;
                    case "9":
                        competition.SortCompetitorsByAge();
                        break;
                    case "10":
                        Console.WriteLine("Enter a target number of wins: ");
                        int Target = Convert.ToInt32(Console.ReadLine());
                        competition.Winners(Target);
                        break;
                    case "11":
                        competition.GetQualifiers();
                        break;
                    case "12":
                        Environment.Exit(0); //Closes Program
                        break;
                    default:
                        Console.WriteLine("Invalid Choice! Please Choose Between 1-12: "); //Prompts the user to input a valid option after an invalid input
                        break;
                }
            }

        }

        public void AddCompetitor() //collects user inputs for the competitor list
        {
            int CompNumber;
            while (true)
            {
                Console.Write("Input Competitor Number (100 - 999): ");
                if (int.TryParse(Console.ReadLine(), out CompNumber) && CompNumber >= 100 && CompNumber <= 999)
                {
                    break;
                }
                Console.WriteLine("Invalid Input! Please Insert An Integer");
            }

            competition.checkCompetitor(CompNumber); //Checks if the competitor number is already in use
            Competitor compValues = competition.getCompetitor(CompNumber, null); //Null value chucked in as i couldnt figure out the purpose of the variable

            string CompName;
            int CompAge;
            string Hometown;

            if (compValues != null) //if the compnumber is already in use then values are automatically inserted
            {
                CompName = compValues.CompName;
                CompAge = compValues.CompAge;
                Hometown = compValues.Hometown;
                Console.WriteLine("Competitor Values Successfully Assigned Automatically!");
            }
            else
            {
                Console.WriteLine("Input Competitors Name: ");
                CompName = Console.ReadLine();

                while (true)
                {
                    Console.WriteLine("Input Competitors Age: ");
                    if (int.TryParse(Console.ReadLine(), out CompAge) && CompAge > 0)
                    {
                        break;
                    }
                    Console.WriteLine("Invalid Input! Please Insert An Integer");
                }

                Console.WriteLine("Input Competitors Hometown: ");
                Hometown = Console.ReadLine();
            }

            int EventNo;
            while (true)
            {
                Console.WriteLine("Input the Event Number (1 - 100): ");
                if (int.TryParse(Console.ReadLine(), out EventNo) && EventNo >= 1 && EventNo <= 100)
                {
                    break;
                }
                Console.WriteLine("Invalid Input! Please Insert An Integer");
            }

            competition.checkEvent(EventNo); //Checks if the event number is already in use
            BreastStroke eventValues = competition.GetEvent(EventNo, null); //Null value chucked in as i couldnt figure out the purpose of the variable

            string Venue;
            string EventDateTime;
            double Record;

            if (eventValues != null) //if the eventno is already in use then values are automatically inserted
            {
                Venue = eventValues.Venue;
                EventDateTime = eventValues.EventDateTime;
                Record = eventValues.Record;
                Console.WriteLine("Event Values Successfully Assigned Automatically!");
            }
            else
            {
                Console.WriteLine("Input Event Venue: ");
                Venue = Console.ReadLine();
                

                Console.WriteLine("Input the Event Date (XXXX-XX-XX): ");
                DateTime EventDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Input the Event Time (XX:XX): ");
                DateTime EventTime = DateTime.Parse(Console.ReadLine());
                DateTime DateandTime = EventDate.Date.Add(EventTime.TimeOfDay); //combines eventdate and eventtime
                EventDateTime = DateandTime.ToString(); //turns dateandtime to a string

                while (true)
                {
                    Console.WriteLine("Input Record: ");
                    if (double.TryParse(Console.ReadLine(), out Record))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid Input! Please Insert An Double");
                }
            }

            int Placed;
            while (true)
            {
                Console.WriteLine("Input the Number the Competitor Placed (1 - 8): ");
                if (int.TryParse(Console.ReadLine(), out Placed) && Placed >= 1 && Placed <= 8)
                {
                    break;
                }
                Console.WriteLine("Invalid Input! Please Insert An Integer");
            }

            double RaceTime;
            while (true)
            {
                Console.WriteLine("Input Competitors Race Time: ");
                if (double.TryParse(Console.ReadLine(), out RaceTime) && RaceTime > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid Input! Please Insert An Double");
            }

            //Method to check qualified
            //Method for newPB

            //Console.WriteLine("Input Event Type: ");
            //string EventType = Console.ReadLine();
            string EventType = "BreastStroke"; //Locked to BreastStroke as other events are not to be implemented

            int Distance;
            while (true)
            {
                Console.WriteLine("Input Event Distance (50 - 1500): ");
                if (int.TryParse(Console.ReadLine(), out Distance) && Distance >= 50 && Distance <= 1500)
                {
                    break;
                }
                Console.WriteLine("Invalid Input! Please Insert An Integer");
            }

            double WinningTime;
            while (true)
            {
                Console.WriteLine("Input the Winning Time: ");
                if (double.TryParse(Console.ReadLine(), out WinningTime) && WinningTime > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid Input! Please Insert An Double");
            }
           
            //Method for newrecord

            Console.WriteLine("Input Most Recent Win: ");
            string MostRecentWin = Console.ReadLine();

            int CareerWins;
            while (true)
            {
                Console.WriteLine("Input CareerWins: ");
                if (int.TryParse(Console.ReadLine(), out CareerWins))
                {
                    break;
                }
                Console.WriteLine("Invalid Input! Please Insert An Integer");
            }

            List<string> Medals = new List<string>();
            Console.WriteLine("Input Medals: ");
            Medals = Console.ReadLine().Split(',').ToList();

            double PersonalBest;
            while (true)
            {
                Console.WriteLine("Input Competitors Personal Best: ");
                if (double.TryParse(Console.ReadLine(), out PersonalBest) && PersonalBest > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid Input! Please Insert An Double");
            }
            Result result = new Result(Placed, RaceTime);
            CompHistory comphistory = new CompHistory(MostRecentWin, CareerWins, Medals, PersonalBest);
            BreastStroke breaststroke = new BreastStroke(EventNo, Venue, EventDateTime, Record, EventType, Distance, WinningTime);
            Competitor competitor = new Competitor(CompNumber, CompName, CompAge, Hometown, breaststroke, result, comphistory);

            competition.AddCompetitor(competitor); //adds the competitor
            Console.WriteLine("Successfully added new Competitor");
        }
    }
}