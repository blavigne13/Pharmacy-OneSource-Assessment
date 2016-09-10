using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_OneSource_Assessment
{
    /// <summary>
    /// 
    /// </summary>
    class Customer
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Name => FirstName + " " + LastName;
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }

        public Customer(string firstName, string lastName, Address shippingAddress, Address billingAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            ShippingAddress = shippingAddress;
            BillingAddress = billingAddress;
        }

        public List<string> orderHistory()
        {
            return null;
        }
    }
}
