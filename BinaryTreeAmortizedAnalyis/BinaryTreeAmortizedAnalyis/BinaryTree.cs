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
        public BinaryTreeNode distinguishedNode { get; }

        /// <summary>
        /// Initializes the BinaryTree with an array of integers. NOTE: All duplicated integers will be removed during the initialization and the tree will contain Nodes with unique values.
        /// </summary>
        /// <param name="integers">An array of integers.</param>
        public BinaryTree(int[] integers)
        {
            int[] arrayOfUniqueIntegers = this.distinctAndOrderArray(integers);
            this.nodeValues = arrayOfUniqueIntegers;
        }
        
        /// <summary>
        /// Initializes the BinaryTree with an array of ordered, unique integers. 
        /// </summary>
        /// <param name="sequenceOfUniqueIntegers"></param>
        //private BinaryTree(int[] sequenceOfUniqueIntegers)
        //{

        //}

        #region IInorderTransversal
        public void inorderFirst()
        {
            throw new NotImplementedException();
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

        /// <summary>
        /// Generates a distinc and ordered array of integers of the given array. Removes duplicate values.
        /// </summary>
        /// <param name="array">The array to be unified and ordered.</param>
        /// <returns>An array of distinct and ordered integers.</returns>
        private int[] distinctAndOrderArray(int[] array)
        {
            int[] arrayOfUniqueIntegers = array.Distinct().ToArray();
            Array.Sort(arrayOfUniqueIntegers);

            return arrayOfUniqueIntegers;
        }
    }
}
