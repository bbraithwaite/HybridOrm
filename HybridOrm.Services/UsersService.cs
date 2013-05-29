using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hybrid.Orm.Repository.Dapper;
using HybridOrm.Model;

namespace HybridOrm.Services
{
    public class UsersService
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Read only paramter that makes use of dapper
        /// </summary>
        private readonly IReadOnlyRepository<User> _userRepository;

        public UsersService(IUnitOfWork unitOfWork, IReadOnlyRepository<User> userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public User GetUser(int id)
        {
            return _userRepository.FindById(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetAll();
        }

        public IEnumerable<User> GetNewUsers()
        {
            return _userRepository.GetNewUsers();
        }

        public User CreateUser(User user)
        {
            _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Save();

            return user;
        }
    }
}
