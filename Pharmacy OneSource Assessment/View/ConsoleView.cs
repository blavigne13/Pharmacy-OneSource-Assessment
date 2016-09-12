using Pharmacy_OneSource_Assessment.Controller;
using System;

namespace Pharmacy_OneSource_Assessment.View
{
    /// <summary>
    /// Implementation of a console-based Viewer.
    /// </summary>
    /// <seealso cref="Pharmacy_OneSource_Assessment.View.Viewer" />
    internal class ConsoleView : Viewer
    {
        private Shopper Shopper { get; set; }

        /// <summary>
        /// Writes an invoice to console.
        /// </summary>
        public void ViewInvoice()
        {
            Console.WriteLine(Shopper.Invoice.ToString());
        }
    }
}