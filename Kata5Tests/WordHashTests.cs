using Microsoft.VisualStudio.TestTools.UnitTesting;
using DifferentialAbstraction;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalUtilities.Utilities;

namespace DifferentialAbstraction.Tests
{

    [TestClass()]
    [UseReporter(typeof(DiffReporter))]
    public class WordHashTests
    {
        const string fileName = @"C:\Users\John\Source\Repos\Kata\Kata5\wordlist.txt";

        [TestMethod()]
        [UseReporter(typeof(ClipboardReporter), typeof(DiffReporter))]
        public void WordHashesTest()
        {
            var words = new WordHash(fileName);
            Approvals.VerifyAll(words, d => "Key {0}, {1}".FormatWith(d.Key, WordHash.WordToString(d)));
        }

        [TestMethod()]
        public void WordHashctor0Test()
        {
            WordHash wh = new WordHash();
            Assert.AreEqual(wh.Count,0);
        }

        [TestMethod()]
        public void WordHashctor1Test()
        {
            WordHash wh = new WordHash(new string[] { "Cat", "Dog" });
            Approvals.VerifyAll(wh, d => "Key {0}, {1}".FormatWith(d.Key, WordHash.WordToString(d)));
        }
        [TestMethod()]
        public void WordHashctor2Test()
        {
            WordHash wh = new WordHash(fileName);
            Approvals.VerifyAll(wh, d => "Key {0}, {1}".FormatWith(d.Key, WordHash.WordToString(d)));
        }

        [TestMethod()]
        public void GetWordsFromFileTest()
        {
            WordHash wh = new WordHash();
            wh.GetWordsFromFile(fileName);
            Approvals.VerifyAll(wh, d => "Key {0}, {1}".FormatWith(d.Key, WordHash.WordToString(d)));
        }

        [TestMethod()]
        public void AddWordsTest()
        {
            WordHash wh = new WordHash();
            wh.AddWords(new string[] { "Cat", "Dog" });
            Approvals.VerifyAll(wh, d => "Key {0}, {1}".FormatWith(d.Key, WordHash.WordToString(d)));
        }

        [TestMethod()]
        public void GetHashTest()
        {
            Approvals.Verify(WordHash.HashToString(WordHash.GetHash("Test")));
        }

        [TestMethod()]
        public void WordToStringTest()
        {
            KeyValuePair<string, int> word = new KeyValuePair<string, int>("Test", 128);
            Approvals.Verify(WordHash.WordToString(word));
        }

        [TestMethod()]
        public void HashToStringTest()
        {
            Approvals.Verify(WordHash.HashToString(new BitArray(new int[] {1024})));
        }
    }
}