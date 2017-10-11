
using System;

namespace LinqToXml
{
    public class Order
    {
        private string id;
        private DateTime orderdate;
        private double total;


        public string Id { get => id; set => id = value; }
        public DateTime Orderdate { get => orderdate; set => orderdate = value; }
        public double Total { get => total; set => total = value; }




    }
}