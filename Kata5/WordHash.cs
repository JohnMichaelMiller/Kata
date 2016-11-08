using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using static System.Security.Cryptography.MD5;

namespace Kata5
{
    public class WordHash : Dictionary<string, byte[]>
    {
        public WordHash(string filename)
        {
            FileInfo fi = new FileInfo(filename);
            if (fi.Exists)
            {
                string[] lines = File.ReadAllLines(filename);

                foreach (string line  in lines)
                {
                    var hash = GetHash(line);
                    Add(line, hash);
                    if (this.Count > 3) return;
                }
            }
        }

        public static byte[] GetHash(string line)
        {
            var algorithm = Create(); //MD5.Create(); 
            byte[] hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(line));
            return hash;
        }
    }
}