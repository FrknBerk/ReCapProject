using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("Araç Kiralama Sistemine Hoşgeldiniz");
            bool secim = true;
            bool secimone = true;
            while (secim)
            {
                Console.WriteLine("Lütfen Aşağıdaki Menüden İşleminizi Seçiniz");
                Console.WriteLine("1-Araç İşlemleri");
                Console.WriteLine("2-Color İşlemleri");
                Console.WriteLine("3-Brand İşlemleri");
                Console.WriteLine("4-Çıkış");
                int sec = Convert.ToInt32(Console.ReadLine());
                switch (sec)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Red;
                        while (secimone)
                        {

                            Console.WriteLine("1-Araç Listele");
                            Console.WriteLine("2-Araç Ekle");
                            Console.WriteLine("3-Marka ya göre Araç Bilgileri Getir");
                            Console.WriteLine("4-Renk e göre Araç Bilgileri Getir");
                            Console.WriteLine("5-Bir üst menüye dön");
                            int secone = Convert.ToInt32(Console.ReadLine());
                            switch (secone)
                            {
                                case 1:
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    foreach (var cars in carManager.GetCarDetails())
                                    {
                                        Console.WriteLine("Marka:{0} Renk:{1} Günlük:{2} Açıklama:{3}", cars.BrandName, cars.ColorName, cars.DailyPrice, cars.Description);
                                    }
                                    break;
                                case 2:
                                    Car car = new Car();
                                    Console.WriteLine("Araç Markası giriniz");
                                    car.BrandId = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Araç Rengi Giriniz");
                                    car.ColorId = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Araç Fiyatı Giriniz");
                                    car.DailyPrice = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Model Giriniz");
                                    car.ModelYear = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Açıklama giriniz");
                                    car.Description = Console.ReadLine();
                                    carManager.AddedCar(car);
                                    break;
                                case 3:
                                    int brandId = Convert.ToInt32(Console.ReadLine());
                                    foreach (var brand in carManager.GetCarsByBrandId(brandId))
                                    {
                                        Console.WriteLine("Id:{0} Renk:{1} ", brand.BrandId, brand.ColorId);
                                    }
                                    break;
                                case 4:
                                    Console.WriteLine("Color Id giriniz");
                                    int colorId = Convert.ToInt32(Console.ReadLine());
                                    foreach (var color in carManager.GetCarsByColorId(colorId))
                                    {
                                        Console.WriteLine("Renk Id:{0} Marka Id:{1}  Fiyat:{2}",color.ColorId,color.BrandId,color.DailyPrice);
                                    }
                                    break;
                                case 5:
                                    secimone = false;
                                    break;
                                default:
                                    Console.WriteLine("Lütfen 1 ile 5 arasında sayı giriniz");
                                    break;
                            }
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Red;
                        while (secimone)
                        {

                            Console.WriteLine("1-Renk Listele");
                            Console.WriteLine("2-Renk Ekle");
                            Console.WriteLine("3-Renk Güncelle");
                            Console.WriteLine("4-Bir üst menüye dön");
                            int secone = Convert.ToInt32(Console.ReadLine());
                            switch (secone)
                            {
                                case 1:
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    foreach (var colors in colorManager.GetAll())
                                    {
                                        Console.WriteLine("Renk Id:{0} Renk Adı:{1}", colors.ColorId,colors.ColorName);
                                    }
                                    break;
                                case 2:
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Color color = new Color();
                                    Console.WriteLine("Renk Adı Giriniz");
                                    color.ColorName = Console.ReadLine();
                                    colorManager.Add(color);
                                    break;
                                case 3:
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    foreach (var colors in colorManager.GetAll())
                                    {
                                        Console.WriteLine("Renk Id:{0} Renk Adı:{1}",colors.ColorId,colors.ColorName);
                                    }
                                    Console.WriteLine("Güncellemek istediğiniz renk ıdsini giriniz");
                                    colorManager.Update(new Color
                                    {
                                        ColorId = Convert.ToInt32(Console.ReadLine()),
                                        ColorName=Console.ReadLine(),
                                    });
                                    break;
                               
                                case 4:
                                    secimone = false;
                                    break;
                                default:
                                    Console.WriteLine("Lütfen 1 ile 4 arasında sayı giriniz");
                                    break;
                            }
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Red;
                        while (secimone)
                        {

                            Console.WriteLine("1-Marka Listele");
                            Console.WriteLine("2-Marka Ekle");
                            Console.WriteLine("3-Marka Güncelle");
                            Console.WriteLine("4-Bir üst menüye dön");
                            int secone = Convert.ToInt32(Console.ReadLine());
                            switch (secone)
                            {
                                case 1:
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    foreach (var brands in brandManager.GetAll())
                                    {
                                        Console.WriteLine("Marka Id:{0} Marka Adı:{1}", brands.BrandId,brands.BrandName);
                                    }
                                    break;
                                case 2:
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Brand  brand = new Brand();
                                    Console.WriteLine("Marka Adı Giriniz");
                                    brand.BrandName = Console.ReadLine();
                                    brandManager.Add(brand);
                                    break;
                                case 3:
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    foreach (var brands in brandManager.GetAll())
                                    {
                                        Console.WriteLine("Marka Id:{0} Marka Adı:{1}", brands.BrandId,brands.BrandName);
                                    }
                                    Console.WriteLine("Güncellemek istediğiniz marka ıdsini giriniz");
                                    brandManager.Update(new Brand
                                    {
                                        BrandId = Convert.ToInt32(Console.ReadLine()),
                                        BrandName = Console.ReadLine(),
                                    });
                                    break;

                                case 4:
                                    secimone = false;
                                    break;
                                default:
                                    Console.WriteLine("Lütfen 1 ile 4 arasında sayı giriniz");
                                    break;
                            }
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        break;
                    case 4:
                        secim = false;
                        break;
                    default:
                        Console.WriteLine("Lütfen 1 ile 5 arasında değer giriniz");
                        break;
                }
                Console.ForegroundColor = ConsoleColor.White;
            }


            Console.ReadKey();
        }
    }
}
