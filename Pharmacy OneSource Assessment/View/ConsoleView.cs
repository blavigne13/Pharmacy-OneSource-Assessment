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
        /// <summary>
        /// Writes the associated Invoice object to the console.
        /// </summary>
        public override void ViewInvoice()
        {
            Console.WriteLine(Shopper.Invoice.ToString());
        }
    }
}