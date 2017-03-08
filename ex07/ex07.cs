using System;
using System.Collections.Generic;
using System.IO;

namespace ShadyProgramming
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                if(args.Length == 2)
                {
                    Functions f = new Functions(Int32.Parse(args[1]));

                    using (StreamReader sr = new StreamReader(File.OpenRead(args[0])))
                    {  
                        string line = "";
                        
                        while((line = sr.ReadLine()) != null)  
                        {  
                            f.GetData(line);
                        }
                    }

                    f.DisplaylastNLines(args[0]);
                } else throw new IndexOutOfRangeException();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file {0} does not exist.", args[0]);
            }
            catch (FormatException)
            {
                Console.WriteLine("{0} is not a number, please input in the correct format", args[1]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Incorrect syntax!\nCorrect Usage:" 
                + "<programfile> <textfile> <no of lines>\ne.g.: ./ex07.exe words.txt 15\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("The program encouter this error: {0}", e.Message);
            }
        }
    }

    class Functions
    {
        private Queue<string> lastLines = new Queue<string>();
        private int nLines;
        
        public Functions(int kLines)
        {
            nLines = kLines;
        }
        public void GetData(string line)
        {
            lastLines.Enqueue(line);
            if(lastLines.Count > nLines) 
                lastLines.Dequeue();
        }
        public void DisplaylastNLines(string filename)
        {
            while(lastLines.Count > 0) 
                Console.WriteLine(lastLines.Dequeue());
        }
    }
}
