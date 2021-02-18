using System;
using System.Collections.Generic;
using System.Text;
using TheMerchant.Model;

namespace TheMerchant.Node
{
    public class MerchantNode : Node, IGold, IEquipment
    {
        public string Name { get; set; }
        public Dictionary<MerchantProduct,int> DefaultProducts { get; set; }
        public Decimal DefaultGold { get; set; }

        public MerchantNode(string name, Node parent = null, params Node[] children) : base(name, parent, children)
        {
        }

        public decimal Gold { get; set; }
        public Dictionary<Product, int> Products { get; set; }
        public decimal Weight { get; set; }
        public decimal MaxWeight { get; set; }
    }
}
