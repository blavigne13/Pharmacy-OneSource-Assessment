using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_OneSource_Assessment
{
    /// <summary>
    /// The Address class represents a physical address. 
    /// 
    /// All properties of the Address class are immutable, thus processing a 
    /// change of address requires instantiation of a new Address object. I felt
    /// that this was preferrable to allowing side-effects, especially considering
    /// the relative infrequency of address changes and the fact that instances of
    /// this class would only be used to temporarily represent data stored in a db.
    /// 
    /// I had briefly considered using a struct, since this class only contains data, 
    /// but I was concerned about the possible overhead due to structs being 
    /// pass-by-value.
    /// </summary>
    class Address
    {
        public string StreetOne { get; }
        public string StreetTwo { get; }
        public string City { get; }
        public string State { get; }
        public string Zip { get; }
    }
}
