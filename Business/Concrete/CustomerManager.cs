using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customer;

        public CustomerManager(ICustomerDal customer)
        {
            _customer = customer;
        }
        //[SecuredOperation("")]
        [CacheRemoveAspect("ICustomerService.Get")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer entity)
        {
            _customer.Add(entity);
            return new SuccessResult();
        }

        //[SecuredOperation("")]
        [CacheRemoveAspect("ICustomerService.Get")]]
        public IResult Delete(Customer entity)
        {
            _customer.Delete(entity);
            return new SuccessResult();
        }

        //[SecuredOperation("")]
        [CacheRemoveAspect("ICustomerService.Get")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer entity)
        {
            _customer.Update(entity);
            return new SuccessResult();
        }

        [CacheAspect()]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customer.GetAll());
        }

        [CacheAspect()]
        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customer.Get(c=>c.Id==customerId));
        }
        
    }
}