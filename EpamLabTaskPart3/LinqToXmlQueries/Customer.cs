using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToXmlQueries
{
    class Customer
    {
        private List<Order> orders = new List<Order>();

        public string Name
        {
            get;
            set;
        }

        public string Id
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
    }
}
