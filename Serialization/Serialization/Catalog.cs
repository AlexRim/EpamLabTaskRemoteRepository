using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
  [Serializable]
   public class BookList
    {
        [XmlElement("catalog")]
        public List<Book> Catalog { get ; set ; }
      
    }
}
