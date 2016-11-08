using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kata5;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalUtilities.Utilities;

namespace Kata5.Tests
{
    [TestClass()]
    public class BloomFilterTests
    {
        private Dictionary<string, byte[]> words;
        private BloomFilter bm;

        public BloomFilterTests()
        {
            words = new WordHash(@"C:\Users\John\Source\Repos\Kata\Kata5\wordlist.txt");
            bm = new BloomFilter(words);
        }

        [TestMethod()]
        [UseReporter(typeof(DiffReporter))]
        public void BloomFilterTest()
        {
            bool[] result = new bool[bm.Bits.Count];
            bm.Bits.CopyTo(result, 0);
            Approvals.VerifyAll(result, "Bits");
        }

        [TestMethod()]
        public void FindWords()
        {
            Assert.IsTrue(bm.FindWord("A"));
            Assert.IsTrue(bm.FindWord("AA"));
            Assert.IsFalse(bm.FindWord("B"));
            Assert.IsFalse(bm.FindWord("C"));
            Assert.IsFalse(bm.FindWord("D"));
            Assert.IsFalse(bm.FindWord("E"));

        }

        [TestMethod()]
        public void EqualBitArraysShouldCompareAsEqual()
        {
            BitArray wordBA = new BitArray(10);
            BitArray bloomBA = new BitArray(10);
            bool result = false;

            wordBA[0] = true;
            wordBA[1] = true;
            wordBA[2] = false;
            wordBA[3] = true;
            wordBA[4] = true;
            wordBA[5] = false;
            wordBA[6] = false;
            wordBA[7] = true;
            wordBA[8] = false;
            wordBA[9] = true;

            bloomBA = wordBA;

            result = bm.CompareArrays(wordBA, bloomBA);
            Assert.IsTrue(result);
        }
        [TestMethod()]
        public void WhenWordBitsAreFalseAndBloomBitsAreTrueTheyShouldCompareAsEqual()
        {
            BitArray wordBA = new BitArray(10);
            bool result = false;

            wordBA[0] = true;
            wordBA[1] = true;
            wordBA[2] = false;
            wordBA[3] = true;
            wordBA[4] = true;
            wordBA[5] = false;
            wordBA[6] = false;
            wordBA[7] = true;
            wordBA[8] = false;
            wordBA[9] = true;

            var bloomBA = wordBA;

            bloomBA[5] = true;

            result = bm.CompareArrays(wordBA, bloomBA);
            Assert.IsTrue(result);
        }
        [TestMethod()]
        public void WhenWordBitsAreTrueAndBloomBitsAreFalseTheyShouldCompareAsNotEqual()
        {
            BitArray wordBA = new BitArray(10);
            bool result = false;

            wordBA[0] = true;
            wordBA[1] = true;
            wordBA[2] = false;
            wordBA[3] = true;
            wordBA[4] = true;
            wordBA[5] = false;
            wordBA[6] = false;
            wordBA[7] = true;
            wordBA[8] = false;
            wordBA[9] = true;

            var bloomBA = wordBA;

            bloomBA[1] = false;

            result = bm.CompareArrays(wordBA, bloomBA);
            Assert.IsTrue(result);
        }
    }
}