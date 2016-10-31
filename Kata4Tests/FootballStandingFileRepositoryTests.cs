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
        var result =
            from w in repo
            where -w.GoalDifferential ==
                repo.Min(d => -d.GoalDifferential)
            select w;

        Approvals.VerifyAll(result, "Football Standing");
    }

    }
}