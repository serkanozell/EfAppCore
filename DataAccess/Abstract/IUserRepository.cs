using DataAccess.Add;
using DataAccess.Repository.IRepo;
using DataAccess.Select;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserRepository : IAddableRepository<User>, ISelectableRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
