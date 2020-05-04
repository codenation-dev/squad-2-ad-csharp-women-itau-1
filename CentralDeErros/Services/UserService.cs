using System;
using System.Collections.Generic;
using System.Linq;
using CentralDeErros.Models;
using Microsoft.EntityFrameworkCore;

namespace CentralDeErros.Services
{
    public class UserService : IUserService
    {
        private CentralErrosContext _context;

        public UserService(CentralErrosContext context)
        {
            _context = context;
        }

        public User ProcurarPorId(int userId)
        {
            return _context.Users.Find(userId);
        }

        public IList<User> procurarPorLogin(string login)
        {
            return _context.Users.Where(x => x.Login == login).ToList();
        }

        public User Deletar(User user)
        {
            _context.Users.Remove(user);

            _context.SaveChanges();

            return user;

        }

        public User Salvar(User user)
        {
            var estado = user.Id == 0 ? EntityState.Added : EntityState.Modified;

            //setar estado do entity
            _context.Entry(user).State = estado;

            //persistir os dados
            _context.SaveChanges();

            //retornar o objeto
            return user;

        }
    }

}
