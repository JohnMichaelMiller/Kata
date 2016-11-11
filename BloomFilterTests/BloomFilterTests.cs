using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kata.BloomFilter;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalUtilities.Utilities;

namespace Kata.BloomFilter.Tests
{
    [TestClass()]
    public class BloomFilterTests
    {
        const string FileName = @"C:\Users\John\Source\Repos\Kata\BloomFilter\wordlist.txt";
        public StringBuilder FinalResult = new StringBuilder("Bloom Filter Tests");
        private BloomFilter bloom = new BloomFilter();

        public BloomFilter Bloom
        {
            get
            {
                return bloom;
            }
            set
            {
                bloom = value;
            }
        }

        [TestMethod()]
        public void DictionarySimulationMergeTest()
        {

            StringBuilder text = new StringBuilder("Dictionary Merge Arrays" + Environment.NewLine);

            AddDictionaryWordSubTest(bloom, text, "A");
            AddDictionaryWordSubTest(bloom, text, "A'asia");
            AddDictionaryWordSubTest(bloom, text, "A's");
            AddDictionaryWordSubTest(bloom, text, "AA");
            AddDictionaryWordSubTest(bloom, text, "AA's");
            AddDictionaryWordSubTest(bloom, text, "AAA");
            AddDictionaryWordSubTest(bloom, text, "AAM");
            AddDictionaryWordSubTest(bloom, text, "AB");
            AddDictionaryWordSubTest(bloom, text, "AB's");

            Approvals.Verify(text);
        }

        private static void AddDictionaryWordSubTest(BloomFilter b, StringBuilder text, string word)
        {
            text.Append("Add Dictionary Word " + word);
            int hash = BloomFilter.GetHash(word);
            b.AddHashToBloom(hash);
            text.AppendLine($" Bits[{hash}]={b.Bits[hash]}");
        }

        [TestMethod()]
        public void FindWords()
        {
            bloom.AddWords(new string[]
            {"A", "A'asia", "A's", "AA", "AA's", "AAA", "AAM", "AB", "AB's"});

            StringBuilder text = new StringBuilder("Find Words");

            FindWordsTestResults(text, "A");
            FindWordsTestResults(text, "AA");
            FindWordsTestResults(text, "B");
            FindWordsTestResults(text, "C");
            FindWordsTestResults(text, "D");
            FindWordsTestResults(text, "E");

            Approvals.Verify(text);
        }

        private void FindWordsTestResults(StringBuilder text, string s)
        {
            text.AppendLine();
            text.Append("Find " + s);
            bool found = bloom.FindWord(s);
            text.Append($" Bits[{BloomFilter.GetHash("A")}]={found}");
        }

        [TestMethod(), TestCategory("Long Running")]
        //        [UseReporter(typeof(ClipboardReporter))]
        public void BloomFilterTest()
        {
            Approvals.VerifyAll(CopyToBoolArray(), "Bits");
        }

        private bool[] CopyToBoolArray()
        {
            bool[] ba = new bool[BloomFilter.BloomSize];
            bloom.Bits.CopyTo(ba, 0);
            return ba;
        }

        private bool[] CopyToBoolArray(BitArray bits)
        {
            bool[] ba = new bool[BloomFilter.BloomSize];
            bits.CopyTo(ba, 0);
            return ba;
        }

        [TestMethod(), TestCategory("Long Running")]
        public void GetWordsFromFileTest()
        {
            BloomFilter bf = new BloomFilter();
            bf.GetWordsFromFile(FileName);
            Approvals.VerifyAll(CopyToBoolArray(bf.Bits), "Bits");
        }

        [TestMethod()]
        public void AddWordsTest()
        {
            BloomFilter bf = new BloomFilter();
            bf.AddWords(new string[] { "Cat", "Dog" });
            Approvals.VerifyAll(CopyToBoolArray(bf.Bits), "Bits");
        }

        [TestMethod()]
        public void GetHashTest()
        {
            Approvals.Verify("Hash of Test:" + BloomFilter.GetHash("Test"));
        }

        [TestMethod()]
        public void BitArrayToStringTest()
        {
            Approvals.Verify("Bit Aray of 1024:" + BloomFilter.BitArrayToString(new BitArray(new int[] { 1024 })));
        }

        [TestMethod()]
        public void ComputeHashTest()
        {
            Approvals.Verify("ComputeHash of 1,2,2:" + BloomFilter.ComputeHash(1, 2, 2));
        }

    }
}