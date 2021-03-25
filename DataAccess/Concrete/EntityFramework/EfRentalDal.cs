using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,ReCapProjectContext>,IRentalDal
    {
        public List<RentalDetailDto> GetAllRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result =
                    from rental in filter == null ? context.tblRentals : context.tblRentals.Where(filter)
                    join customer in context.tblCustomers on rental.CustomerId equals customer.Id
                    join user in context.tblUsers on customer.UserId equals user.Id
                    join car in context.tblCars on rental.CarId equals car.Id
                    join brand in context.tblBrands on car.BrandId equals brand.Id
                    join color in context.tblColors on car.ColorId equals color.Id
                    select new RentalDetailDto
                    {
                        Id = rental.Id,
                        CarName = car.Name,
                        BrandName = brand.Name,
                        ColorName = color.Name,
                        CompanyName = customer.CompanyName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        RentDate = rental.RentDate,
                        ReturnDate = rental.ReturnDate
                    };
                return result.ToList();
            }
        }
        public RentalDetailDto GetRentalDetails(int rentalId)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result =
                    from rental in context.tblRentals.Where(r=>r.Id==rentalId)
                    join customer in context.tblCustomers on rental.CustomerId equals customer.Id
                    join user in context.tblUsers on customer.UserId equals user.Id
                    join car in context.tblCars on rental.CarId equals car.Id
                    join brand in context.tblBrands on car.BrandId equals brand.Id
                    join color in context.tblColors on car.ColorId equals color.Id
                    select new RentalDetailDto
                    {
                        Id = rental.Id,
                        CarName = car.Name,
                        BrandName = brand.Name,
                        ColorName = color.Name,
                        CompanyName = customer.CompanyName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        RentDate = rental.RentDate,
                        ReturnDate = rental.ReturnDate
                    };
                return result.SingleOrDefault();
            }
        }
    }
}