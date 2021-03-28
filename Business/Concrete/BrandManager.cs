using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        //[SecuredOperation("brand.add,admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            IResult result= BusinessRules.Run(CheckIfBrandNameExists(brand.BrandName));
            if(result != null)
            {
                return result;
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionTests(Brand brand)
        {
            _brandDal.Add(brand);
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdate);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        //[PerformanceAspect(5)]
        //[CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll().FindAll(b => b.GetState==true));
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.GetById(c => c.BrandId == brandId));
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdate);
        }
        private IResult CheckIfBrandNameExists(string brandName)
        {
            var result = _brandDal.GetAll(b => b.BrandName == brandName).Any();
            if (result)
            {
                return new ErrorResult(Messages.BrandAddedError);
            }
            return new SuccessResult();
        }
    }
}
