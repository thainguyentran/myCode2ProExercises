using System;
using System.IO;
using System.Collections.Generic;

namespace ShadyProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if(args.Length == 1)
                {
                    string[] text = File.ReadAllLines(args[0]);
                    
                    Functions f = new Functions();
                    Console.WriteLine(f.CheckBrackets(text));
                }
                else 
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("ERROR: Please enter a correct filename");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Incorrect Usage!\nCorrect Usage: <Program name> <filename> e.g.:\n./ex04.exe sample.cpp\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("Program cannot run because of this error:\n{0}",e);
            }
        }
    }
    class Functions
    {
        const string UNMATCHED = "UNMATCHED";
        const string ALLMATCHING = "ALL-MATCHING";
        const string NOWORRIES = "NO-WORRIES";
        private bool NoBrackets = true;
        private Stack<char> brackets = new Stack<char>();

        public string CheckBrackets(string[] text)
        {      
            foreach(string line in text)
            {
                if(line.IndexOfAny("{}[]()".ToCharArray()) != -1)
                {
                    foreach(char i in line)
                    {
                        if(i == '{' || i == '(' || i == '[')
                        {    
                            brackets.Push(i);
                            NoBrackets = false;
                        }
                        if(i == '}' || i == ')' || i == ']')
                        {
                            if(brackets.Count == 0)
                                return UNMATCHED;
                            else
                            {
                                char leftBrackets = brackets.Pop();

                                if((i == '}' && leftBrackets != '{')
                                || (i == ')' && leftBrackets != '(') 
                                || (i == ']' && leftBrackets != '['))
                                    return UNMATCHED;
                            }
                        }    
                    }
                }
                
            }
            if(NoBrackets)
                return NOWORRIES;
            if(brackets.Count == 0)
                return ALLMATCHING;
            else 
                return UNMATCHED;
        }
    }
}
