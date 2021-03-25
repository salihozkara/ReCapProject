using System.Collections.Generic;
using Business.Abstract.Dto;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;

namespace Business.Concrete.Dto
{
    public class RentalDetailDtoManager:IRentalDetailDtoService
    {
        private IRentalDtoDal _rentalDtoDal;

        public RentalDetailDtoManager(IRentalDtoDal rentalDtoDal)
        {
            _rentalDtoDal = rentalDtoDal;
        }

        public IDataResult<RentalDetailDto> GetByRentalId(int rentalId)
        {
            return new SuccessDataResult<RentalDetailDto>(_rentalDtoDal.Get(r => r.Id == rentalId));
        }

        public IDataResult<List<RentalDetailDto>> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}