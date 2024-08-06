using Core.DataAccess.Repositories;
using Core.Entities.Concretes;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class EfUserDal : EfRepositoryBase<User, int, DutyManagementContext>, IUserDal
    {
        DutyManagementContext _dutyManagementContext;

        public EfUserDal(DutyManagementContext context) : base(context)
        {
            _dutyManagementContext = context;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            var result = from operationClaim in _dutyManagementContext.OperationClaims
                         join userOperationClaim in _dutyManagementContext.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.Id
                         select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            return result.ToList();
        }
    }
}
