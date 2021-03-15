using System.Collections.Generic;
using System.Linq;
using Core.DataAccess;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    { 
        List<OperationClaim> GetClaims(User user);
    }
}