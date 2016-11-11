using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kata.DifferentialAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Reporters;

namespace Kata.DifferentialAbstraction.Tests
{
    [TestClass()]
    [UseReporter(typeof(DiffReporter))]
    public class WeatherDataPointFileRepositoryTests
    {
        [TestMethod()]
        public void WeatherFileRepositoryTest()
        {
            var repo = new WeatherDataPointFileRepository();
            Approvals.VerifyAll(repo, "Weather Data Point");
        }
    [TestMethod()]
    public void WeatherFileRepositoryHasCorrectMinimumTemperatureDifferential()
    {
        var repo = new WeatherDataPointFileRepository();
        var result = ((IRepository<IWeatherDataPoint>) repo).GetMinimumDifferential();

        Approvals.VerifyAll(result, "Weather Data Point");
    }

    }
}