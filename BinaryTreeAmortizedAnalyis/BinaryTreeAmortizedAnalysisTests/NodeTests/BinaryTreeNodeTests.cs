using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTreeAmortizedAnalyis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeAmortizedAnalyis.Tests
{
    /// <summary>
    /// Unit test class for the BinaryTreeNode class.
    /// </summary>
    [TestClass()]
    public class BinaryTreeNodeTests
    {
        /// <summary>
        /// Tests the initialization of a BinaryTreeNode object with value only. The TreeNode should not have parent, children and the visited flag is expected to be false.
        /// </summary>
        [TestMethod()]
        public void TestBinaryTreeNodeInitializationWithoutParent()
        {
            BinaryTreeNode testNode = new BinaryTreeNode(1);
            Assert.AreEqual(1, testNode.value);
            Assert.IsNull(testNode.parentNode);
            Assert.IsNull(testNode.leftChild);
            Assert.IsNull(testNode.rightChild);
            Assert.IsFalse(testNode.isVisited());
        }

        /// <summary>
        /// Tests the parent-child connection between two newly initialzied BinaryTreeNode objects.
        /// The value of the child is bigger than the parent and therefore the parent sees the child as child on the right.
        /// </summary>
        [TestMethod()]
        public void TestBinaryTreeNodeInitializationRightChildOnly()
        {
            BinaryTreeNode parentNode = new BinaryTreeNode(1);
            BinaryTreeNode childNode = new BinaryTreeNode(2, parentNode);

            Assert.IsNull(parentNode.parentNode);
            Assert.AreNotEqual(parentNode, childNode);
            // checking if the child knows about the parent
            Assert.AreEqual(childNode.parentNode, parentNode);
            Assert.AreEqual(1, childNode.parentNode.value);
            // checking if the child knows about the child correctly
            Assert.IsNull(parentNode.leftChild);
            Assert.IsNotNull(parentNode.rightChild);
            Assert.AreEqual(parentNode.rightChild, childNode);            
        }

        /// <summary>
        /// Tests the parent-child connection between two newly initialzied BinaryTreeNode objects.
        /// The value of the child is smaller than the parent and therefore the parent sees the child as child on the left.
        /// </summary>
        [TestMethod()]
        public void TestBinaryTreeNodeInitializationLeftChildOnly()
        {
            BinaryTreeNode parentNode = new BinaryTreeNode(2);
            BinaryTreeNode childNode = new BinaryTreeNode(1, parentNode);

            Assert.IsNull(parentNode.parentNode);
            Assert.AreNotEqual(parentNode, childNode);
            // checking if the child knows about the parent
            Assert.AreEqual(childNode.parentNode, parentNode);
            Assert.AreEqual(2, childNode.parentNode.value);
            // checking if the child knows about the child correctly
            Assert.IsNotNull(parentNode.leftChild);
            Assert.IsNull(parentNode.rightChild);
            Assert.AreEqual(parentNode.leftChild, childNode);            
        }

        /// <summary>
        /// Tests the parent-child connection between three newly initialzied BinaryTreeNode objects.
        /// The value of one of the children should be smaller, the other one bigger so both the left and right child of the parent gets initialized.
        /// </summary>
        [TestMethod()]
        public void TestBinaryTreeNodeInitializationBothChildren()
        {
            BinaryTreeNode parentNode = new BinaryTreeNode(2);
            BinaryTreeNode leftChildNode = new BinaryTreeNode(1, parentNode);
            BinaryTreeNode rightChildNode = new BinaryTreeNode(3, parentNode);

            // asserting the left child
            Assert.AreEqual(leftChildNode, parentNode.leftChild);
            Assert.AreEqual(leftChildNode.value, parentNode.leftChild.value);
            Assert.AreEqual(parentNode, leftChildNode.parentNode);

            // asserting the right child
            Assert.AreEqual(rightChildNode, parentNode.rightChild);
            Assert.AreEqual(rightChildNode.value, parentNode.rightChild.value);
            Assert.AreEqual(parentNode, rightChildNode.parentNode);
        }

        /// <summary>
        /// Tests that creating connection between two BinaryTreeNode objects with the same value is not possible.
        /// </summary>
        [TestMethod()]
        public void TestConnectingTwoNodesWithSameValueIsNotPossible()
        {
            BinaryTreeNode parentNode = new BinaryTreeNode(1);
            BinaryTreeNode childNode = new BinaryTreeNode(1, parentNode);

            Assert.IsNull(parentNode.leftChild);
            Assert.IsNull(parentNode.rightChild);
            Assert.IsNull(childNode.parentNode);
        }

        /// <summary>
        /// Tests visiting a BinaryTreeNode object. Before visiting the value of the visited flag should be false; after visiting, the value of the visited flag should be true. 
        /// </summary>
        [TestMethod()]
        public void TestIsVisited()
        {
            BinaryTreeNode testNode = new BinaryTreeNode(1);

            Assert.IsFalse(testNode.isVisited());
            testNode.visit();
            Assert.IsTrue(testNode.isVisited());
        }

        /// <summary>
        /// Tests the isLeftChild() method.
        /// </summary>
        [TestMethod()]
        public void testIsLeftChild()
        {
            BinaryTreeNode rootNode = new BinaryTreeNode(2);
            BinaryTreeNode leftChild = new BinaryTreeNode(1, rootNode);
            BinaryTreeNode rightChild = new BinaryTreeNode(3, rootNode);

            Assert.IsFalse(rootNode.isLeftChild());
            Assert.IsTrue(leftChild.isLeftChild());
            Assert.IsFalse(rightChild.isLeftChild());
        }

        /// <summary>
        /// Tests the isRightChild() method.
        /// </summary>
        [TestMethod()]
        public void testIsRightChild()
        {
            BinaryTreeNode rootNode = new BinaryTreeNode(2);
            BinaryTreeNode leftChild = new BinaryTreeNode(1, rootNode);
            BinaryTreeNode rightChild = new BinaryTreeNode(3, rootNode);

            Assert.IsFalse(rootNode.isRightChild());
            Assert.IsFalse(leftChild.isRightChild());
            Assert.IsTrue(rightChild.isRightChild());
        }
    }
}