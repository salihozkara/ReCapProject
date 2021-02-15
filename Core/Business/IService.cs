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
        IDataResult<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null);
        IDataResult<TEntity> Get(Expression<Func<TEntity, bool>> filter);
    }
}