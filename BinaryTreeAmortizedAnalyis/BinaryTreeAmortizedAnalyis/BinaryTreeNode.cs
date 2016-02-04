using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeAmortizedAnalyis
{
    /// <summary>
    /// A class representing Nodes of a binary tree.
    /// </summary>
    public class BinaryTreeNode: TreeNode
    {
        /// <summary>
        /// The reference to the left child Node.
        /// </summary>
        public Node leftChild { get; set; }

        /// <summary>
        /// The reference to the right child Node.
        /// </summary>
        public Node rightChild { get; set;  }

        /// <summary>
        /// Indicates if the Node was visited during the binary tree transversal. 
        /// </summary>
        private bool visited = false;

        /// <summary>
        /// Sets the visited flag of the Node to true. Should be called when the Node is visited during the Binary tree transversal.
        /// </summary>
        public void visit()
        {
            this.visited = true;
        }

        /// <summary>
        /// Initializes the BinaryTreeNode with the given value. Using this initializer leaves the parent and both children null.
        /// </summary>
        /// <param name="value">The value to be assigned to the Node.</param>
        public BinaryTreeNode(int value): base(value)
        { }

        /// <summary>
        /// Initializes the TreeNode with the given value and parent.
        /// </summary>
        /// <param name="value">The value to be assigned to the Node.</param>
        /// <param name="parentNode">The parent BinaryTreeNode to be assigned to the TreeNode.</param>
        public BinaryTreeNode(int value, BinaryTreeNode parentNode): base(value, parentNode)
        {
            if (this.value <= parentNode.value)
                parentNode.leftChild = this; 
            else
                parentNode.rightChild = this;
        }

        /// <summary>
        /// Tells if the Node was visited during the transversal of the embedding tree.
        /// </summary>
        /// <returns>The value of the visited flag.</returns>
        public bool isVisited()
        {
            return this.visited;
        }
    }
}
