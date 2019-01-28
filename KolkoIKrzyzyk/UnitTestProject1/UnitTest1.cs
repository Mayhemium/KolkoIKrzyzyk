using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            char[,] arr = new char[,] { 
                { ' ', ' ', ' ', 'x' }, 
                { ' ', ' ', 'x', 'o' }, 
                { ' ', 'x', 'o', ' ' }, 
                { 'x', 'o', ' ', ' ' } };

            Assert.AreEqual(" ", MatrixLogics.stringTest(arr, 3, 0));
            Assert.AreEqual("  ", MatrixLogics.stringTest(arr, 2, 0));
            Assert.AreEqual("xxxx", MatrixLogics.stringTest(arr,0,0));
            Assert.AreEqual("ooo", MatrixLogics.stringTest(arr, 0, 1));
            Assert.AreEqual(" ", MatrixLogics.stringTest(arr, 0, 3));
        }
    }
}
