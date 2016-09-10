using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pharmacy_OneSource_Assessment
{
    /// <summary>
    ///  
    /// </summary>
    class Cart
    {
        private Customer Customer;
        private TaxSchedule TaxSchedule;
        private Dictionary<Product, int> Contents;

        public Cart(Customer customer, TaxSchedule taxSchedule)
        {
            //    // Not sure I like this method of ensuring that TaxCode is set, but I don't want to read and parse a
            //    // file for each cart instance when the data is the same. Given the time constraint it will have to do.
            //    if (TaxSchedule == null)
            //    {

            //        //throw new ApplicationException("Tax schedule must be set before carts may be instantiated.");
            //    }

            Customer = customer;
            Contents = new Dictionary<Product, int>();
            TaxSchedule = taxSchedule;
        }

        public void AddProduct(Product product) { Contents[product] = Contents.ContainsKey(product) ? Contents[product] : 1; }
        
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
