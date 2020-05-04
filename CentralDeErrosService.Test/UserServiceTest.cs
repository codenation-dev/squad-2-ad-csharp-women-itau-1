using CentralDeErros.Models;
using CentralDeErros.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace CentralDeErrosService.Test
{
    public class UserServiceTest
    {
        private CentralErrosContext _context;
        private BaseContext _baseContext { get; }

        private UserService _userService;

        public UserServiceTest()
        {
            _context = new CentralErrosContext(_baseContext.Options);
            _baseContext = new BaseContext();
            _userService = new UserService(_context);
        }

        [Fact]
        public void Devera_Add_User()
        {
            var fakeUser = _baseContext.GetTestData<User>().First();
            fakeUser.Id = 0;

            var atual = new User();

            //metodo de teste
            var service = new UserService(_context);
            atual = service.Salvar(fakeUser);

            //Assert
            Assert.NotEqual(0, fakeUser.Id);
        }
    }
}
