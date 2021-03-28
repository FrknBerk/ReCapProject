using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentaCarContext>, IRentalDal
    {
      public List<RentalCarDetailDto> GetRentalCarDetails()
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                var result = from rental in context.Rentals
                             join brand in context.Brands
                             on rental.CarId equals brand.BrandId
                             join user in context.Users
                             on rental.CustomerId equals user.Id
                             select new RentalCarDetailDto
                             {
                                 BrandName = brand.BrandName,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
