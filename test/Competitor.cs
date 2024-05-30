using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OlympicSwimming
{
    public class Competitor
    {
        private int compNumber;
        private string compName;
        private int compAge;
        private string hometown;
        private bool newPB;
        private BreastStroke compEvent;
        public Result results;
        public CompHistory history;

        public int CompNumber { get { return compNumber; } set { compNumber = value; } } //getters and setters
        public string CompName { get { return compName; } set { compName = value; } }
        public int CompAge { get { return compAge; } set { compAge = value; } }
        public string Hometown { get { return hometown; } set { hometown = value; } }
        public bool NewPB { get { return newPB; } set { newPB = value; } }
        public BreastStroke CompEvent { get { return compEvent; } set { compEvent = value; } }
        public Result Results { get { return results; } set { results = value; } }
        public CompHistory History { get { return history; } set { history = value; } }

        //constructor for competitor data and other classes
        public Competitor(int CompNumber ,string CompName, int CompAge, string Hometown, BreastStroke CompEvent, Result Results, CompHistory History)
        {
            this.compNumber = CompNumber;
            this.compName = CompName;
            this.compAge = CompAge;
            this.hometown = Hometown;
            this.newPB = IsNewPB();
            this.compEvent = CompEvent;
            this.results = Results;
            this.history = History;
        }


        public override string ToString() //returns a string of all the details of competitor
        {
            return $"Comp Number: {compNumber}, Comp Name: {compName}, Comp Age: {compAge}, Hometown: {hometown}, New PB?: {newPB}";
        }

        public bool IsNewPB() //checks if a new PB has been set
        {
            if (results != null && history != null)
            {
                if (results.raceTime < history.personalBest)
                {
                    history.personalBest = results.raceTime;
                    return true; //return true if newPB is set
                }
                else
                {
                    return false; //return false if newPB is not set
                }
            }
            return false;
        }

        public string ToFile() //creates data format for the data being inserted into the csv
        {
            return $"Event No,Venue,Event Date and Time,Record,\n" +
                   $"{compEvent.EventNo},{compEvent.Venue},{compEvent.EventDateTime},{compEvent.Record},\n" +
                   $"Event Type,Distance,Winning Time,New record?,\n" +
                   $"{compEvent.EventType},{compEvent.Distance},{compEvent.WinningTime},{compEvent.NewRecord}\n" +
                   $"Placed,Race Time,Qualified?,\n" +
                   $"{results.ToFile()},\n" +
                   $"Most Recent Win,Career Wins,Medals,Personal Best,\n" +
                   $"{history.toFile()},\n" +
                   $"Comp Number,Comp Name,Comp Age,Hometown,NewPB?,\n" +
                   $"{compNumber},{compName},{compAge},{hometown},{newPB}";
        }
    }
}