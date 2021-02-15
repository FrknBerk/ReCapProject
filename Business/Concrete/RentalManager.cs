using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
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
            var result = _rentalDal.GetById(r => r.CarId == carId && r.ReturnDate == null );
            if(result.ReturnDate==null)
            {
                return new ErrorResult(Messages.RentalDate);
            }
            else
            {
                return new SuccessResult(Messages.RentalAdded);
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
    }
}
