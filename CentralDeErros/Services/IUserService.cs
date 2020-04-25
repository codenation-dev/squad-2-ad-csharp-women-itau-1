using System.Collections.Generic;
using CentralDeErros.Models;

namespace CentralDeErros.Services
{
    public interface IUserService
    {
        IList<User> procurarPorLogin(string login);
    }
}