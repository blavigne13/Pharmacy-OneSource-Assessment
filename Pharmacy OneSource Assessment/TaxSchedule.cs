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
    public class TaxSchedule
    {
        public double ImportRate { get; }
        Dictionary<string, Dictionary<int, double>> StateRates { get; }

        public TaxSchedule(double importRate, Dictionary<string, Dictionary<int, double>> stateRates)
        {
            ImportRate = importRate;
            StateRates = stateRates;
        }
    }
}
