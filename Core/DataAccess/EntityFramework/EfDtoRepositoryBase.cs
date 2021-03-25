using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EfDtoRepositoryBase<TDto,TContext>:IDtoRepository<TDto>
    where TDto : class, IDto, new()
    where TContext : DbContext, new()
    {
        public TDto Get(Expression<Func<TDto, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TDto>().SingleOrDefault(filter);
            }
        }

        public List<TDto> GetAll(Expression<Func<TDto, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TDto>().ToList()
                    : context.Set<TDto>().Where(filter).ToList();
            }
        }
    }
}