using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeAmortizedAnalyis
{
    /// <summary>
    /// A class representing a binary tree.
    /// </summary>
    public class BinaryTree : IInorderTransversal
    {
        /// <summary>
        /// The array containing the sequence of the values in the tree.
        /// </summary>
        public int[] nodeValues { get; }

        /// <summary>
        /// The distinguished Node of the BinaryTree during its inorder transverse.
        /// </summary>
        private BinaryTreeNode distinguishedNode;

        /// <summary>
        /// Read only property for the distinguishedNode field.
        /// </summary>
        public BinaryTreeNode DistinguishedNode
        {
            get { return this.distinguishedNode; }
        }

        /// <summary>
        /// The root Node of the BinaryTree.
        /// </summary>
        BinaryTreeNode rootNode;

        /// <summary>
        /// Read only property for the rootNode field.
        /// </summary>
        public BinaryTreeNode RootNode
        {
            get { return this.rootNode; }
        }

        /// <summary>
        /// Initializes the BinaryTree with an array of integers. NOTE: All duplicated integers will be removed during the initialization and the tree will contain Nodes with unique values.
        /// </summary>
        /// <param name="integers">An array of integers.</param>
        public BinaryTree(int[] integers)
        {
            this.nodeValues = integers.Distinct().ToArray();

            this.rootNode = this.buildNodeConnections(this.nodeValues);
            this.distinguishedNode = this.rootNode;
        }

        /// <summary>
        /// Initializes the BinaryTree with a specified number of random Nodes.
        /// </summary>
        /// <param name="numberOfNodes">The number of random Nodes in the tree.</param>
        public BinaryTree(int numberOfNodes)
        {
            this.nodeValues = new int[numberOfNodes];

            int i = 0;
            Random rnd = new Random();

            while (i < numberOfNodes)
            {
                int nextNodeValue = rnd.Next(1, numberOfNodes + 1);

                if (!this.nodeValues.Contains(nextNodeValue))
                {
                    this.nodeValues[i] = nextNodeValue;
                    i++;
                }
            }

            this.rootNode = this.buildNodeConnections(this.nodeValues);
            this.distinguishedNode = this.rootNode;
        }

        #region IInorderTransversal
        /// <summary>
        /// Puts the data structure into the initial state of the transversal (S0).
        /// </summary>
        /// <returns>The currently distinguished node.</returns>
        public BinaryTreeNode inorderFirst()
        {
            if (this.distinguishedNode.isVisited())
                this.rootNode = this.buildNodeConnections(this.nodeValues);

            this.distinguishedNode = this.smallestNode();
            this.distinguishedNode.visit();

            return this.distinguishedNode;
        }

        /// <summary>
        /// Puts the data structure into the next state of the transversal.
        /// </summary>
        /// <returns>The currently distinguished node.</returns>
        public BinaryTreeNode inorderNext()
        {
            BinaryTreeNode nextNode = this.nextNodeInOrder(this.distinguishedNode);

            if (nextNode != null)
            {
                nextNode.visit();
                this.distinguishedNode = nextNode;
            }

            return this.distinguishedNode;
        }

        /// <summary>
        /// Tells if the inorder transversal of the data structure is finished.
        /// </summary>
        /// <returns>True, if the inorder transversal has ended and all nodes have been visited; False, othewise.</returns>
        public bool isInorderTransversalFinished()
        {
            return this.distinguishedNode.value == this.nodeValues.Max();
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Builds up BinaryTreeNode objects and their connections from the an array of integers.
        /// </summary>
        /// <param name="sequenceOfUniqueIntegers">A sequence of unique integers to be used to generate the BinaryTree structure.</param>
        /// <returns>The root BinaryTreeNode matching the first element of the sequence.</returns>
        private BinaryTreeNode buildNodeConnections(int[] sequenceOfUniqueIntegers)
        {
            BinaryTreeNode rootNode = null;
            try
            {
                rootNode = new BinaryTreeNode(sequenceOfUniqueIntegers[0]);

                for (int i = 1; i < sequenceOfUniqueIntegers.Length; i++)
                {
                    BinaryTreeNode newNode = null; //new BinaryTreeNode(sequenceOfUniqueIntegers[i]); // the next Node in the array - we have to find a parent for it in the current structure
                    BinaryTreeNode newNodeParent = rootNode;

                    while (newNode == null)
                    {
                        if (sequenceOfUniqueIntegers[i] < newNodeParent.value)
                        {
                            if (newNodeParent.leftChild != null)
                                newNodeParent = newNodeParent.leftChild;
                            else
                                newNode = new BinaryTreeNode(sequenceOfUniqueIntegers[i], newNodeParent);
                        }
                        else
                        {
                            if (newNodeParent.rightChild != null)
                                newNodeParent = newNodeParent.rightChild;
                            else
                                newNode = new BinaryTreeNode(sequenceOfUniqueIntegers[i], newNodeParent);
                        }
                    }
                }
                return rootNode;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.ToString());
                return rootNode;
            }
            catch
            {
                return rootNode;
            }
        }

        /// <summary>
        /// Gets the smallest Node of the BinaryTree.
        /// </summary>
        /// <returns>The leftmost (smallest value) Node of the tree.</returns>
        private BinaryTreeNode smallestNode()
        {
            if (this.rootNode.leftChild != null)
                return this.leftmostNodeUnder(this.rootNode); // get the leftmost child of the root Node, if there is any
            return this.rootNode; // otherwise, the root Node is the smallest in the tree
        }

        /// <summary>
        /// Gets the leftmost Node under the given Node.
        /// </summary>
        /// <param name="node">The BinaryTreeNode of which's leftmost child Node has to be returned.</param>
        /// <returns>The leftmost child of the given BinaryTreeNode or null if there isn't any.</returns>
        private BinaryTreeNode leftmostNodeUnder(BinaryTreeNode node)
        {
            if (node.leftChild == null)
                return null;

            while (node.leftChild != null)
            { node = node.leftChild; }

            return node;
        }

        /// <summary>
        /// Gets the next Node from the tree in order after the given Node.
        /// </summary>
        /// <param name="afterNode">The Node of discussion.</param>
        /// <returns>The Node in the binary tree has the closes bigger value to the afterNode.</returns>
        private BinaryTreeNode nextNodeInOrder(BinaryTreeNode afterNode)
        {
            if (afterNode.rightChild != null)
            {
                if (this.leftmostNodeUnder(afterNode.rightChild) != null)
                    return this.leftmostNodeUnder(afterNode.rightChild);

                return afterNode.rightChild;
            }
            else if (afterNode.parentNode != null)
            {
                if (afterNode.isLeftChild())
                    return afterNode.parentNode;
                else
                    return firstNotVisitedParent(afterNode);
            }
             return null;
        }

        private BinaryTreeNode firstNotVisitedParent(BinaryTreeNode ofNode)
        {
            while (ofNode.parentNode != null)
            {
                if (ofNode.parentNode.isVisited() == false)
                    return ofNode.parentNode;

                ofNode = ofNode.parentNode;
            }
            return null;
        }
        #endregion
    }
}
