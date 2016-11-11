using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Kata.BloomFilter
{
    public class XWordHash : Dictionary<string, int>
    {
        private const int BloomSize = int.MaxValue;

        public XWordHash()
        {
            ;
        }

        public XWordHash(string[] words)
        {
            AddWords(words);
        }

        public XWordHash(string filename)
        {
            this.GetWordsFromFile(filename);
        }

        public void GetWordsFromFile(string filename)
        {
            FileInfo fi = new FileInfo(filename);
            if (fi.Exists)
            {
                string[] lines = File.ReadAllLines(filename);

                AddWords(lines);
            }
        }

        public void AddWords(string[] lines)
        {
            foreach (string line  in lines)
            {
                var hash = GetHash(line);
                Add(line, hash);
                //if (this.Count > 1) return;
            }
        }

        public static int GetHash(string line)
        {

            int primaryHash = line.GetHashCode();
            int secondaryHash = HashString(line);
            int hash = 0;
            for (int i = 0; i < 2; i++)
            {
                hash = ComputeHash(primaryHash, secondaryHash, i);
            }
            return hash;
        }

        public static string WordToString(KeyValuePair<string, int> word)
        {
            string stringTo = word.Key + ":";
            stringTo = stringTo + word.Value;
            return stringTo;
        }

        public static string BitArrayToString(BitArray ba)
        {
            string stringTo = "";
            foreach (bool bit in ba)
            {
                if (bit)
                    stringTo = stringTo + "1";
                else
                    stringTo = stringTo + "0";
            }
            return stringTo;
        }

        /// <summary>
        /// Hashes a string using Bob Jenkin'input "One At A Time" method from Dr. Dobbs (http://burtleburtle.net/bob/hash/doobs.html).
        /// Runtime is suggested to be 9x+9, where x = input.Length. 
        /// </summary>
        /// <param name="input">The string to hash.</param>
        /// <returns>The hashed result.</returns>
        public static int HashString(string input)
        {
            int hash = 0;

            for (int i = 0; i < input.Length; i++)
            {
                hash += input[i];
                hash += (hash << 10);
                hash ^= (hash >> 6);
            }

            hash += (hash << 3);
            hash ^= (hash >> 11);
            hash += (hash << 15);
            return hash;
        }

        /// <summary>
        /// Performs Dillinger and Manolios double hashing. 
        /// </summary>
        /// <param name="primaryHash"> The primary hash. </param>
        /// <param name="secondaryHash"> The secondary hash. </param>
        /// <param name="i"> The i. </param>
        /// <returns> The <see cref="int"/>. </returns>
        public static int ComputeHash(int primaryHash, int secondaryHash, int i)
        {
            int resultingHash = (primaryHash + (i * secondaryHash)) % BloomSize;
            return Math.Abs(resultingHash);
        }
    }
}