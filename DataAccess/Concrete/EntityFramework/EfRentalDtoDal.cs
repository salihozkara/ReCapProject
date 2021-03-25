using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDtoDal:EfDtoRepositoryBase<RentalDetailDto,ReCapProjectContext>,IRentalDtoDal
    {
        
    }
}