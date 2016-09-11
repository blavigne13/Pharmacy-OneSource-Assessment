using System.Collections.Generic;
using System.Text;

namespace Pharmacy_OneSource_Assessment
{
    /// <summary>
    ///  representation of an individual customer's shopping cart.
    /// </summary>
    internal class Cart
    {
        private Model.Customer Customer;
        private TaxSchedule TaxSchedule;
        private Dictionary<Model.Product, int> Contents;

        public Cart(Model.Customer customer, TaxSchedule taxSchedule)
        {
            //    // Not sure I like this method of ensuring that TaxCode is set, but I don't want to read and parse a
            //    // file for each cart instance when the data is the same. Given the time constraint it will have to do.
            //    if (TaxSchedule == null)
            //    {
            //        //throw new ApplicationException("Tax schedule must be set before carts may be instantiated.");
            //    }

            Customer = customer;
            Contents = new Dictionary<Model.Product, int>();
            TaxSchedule = taxSchedule;
        }

        public void AddProduct(Model.Product product)
        {
            Contents[product] = Contents.ContainsKey(product) ? Contents[product] : 1;
        }

        public override string ToString()
        {
            var priceSum = 0.0;
            var taxSum = 0.0;

            StringBuilder invoice = new StringBuilder(Customer.Name + ":\n", Contents.Count * 50);
            foreach (var product in Contents.Keys)
            {
                double tax = 0.0;
                taxSum += tax;
                priceSum += product.Price;

                invoice.AppendLine(Contents[product] + " " + product.Name + " at " + (product.Price + tax));
            }

            invoice.AppendLine("\tSales Taxes: " + taxSum);
            invoice.AppendLine("\tTotal: " + (priceSum + taxSum));

            return invoice.ToString();
        }
    }
}