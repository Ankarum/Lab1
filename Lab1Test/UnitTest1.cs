using System;
using Lab1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab1Test
{
    [TestClass]
    public class Lab1Test
    {
        [TestMethod]
        public void AddTests()
        {
            MyList<int> testList = new MyList<int>();
            testList.Add(1);
            testList.Add(2);
            testList.Add(65);
            testList.Add(3);
            testList.Add(8);
            Assert.AreEqual(testList.ToString(), "[1, 2, 65, 3, 8]");
        }

        [TestMethod]
        public void RemoveTests()
        {
            MyList<int> testList = new MyList<int>();
            testList.Add(1);
            testList.Add(2);
            testList.Add(65);
            testList.Add(3);
            testList.Add(8);
            testList.Add(3);
            testList.Add(19);
            testList.Remove(3);
            Assert.AreEqual(testList.ToString(), "[1, 2, 65, 8, 3, 19]");
        }

        [TestMethod]
        public void RemoveAtTests()
        {
            MyList<int> testList = new MyList<int>();
            testList.Add(1);
            testList.Add(2);
            testList.Add(65);
            testList.Add(3);
            testList.Add(8);
            testList.RemoveAt(2);
            Assert.AreEqual(testList.ToString(), "[1, 2, 3, 8]");
            testList.RemoveAt(3);
            Assert.AreEqual(testList.ToString(), "[1, 2, 3]");
            testList.RemoveAt(0);
            Assert.AreEqual(testList.ToString(), "[2, 3]");
            testList.RemoveAt(1);
            Assert.AreEqual(testList.ToString(), "[2]");
            testList.RemoveAt(0);
            Assert.AreEqual(testList.ToString(), "[]");
        }

        [TestMethod]
        public void IndexGetSetTests()
        {
            MyList<int> testList = new MyList<int>();
            testList.Add(1);
            testList.Add(2);
            testList.Add(65);
            testList.Add(3);
            testList.Add(8);
            testList[2] = 17;
            Assert.AreEqual(testList.ToString(), "[1, 2, 17, 3, 8]");
            Assert.AreEqual(3, testList[3]);
        }

        [TestMethod]
        public void IndexOfTests()
        {
            MyList<int> testList = new MyList<int>();
            testList.Add(1);
            testList.Add(2);
            testList.Add(65);
            testList.Add(3);
            testList.Add(8);
            Assert.AreEqual(2, testList.IndexOf(65));
        }

        [TestMethod]
        public void InsertTests()
        {
            MyList<int> testList = new MyList<int>();
            testList.Add(1);
            testList.Add(2);
            testList.Add(65);
            testList.Add(3);
            testList.Add(8);
            testList.Insert(3, 66);
            Assert.AreEqual(testList.ToString(), "[1, 2, 65, 66, 3, 8]");
        }

        [TestMethod]
        public void ContainsTests()
        {
            MyList<int> testList = new MyList<int>();
            testList.Add(1);
            testList.Add(2);
            testList.Add(65);
            testList.Add(3);
            testList.Add(8);
            Assert.AreEqual(true, testList.Contains(3));
            Assert.AreEqual(false, testList.Contains(81));
        }

        [TestMethod]
        public void CountTests()
        {
            MyList<int> testList = new MyList<int>();
            Assert.AreEqual(0, testList.Count);
            testList.Add(56);
            testList.Add(14);
            Assert.AreEqual(2, testList.Count);
            testList.Remove(56);
            Assert.AreEqual(1, testList.Count);
            testList.RemoveAt(0);
            Assert.AreEqual(0, testList.Count);
            testList.Insert(0, 7);
            Assert.AreEqual(1, testList.Count);
            testList.Clear();
            Assert.AreEqual(0, testList.Count);
        }
    }
}
