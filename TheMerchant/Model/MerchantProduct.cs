using System;
using System.Collections.Generic;
using System.Text;

namespace TheMerchant.Model
{
    public class MerchantProduct
    {
        public Product Product { get; set; }
        public Decimal BuyRate { get; set; }
        public Decimal SellRate { get; set; }
    }
}
