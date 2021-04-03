using System;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        //[SecuredOperation("")]
        [ValidationAspect(typeof(AddCarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(CarImagesDto carImagesDto)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimitExceded(carImagesDto.CarId));
            if (result!=null)
            {
                return result;
            }
            CarImage carImage = new CarImage
            {
                CarId = carImagesDto.CarId,
                ImagePath = FileHelper.Upload(carImagesDto.ImageFile, FilePaths.ImageDirectory).Message,
                Date = DateTime.Now
            };
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.AddCarImageMessage);
        }

        public IResult AddList(List<CarImagesDto> carImagesDtos)
        {
            var result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }

            List<CarImage> carImages = new List<CarImage>();
            foreach (var carImagesDto in carImagesDtos)
            {
                var result2 = FileHelper.Upload(carImagesDto.ImageFile, FilePaths.ImageDirectory);

                if (result2.Success)
                {
                    carImages.Add(new CarImage
                    {
                        CarId = carImagesDto.CarId,
                        Date = DateTime.Now,
                        ImagePath = result2.Message,
                    });
                }
                else
                {
                    return result2;
                }
            }
            _carImageDal.AddList(carImages);
            return new SuccessResult(Messages.AddCarImageMessage);
        }


        //[SecuredOperation("")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage entity)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return new ErrorResult();
            }
            FileHelper.Delete(_carImageDal.Get(c=>c.Id==entity.Id).ImagePath);
            _carImageDal.Delete(entity);
            return new SuccessResult();
        }

        //[SecuredOperation("")]
        [ValidationAspect(typeof(AddCarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Update(CarImagesDto carImagesDto)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimitExceded(carImagesDto.CarId));
            if (result != null)
            {
                return result;
            }
            FileHelper.Delete(_carImageDal.Get(c => c.Id == carImagesDto.Id).ImagePath);
            CarImage carImage = new CarImage
            {
                Id = carImagesDto.Id,
                CarId = carImagesDto.CarId,
                ImagePath = FileHelper.Upload(carImagesDto.ImageFile, FilePaths.ImageDirectory).Message,
                Date = DateTime.Now
            };

            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IResult UpdateList(List<CarImagesDto> carImagesDtos)
        {
            throw new NotImplementedException();
        }

        [CacheAspect()]
        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _carImageDal.GetAll();
            if (result.Count<=0)
            {
                return new ErrorDataResult<List<CarImage>>();
            }
            else
            {
                return new SuccessDataResult<List<CarImage>>(result);
            }
        }
        [CacheAspect()]
        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var result = _carImageDal.GetAll(c=>c.CarId==carId);
            if (result.Count <= 0)
            {
                return new ErrorDataResult<List<CarImage>>();
            }
            else
            {
                return new SuccessDataResult<List<CarImage>>(result);
            }
        }
        [CacheAspect()]
        public IDataResult<CarImage> GetById(int carImageId)
        {
            var result = _carImageDal.Get(c=>c.Id==carImageId);
            if (result==null)
            {
                return new ErrorDataResult<CarImage>();
            }
            else
            {
                return new SuccessDataResult<CarImage>(result);
            }
        }
        
        private IResult CheckIfCarImageLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(c=>c.CarId==carId).Count;
            if (result>=5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}