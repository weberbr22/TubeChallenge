using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace TubeChallenge
{
    class Program
    {
        static void Task1()
        {
            try
            {
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                docPath = Path.Combine(docPath, "Academic/Computing/C#/unsorted.txt");

                StreamWriter myFile = new StreamWriter(docPath);

                for (int j = 0; j < 3; j++)
                {
                    Random rnd = new Random();
                    int num = rnd.Next(50);
                    myFile.WriteLine(num);
                }

                string docPath1 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                docPath1 = Path.Combine(docPath1, "Academic/Computing/C#/sorted.txt");

                StreamReader input = new StreamReader(docPath);
                StreamWriter output = new StreamWriter(docPath1);


                int[] inter = new int[3];

                string line = string.Empty;
                int i = 0;
                do
                {
                    line = input.ReadLine();
                    if (line != null)
                    {
                        Console.WriteLine(line);
                        inter[i] = Int32.Parse(line);
                        i += 1;
                    }

                } while (line != null);

                int temp = 0;

                for (int write = 0; write < inter.Length; write++)
                {
                    for (int sort = 0; sort < inter.Length - 1; sort++)
                    {
                        if (inter[sort] > inter[sort + 1])
                        {
                            temp = inter[sort + 1];
                            inter[sort + 1] = inter[sort];
                            inter[sort] = temp;
                        }
                    }
                    Console.Write("{0} ", inter[write]);
                }

                output.Write(string.Join(", ", inter));

            }

            catch(IOException e)
            {
                Console.WriteLine("The file could not be read: ");
                Console.WriteLine(e.Message);
            }


        }

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
            Task1();
            //Tubes();
            //Console.WriteLine(Shares("St John's Wood", "Mackerel"));
            Console.WriteLine("Hello World!");
        }
    }
}

