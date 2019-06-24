using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace MentorMateTask
{
    class Task
    {
        static void Main(string[] args)
        {
            // initialize public variables
            string name = "";
            int rating = 0;
            int maxYear = 8;
            int minRating = 85;

            //json filepath
            string filepath = File.ReadAllText("D:/Programs/Temp.json");

            var newPlayer = JsonConvert.DeserializeObject<List<Basketball>>(filepath);

            StringBuilder csv = new StringBuilder();

            //first line of .csv file
            csv.AppendLine("Name, Rating");

            //loop about all of the elements in json file
            for (int i = 0; i <= 6; i++)
            {
                int year = newPlayer[i].years - DateTime.Now.Year;
                if (year <= maxYear)
                {
                    if (newPlayer[i].rating >= minRating)
                    {
                        name = newPlayer[i].name;
                        rating = newPlayer[i].rating;
                        csv.AppendLine(name + ", " + rating);
                    }
                }
            }
            string csvpath = "D:\\Programs\\report.csv";
            File.AppendAllText(csvpath, csv.ToString());
            Console.WriteLine("Report is created!");
        }
    }
    public class Basketball
    {
        public string name { get; set; }
        public int years { get; set; }
        public string position { get; set; }
        public int rating { get; set; }
    }
}
