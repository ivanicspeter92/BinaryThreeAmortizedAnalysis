using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTreeAmortizedAnalyis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeAmortizedAnalyis.Tests
{
    [TestClass()]
    public class BinaryTreeTests
    {
        /// <summary>
        /// Tests the initialization of a BinaryTree with a distinct sequence of integers.
        /// </summary>
        [TestMethod()]
        public void testInitializingWithDistinctOrderedArray()
        {
            BinaryTree tree = new BinaryTree(new int[] { 1, 2, 3, 4, 5 });

            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, tree.nodeValues);
        }

        #region IInorderTransversalTests
        [TestMethod()]
        public void inorderFirstTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void inorderNextTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void isInorderTransversalFinishedTest()
        {
            Assert.Fail();
        }
        #endregion
    }
}