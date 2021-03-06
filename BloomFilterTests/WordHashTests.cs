﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kata.BloomFilter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalUtilities.Utilities;

namespace Kata.BloomFilter.Tests
{

    [TestClass()]
    [UseReporter(typeof(DiffReporter))]
    public class WordHashTests
    {
        const string fileName = @"C:\Users\John\Source\Repos\Kata\BloomFilter\wordlist.txt";

        //[TestMethod()]
        //public void WordHashctor0Test()
        //{
        //    WordHash wh = new WordHash();
        //    Assert.AreEqual(wh.Count, 0);
        //}

        //[TestMethod()]
        //public void WordHashctor1Test()
        //{
        //    WordHash wh = new WordHash(new string[] { "Cat", "Dog" });
        //    Approvals.VerifyAll(wh, d => "Key {0}, {1}".FormatWith(d.Key, WordHash.WordToString(d)));
        //}
        //[TestMethod()]
        //public void WordHashctor2Test()
        //{
        //    WordHash wh = new WordHash(fileName);
        //    Approvals.VerifyAll(wh, d => "Key {0}, {1}".FormatWith(d.Key, WordHash.WordToString(d)));
        //}

        //[TestMethod(),TestCategory("Long Running")]
        //public void GetWordsFromFileTest()
        //{
        //    WordHash wh = new WordHash();
        //    wh.GetWordsFromFile(fileName);
        //    Approvals.VerifyAll(wh, d => "Key {0}, {1}".FormatWith(d.Key, WordHash.WordToString(d)));
        //}

        //[TestMethod()]
        //public void AddWordsTest()
        //{
        //    WordHash wh = new WordHash();
        //    wh.AddWords(new string[] { "Cat", "Dog" });
        //    Approvals.VerifyAll(wh, d => "Key {0}, {1}".FormatWith(d.Key, WordHash.WordToString(d)));
        //}

        //[TestMethod()]
        //public void GetHashTest()
        //{
        //    Approvals.Verify(WordHash.GetHash("Test"));
        //}

        //[TestMethod()]
        //public void WordToStringTest()
        //{
        //    KeyValuePair<string, int> word = new KeyValuePair<string, int>("Test", 128);
        //    Approvals.Verify(WordHash.WordToString(word));
        //}

        //[TestMethod()]
        //public void HashToStringTest()
        //{
        //    Approvals.Verify(WordHash.BitArrayToString(new BitArray(new int[] { 1024 })));
        //}

        //[TestMethod()]
        //public void WordHashTest()
        //{
        //    Approvals.Verify(new WordHash().ToReadableString());
        //}

        //[TestMethod()]
        //public void ComputeHashTest()
        //{
        //    Approvals.Verify(WordHash.ComputeHash(1,2,2));
        //}
    }

    public class TestCategory
    {
    }
}