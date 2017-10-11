using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using LinqToXmlQueries;

namespace LinqToXmlTests
{
    class Query
    {
        public List<XElement> GetTask1()
        {
            XDocument xdoc = XDocument.Load("Test.xml");
            var t1= xdoc.Element("customers").Elements("customer").
               Where(x => x.Element("orders").Elements("order")
         .Sum(z => double.Parse(z.Element("total").Value.FormatingDoubleValue())) > 1000).ToList();
            return t1;
          // Select(x => new Customer { Name = x.Element("name").Value, Country = x.Element("country").Value });
        }











    }
}
