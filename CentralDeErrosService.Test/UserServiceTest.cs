using CentralDeErros.Models;
using CentralDeErros.Services;
using CentralDeErrosService.Test.Comparers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace CentralDeErrosService.Test
{
    public class UserServiceTest
    {
        //private CentralErrosContext _context;
        //private BaseContext _baseContext { get; }

        //private UserService _userService;

        //public UserServiceTest()
        //{
        //    _baseContext = new BaseContext();
        //    _context = new CentralErrosContext(_baseContext.Options);
        //    _userService = new UserService(_context);
        //}

        //[Fact]
        //public void Devera_Add_User()
        //{
        //    var fakeUser = _baseContext.GetTestData<User>().Where(x => x.Id == 4).FirstOrDefault();
        //    fakeUser.Id = 0;

        //    var atual = new User();

        //    var service = _userService;
        //    atual = service.Salvar(fakeUser);

        //    Assert.NotEqual(0, fakeUser.Id);
        //}

        //[Fact]
        //public void Devera_Retornar_User_Por_Id()
        //{
        //    var expectedUser = _baseContext.GetTestData<User>().Where(x => x.Id == 4).FirstOrDefault();

        //    var atual = new User();

        //    var service = _userService;
        //    atual = service.ProcurarPorId(expectedUser.Id);

        //    Assert.Equal(expectedUser, atual, new UserIdComparer());
        //}

        //[Fact]
        //public void Devera_Retornar_User_Por_Login()
        //{
        //    var login = _baseContext.GetTestData<User>().Where(x => x.Login == "juliana_squad2").FirstOrDefault();

        //    var listaPorLogin = _userService.procurarPorLogin(login.Login);

        //    Assert.NotNull(listaPorLogin);
        //}

        //[Fact]
        //public void Devera_Alterar_User()
        //{
        //    var fakeUser = _baseContext.GetTestData<User>().Where(x => x.Id == 1).FirstOrDefault();

        //    var atual = new User();

        //    var service = _userService;
        //    atual = service.Salvar(fakeUser);

        //    Assert.NotEqual(0, fakeUser.Id);
        //}

        //[Fact]
        //public void Devera_Deletar_User()
        //{
        //    var fakeUser = _baseContext.GetTestData<User>().First();
        //    fakeUser.Id = 3;

        //    var atual = new User();

        //    var service = _userService;
        //    atual = service.Deletar(fakeUser);

        //    Assert.NotEqual(0, fakeUser.Id);
        //}
    }
}
