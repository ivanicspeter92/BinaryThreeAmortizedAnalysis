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
    public class BinaryTreeNode: Node
    {
        /// <summary>
        /// The reference to the parent Node.
        /// </summary>
        public BinaryTreeNode parentNode { get; set; }

        /// <summary>
        /// The reference to the left child Node.
        /// </summary>
        public BinaryTreeNode leftChild { get; set; }

        /// <summary>
        /// The reference to the right child Node.
        /// </summary>
        public BinaryTreeNode rightChild { get; set;  }

        /// <summary>
        /// Indicates if the Node was visited during the binary tree transversal. 
        /// </summary>
        private bool visited = false;

        /// <summary>
        /// The rank of the Node in the tree.
        /// </summary>
        int rank { get; }

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
        public BinaryTreeNode(int value, BinaryTreeNode parentNode): base(value)
        {
            if (this.value < parentNode.value)
            {
                parentNode.leftChild = this;
                this.parentNode = parentNode;
            }
            else if (this.value > parentNode.value)
            {
                parentNode.rightChild = this;
                this.parentNode = parentNode;
            }
        }

        /// <summary>
        /// Tells if the Node was visited during the transversal of the embedding tree.
        /// </summary>
        /// <returns>The value of the visited flag.</returns>
        public bool isVisited()
        {
            return this.visited;
        }

        /// <summary>
        /// Tells if the Node is a left child of its parent.
        /// </summary>
        /// <returns>True, if the Node is a left child of its parent; false otherwise.</returns>
        public bool isLeftChild()
        {
            if (this.parentNode != null)
                return this.parentNode.leftChild == this;
            return false;
        }

        /// <summary>
        /// Tells if the Node is a right child of its parent.
        /// </summary>
        /// <returns>True, if the Node is a right child of its parent; false otherwise.</returns>
        public bool isRightChild()
        {
            if (this.parentNode != null)
                return this.parentNode.rightChild == this;
            return false;
        }

        /// <summary>
        /// Tells if the Node is root node.
        /// </summary>
        /// <returns>True, if the node is root node; false otherwise.</returns>
        public bool isRootNode()
        {
            return this.parentNode == null;
        }

        /// <summary>
        /// Tells if the Node is leaf node.
        /// </summary>
        /// <returns>True, if the node is leaft node; false otherwise.</returns>
        public bool isLeafNode()
        {
            return this.leftChild == null && this.rightChild == null;
        }
    }
}
