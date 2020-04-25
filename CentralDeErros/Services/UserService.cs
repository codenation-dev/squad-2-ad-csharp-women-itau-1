using System;
using System.Collections.Generic;
using System.Linq;
using CentralDeErros.Models;

namespace CentralDeErros.Services
{
    public class UserService : IUserService
    {
        private CentralErrosContext _centralErros;

        public UserService(CentralErrosContext context)
        {
            _centralErros = context;
        }

        public User ProcurarPorId(int userId)
        {
            return _centralErros.User.Find(userId);
        }

        public IList<User> procurarPorLogin(string login)
        {
            return _centralErros.User.Where(x => x.Login == login).ToList();
        }

        public User Salvar(User user)
        {
            var existe = _centralErros.User
                .Where(x => x.Login == user.Login)
                .FirstOrDefault();

            if (existe == null)
                _centralErros.User.Add(user);
            else
            {
                existe.Login = user.Login;
            }

            _centralErros.SaveChanges();
            return user;
            
        }
    }

}
