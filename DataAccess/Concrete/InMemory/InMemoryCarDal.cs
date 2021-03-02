using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car
                {
                    Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2001, DailyPrice = 1200, Description = "asdadada"
                },
                new Car
                {
                    Id = 2, BrandId = 1, ColorId = 4, ModelYear = 2002, DailyPrice = 1350, Description = "asdadada"
                },
                new Car
                {
                    Id = 3, BrandId = 3, ColorId = 2, ModelYear = 2003, DailyPrice = 1536, Description = "asdadada"
                },
                new Car
                {
                    Id = 4, BrandId = 2, ColorId = 2, ModelYear = 2005, DailyPrice = 1245, Description = "asdadada"
                },
                new Car
                {
                    Id = 5, BrandId = 2, ColorId = 3, ModelYear = 2007, DailyPrice = 1200, Description = "asdadada"
                }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

     

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }

      
    }
}
