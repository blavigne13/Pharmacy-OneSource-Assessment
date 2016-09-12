using Pharmacy_OneSource_Assessment.Controller;
using System;
using System.Text.RegularExpressions;

namespace Pharmacy_OneSource_Assessment.View
{
    /// <summary>
    /// Generates an invoice for the shopping cart instance supplied to the constructor. The Invoice
    /// class makes use of a lazy-evaluation strategy--all work is deferred until the moment a result
    /// is needed. This strategy also ensures that the output data is "fresh," so long as another
    /// method does not defer output after invoking one of the Invoice class's output methods.
    /// </summary>
    internal class Invoice
    {
        public Shopper Shopper { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Invoice"/> class.
        /// </summary>
        /// <param name="shopper">The shopper.</param>
        public Invoice(Shopper shopper)
        {
            Shopper = shopper;
        }

        /// <summary>
        /// Creates an invoice as an array of strings, with each string representing a single line.
        /// </summary>
        /// <returns>Array of lines as strings</returns>
        public string[] ToStringArray()
        {
            var subtotal = 0.0;
            var taxes = 0.0;
            var lines = new string[Shopper.Cart.Contents.Count + 3];
            var i = 0;

            lines[i++] = Shopper.Customer.FirstName + " " + Shopper.Customer.LastName + ":";

            foreach (var product in Shopper.Cart.Contents.Keys)
            {
                var taxCode = Regex.Split(product.TaxCode, @"_");
                var price = product.Price * Shopper.Cart.Contents[product];
                var tax = Model.TaxServer.CalculateTaxes(Shopper.Customer.Address.State, taxCode, price);

                taxes += tax;
                subtotal += price;

                lines[i++] = "\t" + Shopper.Cart.Contents[product] + " " + product.InvoiceLabel + " at " + (product.Price + tax);
            }

            lines[i++] = "\tSales Taxes: " + taxes;
            lines[i] = "\tTotal: " + (subtotal + taxes);

            return lines;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this Invoice.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            return String.Join("\n", ToStringArray());
        }
    }
}