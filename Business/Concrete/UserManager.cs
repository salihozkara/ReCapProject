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

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_user.Get(u=>u.Id==id));
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_user.GetAll());
        }

        public IResult Update(User entity)
        {
            _user.Update(entity);
            return new SuccessResult();
        }
    }
}