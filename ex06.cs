using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ShadyProgramming
{
    class Program
    {
        public static void Main(string[] args)
        {
            try 
            {
                if(args.Count() == 2)
                {   
                    int SIZELIMIT = Int32.Parse(args[1]);
                    Console.WriteLine();

                    Functions f = new Functions(SIZELIMIT);

                    if (File.Exists(args[0]))
                    {
                        var numbers = File.ReadLines(args[0]);
                        foreach (var number in numbers)
                        {
                            f.GetData(Double.Parse(number));
                        }
                    }
                    
                    f.DisplayLargestNum();
                }
                else throw new IndexOutOfRangeException();
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Error: Incorrect usage.\nUsage: <programname> <filename>\ne.g.: /ex06.exe numbers.dat <numbers to display>.");
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
        private int limit;
        private PriorityQueue pq = new PriorityQueue();
        public Functions(int limit)
        {
            this.limit = limit;
        }
        public void GetData(double num)
        {
            pq.EnQueue(num);
            if(pq.biggestNums.Count > 10)
                pq.DeQueue(limit);

        }
        public void DisplayLargestNum()
        {
            foreach (double i in pq.biggestNums)
            {
                Console.Write("{0} ", i);
            }
        }
    }
    class PriorityQueue
    {
        public List<double> biggestNums = new List<double>();
    
        public void EnQueue(double num)
        {
            biggestNums.Add(num);
            int childIdx = biggestNums.Count - 1;

            while (childIdx > 0)
            {
                int parentIdx = (childIdx - 1) / 2;
                if (biggestNums[childIdx] > biggestNums[parentIdx])
                    break;
                else 
                {
                    double temp = biggestNums[parentIdx];
                    biggestNums[parentIdx] = biggestNums[childIdx];
                    biggestNums[childIdx] = temp;
                }
            }
        }

        public void DeQueue (int SIZELIMIT)
        {
            double min = biggestNums[0];
            for(int i = 0; i < SIZELIMIT/2; i ++)
            {
                double leftChild = biggestNums[2*i + 1];
                double righChild = biggestNums[2*i + 2];
                double temp = Math.Min(leftChild, righChild);

                min = Math.Min(temp,min);
            }
            biggestNums.Remove(min);
        }
    }
}
