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
                   Orders = x.Element("orders").Elements("order").Select(z => new Order { Id = z.Element("id")?.Value,
                       Orderdate = z.Element("orderdate").Value,
        Total = z.Element("total").Value.ConvertToDoubleValue() }).ToList()

               }).ToList();

            return customersList;
        }






        static void Main(string[] args)
        {
            try
            {
                var list = GetCustomersList();
              Customer  customer = new Customer
                {
                    Id = "152",
                    Name = "Zhuravinka",
                    Postalcode = "11134",
                    Phone = "555-69-69",
                    Fax = "555-69-89",
                    Address = "Lenina Street 25",
                    City = "Minsk",
                    Country = "Belarus",
                    Region = "Europe",
                    Orders = new List<Order>
            { new Order {Id="1258",Total=8000,Orderdate="2000-01-21T00:00:00" }
       }
                };


                Customer customer1 = new Customer
                {
                    Id = "1521",
                    Name = "Zhuravinka",
                    Postalcode = "11134",
                    Phone = "555-69-69",
                    Fax = "555-69-89",
                    Address = "Lenina Street 25",
                    City = "Minsk",
                    Country = "Belarus",
                    Region = "Europe",
                    Orders = new List<Order>
            { new Order {Id="1258",Total=7000,Orderdate="2000-01-21T00:00:00" },
           new Order {Id="1254",Total=3000,Orderdate="2001-02-21T00:00:00" } }
                };





                list.Add(customer1);

                list.Add(customer);

                //var list = GetCustomersList().GetTask3List(500);
                var list1 = list.SelectMany(x => x.Orders, (x, y) => new { Name = x.Name, OrderDate = y.Orderdate.ConvertToDateTime() }).
                    GroupBy(x => new { x.Name, x.OrderDate.Year,x.OrderDate.Month },
                    (key, group) => new { Name = key.Name, OrderYear=key.Year, OrderMonth=key.Month, OrderCount = group.Count() }).ToList();
                    /*.GroupBy(x => x.Name)*/

                var cust = list1.FirstOrDefault(x => x.Name == "Zhuravinka" && x.OrderYear == 2000&&x.OrderMonth==1);
                WriteLine(cust.OrderCount + " " + cust.OrderYear + " " + cust.Name);

                //foreach (var i in list1)
                //{
                //    Console.WriteLine(i/*.Key*/);
                //    //foreach (var t in i)
                //    //    Console.WriteLine(t.OrderMonth + " " + t.OrderCount);
                //    //Console.WriteLine();
                //}


                //  SelectMany(x => x.Orders, (x, y) => new { Name = x.Name, OrderDate = y.OrderDate.ConvertToDateTime() }).
                //GroupBy(x => new { x.Name, x.OrderDate.Month },
                //(key, group) => new { Name = key.Name, OrderMonth = key.Month, OrderCount = group.Count() }).
                //  Select(x => new { Month = x.OrderMonth, OrderCount = x.OrderCount, Name = x.Name }).GroupBy(x => x.Name);

                int v = 1;
                //foreach(var i in list1)
                //{
                //    Console.WriteLine(v+" "+ i.City + "==> "+i.Intensity+"==>"+i.AverageTotalSum);
                 
                   
                //    v++;
                //    WriteLine();
                //}

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
