using System;
using System.Collections.Generic;
using System.Text;

namespace TheMerchant.Model
{
    /// <summary>
    /// Class represent all products which we can buy or sell in game.
    /// </summary>
    public class Product : IEquatable<Product>
    {
        /// <summary>
        /// Id is name of product in english and all characters are lower case.
        /// Use in search product in product list.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Name is displayed for user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description for product
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Reference to category
        /// </summary>
        public Category category { get; set;}

        /// <summary>
        /// Original price(not changed by merchants, events, etc.)
        /// </summary>
        public Decimal originalPrice { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Product);
        }
        public bool Equals(Product other)
        {
            return other != null &&
                   ID == other.ID;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(ID);
        }
    }
}
