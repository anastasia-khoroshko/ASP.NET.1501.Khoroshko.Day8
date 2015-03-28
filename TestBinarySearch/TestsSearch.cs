using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinarySearch;

namespace TestBinarySearch
{
    [TestClass]
    public class TestsSearch
    {
        [TestMethod]
        public void TestBinarySearchInt()
        {
            int[] array = new int[] { 5, 1, 8, 6, 8, 2, 2 };
            int itemSerch = 6;
            int expected = 4;
            Assert.AreEqual(BinarySearch<int>.Search(array, itemSerch, delegate(int x, int y) { return x.CompareTo(y); }), expected);
        }
        [TestMethod]
        public void TestBinarySearchDouble()
        {
            double[] array = new double[] { 5.9, 1.8, 8.7, 6.9, 8.7, 2.2, 2.0 };
            double itemSerch = 6.0;
            double expected = -1;
            Assert.AreEqual(BinarySearch<double>.Search(array, itemSerch, delegate(double x, double y) { return x.CompareTo(y); }), expected);
        }
        [TestMethod]
        public void TestBinarySearchChar()
        {
            char[] array = new char[] { 'a', 'c', 'a', 'z', 'p', 'x', 'c' };
            char itemSerch ='z';
            double expected = 6;
            Assert.AreEqual(BinarySearch<char>.Search(array, itemSerch, delegate(char x, char y) { return x.CompareTo(y); }), expected);
        }

        [TestMethod]
        public void TestBinarySearchString()
        {
            string[] array = new string[] { "cat", "tiger", "apple", "pie"};
            string itemSerch = "apple";
            double expected = 0;
            Assert.AreEqual(BinarySearch<string>.Search(array, itemSerch, delegate(string x, string y) { return x.CompareTo(y); }), expected);
        }
    }
}
