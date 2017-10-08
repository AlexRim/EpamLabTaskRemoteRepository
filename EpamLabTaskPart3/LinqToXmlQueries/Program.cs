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
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xdoc = XDocument.Load("Customers.xml");


            try
            {
// query task2
 var clientGroupadByCountry = xdoc.Element("customers").Elements("customer").
                    Select(x => new Customer { Name = x.Element("name").Value, Country = x.Element("country").Value }).GroupBy(x=>x.Country);
// query task1
     var clientsWithSumOfAllOrdersMoreThanX = xdoc.Element("customers").Elements("customer").Where(x => x.Element("orders").Elements("order")
              .Sum(z => double.Parse(z.Element("total").Value.FormatingDoubleValue())) > 100000).
                Select(x => new Customer { Name = x.Element("name").Value, Country = x.Element("country").Value });


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
   Select(z => new Order { Id = z.Element("id").Value, OrderDate = z.Element("orderdate").Value, Total = z.Element("total").Value }).ToList()
                }).Select(x => new Customer { Name = x.Name,FirstOrderDate=x.Orders.FirstOrDefault().OrderDate.ConvertDateTimeFormat()});


                //query task 5
                var client = xdoc.Element("customers").Elements("customer").Where(x => x.Element("orders").Elements("order").Count() > 0)
                    .Select(x => new Customer
                {
                    Name = x.Element("name").Value,
                    Country = x.Element("country").Value,
                    Orders = x.Element("orders").Elements("order").
         Select(z => new Order { Id = z.Element("id").Value, OrderDate = z.Element("orderdate").Value, Total = z.Element("total").Value }).ToList()
                }).Select(x => new Customer { Name = x.Name, FirstOrderDate = x.Orders.FirstOrDefault().OrderDate.ConvertDateTimeFormat(), TurnOver = x.Orders.Sum(b => b.Total.ConvertToDoubleValue()) }).
                OrderBy(x => x.FirstOrderDate.ConvertToDateTime().Year).OrderBy(x => x.FirstOrderDate.ConvertToDateTime().Month).
                OrderByDescending(x => x.TurnOver).OrderBy(x => x.Name);

                // query task 6

                var task6 = xdoc.Element("customers").Elements("customer").Where(x =>x.Descendants().Contains(x.Element("postalcode")))
               .Where(x => x.Element("postalcode").Value.NoneNumberFormat() == false).Concat(xdoc.Element("customers").Elements("customer").
               Where(x => x.Descendants().Contains(x.Element("region"))==false)).Concat(xdoc.Element("customers").Elements("customer").
               Where(x=>x.Element("phone").Value.PhoneCodeDoesntMatch()))
                .Select(x => new Customer {Phone=x.Element("phone").Value, Name = x.Element("name").Value, Country = x.Element("country").Value });


                //task 7

   //             var task7 = xdoc.Element("customers").Elements("customer").Where(x => x.Element("orders").Elements("order").Count() > 0).
   //                    Select(x => new Customer
   //                    {
   //                        City = x.Element("city").Value,
   //                        Name = x.Element("name").Value,
   //                        Country = x.Element("country").Value,
   //                        Orders = x.Element("orders").Elements("order").
   //Select(z => new Order { Id = z.Element("id").Value, OrderDate = z.Element("orderdate").Value, Total = z.Element("total").Value }).ToList()
   //                    }).Select(x)






                foreach (var i in task6)
                {
                   
                        WriteLine(i.Name+"//// "+ i.Phone);


                }


                //string str = "1997-10-03T00:00:00";
                //var dateTime = DateTime.Parse(str);

                //WriteLine(dateTime.ToString());


                //   .Value.FormatingDoubleValue()) > 5000)
                //   Where(z=>double.Parse(z.Element("total").Value.FormatingDoubleValue())>5000).              
                //Select(c => new Customer { Name = c.Element("name").Value, Country = c.Element("country").Value }));




                //var ernst = xdoc.Element("customers").Elements("customer").First(x => x.Element("name").Value == "QUICK-Stop")
                //    .Element("orders").Elements("order")
                //   .Sum(z => double.Parse(z.Element("total").Value.Replace('.', ',')));

                //foreach (var i in q)
                //{
                //    WriteLine(i.Name);
                //}





                //foreach (var i in items)
                //{
                //    Console.WriteLine(i.Key);
                //    foreach (var t in i)
                //        Console.WriteLine(t.Name);
                //    Console.WriteLine();
                //}




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
