using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Solution(2) + "Expected: 0");
            //Console.WriteLine(Solution(1041) + " Expected: 5");
            //Console.WriteLine(Solution(32) + " Expected: 0");
            //Console.WriteLine(Solution(9) + " Expected: 2");
            //Console.WriteLine(Solution(20) + " Expected: 1");
            //Console.WriteLine(Solution(15) + " Expected: 0");

            Console.WriteLine();
        }

        public static int Solution(int N)
        {
            int maxLength = 0;
            int currentLength = 0;
            string binary = Convert.ToString(N, 2);

            for(int i = 0; i < binary.Length; i++)
            {
                if(binary[i] == '1')
                {
                    maxLength = currentLength > maxLength ? currentLength : maxLength;
                    currentLength = 0;
                }
                else
                {
                    currentLength++;
                }
            }

            return maxLength;
        }

        public static int Solution2(int[] A)
        { 
            for(int i = 0; i < A.Length; i++)
            {
                if(A.Where(item => item == A[i]).Count() == 1)
                {
                    return (A[i]);
                }
            }

            return 0;
        }
    }
}
