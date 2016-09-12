using Pharmacy_OneSource_Assessment.Controller;

namespace Pharmacy_OneSource_Assessment.View
{
    /// <summary>
    /// Interface describing an invoice viewer.
    /// </summary>
    internal abstract class Viewer
    {
        protected Shopper Shopper;

        public abstract void ViewInvoice();
    }
}