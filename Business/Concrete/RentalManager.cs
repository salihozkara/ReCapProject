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
            var result = _rental.GetAll(r=>r.CarId==entity.CarId);
            
            foreach (var rental in result)
            {
                if (rental.ReturnDate == null)
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

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rental.Get(r=>r.Id==id));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rental.GetAll());
        }

        public IResult Update(Rental entity)
        {
            _rental.Update(entity);
            return new SuccessResult();
        }
    }
}