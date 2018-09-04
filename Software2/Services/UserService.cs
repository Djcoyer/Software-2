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

        public bool ValidateCredentials(string username, string password)
        {
            var user = _repository.FindByUsername(username);
            return user != null && user.password.Equals(password);
        }
    }
}
