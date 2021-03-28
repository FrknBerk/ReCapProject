using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentaCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             select new CarDetailDto
                             {
                                 CarId=car.CarId,
                                 Description = car.Description,
                                 BrandName= brand.BrandName,
                                 DailyPrice =car.DailyPrice,
                                 ColorName =color.ColorName,
                                 BrandId=brand.BrandId,
                                 ColorId=color.ColorId
                             };
                return result.ToList();
            }
        }
    }
}
