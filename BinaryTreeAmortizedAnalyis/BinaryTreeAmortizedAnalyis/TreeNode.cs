using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeAmortizedAnalyis
{
    /// <summary>
    /// A class representing Nodes of a tree.
    /// </summary>
    public class TreeNode: Node
    {
        /// <summary>
        /// The reference to the parent Node.
        /// </summary>
        public TreeNode parentNode { get; set; }

        /// <summary>
        /// Initializes the TreeNode with the given value. Using this initializer leaves the parent node null.
        /// </summary>
        /// <param name="value">The value to be assigned to the Node.</param>
        public TreeNode(int value): base(value)
        { }

        /// <summary>
        /// Initializes the TreeNode with the given value and parent.
        /// </summary>
        /// <param name="value">The value to be assigned to the Node.</param>
        /// <param name="parentNode">The parent TreeNode to be assigned to the TreeNode.</param>
        public TreeNode(int value, TreeNode parentNode): base(value)
        {
            this.parentNode = parentNode;
        }
    }
}
