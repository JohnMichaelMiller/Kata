using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Kata5
{
    public class BloomFilter 
    {
        private Dictionary<string, byte[]> _words;
        public BitArray Bits { get; private set; }

        public BloomFilter(Dictionary<string, byte[]> words)
        {
            this._words = words;
            this.Bits =  GetBloomFilter();
        }

        private BitArray GetBloomFilter()
        {
            Bits = new BitArray(_words.FirstOrDefault().Value.Length*8);

            foreach (var word in _words)
            {
                byte[] hash = word.Value;

                BitArray ba = new BitArray(hash);

                Bits.Or(ba);

            }
            return Bits;
        }

        public bool FindWord(string word)
        {
            byte[] hash = WordHash.GetHash(word);
            BitArray ba1 = new BitArray(hash);
            //BitArray ba2 = ba1;
            //BitArray ba3 = ba1.And(Bits);
            return CompareArrays(ba1, Bits);
        }

        public bool CompareArrays(BitArray wordArray, BitArray bloomArray)
        {
            for (int i = wordArray.Count - 1; i >= 0; i--)
            {
                if (wordArray[i])
                if (!bloomArray[i]) return false;
            }
            return true;
        }
    }
}