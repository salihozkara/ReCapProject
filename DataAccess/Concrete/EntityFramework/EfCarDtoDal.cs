using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDtoDal:EfDtoRepositoryBase<CarDetailDto,ReCapProjectContext>,ICarDtoDal
    {
        
    }
}