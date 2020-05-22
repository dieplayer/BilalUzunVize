using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BilalUzunVize
{
    class Kutuphane
    {
        private static int kitapsayisi;
        private static int tarih;
        
        private static string kitapadi;
        private static string kitapyazari;
        private static string kitapturu;

        public static string KitapAdi { get => kitapadi; set => kitapadi = value; }
        public static string KitapYazari { get => kitapyazari; set => kitapyazari = value; }
        public static DateTime BasimYili { get; set; }
        public static string KitapTuru { get => kitapturu; set => kitapturu = value; }

        public Kutuphane(string kitapadi, string yazaradi, DateTime basimyili, string kitapturu)
        {
            KitapAdi = kitapadi;
            KitapYazari = yazaradi;
            BasimYili = basimyili;
            KitapTuru = kitapturu;
        }
       
        public static void KitapYazdir()
        {
            FileStream fs = new FileStream("C:/kitap/deneme.txt", FileMode.Append, FileAccess.Write, FileShare.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("\n----------------------------" +
                         "\n| Kitap adı  : " + KitapAdi +
                        " \n| Yazar Adı  : " + KitapYazari +
                        " \n| Kitap Türü : " + KitapTuru + 
                        " \n| Basım Yılı : " + BasimYili.Year + 
                    "\n" + "----------------------------");
            fs.Flush();
            sw.Close();
            fs.Close();
        }

        public static void KitapGoruntule()
        {
            int sayac = 0;
            string line;
            StreamReader file = new StreamReader(@"C:/kitap/deneme.txt");
            while ((line = file.ReadLine()) != null)
            {   
                Console.WriteLine(line);
                sayac++;
            }
            file.Close();
            if (sayac>0)
            {
            Console.WriteLine("uygulamaya " +sayac/7+ " adet kitap eklenmiştir");
            }
            else
            {
            Console.WriteLine("uygulamaya henüz kitap eklenmemiştir");
            }
            
        }
       
        public static void KitapEkle()
        {
            Console.WriteLine("\nKaç adet kitap eklenecek?");
            kitapsayisi = Convert.ToInt32(Console.ReadLine());
            Kutuphane[] kitapdizisi = new Kutuphane[kitapsayisi];

            for (int i = 0; i < kitapsayisi; i++)
            {

                Console.WriteLine("\n----------------------------" +
                                "\n\nAdını Giriniz : ");
                KitapAdi = Console.ReadLine();
                Console.WriteLine("\nYazarını Giriniz : ");
                KitapYazari = Console.ReadLine();
                Console.WriteLine("\nBasım Yılını Giriniz : ");
                do
                {
                    tarih = int.Parse(Console.ReadLine());
                    if (tarih > 2020)
                    {
                        Console.WriteLine("Basım Yılı 2020'den Büyük Olamaz.\n Tekrar Giriniz : ");
                    }
                } while (tarih > 2020);
                BasimYili = new DateTime(tarih, 1, 1);
                Console.WriteLine("\nTürünü Giriniz : ");
                KitapTuru = Console.ReadLine();
                Kutuphane kitap = new Kutuphane(KitapAdi, KitapYazari, BasimYili, KitapTuru);
                kitapdizisi[i] = kitap;
                KitapYazdir();
            }
            Console.ReadKey();
        }
    }
}
