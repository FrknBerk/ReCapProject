using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimited(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Update(CarImage carImage)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(CarImage carImage)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImageList);
        }

        public IDataResult<List<CarImage>> GetImageByCarId(int carId)
        {
            //IResult result = BusinessRules.Run(CheckIfCarIdImageExists(carId));
            //if (result != null)
            //{
            //    return null;
            //}
            CheckIfCarIdImageExists(carId);
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }
      
        
        private IResult CheckIfCarImageLimited(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if(result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimited);
            }
            return new SuccessResult();
        }


        private IResult CheckIfCarIdImageExists(int carId)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "C:\\Users\\FurkanBerk\\source\repos\\ReCapProject\\WebAPI\\wwwroot\\uploads\\8a5b12f4-a7ba-4ea4-9af7-222bd6df526dlogo.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result == 0)
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage> { new CarImage { ImagePath=path } });
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
            
        }
    }
}
