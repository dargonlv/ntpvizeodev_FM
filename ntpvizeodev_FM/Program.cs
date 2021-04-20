﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Timers;

namespace ntpvizeodev_FM
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Timer t = new Timer(1000);//60000 = 1 dakka 60000*5=300000
            t.Elapsed += new ElapsedEventHandler(islemler);
            t.Start();
            while (true)
            {

            }
        }

        public static void islemler(object o, ElapsedEventArgs a)
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


            XElement site;
            site = XElement.Load("http://rss.beyazperde.com/haberler/filmler?format=xml");

            var list = site.Elements().Elements("item").ToList();
            /////////////////////////////
            StreamReader eski = new StreamReader("deneme.txt");
            string eskiveri= eski.ReadToEnd();
            eski.Close();
            ////////////////////////////////
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
            ////////////////////////////////////////////
            StreamReader yeni = new StreamReader("deneme.txt");
            string yeniveri = yeni.ReadToEnd();
            if (yeniveri!=eskiveri)
            {
                Console.WriteLine("\n\tYeni bir kaç haber var !!\n");
            }
            ///////////////////////////////////////////////
            Console.ReadKey();
        }
       
    }
}
