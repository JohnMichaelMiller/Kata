using Microsoft.VisualStudio.TestTools.UnitTesting;
using DifferentialAbstraction;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalUtilities.Utilities;

namespace DifferentialAbstraction.Tests
{
    [TestClass()]
    public class BloomFilterTests
    {
        const string fileName = @"C:\Users\John\Source\Repos\Kata\Kata5\wordlist.txt";
        private readonly BloomFilter _bfilter;

        public BloomFilter Bfilter
        {
            get { return _bfilter; }
        }

        public BloomFilterTests()
        {
            Dictionary<string, int> words = new WordHash(fileName);
            _bfilter = new BloomFilter(words);
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

            result = Bfilter.CompareWordToBloom(wordBA, bloomBA);
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

            result = Bfilter.CompareWordToBloom(wordBA, bloomBA);
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

            result = Bfilter.CompareWordToBloom(wordBA, bloomBA);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void MergeArraysTest()
        {
            BitArray word = new BitArray(new int[] {128});
            Bfilter.MergeWordWiithBits(word);
        }

        [TestMethod()]
        public void FindWords()
        {
            Assert.IsTrue(Bfilter.FindWord("A"), "bm.FindWord('A') should be true and was not.");
            Assert.IsTrue(Bfilter.FindWord("AA"), "bm.FindWord('AA') should be true and was not.");
            Assert.IsFalse(Bfilter.FindWord("B"), "bm.FindWord('B') should be false and was not. ");
            Assert.IsFalse(Bfilter.FindWord("C"), "bm.FindWord('C') should be false and was not. ");
            Assert.IsFalse(Bfilter.FindWord("D"), "bm.FindWord('D') should be false and was not. ");
            Assert.IsFalse(Bfilter.FindWord("E"), "bm.FindWord('E') should be false and was not. ");

        }

        [TestMethod()]
        [UseReporter(typeof(DiffReporter))]
        public void BloomFilterTest()
        {
            var result = new bool[Bfilter.Bits.Count];
            Bfilter.Bits.CopyTo(result, 0);
            Approvals.VerifyAll(result, "Bits");
        }

    }
}