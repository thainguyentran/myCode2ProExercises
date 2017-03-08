using System;
using System.Numerics;
namespace code2pro
{
    public class Solution
    {
        public static void Main (string[] args)
        {
            Functions f = new Functions();
            Console.WriteLine(f.fibonacci(92));  
        }
    }
    public class Functions
    {
        public BigInteger fibonacci(int n)
        {
            BigInteger first = 1;
            BigInteger second = 1;

            for(int i = 2; i <= n; i++)
            {
                BigInteger third = first + second;
                first = second;
                second = third;
            }
            return second;
        }
    }
}
