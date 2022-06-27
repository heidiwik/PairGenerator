using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PairGenerator
{
    class PairGenerator
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" \n** Get pairs for pair programming assignment ** \n\n");

            string path = @"C:\Files\List.txt";
            var names = ReadFile(path);

            if (names != null)
                ListPairs(names);

            saveResultToFile(@"C:\Files\Results.txt", names);

        }

        public static void ListPairs(string[] names)
        {
            if (names != null)
            {
                Random r = new Random();
                names = names.OrderBy(x => r.Next()).ToArray();

                for (int i = 0; i < names.Length; i++)
                {
                    Console.Write(names[i].PadRight(10).PadLeft(11));
                    if (i % 2 == 0)
                    {
                        Console.Write(" ");
                        continue;
                    }
                    Console.WriteLine("");
                }
            }
       }

        public static string[] ReadFile(string fileName)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);

                if (lines.Length == 0)
                {
                    Console.WriteLine("Error: No names in file");
                    return null;
                }
                return lines;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: File not found ");
                return null;
            }
        }

        public static void saveResultToFile(string fileName, string[] names)
        {
            File.AppendAllLines(fileName, names);
        }
    }
}
