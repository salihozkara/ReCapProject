using System.Collections.Generic;
using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService:IService<Rental>
    {
        /// <summary>
        /// Aracı teslim al.
        /// </summary>
        IResult DeliverTheCar(Rental rental);

        /// <summary>
        /// Kiralanan ve kiralanmayan tüm araçların detaylı listesidir.
        /// </summary>
        IDataResult<List<RentalDetailDto>> GetAllRentalDetails();

        /// <summary>
        /// Teslim alınmayan tüm araçların detaylı listesidir.
        /// </summary>
        IDataResult<List<RentalDetailDto>> GetAllUndeliveredRentalDetails();

        /// <summary>
        /// Teslim alınan tüm araçların detaylı listesidir.
        /// </summary>
        IDataResult<List<RentalDetailDto>> GetAllDeliveredRentalDetails();
    }
}