using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ShadyProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pathFile = File.ReadAllLines(args[0]);
                int depthLevel = Int32.Parse(args[1]);
                Functions f = new Functions();

                f.GetDirectorySize(pathFile, depthLevel);
                f.DisplayDirectorySize();
            }

            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Please input in this syntax: <filename> <depth level>");
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter depth level in a correct format");
            }
            catch (Exception e)
            {
                Console.WriteLine("Program cannot run because of this error:\n{0}",e.GetType());
            }
        }
    }

    public class Functions
    {
        private Queue<string> DirDepth = new Queue<string>();
        private Dictionary<string, Int64> directories = new Dictionary<string, Int64>();
        
        public void GetDirectorySize(string[] file, int depthLevel)
        {
            foreach (string i in file)
            {
                int maxDepth = i.Count(x => x == '/');

                if(maxDepth > depthLevel)
                {
                    int lastDoubleColonPos = i.LastIndexOf(':');
                    int lastSlashPos = i.LastIndexOf('/');
                    string directory = "";

                    if (lastDoubleColonPos != -1)
                    {
                        string fullDirPath = i.Substring(0, lastSlashPos);
                        Int64 fileSize = Convert.ToInt64(i.Substring(lastDoubleColonPos + 1));
                        string[] dirLevel = fullDirPath.Split('/');

                        for (int x = 1; x <= depthLevel; x++)
                        {
                            DirDepth.Enqueue(dirLevel[x]);
                        }

                        while (DirDepth.Count > 0)
                        {
                            directory += string.Concat("/" + DirDepth.Dequeue());
                        }
                        
                        if (directories.ContainsKey(directory))
                        {
                            directories[directory] += fileSize;
                        }
                        else
                        {
                            directories.Add(directory, fileSize);
                        }
                    }
                    else
                    {
                        if (!directories.ContainsKey(i))
                            directories.Add(i, 0);
                    }
                }
            }
        }

        public void DisplayDirectorySize()
        {
            foreach (string i in directories.Keys)
                Console.WriteLine("{0}:{1}",i,directories[i]);
        }
    }
}
