using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.UOW;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUnitOfWork _unitOfWork;

        public UserManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _unitOfWork.User.GetClaims(user);
        }

        public void Add(User user)
        {
            _unitOfWork.User.Add(user);
        }

        public User GetByMail(string email)
        {
            return _unitOfWork.User.Get(u => u.Email == email);
        }
    }
}
