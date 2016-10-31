using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kata4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Reporters;

namespace Kata4.Tests
{
    [TestClass()]
    [UseReporter(typeof(DiffReporter))]
    public class WeatherStaticRepositoryTests
    {
        [TestMethod()]
        public void WeatherStaticRepositoryInstantiates()
        {
            var repo = new WeatherStaticRepository();
            Approvals.VerifyAll(repo, "Weather Point");
        }

        [TestMethod()]
        public void WeatherStaticRepositoryHasCorrectMinimumTemperatureDifferential()
        {
            var repo = new WeatherStaticRepository();
            var result =
                from w in repo
                where -w.TemperatureDifferential ==
                    repo.Min(d => -d.TemperatureDifferential)
                select w;
                         
            Approvals.VerifyAll(result, "Weather Data Point");
        }
    }
}