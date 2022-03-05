using LW_2_13;
using LW_2_14;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LW_2_14Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SelectEmptyStack()
        {
            MyNewStack<Organization> st = new();

            int expected = 0;

            int actual = st.Select(x => x.City == "Magadan").Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SelectNoElements()
        {
            MyNewStack<Organization> st = new();
            st.Push(new Organization("A", "A", 100));
            st.Push(new Organization("B", "A", 100));
            st.Push(new Organization("C", "A", 100));

            int expected = 0;

            int actual = st.Select(x => x.City == "Magadan").Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SelectElements()
        {
            MyNewStack<Organization> st = new();
            st.Push(new Organization("A", "A", 100));
            st.Push(new Organization("B", "Magadan", 100));
            st.Push(new Organization("C", "A", 100));

            int expected = 1;

            int actual = st.Select(x => x.City == "Magadan").Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SelectAllElements()
        {
            MyNewStack<Organization> st = new();
            st.Push(new Organization("A", "Magadan", 100));
            st.Push(new Organization("B", "Magadan", 100));
            st.Push(new Organization("C", "Magadan", 100));

            int expected = 3;

            int actual = st.Select(x => x.City == "Magadan").Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountNoElements()
        {
            MyNewStack<Organization> st = new();

            int expected = 0;

            int actual = st.Count(x => x.City == "Magadan");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Count()
        {
            MyNewStack<Organization> st = new();
            st.Push(new Organization("A", "A", 100));
            st.Push(new Organization("B", "Magadan", 100));
            st.Push(new Organization("C", "A", 100));

            int expected = 1;

            int actual = st.Count(x => x.City == "Magadan");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountAllElements()
        {
            MyNewStack<Organization> st = new();
            st.Push(new Organization("A", "Magadan", 100));
            st.Push(new Organization("B", "Magadan", 100));
            st.Push(new Organization("C", "Magadan", 100));

            int expected = 3;

            int actual = st.Count(x => x.City == "Magadan");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AverageNoElements()
        {
            MyNewStack<Organization> st = new();

            Assert.ThrowsException<Exception>(() => st.Average());
        }

        [TestMethod]
        public void Average()
        {
            MyNewStack<Organization> st = new();
            st.Push(new Organization("A", "Magadan", 100));
            st.Push(new Organization("B", "Magadan", 200));
            st.Push(new Organization("C", "Magadan", 300));

            double expected = 200;

            double actual = st.Average();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MinNoElements()
        {
            MyNewStack<Organization> st = new();

            Assert.ThrowsException<Exception>(() => st.Min());
        }

        [TestMethod]
        public void Min()
        {
            MyNewStack<Organization> st = new();
            st.Push(new Organization("A", "Magadan", 100));
            st.Push(new Organization("B", "Magadan", 200));
            st.Push(new Organization("C", "Magadan", 300));

            double expected = 100;

            double actual = st.Min();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MaxNoElements()
        {
            MyNewStack<Organization> st = new();

            Assert.ThrowsException<Exception>(() => st.Max());
        }

        [TestMethod]
        public void Max()
        {
            MyNewStack<Organization> st = new();
            st.Push(new Organization("A", "Magadan", 100));
            st.Push(new Organization("B", "Magadan", 200));
            st.Push(new Organization("C", "Magadan", 300));

            double expected = 300;

            double actual = st.Max();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SumNoElements()
        {
            MyNewStack<Organization> st = new();

            Assert.ThrowsException<Exception>(() => st.Sum());
        }

        [TestMethod]
        public void Sum()
        {
            MyNewStack<Organization> st = new();
            st.Push(new Organization("A", "Magadan", 100));
            st.Push(new Organization("B", "Magadan", 200));
            st.Push(new Organization("C", "Magadan", 300));

            double expected = 600;

            double actual = st.Sum();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GroupNoElements()
        {
            MyNewStack<Organization> st = new();

            Assert.ThrowsException<Exception>(() => st.Group());
        }

        [TestMethod]
        public void Group1()
        {
            MyNewStack<Organization> st = new();
            st.Push(new Organization("A", "Magadan", 100));
            st.Push(new Organization("B", "Magadan", 200));
            st.Push(new Organization("C", "Moscow", 300));

            int expected = 2;

            int actual = st.Group().Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Group2()
        {
            MyNewStack<Organization> st = new();
            st.Push(new Organization("A", "Khabarovsk", 100));
            st.Push(new Organization("B", "Magadan", 200));
            st.Push(new Organization("C", "Moscow", 300));

            int expected = 3;

            int actual = st.Group().Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Group3()
        {
            MyNewStack<Organization> st = new();
            st.Push(new Organization("A", "Magadan", 100));
            st.Push(new Organization("B", "Magadan", 200));
            st.Push(new Organization("C", "Magadan", 300));

            int expected = 1;

            int actual = st.Group().Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToMyNewStack()
        {
            MyNewStack<Organization> st = new();
            st.Push(new Organization("A", "Magadan", 100));
            st.Push(new Organization("B", "Magadan", 200));
            st.Push(new Organization("C", "Magadan", 300));

            List<Organization> l = new();
            l.Add(new Organization("A", "Magadan", 100));
            l.Add(new Organization("B", "Magadan", 200));
            l.Add(new Organization("C", "Magadan", 300));

            bool expected = true;

            bool actual = l.ToMyNewStack().Equals(st);

            Assert.AreEqual(expected, actual);
        }
    }
}