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
    /// Unit test class for the TreeNode class.
    /// </summary>
    [TestClass()]
    public class TreeNodeTests
    {
        /// <summary>
        /// Tests the initialization of a TreeNode object with value only. The TreeNode should not have parents.
        /// </summary>
        [TestMethod()]
        public void TestTreeNodeInitializationWithoutParent()
        {
            TreeNode testNode = new TreeNode(1);
            Assert.AreEqual(1, testNode.value);
            Assert.IsNull(testNode.parentNode);

            testNode = new TreeNode(2);
            Assert.AreEqual(2, testNode.value);
            Assert.IsNull(testNode.parentNode);

            testNode = new TreeNode(-1);
            Assert.AreEqual(-1, testNode.value);
            Assert.IsNull(testNode.parentNode);
        }

        /// <summary>
        /// Tests the initialization of a TreeNode object with value and parent TreeNode.
        /// The child should know about its parent.
        /// </summary>
        [TestMethod()]
        public void TestTreeNodeInitialization()
        {
            TreeNode parentNode = new TreeNode(1);
            TreeNode childNode = new TreeNode(2, parentNode);

            Assert.IsNull(parentNode.parentNode);
            Assert.AreNotEqual(parentNode, childNode);
            Assert.AreEqual(childNode.parentNode, parentNode);
            Assert.AreEqual(1, childNode.parentNode.value);
        }
    }
}