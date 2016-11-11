using System;
using System.Collections.Generic;
using Kata.DifferentialAbstraction;
using Kata.BloomFilter;
using System.Linq;

namespace Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            RunWeatherDataPointStaticRepository();
            RunWeatherDataPointFileRepository();
            RunFootballStandingStaticRepository();
            RunFootballStandingFileRepository();

            Console.ReadLine();

        }

        private static void RunWeatherDataPointFileRepository()
        {
            WeatherDataPointFileRepository repo2 = new WeatherDataPointFileRepository();
            Console.WriteLine("Searching Weather Data Point File Repository");
            IEnumerable<IWeatherDataPoint> result = ((IRepository<IWeatherDataPoint>)repo2).GetMinimumDifferential();
            Console.WriteLine("Found Day {0} has the smallest temperature differential of {1}", result.FirstOrDefault().Day,
                result.FirstOrDefault().TemperatureDifferential);
        }

        private static void RunWeatherDataPointStaticRepository()
        {
            WeatherDataPointStaticRepository repo = new WeatherDataPointStaticRepository();
            Console.WriteLine("Searching Weather Data Point Static Repository");
            IEnumerable<IWeatherDataPoint> result = ((IRepository<IWeatherDataPoint>)repo).GetMinimumDifferential();
            Console.WriteLine("Found Day {0} has the smallest temperature differential of {1}", result.FirstOrDefault().Day, result.FirstOrDefault().TemperatureDifferential);
        }
        private static void RunFootballStandingFileRepository()
        {
            FootballStandingFileRepository repo2 = new FootballStandingFileRepository();
            Console.WriteLine("Searching Weather Data Point File Repository");
            IEnumerable<IFootballStanding> result = ((IRepository<IFootballStanding>)repo2).GetMinimumDifferential();
            Console.WriteLine("Found Team {0} has the smallest goal differential of {1}", result.FirstOrDefault().Team,
                result.FirstOrDefault().GoalDifferential);
        }

        private static void RunFootballStandingStaticRepository()
        {
            FootballStandingStaticRepository repo = new FootballStandingStaticRepository();
            Console.WriteLine("Searching Weather Data Point Static Repository");
            IEnumerable<IFootballStanding> result = ((IRepository<IFootballStanding>)repo).GetMinimumDifferential();
            Console.WriteLine("Found Team {0} has the smallest goal differential of {1}", result.FirstOrDefault().Team, result.FirstOrDefault().GoalDifferential);
        }
    }
}
