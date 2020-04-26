using CentralDeErros.Models;
using CentralDeErros.Services;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace CentralDeErrosService.Test
{
    public class UserServiceTest
    {
        private CentralErrosContext _context;

        public UserServiceTest()
        {
            var options = new DbContextOptionsBuilder<CentralErrosContext>();
            options.UseSqlServer("Server=WIN-M8X17VUIO5\\TESTE;Database=CentralDeErros; User Id =sa; Password=04011995;Trusted_Connection=False");

            _context = new CentralErrosContext(options.Options);
        }
        [Fact]
        public void Save_Test()
        {
            DateTime date = DateTime.Now;
            
            var fakeUser = new User()
            {
                Id = 0,
                Login = "user3",
                Name = "test3",
                CreatedAt = new DateTime(date.Year, date.Month, date.Day, 0, 0, 5),
                Password = "12345"
            };

            var service = new UserService(_context);
            var atual = service.Salvar(fakeUser);

            Assert.Equal(fakeUser.Id, atual.Id);
        }
    }
}
