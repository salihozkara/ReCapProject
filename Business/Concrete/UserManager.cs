using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _user;

        public UserManager(IUserDal user)
        {
            _user = user;
        }

        public IResult Add(User entity)
        {
            _user.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(User entity)
        {
            _user.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<User> Get(Expression<Func<User, bool>> filter)
        {
            return new SuccessDataResult<User>(_user.Get(filter));
        }

        public IDataResult<List<User>> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return new SuccessDataResult<List<User>>(_user.GetAll(filter));
        }

        public IResult Update(User entity)
        {
            _user.Update(entity);
            return new SuccessResult();
        }
    }
}