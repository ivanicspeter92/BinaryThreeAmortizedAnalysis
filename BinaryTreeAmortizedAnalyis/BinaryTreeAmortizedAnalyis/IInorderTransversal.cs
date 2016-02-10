using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeAmortizedAnalyis
{
    public interface IInorderTransversal
    {
        /// <summary>
        /// Puts the data structure into the initial state of the transversal (S0).
        /// </summary>
        /// <returns>The currently distinguished node.</returns>
        BinaryTreeNode inorderFirst();
        /// <summary>
        /// Puts the data structure into the next state of the transversal.
        /// </summary>
        /// <returns>The currently distinguished node.</returns>
        BinaryTreeNode inorderNext();
        /// <summary>
        /// Tells if the inorder transversal of the data structure is finished.
        /// </summary>
        /// <returns>True, if the inorder transversal has ended and all nodes have been visited; False, othewise.</returns>
        bool isInorderTransversalFinished();
    }
}
