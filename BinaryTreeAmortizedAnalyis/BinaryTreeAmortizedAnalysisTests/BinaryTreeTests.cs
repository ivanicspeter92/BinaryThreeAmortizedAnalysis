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
        #region Initializer tests
        /// <summary>
        /// Tests the initialization of a BinaryTree with a distinct sequence of integers.
        /// </summary>
        [TestMethod()]
        public void testInitializingWithDistinctOrderedArray()
        {
            BinaryTree tree = new BinaryTree(new int[] { 1, 2, 3, 4, 5 });

            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, tree.nodeValues);
            Assert.AreEqual(1, tree.RootNode.value);
            Assert.AreEqual(1, tree.DistinguishedNode.value);
        }

        /// <summary>
        /// Tests the initialization of a BinaryTree with a distinct but not sequential array of integers.
        /// </summary>
        [TestMethod()]
        public void testInitializingWithDistinctNotOrderedArray()
        {
            BinaryTree tree = new BinaryTree(new int[] { 3, 2, 5, 1, 4 });

            CollectionAssert.AreEqual(new int[] { 3, 2, 5, 1, 4 }, tree.nodeValues);
            Assert.AreEqual(3, tree.RootNode.value);
            Assert.AreEqual(1, tree.DistinguishedNode.value);
        }

        /// <summary>
        /// Tests the initialization of a BinaryTree with a not distinct and not sequential array of integers.
        /// </summary>
        [TestMethod()]
        public void testInitializingWithNotDistinctNotOrderedArray()
        {
            BinaryTree tree = new BinaryTree(new int[] { 3, 4, 3, 3, 2, 4, 5, 1, 1, 1 });

            CollectionAssert.AreEqual(new int[] { 3, 4, 2, 5, 1 }, tree.nodeValues);
            Assert.AreEqual(3, tree.RootNode.value);
            Assert.AreEqual(1, tree.DistinguishedNode.value);
        }
        #endregion

            #region IInorderTransversal tests
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