using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToXml
{
    class Customer
    {
        private string id;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string Postalcode { get => postalcode; set => postalcode = value; }
        public string Country { get => country; set => country = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Fax { get => fax; set => fax = value; }
        public string Region { get => region; set => region = value; }
        internal List<Order> Orders { get => orders; set => orders = value; }

        private string name;
        private string address;
        private string city;
        private string postalcode;
        private string country;
        private string phone;
        private string fax ;
        private string region;
        private List<Order> orders;





    }
}
