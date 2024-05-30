using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicSwimming
{
    public abstract class Event
    {
        private int eventNo;
        private string venue;
        private int venueID;                            
        private string eventDateTime;
        protected double record;

        public int EventNo { get { return eventNo; } set { eventNo = value; } } //getters and setters
        public string Venue { get { return venue; } set { venue = value; } }
        public int VenueID { get { return venueID; } set { venueID = value; } }
        public string EventDateTime { get { return eventDateTime; } set { eventDateTime = value; } }
        public double Record { get { return record; } set { record = value; } }

        //constructor for event data
        public Event(int EventNo, string Venue, string EventDateTime, double Record)
        {
            this.EventNo = EventNo;
            this.Venue = Venue;
            this.EventDateTime = EventDateTime;
            this.Record = Record;
        }

        //same constructor but for VenueID
        public Event(int EventNo, int VenueID, string EventDateTime, double Record)
        {
            this.EventNo = EventNo;
            this.VenueID = VenueID;
            this.EventDateTime = EventDateTime;
            this.Record = Record;
        }
    }
}