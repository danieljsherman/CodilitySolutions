using ConsoleApp1;
using System;
using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace SolutionTests
{
    public class SolutionTests
    {
        private readonly ITestOutputHelper _output;

        public SolutionTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData(new int[] { 2,4,2,3,4,2,3,5,5,9})]
        public void TestSolution2WithBadArray(int[] A)
        {
            Assert.Throws<Exception>(() => Solutions.OddOccurrencesInArray(A));
            //Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(new int[] {9, 3, 9, 3, 9, 7, 9}, 7)]
        [InlineData(new int[] {90, 33, 90, 36, 90, 77, 91, 33, 36, 77, 91, 234987, 234987, 234987, 90 }, 234987)]
        public void TestSolution2WithGoodArrays(int[] A, int expectedResult)
        {
            int result = Solutions.OddOccurrencesInArray(A);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(new int[] {1,2,3,4,5,6,7}, 3, new int[] { 5,6,7,1,2,3,4})]
        [InlineData(new int[] {3,8,9,7,6}, 3, new int[] { 9, 7, 6, 3, 8 })]
        public void TestCyclicRotation(int[] A, int k, int[] expected)
        {
            int[] result = Solutions.CyclicRotation(A, k);

            Assert.Equal(expected, result);

        }

        [Theory]
        [InlineData(10, 85, 30, 3)]
        [InlineData(20, 100, 30, 3)]
        [InlineData(5, 100, 20, 5)]
        [InlineData(9, 32, 12, 2)]
        [InlineData(1, 2, 5, 1)]
        [InlineData(1, 1000, 15, 67)]
        [InlineData(1, 1000000, 15, 66667)]
        public void TestFrogJmp(int X, int Y, int D, int expected)
        {
            int result = Solutions.FrogJmp(X, Y, D);
            int badResult = Solutions.SlowFrogJmp(X, Y, D);
            _output.WriteLine(badResult.ToString());
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 2,3,1,5}, 4)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51 }, 37)]
        [InlineData(new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61 }, 1)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 61 }, 60)]
        [InlineData(new int[] { 2, 3, 1, 4, 6 }, 5)]
        [InlineData(new int[] { 2, 3, 5, 4 }, 1)]
        public void TestPermMissingElem(int[] A, int expectedValue)
        {
            int ret = Solutions.PermMissingElem(A);
            Assert.Equal(expectedValue, ret);
        }

        [Theory]
        [InlineData(new int[] { 3,1,2,4,3}, 1)]
        public void TestTapeEquilibrium(int[] A, int expectedValue)
        {
            int ret = Solutions.TapeEquilibrium(A);
            Assert.Equal(expectedValue, ret);
        }

        [Theory]
        [InlineData(new int[] {4,1,3,2}, 1)]
        [InlineData(new int[] {4,1,3}, 0)]
        public void TestPermCheck(int[] A, int expectedValue)
        {
            int ret = Solutions.PermCheck(A);
            Assert.Equal(expectedValue, ret);
        }

        [Theory]
        [InlineData(new int[] { 1, 3, 1, 4, 2, 3, 5, 4 }, 5, 6)]
        [InlineData(new int[] { 5, 3, 1, 4, 2, 3, 5, 4 }, 5, 4)]
        [InlineData(new int[] { 6, 3, 1, 4, 2, 3, 3, 4 }, 5, -1)]
        [InlineData(new int[] { 6, 3, 1, 5, 5, 5, 2, 3, 3, 4 }, 5, 9)]
        [InlineData(new int[] { 1, 3, 1, 3, 2, 1, 3 }   , 3, 4)]
        public void TestFrogRiverOne(int[] A, int X, int expected)
        {
            int ret = Solutions.FrogRiverOne2(X, A);
            Assert.Equal(expected, ret);
        }

        [Theory]
        [InlineData(new int[] { 3,4,4,6,1,4,4}, 5, new int[] { 3,2,2,4,2})]
        //[InlineData(new int[] { 3, 6 }, 5, new int[] { 1, 1, 1, 1, 1 })]
        //[InlineData(new int[] { 6, 6, 6, 6, 6, 6, 6 }, 5, new int[] { 0, 0, 0, 0, 0 })]
        //[InlineData(new int[] { 5, 5, 7, 11, 6, 8, 4, 9, 7, 4, 6, 1, 8, 4, 8, 11, 8, 11, 6, 10, 7, 3, 8, 2, 9, 5, 2, 3, 5 }, 10, new int[] { 6, 8, 8, 6, 8, 7, 7, 7, 7, 7 })]
        public void TestMaxCounters(int[] A, int N, int[] expected)
        {
            int[] ret = Solutions.MaxCounters(N, A);
            Assert.Equal(expected, ret);
        }

        [Theory]
        [InlineData(new int[] { 1,2,3}, 4)]
        [InlineData(new int[] { -1, -2, -3 }, 1)]
        [InlineData(new int[] { 11, 8, 12, 20, 5, 26, 29, 1, 21, 16, 7, 28, 13, 24, 6, 18, 30, 22, 23, 2, 15, 9, 27, 17, 3, 14, 25, 4, 19, 31 }, 10)]
        [InlineData(new int[] { 2 }, 1)]
        [InlineData(new int[] {-98,-81,33,50,56,39,61,38,-46,-6,-100,-73,-24,-73,-62,-98,70,9,56,-52,-24,-80,48,-34,-32,75,-86,69,-16,-58,-22,-89,-76,-62,-15,15,76,9,77,94,-79,36,52,79,-68,75,66,-42,-50,77}, 1)]
        public void TestMissingInteger(int[] A, int expectedValue)
        {
            Stopwatch s = Stopwatch.StartNew();
            int ret = Solutions.MissingInteger(A);
            _output.WriteLine(s.ElapsedMilliseconds.ToString());
            Assert.Equal(expectedValue, ret);
        }

        [Theory]
        [InlineData(6,11,2,3)]
        [InlineData(0, 2000000, 2, 1000001)]
        public void TestCountDiv(int A, int B, int K, int expected)
        {
            int ret = Solutions.CountDiv(A, B, K);
            Assert.Equal(expected, ret);
        }
    }
}
