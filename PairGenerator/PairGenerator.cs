using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PairGenerator
{
    class PairGenerator
    {
        static async Task Main(string[] args)
        {

            Console.WriteLine(" \n** Get pairs for pair programming assignment ** \n\n"); 

            Console.WriteLine(" \n** Get pairs for pair programming assignment ** \n\n"); //Lasselta kommentti moro vaan

            //To-do: If file isn't found, throw exception


            string path = @"C:\Files\List.txt";
            var names = ReadFile(path);

            
            if (names != null) { 
                string[] randomNames = ListPairs(names);

                await WriteResultsFile(names, path);
            }
        }

        public static string[] ListPairs(string[] names)
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

            return names;
       }

        public static string[] ReadFile(string fileName)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);

                if (lines.Length == 0)
                {
                    //Console.WriteLine("Error: No names in file");
                    Console.WriteLine("Error: Nothing was found!"); //TÄSSÄ ANNA V. MUUTOKSET.
                    return null;
                }
                return lines;
            }
            catch (Exception e)
            {
                //Console.WriteLine("Error: File not found ");
                Console.WriteLine("Error: CThere is no such file!"); //TÄSSÄ ANNA V. MUUTOKSET.
                return null;
            }
        }


        public static async Task WriteResultsFile(string[] names, string path)
        {
            //todo: write separate files
            await File.WriteAllLinesAsync(path, names);
            //Console.WriteLine("Error: File not found ");-AKN
        }
    }
}
