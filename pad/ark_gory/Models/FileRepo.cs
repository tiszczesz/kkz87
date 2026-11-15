using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ark_gory.Models
{
    public class FileRepo
    {
        public static int LoadLikes(string filePath="counter.txt")
        {
            var content = File.ReadAllText(filePath).Trim();
            return Convert.ToInt32(content);
        }
        public static void SaveLikes(int value,
                     string filePath="counter.txt")
        {
            File.WriteAllText(filePath, value.ToString());
        }
    }
}
