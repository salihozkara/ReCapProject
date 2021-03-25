using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract.Dto
{
    public interface ICarDetailDtoService
    {
        IDataResult<CarDetailDto> GetByCarId(int carId);
        IDataResult<List<CarDetailDto>> GetAll();
    }
}