using System.Collections.Generic;
using CentralDeErros.Models;

namespace CentralDeErros.Services
{
    public interface IUserService
    {
        User ProcurarPorId(int userId);
        IList<User> procurarPorLogin(string login);
        User Salvar(User user);
    }
}