using System;
using System.Collections.Generic;
using System.Text;

namespace TheMerchant.Node
{
    public class Node
    {

        public string Name { get; }

        #region References to neighbours

        public Node Parent { get; set; }

        public IList<Node> Children { get; }
        
        #endregion


        public Node(string name, Node parent = null, params Node[] children)
        {
            
        }



    }
}
