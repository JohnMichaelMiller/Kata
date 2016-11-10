using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DifferentialAbstraction
{
    public class BloomFilter 
    {
        private Dictionary<string, int> ReferenceWords;
        public BitArray Bits { get; private set; }

        public BloomFilter(Dictionary<string, int> words)
        {
            this.ReferenceWords = words;
            this.Bits =  LoadBloomFilterFromWordDictionary();
        }

        private BitArray LoadBloomFilterFromWordDictionary()
        {
            Bits = new BitArray(32);

            foreach (var word in ReferenceWords)
            {
                
                BitArray ba = new BitArray(new int[] {word.Value});

                Bits = MergeWordWiithBits(ba);

            }
            return Bits;
        }

        public bool FindWord(string word)
        {
            return CompareWordToBloom(new BitArray(WordHash.GetHash(word)), Bits);
        }

        public bool CompareWordToBloom(BitArray word, BitArray bloomArray)
        {
            Bits = bloomArray;

            return CompareWordToBloom(word);
        }

        /// <summary>
        /// When a set bit in the word is not set in the bloom the word is not in the dictionary.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool CompareWordToBloom(BitArray word)
        {
            for (int i = word.Count - 1; i >= 0; i--)
            {
                if (word[i])
                    if (!Bits[i]) return false;
            }
            return true;
        }


        /// <summary>
        /// Set the bits in the bloom that are set in the word.
        /// </summary>
        /// <param name="words">A BitArray containing the hash of the word.</param>
        /// <returns></returns>
        public BitArray MergeWordWiithBits(BitArray words)
        {
            for (int i = words.Count - 1; i >= 0; i--)
            {
                if (words[i] && !Bits[i])
                {
                    Bits[i] = true;
                }
            }
            return Bits;
        }
    }
}