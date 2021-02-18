using System;
using System.Collections.Generic;
using System.Text;

namespace TheMerchant.Node
{
    class TownNode : Node
    {
        public TownNode(string name, Node parent = null, params Node[] children) : base(name, parent, children)
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
