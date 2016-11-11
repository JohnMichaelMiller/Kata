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
    public class FootballStandingFileRepositoryTests
    {
        [TestMethod()]
        public void FootballStandingFileRepositoryTest()
        {
            var repo = new FootballStandingFileRepository();
            Approvals.VerifyAll(repo, "Football Standing");
        }
    [TestMethod()]
    public void FootballStandingFileRepositoryHasCorrectMinimumTemperatureDifferential()
    {
        var repo = new FootballStandingFileRepository();
        var result = ((IRepository<IFootballStanding>) repo).GetMinimumDifferential();

        Approvals.VerifyAll(result, "Football Standing");
    }

    }
}