using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static NUnit.Framework.Assert;
using LinqToXmlQueries;
using System.Xml.Linq;


namespace LinqToXmlTests
{
    [TestFixture]
    class LinqToXmlTestClass
    {

        [Test]
        public void Test1()
        {

            //XDocument xdoc = XDocument.Load("Test.xml");
            //var task1 = xdoc.Element("customers").Elements("customer").
            //Where(x => x.Element("orders").Elements("order")
            //.Sum(z => double.Parse(z.Element("total").Value.FormatingDoubleValue())) > 5000).ToList();
            //int count1 = task1.Count;
            //Select(x => new Customer { Name = x.Element("name").Value, Country = x.Element("country").Value, }).ToList();

            //XElement customer = new XElement("customer");
            //var name = new XElement("name", "TestName");
            //var country = new XElement("country", "TestCountry");
            //customer.Add(name);
            //customer.Add(country);
            //var orders = new XElement("orders");
            //var order = new XElement("order");
            //var total = new XElement("total", "10000");
            //order.Add(total);
            //orders.Add(order);
            //customer.Add(orders);
            //task1.Add(customer);

            //int count2 = task1.Count;

            Assert.AreEqual(10, 5 + 5);

        }


        [Test]

        public void SumOfTwoNumbers()

        {

            Assert.AreEqual(10, 5 + 5);

        }



    }
}
