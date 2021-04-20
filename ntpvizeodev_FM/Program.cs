using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;


namespace ntpvizeodev_FM
{
    class Program
    {
        public static XElement site = XElement.Load("http://rss.beyazperde.com/haberler/filmler?format=xml");
        public static List<XElement> list = site.Elements().Elements("item").ToList();
        static void Main(string[] args)
        {
            

        
            }

        public static void islemler()
        {
            if (File.Exists("deneme.txt"))
            {

            }
            else
            {
                FileStream fs = new FileStream("deneme.txt", FileMode.OpenOrCreate, FileAccess.Write);
                Console.WriteLine("eklendi");
                fs.Close();
            }

            
            StreamWriter sil = new StreamWriter("deneme.txt");
            sil.Write("");
            sil.Close();
            Console.Clear();


            StreamWriter Yaz = new StreamWriter("deneme.txt", true);
            int uzunluk;
            
            foreach (var item in list)
            {
                Console.WriteLine(item.Element("title").Value);
                Console.WriteLine(Convert.ToDateTime(item.Element("pubDate").Value));////<----///
                XElement aciklama = item.Element("description");
                uzunluk = aciklama.Value.IndexOf("&", 0, aciklama.Value.Length - 1);
                Console.WriteLine(aciklama.Value.Substring(0, uzunluk - 3));
                Console.WriteLine("\n-------------------------------------------\n");

                Yaz.WriteLine(item.Element("title").Value);
                Yaz.WriteLine(Convert.ToDateTime(item.Element("pubDate").Value));

                Yaz.WriteLine(aciklama.Value.Substring(0, uzunluk - 3));
                Yaz.WriteLine("\n-------------------------------------------\n");

            }
            Yaz.Close();
            Console.ReadKey();
        }

        public static void ss()
        {
            
            while (true)
            {

                StreamReader eski = new StreamReader("deneme.txt");
                string eskiveri = eski.ReadToEnd();
                eski.Close();

                StreamWriter Yaz = new StreamWriter("deneme.txt", true);
                int uzunluk;
                string yeniveri = "";
                foreach (var items in list)
                {
                    XElement aciklama = items.Element("description");
                    uzunluk = aciklama.Value.IndexOf("&", 0, aciklama.Value.Length - 1);

                    yeniveri += (items.Element("title").Value) + "\n";
                    yeniveri += (Convert.ToDateTime(items.Element("pubDate").Value)) + "\n";

                    yeniveri += (aciklama.Value.Substring(0, uzunluk - 3)) + "\n";
                    yeniveri += ("\n-------------------------------------------\n") + "\n";

                }
                Yaz.Close();

                
            }
        }
        
       
    }
}
