using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;
using Core.Utilities.Results;

namespace Core.Business
{
    public interface IService<TEntity> where TEntity:class,IEntity,new()
    {
        IResult Add(TEntity entity);
        IResult Delete(TEntity entity);
        IResult Update(TEntity entity);
        IDataResult<List<TEntity>> GetAll();
        IDataResult<TEntity> GetById(int id);
    }
}