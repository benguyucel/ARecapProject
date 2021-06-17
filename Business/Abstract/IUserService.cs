using Core.Entities.Concrete;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<User> GetUserById(int userId);
        IDataResult<List<User>> GetUsers();
       List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
    }
}
