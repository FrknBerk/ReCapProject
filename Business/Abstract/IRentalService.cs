using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult RentCarId(int carId);//Araç kiralama kontrol
        IResult RentAdd(Rental rental);//Araç kiralama
        IResult Update(Rental rental);
        IResult Delete(Rental rental);

        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalCarDetailDto>> GetRentalCarDetails();
    }
}
