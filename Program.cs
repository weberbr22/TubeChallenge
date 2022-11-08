using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace TubeChallenge
{
    class Program
    {
        static bool Shares(string s1, string s2)
        {
            bool[] v = new bool[126];
            v = (v.Select(x => x = false)).ToArray(); 
            for (int i = 0; i < s1.Length; i++) v[s1[i]] = true;
            for (int i = 0; i < s2.Length; i++)
                if (v[s2[i]]) return true;
            return false;
        }

        static void Tubes()
        {
            try
            {
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                docPath = Path.Combine(docPath, "Downloads/stations.txt");

                StreamReader myFile = new StreamReader(docPath);
                //string[] unsorted = new string[272];
                //string[] sorted = new string[272];
                List<string> Stations = new List<string>();
                string input = myFile.ReadToEnd();
                myFile.Close();

                using (StringReader reader = new StringReader(input))
                {
                    string line = string.Empty;
                    do
                    {
                        line = reader.ReadLine();
                        if (line != null)
                        {
                            Console.WriteLine(line);
                            string[] inter = line.Split(", ");
                            Stations.Add(inter[0]);
                        }

                    } while (line != null);
                }

                Console.WriteLine("What string do you want to compare: ");
                string comparator = Console.ReadLine();
                string output = string.Empty;

                foreach(string i in Stations)
                {
                    bool inter = Shares(comparator, i);
                    //Console.WriteLine(i);

                    if (inter == true)
                    {
                        output = "Could not find any non sharers";
                    }

                    else if (inter == false)
                    {
                        output = i;
                    } 
                }

                Console.WriteLine(output);
            }
            
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read: ");
                Console.WriteLine(e.Message);
            }

        }

        static void Main(string[] args)
        {
            Tubes();
            //Console.WriteLine(Shares("St John's Wood", "Mackerel"));
            Console.WriteLine("Hello World!");
        }
    }
}

