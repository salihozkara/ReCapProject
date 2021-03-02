using System.Collections.Generic;
using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetAllByCarId(int carId);
        IDataResult<CarImage> GetById(int id);
        IResult Add(CarImagesDto carImagesDto);
        IResult Delete(CarImage carImage);
        IResult Update(IFormFile image, CarImage carImage);
    }
}