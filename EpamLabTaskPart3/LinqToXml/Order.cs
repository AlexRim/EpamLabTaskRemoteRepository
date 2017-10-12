
using System;

namespace LinqToXml
{
    public class Order
    {
        private string id;
        private string orderdate= "0000-00-00T00:00:00";
        private double total=0;


        public string Id { get => id; set => id = value; }
        public string Orderdate { get => orderdate; set => orderdate = value; }
        public double Total { get => total; set => total = value; }




    }
}