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

            
            Console.ReadKey();
        }

       
    }
}
