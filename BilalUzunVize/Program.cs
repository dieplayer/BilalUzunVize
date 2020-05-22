using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilalUzunVize
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {                               
                Console.WriteLine("Kitapevi Sistemine Hoşgeldiniz");
                Console.WriteLine("\nKitap eklemek için 1'e " +
                                  "\nKitapları görüntülemek için 2'ye basınız\n");               
                byte sayi = Convert.ToByte(Console.ReadLine());
                switch (sayi)
                {
                    case 1:
                        Console.WriteLine("----------------------------\n");
                        Kutuphane.KitapEkle();
                        break;
                    case 2:
                        Kutuphane.KitapGoruntule();
                        break;
                    default:
                        Console.WriteLine("Lütfen 1 yada 2'ye basınız");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Lütfen 1 yada 2'ye basınız");
            }
            Console.ReadKey();
        }
    }
}
