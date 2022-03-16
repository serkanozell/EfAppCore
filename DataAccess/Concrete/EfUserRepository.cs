using DataAccess.Abstract;
using DataAccess.Repository.Repository;
using Entity.Context;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfUserRepository : Repository<User>, IUserRepository
    {
        public EfUserRepository(DbContext context):base(context)
        {

        }
        public List<OperationClaim> GetClaims(User user)
        {
            using (EfAppContext context = new EfAppContext())
            {
                var result = from operationClaim in context.OperationClaim
                             join userOperationClaim in context.UserOperationClaim
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, OperationClaimName = operationClaim.OperationClaimName };
                return result.ToList();

            }
        }
    }
}
