using Pharmacy_OneSource_Assessment.Model;
using Pharmacy_OneSource_Assessment.View;

namespace Pharmacy_OneSource_Assessment.Controller
{
    /// <summary>
    /// Represents a "shopping session" and serves as a container for a Customer, Cart and Invoice. Not strictly necessary as is, but could be
    /// extended to manage the various session information that would exist in a real-world use-case.
    /// </summary>
    internal class Shopper
    {
        public readonly Customer Customer;
        public readonly Cart Cart;
        public readonly Invoice Invoice;

        /// <summary>
        /// Initializes a new instance of the <see cref="Shopper" /> class.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public Shopper(Customer customer)
        {
            Customer = customer;
            Cart = new Cart();
            Invoice = new Invoice(this);
        }
    }
}