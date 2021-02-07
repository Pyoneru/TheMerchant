using System;
using System.Collections.Generic;
using System.Text;

namespace TheMerchant.Model
{
    /// <summary>
    /// Class represent category of product.
    /// Group many products in one group. e.g. For specific merchant wchich sell or buy only food.
    /// </summary>
    public class Category : IEquatable<Category>
    {
        /// <summary>
        /// Id is name of category in english and his all charcaters are lower case.
        /// Use in search in list.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Name of category
        /// </summary>
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Category);
        }
        public bool Equals(Category other)
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
