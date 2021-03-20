using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental entity)
        {
            var result = BusinessRules.Run(CanARentalCarBeReturned(entity));
            if (result!=null)
            {
                return result;
            }


            _rentalDal.Add(entity);
            return new SuccessResult();
        }

        private IResult CanARentalCarBeReturned(Rental entity)
        {
            var result = _rentalDal.GetAll(r => r.CarId == entity.CarId && r.ReturnDate == null && r.ReturnDate > entity.RentDate).Count;

            if (result>0)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult();
        }

        public IResult DeliverTheCar(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<RentalDetailDto>> GetAllRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllRentalDetails());
        }

        public IDataResult<List<RentalDetailDto>> GetAllUndeliveredRentalDetails()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<RentalDetailDto>> GetAllDeliveredRentalDetails()
        {
            throw new NotImplementedException();
        }
    }
}