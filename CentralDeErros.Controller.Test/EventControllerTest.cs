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
    public class EventControllerTest
    {
        private readonly ServiceFake _serviceFake;

        public EventControllerTest()
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
    }
}
