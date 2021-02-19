using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        public static bool döngü;
        public static int secim;
        static void Main(string[] args)
        {

            Console.WriteLine("1-Renk İşlemleri");
            Console.WriteLine("2-Marka İşlemleri");
            Console.WriteLine("3-Araba İşlemleri");
            Console.WriteLine("4-Kullanıcı İşlemleri");
            Console.WriteLine("5-Müşteri İşlemleri");
            Console.WriteLine("6-Araç Kiralama İşlemleri");
            Console.WriteLine("7-Çıkış\n");
            döngü = true;

            while (döngü)
            {
                Console.WriteLine("Yukarıdaki menüden seçiniz");
                secim = Convert.ToInt32(Console.ReadLine());
                switch (secim)
                {
                    case 1:
                        ColorOperations();
                        döngü = true;
                        break;
                    case 2:
                        BrandOperations();
                        döngü = true;
                        break;
                    case 3:
                        döngü = true;
                        break;
                    case 4:
                        döngü = true;
                        break;
                    case 5:
                        döngü = true;
                        break;
                    case 6:
                        döngü = true;
                        break;
                    case 7:
                        döngü = false;
                        break;
                    default:
                        Console.WriteLine("1 ile 7 arasında seçim yapınız");
                        döngü = true;
                        break;
                }
            }


            Console.ReadLine();
        }
        public static void ColorOperations()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("1-Renk listele");
            Console.WriteLine("2-Renk ekle");
            Console.WriteLine("3-Renk güncelle");
            Console.WriteLine("4-Renk sil");
            Console.WriteLine("5-Üst menüye dön\n");
            döngü = true;
            while (döngü)
            {
                ColorManager colorManager = new ColorManager(new EfColorDal());
                Color color = new Color();
                Console.WriteLine("Yukarıdaki menüden seçiniz");
                secim = Convert.ToInt32(Console.ReadLine());
                switch (secim)
                {
                    case 1:
                        ColorList(colorManager);
                        break;
                    case 2:
                        Console.WriteLine("Renk ismi giriniz");
                        color.ColorName = Console.ReadLine();
                        color.GetState = true;
                        var colorAdded =colorManager.Add(color);
                        if (colorAdded.Success==true)
                        {
                            Console.WriteLine(Messages.ColorAdded);
                        }
                        break;
                    case 3:
                        ColorList(colorManager);
                        Console.WriteLine("Yukarıdan güncellenecek renk id sini seçiniz");
                        color.ColorId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Renk ismi");
                        color.ColorName = Console.ReadLine();
                        color.GetState = true;
                        var colorUpdated = colorManager.Update(color);
                        if (colorUpdated.Success==true)
                        {
                            Console.WriteLine(Messages.ColorUpdated);
                        }
                        break;
                    case 4:
                        ColorList(colorManager);
                        Console.WriteLine("Yukarıdan silinecek renk id sinizi seçiniz");
                        color.ColorId = Convert.ToInt32(Console.ReadLine());
                        color.GetState = false;
                        var colorDelete = colorManager.Delete(color);
                        if (colorDelete.Success==true)
                        {
                            Console.WriteLine(Messages.ColorDeleted);
                        }
                        break;
                    case 5:
                        döngü = false;
                        break;
                    default:
                        Console.WriteLine("");
                        break;
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void ColorList(ColorManager colorManager)
        {
            var colorList = colorManager.GetAll();
            if (colorList.Success == true)
            {
                Console.WriteLine(Messages.ColorList);
                foreach (var colorlist in colorList.Data)
                {
                    Console.WriteLine("Renk Id:{0} Renk Adı:{1}", colorlist.ColorId, colorlist.ColorName);
                }
            }
        }

        public static void BrandOperations()
        {
            Console.WriteLine("Brand İşlemleri");
        }
        
    }
    
}
