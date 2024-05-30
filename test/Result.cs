using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicSwimming
{
    public class Result
    {
        public int placed;
        public double raceTime;
        public bool qualified;
        
        //constructor for result data
        public Result(int Placed, double RaceTime)
        {
            this.placed = Placed;
            this.raceTime = RaceTime;
            this.qualified = isQualified();
        }

        public override string ToString() //returns a string of all the details of result
        {
            return $"Placed: {placed}, Race Time: {raceTime}, Qualified?: {qualified}";
        }
        public bool isQualified()
        {
            if (placed < 4) //if statement to check if the competitor placed 3rd place or better
            {
                return true; //if the user did place 3rd or better then they qualify
            }
            else
            {
                return false; //if not then they do no qualify
            }
            return false;
        }

        public string ToFile() //Prepares the data from result to be passed through SaveToFile
        {
            return $"{placed},{raceTime},{qualified}";
        }
    }
}