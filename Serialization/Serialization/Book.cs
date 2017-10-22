using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
 [Serializable]
 public   class Book
    {
        private string bookId;

        private string isbn;

        private string author;

        private string title;
      
        private string genre;

        private string publisher;

        private DateTime publish_date;

        private string description;

        private DateTime registration_date;

        public string BookId { get => bookId; set => bookId = value; }

        public string Isbn { get => isbn; set => isbn = value; }

        public string Author { get => author; set => author = value; }

        public string Title { get => title; set => title = value; }

        public string Genre { get => genre; set => genre = value; }

        public string Publisher { get => publisher; set => publisher = value; }

        [XmlElement(DataType = "date")]
        public DateTime Publish_date { get => publish_date; set => publish_date = value; }

        public string Description { get => description; set => description = value; }

        [XmlElement(DataType = "date")]
        public DateTime Registration_date { get => registration_date; set => registration_date = value; }
    }
}
