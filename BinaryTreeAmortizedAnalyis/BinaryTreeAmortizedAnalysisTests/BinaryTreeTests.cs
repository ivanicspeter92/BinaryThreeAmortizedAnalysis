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
            this.exampleTree = new BinaryTree(new int[] { 3, 2, 7, 1, 5, 4, 6, 8 });
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
        public void testTransverse()
        {
            for (int i = 1; i < this.exampleTree.nodeValues.Length; i++)
            {
                Assert.IsFalse(exampleTree.isInorderTransversalFinished());
                Assert.AreEqual(i, this.exampleTree.DistinguishedNode.value);
                this.exampleTree.inorderNext();
            }
            // the transverse should be finished at this point
            Assert.IsTrue(exampleTree.isInorderTransversalFinished()); // calling inorderNext() should keep the tree in the last state.
            this.exampleTree.inorderNext();
            Assert.AreEqual(8, this.exampleTree.DistinguishedNode.value);
            this.exampleTree.inorderNext();
            Assert.AreEqual(8, this.exampleTree.DistinguishedNode.value);
        }

        /// <summary>
        /// Tests transversing the exampleTree class variable. Walks through and validates the 8 states of the tree, then resets the tree to its original state and transverses it again.
        /// </summary>
        [TestMethod()]
        public void testTransverseTwoTimes()
        {
            int i = 1;
            while (this.exampleTree.isInorderTransversalFinished() == false)
            {
                Assert.IsFalse(exampleTree.isInorderTransversalFinished());
                Assert.AreEqual(i, this.exampleTree.DistinguishedNode.value);
                this.exampleTree.inorderNext();
                i++;
            }
            Assert.IsTrue(exampleTree.isInorderTransversalFinished());
            this.exampleTree.inorderFirst();
            Assert.IsFalse(exampleTree.isInorderTransversalFinished());

            i = 1;
            while (this.exampleTree.isInorderTransversalFinished() == false)
            {
                Assert.IsFalse(exampleTree.isInorderTransversalFinished());
                Assert.AreEqual(i, this.exampleTree.DistinguishedNode.value);
                this.exampleTree.inorderNext();
                i++;
            }
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

        /// <summary>
        /// Initializes a BinaryTree with 10 Nodes. Validates, that the node values are unique, the lowest Node value is 0 and the highest Node value is 10.
        /// </summary>
        [TestMethod()]
        public void testInitializingWithTenRandomNodes()
        {
            BinaryTree treeWithTenNodes = new BinaryTree(10);

            Assert.AreEqual(treeWithTenNodes.nodeValues.Length, 10);
            Assert.AreEqual(treeWithTenNodes.nodeValues.Min(), 1);
            Assert.AreEqual(treeWithTenNodes.nodeValues.Max(), 10);
        }

        /// <summary>
        /// Initializes a BinaryTree with more than 100 Nodes. Validates, that the generated tree is NOT sequential.
        /// </summary>
        [TestMethod()]
        public void testIfRandomNodeInitializerGeneratesNonSequentialArray()
        {
            BinaryTree treeWithTenNodes = new BinaryTree(100);
            
            for (int i = 0; i < treeWithTenNodes.nodeValues.Length - 1; i++)
            {
                if (treeWithTenNodes.nodeValues[i] > treeWithTenNodes.nodeValues[i + 1])
                    return;
            }

            Assert.Fail("The binary tree of 100 random Nodes was sequential");
        }

        /// <summary>
        /// Tests the transverse of custom, complex tree.
        /// </summary>
        [TestMethod()]
        public void testTransverseComplexTree()
        {
            BinaryTree tree = new BinaryTree(new int[] { 14, 8, 6, 4, 2, 7, 9, 11, 13, 25, 15, 18, 17, 29, 28, 30, 31 });
            int[] transverseOrder = new int[] { 2, 4, 6, 7, 8, 9, 11, 13, 14, 15, 17, 18, 25, 28, 29, 30, 31 };

            Assert.AreEqual(14, tree.RootNode.value);

            for (int i = 0; i < transverseOrder.Length; i++)
            {
                Assert.AreEqual(transverseOrder[i], tree.DistinguishedNode.value);
                tree.inorderNext();
            }            
        }
        #endregion

        #region Tests for random trees
       
        #endregion
        }
}