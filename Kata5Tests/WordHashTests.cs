using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kata5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalUtilities.Utilities;

namespace Kata5.Tests
{
    [TestClass()]
    [UseReporter(typeof(DiffReporter))]
    public class WordHashTests
    {
        [TestMethod()]
        [UseReporter(typeof(ClipboardReporter), typeof(DiffReporter))]
        public void WordHashesTest()
        {
            var words = new WordHash(@"C:\Users\John\Source\Repos\Kata\Kata5\wordlist.txt");
            Approvals.VerifyAll(words, d => "Key {0}, Hash Length {1}".FormatWith(d.Key, d.Value.Length));
        }
    }
}