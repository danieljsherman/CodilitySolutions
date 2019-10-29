using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    public static class Solutions
    {
        /// <summary>
        /// Given and integer, convert to binary form and get max sequence of zeroes
        /// that are surrounded by ones.
        /// i.e., 20 (10100) returns 1; 4 (100) returns 0; 81 (1010001) returns 3
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public static int GetBinaryGap(int N)
        {
            int maxLength = 0;
            int currentLength = 0;
            string binary = Convert.ToString(N, 2);

            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] == '1')
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

        /// <summary>
        /// Given an array with an odd number of integers and where each of the values, except for one, occur
        /// an even number of times, return the value that occurs an odd number of times.
        /// A.Length is odd and < 1,000,000
        /// Each element is an integer [1..1,000,000]
        /// All but one of the values in A occurs an even number of times
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int OddOccurrencesInArray(int[] A)
        {
            if (A.Length > 1000000 || A.Length % 2 == 0)
                throw new Exception("Incorrect array passed in.");

            Dictionary<int, int> counts = new Dictionary<int, int>();
            
            for (int i = 0; i < A.Length; i++)
            {
                if(!counts.ContainsKey(A[i]))
                {
                    counts.Add(A[i], 0);
                }

                counts[A[i]]++;
            }

            var oddCounts = counts.Where(item => item.Value % 2 == 1);
            if (oddCounts.Count() == 1) return oddCounts.First().Key;

            throw new Exception("Incorrect array passed in.");
        }

        /// <summary>
        /// Write a function:
        /// that, given an array A consisting of N integers and an integer K, returns the array A rotated K times.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int[] CyclicRotation(int[] A, int k)
        {
            if (A.Length <= 1) return A;
            
            for(int i = 0; i < k; i++)
            {
                //shift array one place to the right (wrap around)
                int temp = A[0];
                A[0] = A[A.Length - 1];
                for(int j = A.Length - 1; j > 1; j--)
                {
                    A[j] = A[j - 1];
                }

                A[1] = temp;
            }

            return A;
        }

        /// <summary>
        /// Given three integers X, Y and D, return the minimal number of jumps from position X to a position equal to or greater than Y
        /// i.e., X = 10, Y = 85, D = 30 returns 3 [(10 + 30) = (40 + 30) = (70 + 30) = 100] (there were 3 additions/steps) 
        /// </summary>
        /// <returns></returns>
        public static int FrogJmp(int X, int Y, int D)
        {
            if (X > Y) throw new Exception("Bad Values.");
            if (X > 1000000 || Y > 1000000 || D > 1000000) throw new Exception("Bad Value");

            decimal val = (Y - X) / D;
            return (int)Math.Ceiling(val) + 1;
        }

        public static int SlowFrogJmp(int X, int Y, int D)
        {
            int tally = X;
            int jumps = 0;
            do
            {
                tally += D;
                jumps++;
            } while (tally < Y);

            return jumps;
        }

        /// <summary>
        /// An array A consisting of N different integers is given. The array contains integers in the range [1..(N + 1)], which means that exactly one element is missing.
        /// Return the missing element
        /// Assume: max array size is 100,000; elements are all distinct; each element is within range 1..(N + 1) where N is the size of the array.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int PermMissingElem(int[] A)
        {
            if (A.Length == 0) return 1;

            Array.Sort(A);
            int maxVal = A.Length + 1;
            int index = 0;
            do
            {
                if (A[index] != index + 1) return index + 1;
                index++;
            } while (index < A.Length);

            return maxVal;
        }

        /// <summary>
        /// A non-empty array A consisting of N integers is given. Array A represents numbers on a tape.
        /// Any integer P, such that 0 < P < N, splits this tape into two non-empty parts: 
        /// A[0], A[1], ..., A[P − 1] and A[P], A[P + 1], ..., A[N − 1].
        /// The difference between the two parts is the value of: |(A[0] + A[1] + ... + A[P − 1]) − (A[P] + A[P + 1] + ... + A[N − 1])|
        /// That is, the absolute value of the difference.
        /// Given a non-empty array A of N integers, return the minimal difference that can be achieved.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int TapeEquilibrium(int[] A)
        {
            int leftSum = 0;
            int rightSum = A.Sum();
            int minDifference = Int32.MaxValue;
            
            for(int p = 1; p < A.Length; p++)
            {
                leftSum += A[p - 1];
                rightSum -= A[p - 1];

                int temp = Math.Abs(leftSum - rightSum);
                minDifference = temp < minDifference ? temp : minDifference;
            }

            return minDifference;
        }

        /// <summary>
        /// A non-empty array A consisting of N integers is given.
        /// A permutation is a sequence containing each element from 1 to N once, and only once.
        /// i.e, [1,3,4,2] is a permutation. [3,4,1,5] is not because 2 is missing
        /// Given an array A, return 1 if array A is a permutation and 0 if it is not.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int PermCheck(int[] A)
        {
            //This is the similar to PermMissingElement
            Array.Sort(A);
            for(int i = 0; i < A.Length; i++)
            {
                if (A[i] != (i + 1)) return 0;
            }

            return 1;
        }

        public static int FrogRiverOne(int X, int[] A)
        {
            int[] leaves = new int[X];

            int index = 0;
            
            while(index < A.Length)
            {
                if(A[index] == X)
                {
                    bool found = true;
                    for(int i = 1; i < leaves.Length; i++)
                    {
                        if (leaves[i] != i) found = false;
                    }

                    //if we got this far then the array looks good so just return index
                    if(found) return index;
                }
                else if(A[index] < X)
                {
                    leaves[A[index]] = A[index];
                }

                index++;
            }
            
            return -1;
        }

        public static int FrogRiverOne2(int X, int[] A)
        {
            HashSet<int> steps = new HashSet<int>();
            for(int i = 0; i < A.Length; i++)
            {
                if(A[i] <= X && !steps.Contains(A[i]))
                {
                    steps.Add(A[i]);
                }

                if (steps.Count == X) return i;
            }

            return -1;
        }

        public static int[] MaxCounters(int N, int[] A)
        {
            int[] counters = new int[N];
            int maxCounterValue = 0;

            for(int i = 0; i < A.Length; i++)
            {
                if(A[i] <= N)
                {
                    int counterVal = ++counters[A[i]-1];
                    maxCounterValue = counterVal > maxCounterValue ? counterVal : maxCounterValue;
                }
                else
                {
                    for(int j = 0; j < counters.Length; j++)
                    {
                        counters[j] = maxCounterValue;
                    }
                }
            }

            return counters;
        }

        public static int MissingInteger(int[] A)
        {
            List<int> positiveIntegers = A.Where(item => item > 0).ToList();
            if (positiveIntegers.Count() == 0) return 1;

            positiveIntegers.Sort();
            int index = 1;
            foreach(int i in positiveIntegers)
            {
                if (i != index) return index;
                index++;
            }

            return index;
        }

        public static int MissingInteger2(int[] A)
        {
            Array.Sort(A);
            int index = 1;
            for(int i = 0; i < A.Length; i++)
            {
                if(A[i] > 0)
                {
                    if (A[i] != index) return index;
                    if (i == A.Length - 1) return ++index;
                    if(A[i] < A[i+1])
                    {
                        index++;
                    }
                }
            }

            return index++; ;
        }

        public static int CountDiv(int A, int B, int K)
        {
            int count = 0;
            for (int i = A; i <= B; i++)
            {
                if (i % K == 0) count++;
            }

            return count;
        }

        public static int CountDivBetter(int A, int B, int K)
        {
            if (A % K == 0)
                return (B / K) - (A / K) + 1;

            return (B / K) - (A / K);
        }
    }
}
