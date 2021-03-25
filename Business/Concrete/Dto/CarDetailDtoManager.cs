using System.Collections.Generic;
using Business.Abstract.Dto;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;

namespace Business.Concrete.Dto
{
    public class CarDetailDtoManager:ICarDetailDtoService
    {
        private ICarDtoDal _carDtoDal;

        public CarDetailDtoManager(ICarDtoDal carDtoDal)
        {
            _carDtoDal = carDtoDal;
        }

        public IDataResult<CarDetailDto> GetByCarId(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDtoDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetAll()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDtoDal.GetAll());
        }
    }
}