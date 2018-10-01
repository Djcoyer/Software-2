using Software2.Models.Exceptions;
using Software2.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Services
{
    public class UserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            this._repository = repository;
        }

        public user FindUserById(int id)
        {
            var user = _repository.FindById(id);
            if (user == null)
                throw new NotFoundException("Could not locate user with specified ID.");
            return user;
        }

        public List<user> FindAllUsers()
        {
            return _repository.FindAll().ToList();
        }

        public void ValidateCredentials(string username, string password)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                throw new Exception("Username and password are required");
            }
            var user = _repository.FindByUsername(username);
            if (user == null || !user.password.Equals(password))
                throw new InvalidInputException("Username or password incorrect");
        }

        public void UpdateUser(user updatedUser, int id)
        {
            if (updatedUser.active == null)
                throw new Exception();
            if (updatedUser.password.Length < 10)
                throw new Exception();
            this._repository.UpdateUser(updatedUser, id);
        }
    }
}
