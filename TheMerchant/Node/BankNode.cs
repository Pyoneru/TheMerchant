using System;
using System.Collections.Generic;
using System.Text;

namespace TheMerchant.Node
{
    public class BankNode : Node
    {
        public BankNode(string name, Node parent = null, params Node[] children) : base(name, parent, children)
        {
            
        }

        public string Name { get; set; }
        public Decimal Debt { get; set; }
    }
}
