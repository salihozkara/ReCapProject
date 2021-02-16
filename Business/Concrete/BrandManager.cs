using System;
using Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Core.Business;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brand;

        public BrandManager(IBrandDal brand)
        {
            _brand = brand;
        }

        public IResult Add(Brand brand)
        {
            _brand.Add(brand);
            return new SuccessResult();
        }

        public IResult Delete(Brand brand)
        {
            _brand.Delete(brand);
            return new SuccessResult();
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brand.Get(b=>b.Id==id));
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brand.GetAll());
        }
        
        public IResult Update(Brand brand)
        {
            _brand.Update(brand);
            return new SuccessResult();
        }

    }
}