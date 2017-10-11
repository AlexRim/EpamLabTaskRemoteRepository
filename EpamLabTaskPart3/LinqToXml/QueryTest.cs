using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NUnit.Framework;
using System.IO;
using static System.Console;

namespace LinqToXml
{
    [TestFixture]
    class QueryTest
    {
        List<Customer> customersList;
        Customer customer;
        double totalMaxSumValue;
        double totalX;

        [SetUp]
        public void SetUp()
        {
            customersList = Program.GetCustomersList();
            customer = new Customer {Id="152",Name="Zhuravinka",Postalcode="1sd34",Phone="555-69-69",Fax="555-69-89",
            Address="Lenina Street 25", City="Minsk",Country="Belarus",Region="Europe",Orders=new List<Order>
            { new Order {Id="1258",Total=7000,Orderdate="1997-01-21T00:00:00".ConvertToDateTime() },
           new Order {Id="1254",Total=1000,Orderdate="1997-02-21T00:00:00".ConvertToDateTime() } }
            };
            totalMaxSumValue = 7500;
            totalX = 50;
    }


        [Test]
        public void TestForTask1()
        {           
            int count1 = customersList.GetTask1List(totalMaxSumValue).Count();
            customersList.Add(customer);
            int count2 = customersList.GetTask1List(totalMaxSumValue).Count();
            Assert.AreEqual(count2-1, count1);
        }

    

        [Test]
        public void TestForTask2()
        {
            int count1 = customersList.GetTask2List().Count();
            customersList.Add(customer);
            int count2 = customersList.GetTask2List().Count();
            Assert.AreEqual(count2 - 1, count1);

        }


        [Test]
        public void TestForTask3()
        {
            int count1 = customersList.GetTask3List(totalX).Count();
            customersList.Add(customer);
            int count2 = customersList.GetTask3List(totalX).Count();
            Assert.AreEqual(count2 - 1, count1);

        }


        [TearDown]
        public void CleanUp()
        {
            customersList.Remove(customer);
        }

    }
}
