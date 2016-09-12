using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Pharmacy_OneSource_Assessment.Model
{
    /// <summary>
    /// Static class reads, calculates and disseminates tax data. Ideally this data would live in the
    /// database with customer and product data, but this version was largely complete when that
    /// decision was made. Plus, it was an opportunity to get a little more hands-on with JSON, which
    /// was new to me. Now, after all the time spent sorting out Visual Studio issues (a few of which
    /// weren't even my own fault!), there simply isn't time to change it.
    /// </summary>
    public static class TaxServer
    {
        public const string BASE_RATE = "BASERATE";
        public const string IMPORTED = "IMP";
        public const string DOMESTIC = "DOM";

        private static double importRate;

        public static double ImportRate
        {
            get
            {
                if (null == StateTaxes)
                { ReadTaxSchedule(); }
                return importRate;
            }
            set { importRate = value; }
        }

        // taxes by (state, (tax code, tax rate))
        private static Dictionary<string, Dictionary<string, double>> StateTaxes;

        /// <summary>
        /// Calculates combined state and import taxes for the given tax code and item price.
        /// </summary>
        /// <param name="state">The 2-letter state code.</param>
        /// <param name="taxCode">The tax codes for the item category being taxed.</param>
        /// <param name="price">The price of the item(s) being taxed.</param>
        /// <returns>The amount of tax to be added.</returns>
        public static double CalculateTaxes(string state, string[] taxCode, double price)
        {
            if (null == StateTaxes)
            {
                ReadTaxSchedule();
            }

            var rate = StateTaxes[state][taxCode[1]] + (IMPORTED.Equals(taxCode[0]) ? importRate : 0.0);

            // tax rate is a percentage, so calculated tax needs to be divided by 100, but we need
            // to round up to nearest nickel, so we divide by 20, get the ceiling, and then divide
            // by the remaining factor of 5
            return Math.Ceiling(price * rate / 20.0) / 5.0;
        }

        /// <summary>
        /// Read tax data from json file.
        /// </summary>
        private static void ReadTaxSchedule()
        {
            using (StreamReader reader = new StreamReader(CartSim.TAX_FILE))
            {
                JObject json = JObject.Parse(reader.ReadToEnd());
                StateTaxes = new Dictionary<string, Dictionary<string, double>>();
                ImportRate = (double)json["import-rate"];

                foreach (var state in json["states"])
                {
                    // get 2-letter state code
                    string stateCode = (string)state["state-code"];

                    // instantiate state's dictionary
                    StateTaxes.Add(stateCode, new Dictionary<string, double>());

                    // add state's base tax
                    StateTaxes[stateCode].Add(BASE_RATE, (double)state["base-rate"]);

                    // add each category exception to base tax
                    foreach (var taxCode in state["exceptions"])
                    {
                        StateTaxes[stateCode].Add((string)taxCode["tax-code"], (double)taxCode["rate"]);
                    }
                }

                foreach (var d in StateTaxes)
                {
                    foreach (var c in d.Value)
                    {
                        Console.WriteLine(c);
                    }
                }
            }
        }
    }
}