using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ShadyProgramming
{
    class Programs
    {
        public static void Main(string[] args)
        {
            
            try 
            {
                if(args.Length == 2)
                {  
                    List<string> censorFile = new List<string>();
                    List<string> textFile = new List<string>();
                    
                    using (StreamReader sr = new StreamReader(File.OpenRead(args[0])))
                    {
                        string cWords = "";

                        while ((cWords = sr.ReadLine()) != null)
                        {
                            censorFile.Add(cWords);
                        }
                    }

                    using (StreamReader sr = new StreamReader(File.OpenRead(args[1])))
                    {
                        string line = "";

                        while ((line = sr.ReadLine()) != null)
                        {
                            textFile.Add(line);
                        }
                    }

                    Functions f = new Functions();
                    f.Init(censorFile, textFile);
                    f.Censor();
                    f.PrintResult();
                }
                else 
                    throw new IndexOutOfRangeException();
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Error: Incorrect usage.\nUsage: <programname> <censorfile> <textfile>\ne.g.: /ex11.exe censor.dat document.txt.");
            }
            catch (FormatException)
            {
                Console.WriteLine("File is empty or data is not in a correct format.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Please make sure the filename is correct.");
            }
            catch (Exception e)
            {
                Console.WriteLine("The file encounter this problem: {0}", e.Message);
            }
        }
    }

    class Functions
    {
        SortedDictionary<int, string> censoredWordsCount = new SortedDictionary<int, string>();
        string[] wordsToCensor = null;
        string[] text = null;
        List<string> censoredText = new List<string>();

        public void Init(List<string> CensorWords, List<string> textFile)
        {
            wordsToCensor = CensorWords.ToArray();
            text = textFile.ToArray();

            foreach (string word in wordsToCensor)
            {
                int len = word.Length;

                if (!censoredWordsCount.ContainsKey(len))
                {
                    string censored = word.Replace(word, new string('*', len));

                    censoredWordsCount.Add(len, censored);
                }
            }
        }

        public void Censor ()
        {
            foreach (string line in text)
            {
                if (line != "")
                {
                    string censoredLine = line;

                    foreach (string word in wordsToCensor)
                    {
                        if (censoredLine.Contains(word))
                        {
                            string pattern = String.Format(@"\b{0}\b", word);

                            censoredLine = Regex.Replace(censoredLine, pattern, censoredWordsCount[word.Length]);
                        }
                    }
                    censoredText.Add(censoredLine);
                }
            }
        }

        public void PrintResult()
        {
            foreach (string line in censoredText)
                Console.WriteLine(line);
        }
    }
}
