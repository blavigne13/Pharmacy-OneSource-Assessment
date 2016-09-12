using Pharmacy_OneSource_Assessment.Model;
using System.Collections.Generic;
using System.Linq;

namespace Pharmacy_OneSource_Assessment.Controller
{
    /// <summary>
    /// The Store class is the top-level object of the controller section. It is responsible for
    /// instantiating a DbContext and managing the set of active shoppers, as well as providing
    /// methods to query the database and facilitating the exchange of data between the two.
    ///
    /// **Whether the queries would be better off in a class in the .Model namespace is under
    ///   consideration...or would be if this was a longer-term project.
    /// </summary>
    internal class Store
    {
        public PosDbContext db { get; private set; }
        public HashSet<Shopper> Shoppers { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Store"/> class.
        /// </summary>
        public Store()
        {
            db = new PosDbContext();
            Shoppers = new HashSet<Shopper>();
        }

        /// <summary>
        /// Gets a product by its product code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>A Product object</returns>
        public Product GetProductByCode(int code)
        {
            return db.Products
                .Where(p => p.ProductCode == code)
                .DefaultIfEmpty(null)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets all products matching a given label.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns>Products as an IQueryable of Product</returns>
        public IQueryable<Product> GetProductsByLabel(string label)
        {
            return db.Products
                .Where(p => p.InvoiceLabel.Equals(label));
        }

        /// <summary>
        /// Gets the product codes of all products matching a given label.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns>Product codes as an IQueryable of int</returns>
        public IQueryable<int> GetCodesByLabel(string label)
        {
            return GetProductsByLabel(label)
                .Select(p => p.ProductCode);
        }

        /// <summary>
        /// Instantiates a new shopper.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public void AddShopper(Customer customer)
        {
            Shoppers.Add(new Shopper(customer));
        }
    }
}