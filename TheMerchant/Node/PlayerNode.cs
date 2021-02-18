using System;
using System.Collections.Generic;
using System.Text;
using TheMerchant.Model;

namespace TheMerchant.Node
{
    public class PlayerNode : Node, IGold, IEquipment
    {
        public string Name { get; set; }
        public string TownID { get; set; }

        public PlayerNode(string name, Node parent = null, params Node[] children) : base(name, parent, children)
        {

        }

        public decimal Gold { get; set; }
        public Dictionary<Product, int> Products { get; set; }
        public decimal Weight { get; set; }
        public decimal MaxWeight { get; set; }
    }
}
