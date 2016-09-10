using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_OneSource_Assessment
{
    /// <summary>
    /// Basic representation of a product
    /// </summary>
    class Product
    {
        public string Name { get; }
        public double Price { get; }
        public int TaxCode { get; }
        public bool Imported { get; }

        public Product(string name, double price, int taxCode, bool imported)
        {
            Name = name;
            Price = price;
            TaxCode = taxCode;
            Imported = false;
        }
    }
}
