using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ntpvizeodev_FM
{
    class Program
    {
        
        static void Main(string[] args)
        {
            XElement site;
            site = XElement.Load("http://rss.beyazperde.com/haberler/filmler?format=xml");

            var list = site.Elements().Elements("item").ToList();



            
            foreach (var item in list)
            {
                Console.WriteLine(item.Element("title").Value);
                Console.WriteLine(Convert.ToDateTime(item.Element("pubDate").Value));////<----///
                

                Console.WriteLine("\n-------------------------------------------\n");

            }
            Console.ReadKey();
        }

       
    }
}
