using System;
using System.Collections.Generic;
using System.Text;

namespace TheMerchant.Model
{
    public interface IEquipment
    {
        public Dictionary<Product,int> Products { get; set; }
        public Decimal Weight { get; set; }
        public Decimal MaxWeight { get; set; }
    }
}
