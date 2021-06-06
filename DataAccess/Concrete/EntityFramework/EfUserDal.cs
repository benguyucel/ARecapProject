using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTO;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EntityRepositoryBase<User, RecapContext>, IUserDal
    {
        public IDataResult<List<UserDetailDto>> GetUsersDetail()
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from u in context.Users
                             join c in context.Customers
                             on u.Id equals c.UserId
                             select new UserDetailDto
                             {
                                Id=u.Id,FirstName=u.FirstName,LastName=u.LastName,Email=u.Email,Password=u.Password,
                                CompanyName=c.CompanyName
                             };
                return new SuccessDataResult<List<UserDetailDto>>(result.ToList());
            }
        }
    }
}
