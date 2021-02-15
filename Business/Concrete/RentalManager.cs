using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rental;

        public RentalManager(IRentalDal rental)
        {
            _rental = rental;
        }

        public IResult Add(Rental entity)
        {
            Rental result = this.Get(p=>p.CarId==entity.CarId).Data;
            if (result!=null)
            {
                if (result.RentDate == null)
                {
                    return new ErrorResult();
                }
            }
            _rental.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Rental entity)
        {
            _rental.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<Rental> Get(Expression<Func<Rental, bool>> filter)
        {
            return new SuccessDataResult<Rental>(_rental.Get(filter));
        }

        public IDataResult<List<Rental>> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            return new SuccessDataResult<List<Rental>>(_rental.GetAll(filter));
        }

        public IResult Update(Rental entity)
        {
            _rental.Update(entity);
            return new SuccessResult();
        }
    }
}