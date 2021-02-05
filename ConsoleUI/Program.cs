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
            //CarManager carManager = new CarManager(new InMemoryCarDal());

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}

            //Brand brand = new Brand();
            //brand.BrandName = "Bmw M5";
            //EfBrandDal efBrand = new EfBrandDal();
            //efBrand.Add(brand);

            //Color color = new Color();
            //color.ColorName = "Beyaz";
            //EfColorDal efColor = new EfColorDal();
            //efColor.Add(color);

            //Car car = new Car();
            //car.DailyPrice = 200;
            //car.BrandId = 3;
            //car.ColorId = 2;
            //car.Description = "Kiralık";
            //car.ModelYear = 2018;


            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.AddedCar(car);

            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine("Id :{0} BrandId :{1} ColorId:{2} ModelYear : {3} DailyPrice : {4} Description:{5} ",
                    cars.Id, cars.BrandId, cars.ColorId, cars.ModelYear, cars.DailyPrice, cars.Description);
            }

            foreach (var color in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(color.ColorId);
            }
            Console.WriteLine("\n");
            foreach (var brand in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(brand.BrandId);
            }

            Console.ReadKey();
        }
    }
}
