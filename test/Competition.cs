using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OlympicSwimming
{

    public class Competition
    {
        private List<Competitor> competitors;

        public Competition()
        {
            competitors = new List<Competitor>(); //initialise list
        }

        public void AddCompetitor(Competitor c) //adds the inserted competitor data to the competitors list
        {
            competitors.Add(c);
        }

        public void RemoveCompetitor(Competitor c) //unkown purpose
        {
            
        }

        public void DeleteCompetitor(int CompNo) //deletes a competitor from the competitors list
        {
            if (competitors.Any(comp => comp.CompNumber == CompNo))
            {
                Competitor competitor = competitors.FirstOrDefault(comp => comp.CompNumber == CompNo);
                competitors.Remove(competitor);
            }
            else
            {
                Console.WriteLine("Competitor Not Found");
            }
        }

        public Boolean checkCompetitor(int CompNo) //checks to see if the compnumber already exists
        {
            if (competitors.Any(comp => comp.CompNumber == CompNo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean checkEvent(int EventNo) //checks to see if the eventno exists
        {
            if(competitors.Any(comp => comp.CompEvent.EventNo == EventNo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Competitor getCompetitor(int CompNo, Competitor Competitor) //if the compnumber exists then thsi function fetches that data to be used again
        {
            foreach (Competitor competitor in competitors)
            {
                if (competitor.CompNumber == CompNo)
                {
                    return competitor;
                }
            }
            return null;
        }

        public BreastStroke GetEvent(int EventNo, Event Event) //if the eventno exists then thsi function fetches that data to be used again
        {
            foreach (Competitor competitor in competitors)
            {   
                if (competitor.CompEvent is BreastStroke bSEvent && bSEvent.EventNo == EventNo)
                {
                    return bSEvent;
                }
            }
            return null;
        }

        public void ClearAll() //clears all data from the competitors list
        {
            competitors.Clear();
            Console.WriteLine("Cleared Data");
        }

        public void GetAllByEvent(int Event) //returns all competitors partaking in an event with the inserted eventno
        {
            var eventQuery = from comp in competitors
                             where comp.CompEvent.EventNo == Event
                             select comp;
            foreach (var competitors in eventQuery)
            {
                Console.WriteLine(competitors);
            }
        }

        public void LoadFromFile() //loads the contents of the csv file into memory 
        {
            if (File.Exists("Competitor.csv"))
            {
                using (StreamReader reader = new StreamReader("Competitor.csv"))
                {

                    string line;
                    while ((line = reader.ReadLine()) != null) //skips headers
                    {
                        if (line.Contains("Event No") || line.Contains("Event Type") || line.Contains("Placed") || line.Contains("Most Recent Win") || line.Contains("Comp Number"))
                        {
                            continue;
                        }

                        string[] eventData = line.Split(',');
                        if (eventData.Length < 4) 
                        { 
                            continue; 
                        }
                            int eventNo = int.Parse(eventData[0]);
                            string venue = eventData[1];
                            string eventDateTime = eventData[2];
                            double record = double.Parse(eventData[3]);

                        reader.ReadLine();

                        line = reader.ReadLine();
                        string[] bSData = line.Split(',');
                        if (eventData.Length < 4)
                        {
                            continue;
                        }
                            string eventType = bSData[0];
                            int distance = int.Parse(bSData[1]);
                            double winningTime = double.Parse(bSData[2]);
                            bool newRecord = bool.Parse(bSData[3]);

                        reader.ReadLine();

                        line = reader.ReadLine();
                        string[] resultData = line.Split(',');
                        if (eventData.Length < 3)
                        {
                            continue;
                        }
                            int placed = int.Parse(resultData[0]);
                            double raceTime = double.Parse(resultData[1]);
                            bool qualified = bool.Parse(resultData[2]);

                        reader.ReadLine();

                        line = reader.ReadLine();
                        string[] historyData = line.Split(',');
                        if (eventData.Length < 3)
                        {
                            continue;
                        }
                            string mostRecentWin = historyData[0];
                            int careerWins = int.Parse(historyData[1]);
                            List<string> medals = historyData[2].Split(' ').ToList();
                            double personalBest = double.Parse(historyData[3]);

                        reader.ReadLine();

                        line = reader.ReadLine();
                        string[] compData = line.Split(',');
                        if (eventData.Length < 5)
                        {
                            continue;
                        }
                            int compNumber = int.Parse(compData[0]);
                            string compName = compData[1];
                            int compAge = int.Parse(compData[2]);
                            string hometown = compData[3];
                            bool newPB = bool.Parse(compData[4]);

                        Result result = new Result(placed, raceTime);
                        CompHistory comphistory = new CompHistory(mostRecentWin, careerWins, medals, personalBest);
                        BreastStroke breaststroke = new BreastStroke(eventNo, venue, eventDateTime, record, eventType, distance, winningTime);
                        Competitor competitor = new Competitor(compNumber, compName, compAge, hometown, breaststroke, result, comphistory);

                        AddCompetitor(competitor);
                    }
                }
                Console.WriteLine("File has been loaded");
            }
            else
            {
                Console.WriteLine("File does not exist");
                return;
            }
        }

        public void SaveToFile() //saves the data from ToFile to the csv file
        {
            using (StreamWriter writer = new StreamWriter("Competitor.csv"))
            {

                    writer.WriteLine(ToFile());

            }
            Console.WriteLine("Data has been successfully saved to file");
        }

        public Dictionary<string, Competitor> CompIndex()
        {
            Dictionary<string, Competitor> compIndex = new Dictionary<string, Competitor>();

            foreach (Competitor competitor in competitors)
            {
                string key = $"Competitor {competitor.CompNumber} - Event {competitor.CompEvent.EventNo}";
                compIndex[key] = competitor;
            }
            foreach (var kvp in compIndex)
            {
                Console.WriteLine($"{kvp.Key}");
            }
            return compIndex;
        }


        public void SortCompetitorsByAge() //sorts competitors by age
        {
            competitors.Sort((x, y) => x.CompAge.CompareTo(y.CompAge));
            Console.WriteLine("Competitors Sorted");
        }

        public void Winners(int Target) //returns all competitors with a number of wins equal or more than the amount inserted
        {
            var winnersQuery = from comp in competitors
                               where comp.history.careerWins >= Target
                               select comp;
            foreach (var winners in winnersQuery)
            {
                Console.WriteLine(winners);
            }
        }

        public void GetQualifiers() //returns all qualifying competitors
        {
            var qualifierQuery = from comp in competitors 
                                 where comp.results.qualified = true
                                 orderby comp.CompNumber, comp.results.raceTime
                                 select comp;
            foreach (var qualifiers in qualifierQuery)
            {
                Console.WriteLine(qualifiers);
            }
        }

        public void printComp() //returns all competitors
        {
            var eventQuery = from comp in competitors
                             select comp;
            foreach (var competitors in eventQuery)
            {
                Console.WriteLine(competitors);
            }
        }

        public string ToFile() //Prepares the data from the competitors list to be passed through SaveToFile
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (Competitor competitor in competitors)
            {
                stringBuilder.AppendLine(competitor.ToFile() + Environment.NewLine);
                stringBuilder.AppendLine();
            }
            return stringBuilder.ToString();
        }

    }
}