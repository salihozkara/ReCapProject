using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(CarImagesDto carImagesDto);
        IResult AddList(List<CarImagesDto> carImagesDtos);
        IResult Delete(CarImage carImage);
        IResult Update(CarImagesDto carImagesDto);
        IResult UpdateList(List<CarImagesDto> carImagesDtos);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetAllByCarId(int carId);
        IDataResult<CarImage> GetById(int carImageId);
        
    }
}