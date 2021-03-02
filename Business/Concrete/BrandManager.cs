using System;
using Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Core.Business;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult();
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult();
        }

        public IDataResult<Brand> GetById(int id)
        {
            var result = _brandDal.Get(p => p.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<Brand>(Messages.GetErrorBrandMessage);
            }
            else
            {
                return new SuccessDataResult<Brand>(result, Messages.GetSuccessBrandMessage);
            }
        }

        public IDataResult<List<Brand>> GetAll()
        {
            var result = _brandDal.GetAll();
            if (result == null)
            {
                return new ErrorDataResult<List<Brand>>(Messages.GetErrorBrandMessage);
            }
            else
            {
                return new SuccessDataResult<List<Brand>>(result, Messages.GetSuccessBrandMessage);
            }
        }
        
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.EditBrandMessage);
        }

    }
}