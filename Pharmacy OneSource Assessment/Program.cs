using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Data.Entity;

namespace Pharmacy_OneSource_Assessment
{
    class Program
    {
        public const string TAX_FILE = @"..\..\json\tax.json";
        public const string INPUT_FILE = @"..\..\in.txt";

        static void Main(string[] args)
        {
            //using (SqlConnection conn = new SqlConnection())
            //{
            //    conn.ConnectionString = "Server=mssql4.gear.host;Database=devpos;Trusted_Connection=false";
            //    conn.Open();
            //    // using the code here...
            //}
            Meth();

            foreach (var cart in GetCarts())
            {
                Console.WriteLine(cart);
            }
        }

        private static Queue<Cart> GetCarts()
        {
            Queue<Cart> carts = new Queue<Cart>();
            TaxSchedule taxSchedule = GetTaxSchedule();

            using (StreamReader reader = new StreamReader(INPUT_FILE))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    Regex regex = new Regex(@"(\d+:)$");
                    Match match = regex.Match(line);
                    if (match.Success)
                    {
                        //Console.WriteLine(match.Value);
                        carts.Enqueue(new Cart(new Customer("Output ", match.Value.Substring(0, match.Value.Length - 1), new Address(), new Address()), taxSchedule));

                    }

                    //Console.WriteLine(line.EndsWith(":"));
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

        public static void Meth()
        {
            using (var db = new BloggingContext())
            {
                // Create and save a new Blog 
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();

                var blog = new Blog { Name = name };
                db.Blogs.Add(blog);
                db.SaveChanges();

                // Display all Blogs from the database 
                var query = from b in db.Blogs
                            orderby b.Name
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }
    }

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }

}
