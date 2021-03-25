using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
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

        //[SecuredOperation("")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental entity)
        {
            var result = BusinessRules.Run(CanARentalCarBeReturned(entity));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(entity);
            return new SuccessResult();
        }

        //[SecuredOperation("")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult();
        }
        //[SecuredOperation("")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult();
        }

        [CacheAspect()]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        [CacheAspect()]
        public IDataResult<List<RentalDetailDto>> GetAllRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllRentalDetails());
        }

        [CacheAspect()]
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }
        
        [CacheAspect()]
        public IDataResult<List<RentalDetailDto>> GetAllDeliveredRentalDetails()
        {
            var rentalDetailDtos = _rentalDal.GetAllRentalDetails(p => p.ReturnDate != null);
            if (rentalDetailDtos.Count > 0)
                return new SuccessDataResult<List<RentalDetailDto>>(rentalDetailDtos, Messages.GetSuccessRentalMessage);
            else
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.GetErrorRentalMessage);
        }

        private IResult CanARentalCarBeReturned(Rental entity)
        {
            var result = _rentalDal.GetAll(r => r.CarId == entity.CarId && r.ReturnDate == null && r.ReturnDate > entity.RentDate).Count;

            if (result > 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}