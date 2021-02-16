using Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System.Linq.Expressions;
using System;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _color;

        public ColorManager(IColorDal color)
        {
            _color = color;
        }

        public IResult Add(Color color)
        {
            _color.Add(color);
            return new SuccessResult(Messages.Added("Renk"));
        }

        public IResult Delete(Color color)
        {
            _color.Delete(color);
            return new SuccessResult();
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_color.Get(c=>c.Id==id));
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_color.GetAll());
        }

        public IResult Update(Color color)
        {
            _color.Update(color);
            return new SuccessResult();
        }
    }
}