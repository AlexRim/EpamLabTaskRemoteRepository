using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using static System.Console;



namespace LinqToXmlQueries
{
   public class Program
    {









        public static List<Customer> GetCustomersList()
        {
            XDocument xdoc = XDocument.Load("Customers.xml");
            var customersList = xdoc.Element("customers").Elements("customer").Where(x => x.Element("orders").Elements("order").Count() > 0)
               .Select(x => new Customer
               {
                   Name = x.Element("name").Value,
                   Country = x.Element("country").Value,
                   Orders = x.Element("orders").Elements("order").
    Select(z => new Order { Id = z.Element("id").Value, OrderDate = z.Element("orderdate").Value, Total = z.Element("total").Value }).ToList()

               }).ToList();

            return customersList;
        }



        static void Main(string[] args)
        {
            XDocument xdoc = XDocument.Load("Customers.xml");


            try
            {
                var list = GetCustomersList();

                foreach(var i in list)
                {
                    WriteLine(i);
                }







// query task2
 var clientGroupadByCountry = xdoc.Element("customers").Elements("customer").
                    Select(x => new Customer { Name = x.Element("name").Value, Country = x.Element("country").Value }).GroupBy(x=>x.Country);
// query task1
     var clientsWithSumOfAllOrdersMoreThanX = xdoc.Element("customers").Elements("customer").
                    Where(x => x.Element("orders").Elements("order")
              .Sum(z => double.Parse(z.Element("total").Value.FormatingDoubleValue())) > 1000).
                Select(x => new Customer { Name = x.Element("name").Value, Country = x.Element("country").Value });

                foreach(var i in clientsWithSumOfAllOrdersMoreThanX)
                {
                    WriteLine(i.Name);
                }
                //query task3
  var clientWithMaxTotalSumMoreThanX = xdoc.Element("customers").Elements("customer").Where(x => x.Element("orders").Elements("order").Count()>0 &&
  x.Element("orders").Elements("order").Max(z => double.Parse(z.Element("total").Value.FormatingDoubleValue())) >3800).
 Select(x => new Customer { Name = x.Element("name").Value, Country = x.Element("country").Value });


                //query task 4
                var cl = xdoc.Element("customers").Elements("customer").Where(x=>x.Element("orders").Elements("order").Count()>0).
                    Select(x => new Customer
                {
                    Name = x.Element("name").Value,
                    Country = x.Element("country").Value,
                    Orders = x.Element("orders").Elements("order").
   Select(z => new Order { Id = z.Element("id").Value, OrderDate = z.Element("orderdate").Value, Total = z.Element("total").Value })
   .ToList()
                }).
          Select(x => new Customer { Name = x.Name,FirstOrderDate=x.Orders.FirstOrDefault().OrderDate.ConvertDateTimeFormat()});


                //query task 5
                var client = xdoc.Element("customers").Elements("customer").Where(x => x.Element("orders").Elements("order").Count() > 0)
                    .Select(x => new Customer
                {
                    Name = x.Element("name").Value,
                    Country = x.Element("country").Value,
                    Orders = x.Element("orders").Elements("order").
         Select(z => new Order { Id = z.Element("id").Value, OrderDate = z.Element("orderdate").Value, Total = z.Element("total").Value }).ToList()
                }).Select(x => new Customer { Name = x.Name, FirstOrderDate = x.Orders.FirstOrDefault().
                OrderDate.ConvertDateTimeFormat(), TurnOver = x.Orders.Sum(b => b.Total.ConvertToDoubleValue()) }).
                OrderBy(x => x.FirstOrderDate.ConvertToDateTime().Year).OrderBy(x => x.FirstOrderDate.ConvertToDateTime().Month).
                OrderByDescending(x => x.TurnOver).OrderBy(x => x.Name);

                // query task 6

                var task6 = xdoc.Element("customers").Elements("customer").Where(x =>x.Descendants().Contains(x.Element("postalcode")))
               .Where(x => x.Element("postalcode").Value.NoneNumberFormat() == false).Concat(xdoc.Element("customers").Elements("customer").
               Where(x => x.Descendants().Contains(x.Element("region"))==false)).Concat(xdoc.Element("customers").Elements("customer").
               Where(x=>x.Element("phone").Value.PhoneCodeDoesntMatch()))
                .Select(x => new Customer {Phone=x.Element("phone").Value, Name = x.Element("name").Value, Country = x.Element("country").Value }).ToList();


                //task 7

                var task7 = xdoc.Element("customers").Elements("customer").Where(x => x.Element("orders").Elements("order").Count() >=0)

                  .Select(x => new Customer
                  {
                      City = x.Element("city").Value,
                      Name = x.Element("name").Value,
                      Country = x.Element("country").Value,
                      Orders = x.Element("orders").Elements("order").
       Select(z => new Order { Id = z.Element("id").Value, OrderDate = z.Element("orderdate").Value, Total = z.Element("total").Value }).ToList()
                  }).Select(x => new { City = x.City, TotalSum =x.Orders.Sum(z=>z.Total.ConvertToDoubleValue()), OrdersCount=x.Orders.Count() }).
                  GroupBy(x=>x.City).Select(x=>new {City=x.Key,AverageTotalSum=x.Average(z=>z.TotalSum),
                     Intensity=x.Average(z=>z.OrdersCount)
                  });

                //task 8

                var task83 = xdoc.Element("customers").Elements("customer").Where(x => x.Element("orders").Elements("order").Count() >= 0)

                  .Select(x => new Customer
                  {
                      Name = x.Element("name").Value,
                      Orders = x.Element("orders").Elements("order").
       Select(z => new Order { OrderDate = z.Element("orderdate").Value }).ToList()
                  }).SelectMany(x => x.Orders, (x, y) => new { Name = x.Name, OrderDate = y.OrderDate.ConvertToDateTime() }).
 GroupBy(x => new { x.Name, x.OrderDate.Year, x.OrderDate.Month }, (key, group) => new { Name = key.Name, OrderMonth = key.Month, OrderYear = key.Year, OrderCount = group.Count() }).
                  Select(x => new { Year = x.OrderYear, Month = x.OrderMonth, OrderCount = x.OrderCount, Name = x.Name }).
                  GroupBy(x => x.Name);

                //foreach (var i in task83)
                //{
                //    Console.WriteLine(i.Key);
                //    foreach (var t in i)
                //        Console.WriteLine(t.Month+"."+t.Year+" "+t.OrderCount);
                //    Console.WriteLine();
                //}

              var  task81= xdoc.Element("customers").Elements("customer").Where(x => x.Element("orders").Elements("order").Count() >= 0)

                  .Select(x => new Customer
                  {
                      Name = x.Element("name").Value,
                      Orders = x.Element("orders").Elements("order").
       Select(z => new Order { OrderDate = z.Element("orderdate").Value }).ToList()
                  }).SelectMany(x => x.Orders, (x, y) => new { Name = x.Name, OrderDate = y.OrderDate.ConvertToDateTime() }).
                  GroupBy(x => new { x.Name, x.OrderDate.Month },
                  (key, group) => new { Name = key.Name, OrderMonth = key.Month, OrderCount = group.Count() }).
                    Select(x => new { Month = x.OrderMonth, OrderCount = x.OrderCount, Name = x.Name }).GroupBy(x => x.Name);

                //foreach (var i in task81)
                //{
                //    Console.WriteLine(i.Key);
                //    foreach (var t in i)
                //        Console.WriteLine(t.Month  + " " + t.OrderCount);
                //    Console.WriteLine();
                //}


                var task82 = xdoc.Element("customers").Elements("customer").Where(x => x.Element("orders").Elements("order").Count() >= 0)

                .Select(x => new Customer
                {
                    Name = x.Element("name").Value,
                    Orders = x.Element("orders").Elements("order").
     Select(z => new Order { OrderDate = z.Element("orderdate").Value }).ToList()
                }).SelectMany(x => x.Orders, (x, y) => new { Name = x.Name, OrderDate = y.OrderDate.ConvertToDateTime() }).
                GroupBy(x => new { x.Name, x.OrderDate.Year },
                (key, group) => new { Name = key.Name, OrderYear = key.Year, OrderCount = group.Count() }).
                  Select(x => new {Year = x.OrderYear, OrderCount = x.OrderCount, Name = x.Name }).GroupBy(x => x.Name);

            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                WriteLine(ex.StackTrace);
            }


            Console.ReadKey();
        }
    }
}
