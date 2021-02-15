using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public IResult Add(Customer entity)
        {
            _customer.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Customer entity)
        {
            _customer.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<Customer> Get(Expression<Func<Customer, bool>> filter)
        {
            return new SuccessDataResult<Customer>(_customer.Get(filter));
        }

        public IDataResult<List<Customer>> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            return new SuccessDataResult<List<Customer>>(_customer.GetAll(filter));
        }

        public IResult Update(Customer entity)
        {
            _customer.Update(entity);
            return new SuccessResult();
        }
    }
}