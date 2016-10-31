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
    public class WeatherFileRepositoryTests
    {
        [TestMethod()]
        public void WeatherFileRepositoryTest()
        {
            var repo = new WeatherFileRepository();
            Approvals.VerifyAll(repo, "Weather Data Point");
        }
    [TestMethod()]
    public void WeatherFileRepositoryHasCorrectMinimumTemperatureDifferential()
    {
        var repo = new WeatherFileRepository();
        var result =
            from w in repo
            where -w.TemperatureDifferential ==
                repo.Min(d => -d.TemperatureDifferential)
            select w;

        Approvals.VerifyAll(result, "Weather Data Point");
    }

    }
}