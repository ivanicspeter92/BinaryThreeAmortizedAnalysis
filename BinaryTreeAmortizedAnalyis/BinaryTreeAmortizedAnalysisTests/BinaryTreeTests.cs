using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTreeAmortizedAnalyis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

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
        /// Tests the initialization method of a BinaryTree class for the exampleTree class variable. Validates the correctness of the BinaryTree Node structure, values and ranks.
        /// </summary>
        [TestMethod()]
        public void testExampleTreeInitialization()
        {
            CollectionAssert.AreEqual(new int[] { 3, 2, 7, 1, 5, 4, 6, 8 }, this.exampleTree.nodeValues);
            Assert.AreEqual(3, this.exampleTree.DistinguishedNode.value); // checking if the distinguished node is the root node after the initialization

            // going through the Node values and ranks
            BinaryTreeNode rootNode = this.exampleTree.RootNode;

            Assert.AreEqual(3, rootNode.value);
            Assert.AreEqual(0, rootNode.rank);

            Assert.AreEqual(2, rootNode.leftChild.value);
            Assert.AreEqual(-1, rootNode.leftChild.rank);

            Assert.AreEqual(1, rootNode.leftChild.leftChild.value);
            Assert.AreEqual(-2, rootNode.leftChild.leftChild.rank);

            Assert.AreEqual(7, rootNode.rightChild.value);
            Assert.AreEqual(1, rootNode.rightChild.rank);

            Assert.AreEqual(5, rootNode.rightChild.leftChild.value);
            Assert.AreEqual(0, rootNode.rightChild.leftChild.rank);

            Assert.AreEqual(4, rootNode.rightChild.leftChild.leftChild.value);
            Assert.AreEqual(-1, rootNode.rightChild.leftChild.leftChild.rank);

            Assert.AreEqual(6, rootNode.rightChild.leftChild.rightChild.value);
            Assert.AreEqual(1, rootNode.rightChild.leftChild.rightChild.rank);

            Assert.AreEqual(8, rootNode.rightChild.rightChild.value);
            Assert.AreEqual(2, rootNode.rightChild.rightChild.rank);
        }

        /// <summary>
        /// Tests the inorderNext() function for the exampleTree class variable. Walks through and validates the 8 states of the tree.
        /// </summary>
        [TestMethod()]
        public void testExampleTreeTransversal()
        {
            this.exampleTree.inorderFirst();
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
        public void testExampleTreeTransversalTwoTimes()
        {
            int i = 1;
            this.exampleTree.inorderFirst();
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
            this.exampleTree.inorderFirst();
            while (this.exampleTree.isInorderTransversalFinished() == false)
            {
                Assert.IsFalse(exampleTree.isInorderTransversalFinished());
                Assert.AreEqual(i, this.exampleTree.DistinguishedNode.value);
                this.exampleTree.inorderNext();
                i++;
            }
        }

        /// <summary>
        /// Tests calculating the amortized complexity the exampleTree class variable. 
        /// </summary>
        [TestMethod()]
        public void testExampleTreeAmortizedComplexity()
        {
            // number of nodes = 8
            // a = 2*(n - 1) = 2*( 8 - 1) = 14
            Assert.AreEqual(14, this.exampleTree.calculateAmortizedComplexity());
        }
            #endregion

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
            Assert.AreEqual(3, tree.DistinguishedNode.value);
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
            Assert.AreEqual(3, tree.DistinguishedNode.value);
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
            BinaryTree treeWithHundredNodes = new BinaryTree(100);
            
            for (int i = 0; i < treeWithHundredNodes.nodeValues.Length - 1; i++)
            {
                if (treeWithHundredNodes.nodeValues[i] > treeWithHundredNodes.nodeValues[i + 1])
                    return;
            }

            Assert.Fail("The binary tree of 100 random Nodes was sequential");
        }
        #endregion

        #region Transverse tests
        /// <summary>
        /// Tests the transverse of custom, complex tree.
        /// </summary>
        [TestMethod()]
        public void testTransverseComplexTree()
        {
            BinaryTree tree = new BinaryTree(new int[] { 14, 8, 6, 4, 2, 7, 9, 11, 13, 25, 15, 18, 17, 29, 28, 30, 31 });
            int[] transverseOrder = new int[] { 2, 4, 6, 7, 8, 9, 11, 13, 14, 15, 17, 18, 25, 28, 29, 30, 31 };

            Assert.AreEqual(14, tree.RootNode.value);

            tree.inorderFirst();
            for (int i = 0; i < transverseOrder.Length; i++)
            {
                Assert.AreEqual(transverseOrder[i], tree.DistinguishedNode.value);
                tree.inorderNext();
            }            
        }

        /// <summary>
        /// Tests the transverse of random tree with 100 Nodes.
        /// </summary>
        [TestMethod()]
        public void testTransverseRandomTreeOfHundredNodes()
        {
            BinaryTree tree = new BinaryTree(100); // will generate Nodes with values [1, 100] in random order

            tree.inorderFirst();
            for (int i = 1; i < tree.nodeValues.Length + 1; i++)
            {
                Assert.AreEqual(i, tree.DistinguishedNode.value, "Assertion failed, tree node values: " + string.Join(" ", tree.nodeValues));
                tree.inorderNext();
            }
        }

        /// <summary>
        /// Test for a problematic sequence of integers that was randomly generated and cought on the testTransverseRandomTreeOfHundredNodes().
        /// </summary>
        [TestMethod()]
        public void testTransverseProblematicTreeOfHundredNodes()
        {
            BinaryTree tree = new BinaryTree(new int[] { 61, 33, 9, 81, 22, 75, 45, 8, 16, 54, 4, 66, 63, 53, 62, 48, 14, 90, 1, 38, 80, 28, 44, 68, 76, 82, 69, 93, 96, 71, 98, 31, 100, 41, 84, 35, 24, 51, 73, 47, 6, 20, 23, 7, 37, 94, 97, 70, 58, 91, 17, 57, 78, 13, 32, 50, 18, 34, 87, 79, 85, 27, 46, 39, 83, 30, 3, 36, 42, 67, 26, 40, 5, 25, 12, 10, 74, 19, 15, 2, 29, 60, 65, 86, 64, 11, 52, 77, 59, 95, 99, 72, 89, 88, 92, 49, 43, 56, 55, 21 });

            tree.inorderFirst();
            for (int i = 1; i < tree.nodeValues.Length + 1; i++)
            {
                Assert.AreEqual(i, tree.DistinguishedNode.value);
                tree.inorderNext();
            }
        }

        /// <summary>
        /// Tests the amortized complexity calculation of a random tree with 100 Nodes.
        /// </summary>
        [TestMethod()]
        public void testCalculateAmortizedComplexityOfRandomTreeOfHundredNodes()
        {
            BinaryTree tree = new BinaryTree(100); // will generate Nodes with values [1, 100] in random order
            Assert.AreEqual(2 * (tree.nodeValues.Length - 1), tree.calculateAmortizedComplexity()); // the complexity is always 2*(n-1)
        }

        /// <summary>
        /// Tests the amortized complexity calculations of random trees with random number of Nodes and iterations in a loop. Allows to write the results to file.
        /// </summary>
        [TestMethod()]
        public void testCalculateAmortizedComplexityOfRandomTreesInLoop()
        {
            int minNumberOfNodes = 50, maxNumberOfNodes = 100, numberOfTrees = 50;
            bool writeResultsToFile = true;
            FileStream fs = new FileStream("./amortizedAnalysisResults.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            Random rnd = new Random();

            if (minNumberOfNodes > maxNumberOfNodes || minNumberOfNodes < 0 || maxNumberOfNodes < 1 || numberOfTrees < 1)
                Assert.Fail("The configuration is incorrect");

            for (int i = 0; i < numberOfTrees; i++)
            {
                Debug.WriteLine("-----------------------------------------------------------------");
                var numberOfNodes = rnd.Next(minNumberOfNodes, maxNumberOfNodes);
                Debug.WriteLine("Generating " + numberOfTrees + " random trees with " + numberOfNodes + " Nodes");
                BinaryTree tree = new BinaryTree(numberOfNodes);

                Debug.WriteLine("Tree was generated from the following values: { " + string.Join(",", tree.nodeValues) + "} (" + tree.nodeValues.Length + " nodes)");

                int amortizedComplexity = tree.calculateAmortizedComplexity();
                Assert.AreEqual(2 * (tree.nodeValues.Length - 1), amortizedComplexity); // the complexity is always 2*(n-1)

                Debug.WriteLine("Amortized complexity: " + amortizedComplexity);
                Debug.WriteLine("Is amortized complexity right: " + (2 * (tree.nodeValues.Length - 1) == amortizedComplexity).ToString());

                if (writeResultsToFile)
                    sw.WriteLine(tree.nodeValues.Length + "," + amortizedComplexity);                
            }
            sw.Close();
            fs.Close();
        }
            #endregion
        }
}