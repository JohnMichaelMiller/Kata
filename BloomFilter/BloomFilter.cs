using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Kata.BloomFilter
{
    public class BloomFilter
    {
        private const int TestBloomSize = 55; 
        private const int ProductionBloomSize = int.MaxValue;
        public static int BloomSize = TestBloomSize;
        const string fileName = @"C:\Users\John\Source\Repos\Kata\BloomFilter\wordlist.txt";
        public BitArray Bits { get; set; } = new BitArray(BloomSize);

        public BloomFilter()
        {
     //       AddWords(new string[] { "a", "al", "alt", "salt", "stall" });
        }

        public BloomFilter(string[] words)
        {
       //     AddWords(words);
        }

        public BloomFilter(string filename)
        {
       //     this.GetWordsFromFile(filename);
        }

        public void GetWordsFromFile(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            string[] somelines = new string[BloomSize];

            if (lines.Length > BloomSize)
            {
                Array.Copy(lines, somelines,BloomSize);
            }
            else
            {
                somelines = lines;
            }
            AddWords(somelines);
        }

        private void LoadBloomFilterFromWordDictionary(string[] words)
        {
            Bits = new BitArray(BloomSize);
            foreach (var word in words)
            {
                AddHashToBloom(GetHash(word));
            }
        }

        public override string ToString()
        {
            string outputString = "Bits:";

            foreach (bool bit in Bits)
            {
                outputString = outputString + (bit?"1":"0");
            }
            return outputString;
        }


        public bool FindWord(string word)
        {
            return CompareWordToBloom(word);
        }

        /// <summary>
        /// When a set bit in the word is not set in the bloom the word is not in the dictionary.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool CompareWordToBloom(string word)
        {
            int hash = BloomFilter.GetHash(word);
            return Bits[hash];
        }


        /// <summary>
        /// Set the bits in the bloom that are set in the word.
        /// </summary>
        /// <param name="hash">A BitArray containing the hash of the word.</param>
        /// <returns></returns>
        public void AddHashToBloom(int hash)
        {
                    Bits[hash] = true;
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

        public void AddWords(string[] lines)
        {
            foreach (string line in lines)
            {
                int hash = GetHash(line);
                Bits[hash] =true;
                //if (this.Count > 1) return;
            }
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

    }
}