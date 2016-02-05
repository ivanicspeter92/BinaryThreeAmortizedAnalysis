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
    /// Unit test class for the Node class.
    /// </summary>
    [TestClass()]
    public class NodeTests
    {
        /// <summary>
        /// Tests the initialization of a Node object with simple values.
        /// </summary>
        [TestMethod()]
        public void TestNodeInitialization()
        {
            Node testNode = new Node(1);
            Assert.AreEqual(1, testNode.value);

            testNode = new Node(2);
            Assert.AreEqual(2, testNode.value);

            testNode = new Node(-1);
            Assert.AreEqual(-1, testNode.value);
        }
    }
}