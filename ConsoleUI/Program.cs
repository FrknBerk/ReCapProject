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

            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Brand brand = new Brand();
            brand.BrandName = "BMW M4";
            brand.GetState = true;
           
            var brandAdded = brandManager.Add(brand);
            if (brandAdded.Success == true)
            {
                Console.WriteLine(brandAdded.Message);
            }
            else
            {
                Console.WriteLine(brandAdded.Message);
            }
        
            Console.ReadLine();
        }
    }
}
