using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicSwimming
{
    public class CompHistory
    {
        public string mostRecentWin;
        public int careerWins;
        public List<string> medals;
        public double personalBest;

        //constructor for comphistory data
        public CompHistory(string MostRecentWin, int CareerWins, List<string> Medals, double PersonalBest)
        {
            this.mostRecentWin = MostRecentWin; 
            this.careerWins = CareerWins;
            this.medals = Medals;
            if (personalBest > 0)
            {
                this.personalBest = personalBest;
            }
            else
            {
                this.personalBest = PersonalBest;
            }
        }
        public override string ToString() //returns a string of all the details of comphistory
        {
            string medalsString = String.Join(" ", medals);
            return $"Most Recent Win: {mostRecentWin}, Career Wins: {careerWins}, Medals: {medalsString}, Personal Best: {personalBest}";
            //string.Join lists the contents of the medals list into a string seperated by commas
        }

        public string toFile() //Prepares the data comphistory to be passed through SaveToFile
        {
            string medalsString = String.Join(" ", medals);
            return $"{mostRecentWin},{careerWins},{medalsString},{personalBest}";
        }
    }
}