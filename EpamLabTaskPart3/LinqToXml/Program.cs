using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using static System.Console;

namespace LinqToXml
{
    class Program
    {





        public static List<Customer> GetCustomersList()
        {
            XDocument xdoc = XDocument.Load(@"e:\Customers.xml");
            var customersList = xdoc.Element("customers").Elements("customer")
                //.Where(x => x.Element("orders").Elements("order").Count() > 0)
               .Select(x => new Customer
               {
                   Postalcode=x.Element("postalcode")?.Value,
                   Region = x.Element("region")?.Value,
                   Fax = x.Element("phone").Value,
                   City = x.Element("city").Value,
                   Phone = x.Element("phone").Value,
                   Id = x.Element("id").Value,
                   Name = x.Element("name").Value,
                   Country = x.Element("country").Value,
                   Orders = x.Element("orders").Elements("order").
    Select(z => new Order { Id = z.Element("id")?.Value, Orderdate = z.Element("orderdate")!=null? z.Element("orderdate").Value.ConvertToDateTime():DateTime.Now,
        Total = z.Element("total")!=null? z.Element("total").Value.ConvertToDoubleValue():0 }).ToList()

               }).ToList();

            return customersList;
        }






        static void Main(string[] args)
        {
            try
            {
                var list = GetCustomersList();

                //var list = GetCustomersList().GetTask3List(500);


                int v = 1;
                foreach(var i in list)
                {
                    Console.WriteLine(v+" "+ i.Name + " " + /*i.Orders.Max(x=>x.Total) +*/ " " + list.Count());
                    v++;
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            Console.ReadKey();

        }
    }
}
