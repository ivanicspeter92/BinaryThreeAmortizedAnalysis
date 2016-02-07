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
        BinaryTreeNode distinguishedNode;

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
            //int[] arrayOfUniqueIntegers = this.distinctAndOrderArray(integers);
            int[] nodeValues = integers.Distinct().ToArray();
            this.rootNode = this.buildNodeConnections(nodeValues);
            this.inorderFirst();
        }

        #region IInorderTransversal
        public void inorderFirst()
        {
            //this.distinguishedNode = this.rootNode;
        }

        public void inorderNext()
        {
            throw new NotImplementedException();
        }

        public bool isInorderTransversalFinished()
        {
            throw new NotImplementedException();
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
                    BinaryTreeNode newNode = new BinaryTreeNode(sequenceOfUniqueIntegers[i]); // the next Node in the array - we have to find a parent for it in the current structure
                    BinaryTreeNode newNodeParent = rootNode;

                    while (newNode.parentNode == null)
                    {
                        if (newNode.value < newNodeParent.value)
                        {
                            if (newNodeParent.leftChild != null)
                                newNodeParent = newNodeParent.leftChild;
                            else
                            {
                                newNode.parentNode = newNodeParent;
                                newNodeParent.leftChild = newNode;
                            }
                        }
                        else
                        {
                            if (newNodeParent.rightChild != null)
                                newNodeParent = newNodeParent.rightChild;
                            else
                            {
                                newNode.parentNode = newNodeParent;
                                newNodeParent.rightChild = newNode;
                            }
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
        #endregion
    }
}
