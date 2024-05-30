using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicSwimming
{
    public class FrontCrawl : Event //derived class of Event
    {
        private string eventType;
        private int distance;
        private double winningTime;
        private bool newRecord;

        public string EventType { get { return eventType; } set { eventType = value; } } //getters and setters
        public int Distance { get { return distance; } set { distance = value; } }
        public double WinningTime { get { return winningTime; } set { winningTime = value; } }
        public bool NewRecord { get { return newRecord; } set { newRecord = value; } }

        //constructor including local and inherited data
        public FrontCrawl(int EventNo, string Venue, string EventDateTime, double Record, string EventType, int Distance, double WinningTime) : base(EventNo, Venue, EventDateTime, Record)
        {
            this.EventType = EventType;
            this.Distance = Distance;
            this.WinningTime = WinningTime;
            this.NewRecord = IsNewRecord();
        }

        //same constructor for VenueID
        public FrontCrawl(int EventNo, int VenueID, string EventDateTime, double Record, string EventType, int Distance, double WinningTime) : base(EventNo, VenueID, EventDateTime, Record)
        {
            this.EventType = EventType;
            this.Distance = Distance;
            this.WinningTime = WinningTime;
            this.NewRecord = IsNewRecord();
        }

        public override string ToString() //returns a string of all the details of the frontcrawl event
        {
            return $"Event No: {EventNo}, Venue: {Venue}, Event Date and Time {EventDateTime}, Record: {Record}, Event Type: {eventType}, Distance: {distance}, Winning Time: {winningTime}, New Record?: {newRecord}";
        }

        public string ToFile() //prepares data
        {
            return $"{EventNo},{Venue},{EventDateTime},{Record},\n{eventType},{distance},{winningTime},{newRecord}";
        }

        public bool IsNewRecord()
        {
            if (WinningTime > Record) //if statement to check if the winning time is greater than the record
            {
                WinningTime = Record;
                return true; //return true if a new record is set
            }
            else
            {
                return false; //return false if a new record is not set
            }
            return false;
        }
    }
}