using System;

namespace Code2Pro
{
    class Program
    {
        static void Main(string[] args)
        {
            Functions f = new Functions();
            
            Console.WriteLine(f.IsSuperNumber(args[0]));
        }
    }
    
    class Functions
    {
        public bool IsSuperNumber(string number)
        {
            string flippedNumber = "";

            for (int pos = number.Length - 1; pos >= 0; pos--)
            {
                if (number[pos] == '6')
                    flippedNumber += '9';
                else if (number[pos] == '9')
                    flippedNumber += '6';
                else flippedNumber += number[pos];
            }
            return number.Equals(flippedNumber);
        }
    }
}
