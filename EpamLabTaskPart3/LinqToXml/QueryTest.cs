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
        Customer customerForTask7;
        double totalMaxSumValue;
        double totalX;

        [SetUp]
        public void SetUp()
        {
            customersList = Program.GetCustomersList();
            customer = new Customer {Id="152",Name="Zhuravinka",Postalcode="11134",Phone="555-69-69",Fax="555-69-89",
            Address="Lenina Street 25", City="Minsk",Country="Belarus",Region="Europe",Orders=new List<Order>
            { new Order {Id="1258",Total=7000,Orderdate="2000-01-21T00:00:00" },
           new Order {Id="1254",Total=10000,Orderdate="2000-02-21T00:00:00" } }
            };
            totalMaxSumValue = 7500;
            totalX = 5000;
          customerForTask7= new Customer
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
            { new Order {Id="1258",Total=7000,Orderdate="2000-01-21T00:00:00" }}
           
          };
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


        [Test]
        public void TestForTask4()
        {
            int count1 = customersList.Where(x=>x.Orders.Count>0).Select(x => new { Name = x.Name, FirstOrderDate = x.Orders.FirstOrDefault().Orderdate }).ToList().Count();
            customersList.Add(customer);
            int count2 = customersList.Where(x => x.Orders.Count > 0).Select(x => new { Name = x.Name, FirstOrderDate = x.Orders.FirstOrDefault().Orderdate }).ToList().Count();
            Assert.AreEqual(count2 - 1, count1);

        }


        [Test]
        public void TestForTask5()
        {
            int count1 = customersList.Where(x => x.Orders.Count > 0).Select(x => new {  Name = x.Name,  FirstOrderDate = x.Orders.FirstOrDefault().
       Orderdate.ConvertToDateTime(),  TurnOver = x.Orders.Sum(z => z.Total)   }).OrderBy(x => x.FirstOrderDate).ThenBy(x => x.FirstOrderDate.Month).      
       ThenByDescending(x => x.TurnOver).ThenBy(x => x.Name).ToList().Count();   
            
       customersList.Add(customer);

            int count2 = customersList.Where(x => x.Orders.Count > 0).Select(x => new {   Name = x.Name, FirstOrderDate = x.Orders.FirstOrDefault().
 Orderdate.ConvertToDateTime(),TurnOver = x.Orders.Sum(z => z.Total)}).OrderBy(x => x.FirstOrderDate).ThenBy(x => x.FirstOrderDate.Month).    
  ThenByDescending(x => x.TurnOver).ThenBy(x => x.Name).ToList().Count();    
                                   
            Assert.AreEqual(count2 - 1, count1);

        }



        [Test]
        public void TestForTask6()
        {
            int count1 = customersList.Where(x => x.Region == null). 
                Concat(customersList.Where(x => x.Postalcode != null && x.Postalcode.NoneNumberFormat() == false)).                  
                Concat(customersList.Where(x => x.Phone.PhoneCodeDoesntMatch())).ToList().Count();

            customersList.Add(customer);

            int count2 = customersList.Where(x => x.Region == null).
                Concat(customersList.Where(x => x.Postalcode != null && x.Postalcode.NoneNumberFormat() == false)).
                Concat(customersList.Where(x => x.Phone.PhoneCodeDoesntMatch())).ToList().Count();        
                  
            Assert.AreEqual(count2 - 1, count1);

        }

        [Test]
        public void TestForTask7()
        {
            customersList.Add(customer);
            customersList.Add(customerForTask7);

            var list=customersList.Select(x => new { City = x.City, CurrentCityTotalSum = x.Orders.Sum(z => z.Total),
                CurrentCityOrderCount = x.Orders.Count() }).
                    GroupBy(x => x.City).Select(x => new
                    {
                        City = x.Key,
                        AverageTotalSum = x.Average(z => z.CurrentCityTotalSum),
                        Intensity = x.Average(b => b.CurrentCityOrderCount)
                    }).ToList();

            var cust = list.FirstOrDefault(x => x.City == "Minsk");
            Assert.AreEqual(1.5, cust.Intensity);
            Assert.AreEqual(12000, cust.AverageTotalSum);
            Assert.AreEqual("Minsk", cust.City);

        }

        [Test]
        public void TestForTask81()
        {
            customersList.Add(customer);
            customersList.Add(customerForTask7);

            var list = customersList.SelectMany(x => x.Orders, (x, y) => new { Name = x.Name, OrderDate = y.Orderdate.ConvertToDateTime() }).
                    GroupBy(x => new { x.Name, x.OrderDate.Month },
                    (key, group) => new { Name = key.Name, OrderMonth = key.Month, OrderCount = group.Count() }).ToList();

            var cust = list.FirstOrDefault(x => x.Name == "Zhuravinka" && x.OrderMonth == 1);
            var cust1 = list.FirstOrDefault(x => x.Name == "Zhuravinka" && x.OrderCount == 1);
            Assert.AreEqual(2, cust.OrderCount);
            Assert.AreEqual(2, cust1.OrderMonth);

        }






        [TearDown]
        public void CleanUp()
        {
            customersList.Remove(customer);
            if(customersList.Contains(customerForTask7))
            {
                customersList.Remove(customerForTask7);
            }
        }

    }
}
