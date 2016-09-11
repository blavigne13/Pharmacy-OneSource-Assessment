using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Pharmacy_OneSource_Assessment
{
    internal class Program
    {
        public const string TAX_FILE = @"Resources\JSON\tax.json";
        public const string INPUT_FILE = @"Resources\in.txt";

        private static void Main(string[] args)
        {
            DBTest();

            //foreach (var cart in GetCarts())
            //{
            //    Console.WriteLine(cart);
            //}
        }

        /// <summary>
        /// Gets the carts.
        /// </summary>
        /// <returns>The aforementioned carts.</returns>
        private static Queue<Cart> GetCarts()
        {
            Queue<Cart> carts = new Queue<Cart>();
            TaxSchedule taxSchedule = GetTaxSchedule();

            using (StreamReader reader = new StreamReader(INPUT_FILE))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    Regex regex = new Regex(@"(\d+:)$");
                    Match match = regex.Match(line);
                    if (match.Success)
                    {
                        //Console.WriteLine(match.Value);
                        //carts.Enqueue(new Cart(new Model.Customer("Output ", match.Value.Substring(0, match.Value.Length - 1), new Model.Address(), new Model.Address()), taxSchedule));
                    }

                    //Console.WriteLine(line.EndsWith(":"));
                }
            }
            return carts;
        }

        private static void getInvoices(Queue<Cart> carts)
        {
        }

        /// <summary>
        /// Read tax schedule data from the provided json file.
        /// </summary>
        /// <param name="taxFile">File containing tax schedule data--should conform to tax-schema.json</param>
        public static TaxSchedule GetTaxSchedule()
        {
            using (StreamReader reader = new StreamReader(TAX_FILE))
            {
                var jarr = JObject.Parse(reader.ReadToEnd());
                //foreach (JObject jobj in jarr)
                //{
                //    Console.WriteLine(jobj.Property("name").Value);
                //}
            }

            return new TaxSchedule(0.0, null);
        }

        public static void DBTest()
        {
            using (var db = new Model.PosDbContext())
            {
                Console.WriteLine(db.Customers.Count<Model.Customer>());

                foreach (var c in db.Customers)
                {
                    Console.WriteLine(c.Name);
                }
            }
        }
    }
}