using Pharmacy_OneSource_Assessment.Controller;
using Pharmacy_OneSource_Assessment.Model;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Pharmacy_OneSource_Assessment
{
    /// <summary>
    /// Instantiates a Store and executes simulated customer interactions.
    /// </summary>
    internal class CartSim
    {
        public const string TAX_FILE = @"Resources\JSON\tax.json";
        public const string INPUT_FILE = @"Resources\in.txt";

        public static void Main(string[] args)
        {
            RunSimulation();
        }

        /// <summary>
        /// Runs the simulation. A Store instance is created and then a text file containing the
        /// example input from the problem statement is parsed and used to query the database (via
        /// the Store instance) for product information, then fed to the Store in something roughly
        /// similar to the way it would be in a production environment.
        /// </summary>
        private static void RunSimulation()
        {
            var store = new Store();
            Shopper shopper = null;
            Regex custRegex = new Regex(@"(\d+:)$");
            Regex priceRegex = new Regex(@"(\d+.\d+)$");

            foreach (var line in ReadInputFile())
            {
                Match match = custRegex.Match(line);

                if (match.Success)
                {
                    shopper = store.AddShopper(new Customer
                    {
                        FirstName = "Output",
                        LastName = match.Value.Substring(0, match.Value.Length - 1),
                        Address = new Address { State = "WI" }
                    });
                }
                else
                {
                    match = priceRegex.Match(line);
                    shopper.Cart.Add(store.GetProductByPrice(Double.Parse(match.Value)));
                }
            }

            foreach (var s in store.Shoppers)
            {
                Console.WriteLine(s.Invoice);
            }
        }

        private static string[] ReadInputFile()
        {
            var input = "";

            using (StreamReader reader = new StreamReader(INPUT_FILE))
            {
                input = reader.ReadToEnd();
            }

            return Regex.Split(input, @"[\r\n]+");
        }
    }
}