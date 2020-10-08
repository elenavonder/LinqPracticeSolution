using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Xml.Schema;

namespace LinqPractice
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class City
    {
        public string Name { get; set; }
        public int StateId { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {

            var states = new List<State>
            {
                new State {Id = 1, Name = "Ohio" }, 
                new State {Id = 2, Name = "Kentucky"},
                new State {Id = 3, Name = "Indiana"}
            };
            var cities = new List<City>
            {
                new City {Name = "Cincinnati", StateId = 1},
                new City {Name = "Columbus", StateId = 1},
                new City {Name = "Cleveland", StateId = 1},
                new City {Name = "Newport", StateId = 2},
                new City {Name = "Covington", StateId = 2},
                new City {Name = "Indianapolis", StateId = 3},
            };

            var CitiesStates = from s in states
                         join c in cities
                         on s.Id equals c.StateId
                         select new
                         {
                             StateName = s.Name,
                             CityName = c.Name
                         };
            foreach(var CS in CitiesStates.ToList())
            {
                Console.WriteLine($"City/State: {CS.CityName}, {CS.StateName}");
            }


            var nbrs = new List<int> {
                268,876,510,365,219,299,489,390,965,993,
                419,726,282,926,681,206,263,481,501,456,
                744,976,792,201,674,595,805,360,973,203,
                913,747,356,437,897,170,151,906,684,763,
                369,332,215,660,666,366,272,127,543,803,
                175,823,119,427,963,478,553,903,384,220,
                471,164,401,236,539,845,805,489,209,273,
                944,261,529,570,206,401,157,870,266,861,
                411,487,600,702,177,829,810,371,932,262,
                286,467,834,303,842,544,659,738,431,458
            };

            //distinct all the numbers if there are doubles
            //All used to see if all numbers are even or odd or statisfys some other condition(bool)

            //sum of numbers divisible by 3 and 7
            var sumdiv37 = nbrs.Where(n => n % 3 == 0 || n % 7 == 0).Sum();
            sumdiv37 = (from n in nbrs
                       where n % 3 == 0 || n % 7 == 0
                       select n).Sum();
            //average of the numbers greater than or equal to 500
            var avgGE500 = (from n in nbrs
                           where n >= 500
                           select n).Average();

            var ints = new int[] { 1, 3, 5, 7, 9, 11, 13, 17 };

            //method form: the sum of numbers greater than 7 
            var sumGT7 = ints.Where(i => i > 7).Sum();
            //query form: need to wrap in parenthesis and put .sum(); to get sum
            sumGT7 = (from i in ints
                       where i > 7
                       select i).Sum();

            //method form: the average of numbers less than or equal to 11
            var AvgLE11 = ints.Where(e => e <= 11).Average();
            //query form: 
            AvgLE11 = (from e in ints
                      where e <= 11
                      select e).Average();

            //methods examples
            var max = ints.Max();
            var min = ints.Min();
            var sum = ints.Sum();
            var count = ints.Count();
            var avg = ints.Average();

            //var total = 0;
            //for(var idx = 1; idx < 50; idx++)
            //{
            //    if (idx % 5 == 0 || idx % 7 == 0)
            //        total += idx;
            //}
            //Console.WriteLine(total);
        }
    }
}
