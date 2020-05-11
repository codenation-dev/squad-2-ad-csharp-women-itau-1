using System;
using System.Collections.Generic;
using System.Linq;
using CentralDeErros.Controller.Test.Comparacoes;
using CentralDeErros.Controllers;
using CentralDeErros.DTO;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CentralDeErros.Controller.Test
{
    public class UserControllerTest
    {
        private readonly ServiceFake _serviceFake;

        public UserControllerTest()
        {
            _serviceFake = new ServiceFake();
        }


        [Fact]
        public void Devera_Retornar_Get_Por_Id()
        {

            var service = _serviceFake.FakeUser().Object;

            var esperado = _serviceFake.Mapper.Map<UserDTO>(service.ProcurarPorId(1));

            var controle = new UserController(service, _serviceFake.Mapper);

            var resultado = controle.Get(1);
            

            Assert.IsType<OkObjectResult>(resultado.Result);

            var userAtual = (resultado.Result as OkObjectResult).Value as UserDTO;

            Assert.IsType<UserDTO>(userAtual);

            Assert.NotNull(userAtual);

            Assert.Equal(esperado, userAtual, new UserIdDtoComparer());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Devera_Retornar_Ok_Quando_Get_Por_Ids(int id)
        {
            var service = _serviceFake.FakeUser().Object;
           
            var expected = _serviceFake.Mapper.Map<UserDTO>(service.ProcurarPorId(id));

            var controller = new UserController(service, _serviceFake.Mapper);

            var result = controller.Get(id);

            Assert.IsType<OkObjectResult>(result.Result);

            
            var actual = (result.Result as OkObjectResult).Value as UserDTO;

            Assert.NotNull(actual);
           
            Assert.Equal(expected, actual, new UserIdDtoComparer());
        }

        [Fact]
        public void Devera_Retornar_Get_Por_login()
        {

            var service = _serviceFake.FakeUser().Object;

         //   var nomeLogin = "izabel_squad2";

            var esperado = _serviceFake.Mapper.Map<List<UserDTO>>(service.procurarPorLogin("izabel_squad2"));

            var controle = new UserController(service, _serviceFake.Mapper);

            var resultado = controle.GetLogin("izabel_squad2");


            Assert.IsType<OkObjectResult>(resultado.Result);

            var userAtual = (resultado.Result as OkObjectResult).Value as List<UserDTO>;

            Assert.IsType<List<UserDTO>>(userAtual);

            Assert.NotNull(userAtual);

            Assert.Equal(esperado, userAtual, new UserIdDtoComparer());
        }
        [Fact]
        public void Devera_Retornar_OK_Quando_Add_Post()
        {
            var service = _serviceFake.FakeUser().Object;
           
            var expected = _serviceFake.GetDadosFake<UserDTO>().First();
            expected.Id = 0;

            
            var controller = new UserController(service, _serviceFake.Mapper);

            var result = controller.Post(expected);

            Assert.IsType<OkObjectResult>(result.Result);

            
            var actual = (result.Result as OkObjectResult).Value as UserDTO;
            //comparar valor retorno controller é nulo
            Assert.NotNull(actual);

            // comparar retorno com esperado inserido no retorno dos metodo fake
            Assert.Equal(999, actual.Id);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Login, actual.Login);
            Assert.Equal(expected.Password, actual.Password);
            Assert.Equal(expected.CreatedAt, actual.CreatedAt);

        }
        [Fact]
        public void Devera_Retornar_OK_Quando_Aletrar_Put()
        {

            var service = _serviceFake.FakeUser().Object;

            var expected = _serviceFake.GetDadosFake<UserDTO>().First();
           // expected.Id = _serviceFake.GetDadosFake<UserDTO>().Where(x => x.Id == expected.Id).FirstOrDefault();

            var controller = new UserController(service, _serviceFake.Mapper);
            
            var result = controller.Put(expected);

           
            Assert.IsType<OkObjectResult>(result.Result);

           
            var actual = (result.Result as OkObjectResult).Value as UserDTO;

            Assert.NotNull(actual);

            // comparar retorno com esperado inserido no retorno dos metodo fake
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Login, actual.Login);
            Assert.Equal(expected.Password, actual.Password);
            Assert.Equal(expected.CreatedAt, actual.CreatedAt);

        }
       /* [Fact]
        public void Devera_Retornar_Deletar_Users()
        {

            var service = _serviceFake.FakeUser().Object;

            var esperado = _serviceFake.Mapper.Map<UserDTO>(service.Deletar(evento));

            var controle = new UserController(service, _serviceFake.Mapper);

            var resultado = controle.Deletar();


            Assert.IsType<OkObjectResult>(resultado.Result);

            var userAtual = (resultado.Result as OkObjectResult).Value as UserDTO;

            Assert.IsType<UserDTO>(userAtual);

            Assert.NotNull(userAtual);

            Assert.Equal(esperado, userAtual, new UserIdDtoComparer());
        }
        */

    }
}
