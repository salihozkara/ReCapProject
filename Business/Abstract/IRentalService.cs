using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IResult GetCarControl(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int rentalId);
        IDataResult<RentalDetailDto> GetByRentalIdRentalDetails(int rentalID);
        IDataResult<List<RentalDetailDto>> GetAllRentalDetails();

        /// <summary>
        /// Teslim alınan tüm araçların detaylı listesidir.
        /// </summary>
        IDataResult<List<RentalDetailDto>> GetAllDeliveredRentalDetails();

    }
}