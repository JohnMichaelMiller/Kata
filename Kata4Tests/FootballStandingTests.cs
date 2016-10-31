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
    [UseReporter(typeof(BeyondCompareReporter))]
    public class FootballStandingTests
    {
        [TestMethod()]
        public void FootballStandingTest()
        {
            //1.Arsenal         38    26   9   3    79 - 36    87

            FootballStanding t = new FootballStanding(1, "Arsenal", 79, 36);
            Approvals.Verify(t.ToString());
        }
    }
}