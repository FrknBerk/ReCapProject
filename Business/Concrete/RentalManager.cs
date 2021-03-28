using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
   // Mesela Rental tablosuna ekleme yapmadan önde Eklenecek Car Id nin car tablosunda olup olmadığını
   //yada rent işlemini yapacak Customer ID nin tabloda var olup olmadığını kontrol edip ekleme işlemi yapabilirsiniz eğer sorunuzu yanlış anlamadıysam
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
       
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        
        public IResult RentCarId(int carId)
        {
            //var result = _rentalDal.GetById(r => r.CarId == carId && r.ReturnDate == null);
            var result = _rentalDal.GetById(r => r.CarId == carId);
            if (result.ReturnDate != null)
            {
                //return new ErrorResult(Messages.RentalDate);
                return new ErrorResult(Messages.RentalSuccesAdded);
            }
            else
            {
                //return new ErrorResult(Messages.RentalSuccesAdded);
                return new ErrorResult(Messages.RentalDate);
            }
        }


        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult RentAdd(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IDataResult<List<RentalCarDetailDto>> GetRentalCarDetails()
        {
            return new SuccessDataResult<List<RentalCarDetailDto>>(_rentalDal.GetRentalCarDetails());
        }

       
    }
}
