using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract.Dto
{
    public interface IRentalDetailDtoService
    {
        IDataResult<RentalDetailDto> GetByRentalId(int rentalId);
        IDataResult<List<RentalDetailDto>> GetAll();
    }
}