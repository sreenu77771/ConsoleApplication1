using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;

namespace ConsoleApplication1
{
    public class Test1
    {
        public static void InternalMain()
        {
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    string[] pairs = line.Trim().Split(';');
                    Console.WriteLine(line);
                    bool badChain = CreateMap(pairs, dict);

                    if (!badChain)
                    {
                        int count = 0;

                        string beginKey = "BEGIN";
                        string endKey = "END";
                        string currentKey = beginKey;

                        while (!currentKey.Equals(endKey, StringComparison.InvariantCultureIgnoreCase))
                        {
                            //string currentVal;
                            if (!dict.TryGetValue(currentKey, out currentKey))
                            {
                                break;
                            }
                            ++count;
                            if (count > dict.Count)
                            {
                                break;
                            }
                        }

                        if (count == dict.Count &&
                            currentKey.Equals(endKey, StringComparison.InvariantCultureIgnoreCase))
                        {
                            Console.WriteLine("GOOD");
                        }
                        else
                        {
                            Console.WriteLine("BAD");
                        }
                    }
                    else
                    {
                        Console.WriteLine("BAD");
                    }
                }
        }

        private static bool CreateMap(string[] pairs, Dictionary<string, string> dict)
        {
            bool badChain = false;
            foreach (var pair in pairs)
            {
                string[] tokens = pair.Split('-');

                if (tokens[0].Equals(tokens[1], StringComparison.InvariantCultureIgnoreCase))
                {
                    badChain = true;
                    break;
                }
                else
                {
                    if (!dict.ContainsKey(tokens[0]))
                    {
                        dict.Add(tokens[0], tokens[1]);
                    }
                    else
                    {
                        badChain = true;
                        break;
                    }
                }
            }
            return badChain;
        }
    }
}