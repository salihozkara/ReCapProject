using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
        List<RentalDetailDto> GetAllRentalDetails(Expression<Func<Rental, bool>> filter = null);
        RentalDetailDto GetRentalDetails(Expression<Func<Rental, bool>> filter);
    }
}