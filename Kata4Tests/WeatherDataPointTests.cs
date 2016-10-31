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
    public class WeatherDataPointTests
    {
        [TestMethod()]
        public void WeatherDataPointTest()
        {
            WeatherDataPoint t = new WeatherDataPoint(1, 80, 50);
            Approvals.Verify(t.ToString());
        }
    }
}