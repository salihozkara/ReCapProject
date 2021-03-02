using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService:IService<User>
    {
        IDataResult<User> GetByEmail(string email);
    }
}