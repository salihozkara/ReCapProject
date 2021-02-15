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

        public Car GetById(int id)
        {
            using (ReCapProjectContext context=new ReCapProjectContext())
            {
                return context.Set<Car>().SingleOrDefault(c => c.Id == id);
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext context=new ReCapProjectContext())
            {
                var result = from c in context.tblCars
                    join b in context.tblBrands on c.BrandId equals b.Id
                    join c2 in context.tblColors on c.ColorId equals c2.Id
                    select new CarDetailDto
                    {
                        CarId = c.Id, CarName = c.Name, BrandName = b.Name, ColorName = c2.Name,
                        DailyPrice = c.DailyPrice
                    };
                return result.ToList();
            }
        }
    }
}