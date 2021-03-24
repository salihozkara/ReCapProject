using System;
using Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        //[SecuredOperation("")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(Brand brand)
        {
            var result=BusinessRules.Run();
            if (result!=null)
            {
                return result;
            }
            _brandDal.Add(brand);
            return new SuccessResult();
        }

        //[SecuredOperation("admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult();
        }

        //[SecuredOperation("")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.EditBrandMessage);
        }

        [CacheAspect]
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

        [CacheAspect]
        public IDataResult<Brand> GetById(int brandId)
        {
            var result = _brandDal.Get(p => p.Id == brandId);

            if (result == null)
            {
                return new ErrorDataResult<Brand>(Messages.GetErrorBrandMessage);
            }
            else
            {
                return new SuccessDataResult<Brand>(result, Messages.GetSuccessBrandMessage);
            }
        }
    }
}