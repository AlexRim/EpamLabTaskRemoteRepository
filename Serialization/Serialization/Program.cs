using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Serialization
{
    class Program
    {

        static void SaveXml(object obj, string filename)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Book));
           
                using (Stream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fs, obj);
            }
            
        }


        static void Main(string[] args)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(BookList));

                using (FileStream fileStream = new FileStream("Books.xml", FileMode.Open))
                {
                    BookList result = (BookList)serializer.Deserialize(fileStream);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            Console.ReadKey();


        }
    }
}
