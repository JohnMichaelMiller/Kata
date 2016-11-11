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
    public class WeatherDataPointStaticRepositoryTests
    {
        [TestMethod()]
        public void WeatherStaticRepositoryInstantiates()
        {
            var repo = new WeatherDataPointStaticRepository();
            Approvals.VerifyAll(repo, "Weather Point");
        }

        [TestMethod()]
        public void WeatherStaticRepositoryHasCorrectMinimumGoalDifferential()
        {
            var repo = new WeatherDataPointStaticRepository();
            IEnumerable<IItem> result = ((IRepository<IWeatherDataPoint>) repo).GetMinimumDifferential();

            Approvals.VerifyAll(result, "Weather Data Point");
        }

    }
}