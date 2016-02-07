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
        /// A test BinaryTree object to be used for the unit tests.
        /// </summary>
        BinaryTree exampleTree;

        /// <summary>
        /// Initializes the exampleTree class variable before running each test in the class.
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
            this.exampleTree = new BinaryTree(new int []{ 3, 2, 7, 1, 5, 4, 6, 8 });
        }       

        #region Tests for the exampleTree class variable.
        /// <summary>
        /// Tests the initialization method of a BinaryTree class for the exampleTree class variable.
        /// </summary>
        [TestMethod()]
        public void testExampleTreeInitialization()
        {
            CollectionAssert.AreEqual(new int[] { 3, 2, 7, 1, 5, 4, 6, 8 }, this.exampleTree.nodeValues);
            Assert.AreEqual(3, this.exampleTree.RootNode.value);
            Assert.AreEqual(1, this.exampleTree.DistinguishedNode.value);
        }

        /// <summary>
        /// Tests the inorderNext() function for the exampleTree class variable. Walks through and validates the 8 states of the tree.
        /// </summary>
        [TestMethod()]
        public void testInorderNext()
        {
            Assert.AreEqual(1, this.exampleTree.DistinguishedNode.value);
            this.exampleTree.inorderNext();
            Assert.AreEqual(2, this.exampleTree.DistinguishedNode.value);
            this.exampleTree.inorderNext();
            Assert.AreEqual(3, this.exampleTree.DistinguishedNode.value);
            this.exampleTree.inorderNext();
            Assert.AreEqual(4, this.exampleTree.DistinguishedNode.value);
            this.exampleTree.inorderNext();
            Assert.AreEqual(5, this.exampleTree.DistinguishedNode.value);
            this.exampleTree.inorderNext();
            Assert.AreEqual(6, this.exampleTree.DistinguishedNode.value);
            this.exampleTree.inorderNext();
            Assert.AreEqual(7, this.exampleTree.DistinguishedNode.value);
            this.exampleTree.inorderNext();
            Assert.AreEqual(8, this.exampleTree.DistinguishedNode.value);
            // the transverse should be finished at this point
            Assert.IsTrue(exampleTree.isInorderTransversalFinished()); // calling inorderNext() should keep the tree in the last state.
            this.exampleTree.inorderNext();
            Assert.AreEqual(8, this.exampleTree.DistinguishedNode.value);
            this.exampleTree.inorderNext();
            Assert.AreEqual(8, this.exampleTree.DistinguishedNode.value);
        }

        [TestMethod()]
        public void testInorderFirst()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void isInorderTransversalFinishedTest()
        {
            Assert.Fail();
        }
        #endregion

        #region Other tests
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
    }
}