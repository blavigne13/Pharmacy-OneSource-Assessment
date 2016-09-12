using Pharmacy_OneSource_Assessment.Controller;

namespace Pharmacy_OneSource_Assessment.View
{
    /// <summary>
    /// Abstract class describing an invoice viewer.
    /// </summary>
    internal abstract class Viewer
    {
        protected Shopper Shopper;

        public abstract void ViewInvoice();
    }
}