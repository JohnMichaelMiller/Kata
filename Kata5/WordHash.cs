using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using static System.Security.Cryptography.MD5;

namespace DifferentialAbstraction
{
    public class WordHash : Dictionary<string, int>
    {
        public WordHash()
        {
            ;
        }

        public WordHash(string[] words)
        {
            AddWords(words);
        }

        public WordHash(string filename)
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
                int[] array = new int[1];
                hash.CopyTo(array, 0);
                Add(line, array[0]);
                if (this.Count > 11) return;
            }
        }

        public static BitArray GetHash(string line)
        {
            int hash = line.GetHashCode();
            int doublehash = hash + (line.Length * line.GetHashCode());
            int[] arrayOfHash = new int[] {doublehash};
            return new BitArray(arrayOfHash);
        }

        public static string WordToString(KeyValuePair<string, int> word)
        {
            string stringTo = word.Key + ":";
            stringTo = stringTo + word.Value;
            return stringTo;
        }

        public static string HashToString(BitArray ba)
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