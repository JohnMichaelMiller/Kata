using System;
using Kata4;
using System.Linq;

namespace Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing");
            var repo = new WeatherStaticRepository();
            Console.WriteLine("Searching Repository");
            var result =
                from w in repo
                where -w.TemperatureDifferential ==
                    repo.Min(d => -d.TemperatureDifferential)
                select w;
            Console.WriteLine("Found Day {0} has the smallest temperature differential of {1}",result.FirstOrDefault().Day, result.FirstOrDefault().TemperatureDifferential);
            Console.ReadLine();

        }
    }
}
