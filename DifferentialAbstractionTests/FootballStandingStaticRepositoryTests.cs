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
    public class FootballStandingStaticRepositoryTests
    {
        [TestMethod()]
        public void FootballStandingStaticRepositoryInstantiates()
        {
            var repo = new FootballStandingStaticRepository();
            Approvals.VerifyAll(repo, "Football Standing");
        }

        [TestMethod()]
        public void FootballStandingStaticRepositoryHasCorrectMinimumGoalDifferential()
        {
            var repo = new FootballStandingStaticRepository();
            IEnumerable<IItem> result = ((IRepository<IFootballStanding>) repo).GetMinimumDifferential();
                         
            Approvals.VerifyAll(result, "Football Standing");
        }
    }
}