using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToXmlQueries
{
  public  class Customer
    {
        private List<Order> orders;


        public string Id
        {
            get;
            set;
        }


        public string FirstOrderDate
        {
            get;
            set;
        }

        private string region = "";
   

        public string Name
        {
            get;
            set;
        }

  

        public string Address
        {
            get;
            set;
        }

        public string Country

        {
            get;
            set;
        }

        public string Phone
        {
            get;
            set;
        }

        public string Fax
        {
            get;
            set;
        }
        public List<Order> Orders { get => orders; set => orders = value; }

        public double TurnOver
        {
            get;
            set;
        }
        public string Region { get => region; set => region = value; }

        public override string ToString()
        {
            return Name + "\n" + FirstOrderDate + "\n" + TurnOver + "\n\n";
        }

        public string PostalCode
        {
            get;
            set;
        }

     public double   AverageProfitability
        {
            get;
            set;
        }

        public string City
        {
            get;
            set;
        }

    }
}
