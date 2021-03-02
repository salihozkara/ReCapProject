using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal :EfEntityRepositoryBase<Car, ReCapProjectContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectContext context=new ReCapProjectContext())
            {
                var result = 
                    from car in filter == null ? context.tblCars : context.tblCars.Where(filter)
                    join brand in context.tblBrands on car.BrandId equals brand.Id
                    join color in context.tblColors on car.ColorId equals color.Id
                    select new CarDetailDto
                    {
                        CarId = car.Id, CarName = car.Name, BrandName = brand.Name, ColorName = color.Name,
                        DailyPrice = car.DailyPrice
                    };
                return result.ToList();
            }
        }
    }
}