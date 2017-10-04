using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;



namespace LinqToXmlQueries
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xdoc = XDocument.Load("Customers.xml");


            try
            {

 var items = xdoc.Element("customers").Elements("customer").
                    Select(x => new Customer { Name = x.Element("name").Value, Country = x.Element("country").Value }).GroupBy(x=>x.Country);

              //  var items1=xdoc.Element("customers").Elements("customer").Select(x=>x.Elements("Orders")
               //   .Select(z=>new Order {Id=z.Element("id").Value,Total=z.Element("total").Value,OrderDate=z.Element("orderDate").Value}));
                 

                foreach (var i in items)
                {
                    Console.WriteLine(i.Key);
                    foreach (var t in i)
                        Console.WriteLine(t.Name);
                    Console.WriteLine();
                }

                IEnumerable<XElement> tracks = xdoc.Root.Descendants("track").Where(
				t => t.Element("artist").Value == "DMX");
tracks.Remove();



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }


            Console.ReadKey();
        }
    }
}
