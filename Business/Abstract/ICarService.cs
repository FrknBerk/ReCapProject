using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetCarsByBrandId(int brandId);
        void AddedCar(Car car);
        List<Car> GetCarsByColorId(int colorId);
        List<CarDetailDto> GetCarDetails();
        
    }
}
