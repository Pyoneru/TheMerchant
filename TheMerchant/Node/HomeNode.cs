using System;
using System.Collections.Generic;
using System.Text;

namespace TheMerchant.Node
{
    public class HomeNode : Node
    {
        public HomeNode(string name, Node parent = null, params Node[] children) : base(name, parent, children)
        {
        }

        public string Name { get; set; }
        public bool Owned { get; set; }
    }
}
