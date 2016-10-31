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
            var result =
                from w in repo
                where -w.GoalDifferential ==
                    repo.Min(d => -d.GoalDifferential)
                select w;
                         
            Approvals.VerifyAll(result, "Football Standing");
        }
    }
}