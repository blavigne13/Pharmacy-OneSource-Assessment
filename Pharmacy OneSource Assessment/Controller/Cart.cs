using Pharmacy_OneSource_Assessment.Model;
using Pharmacy_OneSource_Assessment.View;
using System.Collections.Generic;

namespace Pharmacy_OneSource_Assessment.Controller
{
    /// <summary>
    ///  Representation of an individual shopping cart.
    /// </summary>
    internal class Cart
    {
        // contents by (product, quantity)
        public Dictionary<Product, int> Contents { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cart" /> class.
        /// </summary>
        public Cart()
        {
            Contents = new Dictionary<Product, int>();
        }

        /// <summary>
        /// Adds a product to the cart.
        /// </summary>
        /// <param name="product">The Product object to add.</param>
        public void AddProduct(Product product)
        {
            Contents[product] = Contents.ContainsKey(product) ? Contents[product] + 1 : 1;
        }

        /// <summary>
        /// Removes the specified product. *untested*
        /// </summary>
        /// <param name="product">The product.</param>
        public void Remove(Product product)
        {
            if (Contents[product] > 1)
            {
                Contents[product] = Contents[product] - 1;
            }
            else
            {
                Contents.Remove(product);
            }
        }

        /// <summary>
        /// Removes all of the specified product. *untested*
        /// </summary>
        /// <param name="product">The product.</param>
        public void RemoveAll(Product product)
        {
            Contents.Remove(product);
        }

        /// <summary>
        /// Empties the cart. *untested*
        /// </summary>
        public void EmptyCart()
        {
            Contents.Clear();
        }
    }
}