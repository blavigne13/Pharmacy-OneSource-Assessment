using Pharmacy_OneSource_Assessment.Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Pharmacy_OneSource_Assessment
{
    internal class CartSim
    {
        public const string TAX_FILE = @"Resources\JSON\tax.json";
        public const string INPUT_FILE = @"Resources\in.txt";

        public static void Main(string[] args)
        {
            //DBTest();
            //Model.TaxServer.ReadTaxSchedule();
            RunSimulation();
        }

        private static void RunSimulation()
        {
            //Queue<Cart> Carts = new Queue<Cart>();

            ReadInputFile();
            //Cart c = new Cart(new Model.Customer());

            /*
              while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    Regex regex = new Regex(@"(\d+:)$");
                    Match match = regex.Match(line);
                    if (match.Success)
                    {
                        Console.WriteLine(match.Value);

                        //carts.Enqueue(new Cart(new Model.Customer("Output ", match.Value.Substring(0, match.Value.Length - 1), new Model.Address(), new Model.Address()), taxSchedule));
                    }

                    //Console.WriteLine(line.EndsWith(":"));
                }
             */
        }

        private static string ReadInputFile()
        {
            var input = "";

            using (StreamReader reader = new StreamReader(INPUT_FILE))
            {
                input = reader.ReadToEnd();
            }

            return input;
        }

        private static void DBTest()
        {
            Store s = new Controller.Store();
            var price = 11.25;

            List<Model.Product> l = s.GetProductsByLabel("box of chocolates")
                .Where(p => p.Price.Equals(price))
                .ToList<Model.Product>();

            foreach (var v in l)
            {
                Console.WriteLine("__> " + v.InvoiceLabel + " " + v.TaxCode);
            }

            using (var db = new Model.PosDbContext())
            {
                Console.WriteLine(db.Customers.Count<Model.Customer>());

                foreach (var c in db.Customers)
                {
                    Console.WriteLine(c.FirstName);
                }
            }
        }
    }
}