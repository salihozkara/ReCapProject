using System;
using Business.Concrete;
using Business.Concrete.Dto;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //BrandManager brandManager=new BrandManager(new EfBrandDal());
            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //CarManager carManager = new CarManager(new EfCarDal());
            //UserManager userManager = new UserManager(new EfUserDal());
            CarDetailDtoManager carDetail = new CarDetailDtoManager(new EfCarDtoDal());
            foreach (var carDetailDto in carDetail.GetAll().Data)
            {
                Console.WriteLine(carDetailDto.CarName);
            }

            //colorManager.Add(new Color{Name = "kırmızı"});
            //carManager.Add(new Car{BrandId = 2,ColorId = 1,DailyPrice = 1250,Description = "",ModelYear = 2001,Name = "sasdsa"});
            //userManager.Add(new User{FirstName = "salih",LastName = "özkara",Email = "salih@gamil.com"});
            //userManager.Update(new User { Id = 1,FirstName = "salih", LastName = "özkara", Email = "salih@gamil.com",Password = "123"});
            //customerManager.Add(new Customer{CompanyName = "salihltd",UserId = 1});
            //Console.WriteLine(rentalManager.Add(new Rental { CarId = 2, CustomerId = 1, RentDate = DateTime.Now }).Success.ToString());
        }
    }
}
