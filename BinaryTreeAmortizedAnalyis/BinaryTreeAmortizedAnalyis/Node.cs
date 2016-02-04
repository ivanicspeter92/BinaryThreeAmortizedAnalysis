using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeAmortizedAnalyis
{
    /// <summary>
    /// A class representing Nodes of graphs and trees.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// The assigned integer value of this Node.
        /// </summary>
        public int value { get; }
        
        /// <summary>
        /// Initializes the Node with the given value.
        /// </summary>
        /// <param name="value">The value to be assigned to the Node.</param>
        public Node(int value)
        {
            this.value = value;
        }       
    }
}
