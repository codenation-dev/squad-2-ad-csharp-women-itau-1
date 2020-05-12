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

            var service = _serviceFake.FakeEvent().Object;

            var esperado = _serviceFake.Mapper.Map<EventDTO>(service.ProcurarPorId(1));

            var controle = new EventController(service, _serviceFake.Mapper);

            var resultado = controle.Get(1);


            Assert.IsType<OkObjectResult>(resultado.Result);

            var userAtual = (resultado.Result as OkObjectResult).Value as EventDTO;

            Assert.IsType<EventDTO>(userAtual);

            Assert.NotNull(userAtual);

           Assert.Equal(esperado, userAtual, new EventIdDtoComparer());
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Devera_Retornar_Ok_Quando_Get_Por_Ids(int id)
        {
            var service = _serviceFake.FakeEvent().Object;

            var esperado = _serviceFake.Mapper.Map<EventDTO>(service.ProcurarPorId(id));

            var controle = new EventController(service, _serviceFake.Mapper);


            var resultado = controle.Get(id);

            Assert.IsType<OkObjectResult>(resultado.Result);

            var userAtual = (resultado.Result as OkObjectResult).Value as EventDTO;

            Assert.IsType<EventDTO>(userAtual);

            Assert.NotNull(userAtual);

            Assert.Equal(esperado, userAtual, new EventIdDtoComparer());
        }
        [Fact]
        public void Devera_Retornar_OK_Quando_Add_Post()
        {
            var service = _serviceFake.FakeEvent().Object;

            var expected = _serviceFake.GetDadosFake<EventDTO>().First();
            expected.Id = 0;


            var controller = new EventController(service, _serviceFake.Mapper);

            var result = controller.Post(expected);

            Assert.IsType<OkObjectResult>(result.Result);


            var actual = (result.Result as OkObjectResult).Value as EventDTO;

            Assert.NotNull(actual);

        //    // comparar retorno com esperado inserido no retorno dos metodo fake
            Assert.Equal(999, actual.Id);
            Assert.Equal(expected.Level, actual.Level);
            Assert.Equal(expected.Description, actual.Description);
            Assert.Equal(expected.Origin, actual.Origin);
            Assert.Equal(expected.Data, actual.Data);
            Assert.Equal(expected.Log, actual.Log);
            Assert.Equal(expected.Environment, actual.Environment);
            Assert.Equal(expected.Archived, actual.Archived);
            Assert.Equal(expected.LogId, actual.LogId);
            Assert.Equal(expected.Title, actual.Title);
            Assert.Equal(expected.CollectedBy, actual.CollectedBy);

        }
        [Fact]
        public void Devera_Retornar_OK_Quando_Aletrar_Put()
        {

           var service = _serviceFake.FakeEvent().Object;

            var expected = _serviceFake.GetDadosFake<EventDTO>().First();
        //    // expected.Id = _serviceFake.GetDadosFake<UserDTO>().Where(x => x.Id == expected.Id).FirstOrDefault();

            var controller = new EventController(service, _serviceFake.Mapper);

            var result = controller.Put(expected);


            Assert.IsType<OkObjectResult>(result.Result);


            var actual = (result.Result as OkObjectResult).Value as EventDTO;

           Assert.NotNull(actual);

            // comparar retorno com esperado inserido no retorno dos metodo fake
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Level, actual.Level);
            Assert.Equal(expected.Description, actual.Description);
            Assert.Equal(expected.Origin, actual.Origin);
            Assert.Equal(expected.Data, actual.Data);
            Assert.Equal(expected.Log, actual.Log);
            Assert.Equal(expected.Environment, actual.Environment);
            Assert.Equal(expected.Archived, actual.Archived);
            Assert.Equal(expected.LogId, actual.LogId);
            Assert.Equal(expected.Title, actual.Title);
           Assert.Equal(expected.CollectedBy, actual.CollectedBy);
        }
        [Fact]
        public void Devera_Retornar_Get_Listar_Por_Ambiente()
        {

            var service = _serviceFake.FakeEvent().Object;

            //   var nomeLogin = "izabel_squad2";

           var esperado = _serviceFake.Mapper.Map<List<EventDTO>>(service.BuscarPorAmbiente("Dev"));

           var controle = new EventController(service, _serviceFake.Mapper);

            var resultado = controle.ListarPorAmbiente("Dev");


            Assert.IsType<OkObjectResult>(resultado.Result);

          var userAtual = (resultado.Result as OkObjectResult).Value as List<EventDTO>;


            Assert.IsType<List<EventDTO>>(userAtual);
            Assert.NotNull(userAtual);


            Assert.Equal(esperado.Count, userAtual.Count);
        }
        [Fact]
        public void Devera_Retornar_Get_Listar_Por_Level()
        {

            var service = _serviceFake.FakeEvent().Object;

        //    //   var nomeLogin = "izabel_squad2";

            var esperado = _serviceFake.Mapper.Map<List<EventDTO>>(service.BuscarPorLevel("error", "Dev"));

            var controle = new EventController(service, _serviceFake.Mapper);

            var resultado = controle.ListarPorLevel("error", "Dev");


            Assert.IsType<OkObjectResult>(resultado.Result);

            var userAtual = (resultado.Result as OkObjectResult).Value as List<EventDTO>;

              Assert.IsType<List<EventDTO>>(userAtual);

           Assert.NotNull(userAtual);


            Assert.Equal(esperado.Count, userAtual.Count);
        }
        [Fact]
        public void Devera_Retornar_Get_Listar_Por_Descricao()
        {


          var service = _serviceFake.FakeEvent().Object;

            
           var esperado = _serviceFake.Mapper.Map<List<EventDTO>>(service.BuscarPorDescricao("acceleration.Service.AddCandidate: <forbidden>", "Dev"));

            var controle = new EventController(service, _serviceFake.Mapper);

           var resultado = controle.ListarPorDescricao("acceleration.Service.AddCandidate: <forbidden>", "Dev");


           Assert.IsType<OkObjectResult>(resultado.Result);

            var userAtual = (resultado.Result as OkObjectResult).Value as List<EventDTO>;

            Assert.IsType<List<EventDTO>>(userAtual);

            Assert.NotNull(userAtual);

            Assert.Equal(esperado, userAtual, new EventIdDtoComparer());
        }
        [Fact]
        public void Devera_Retornar_Get_Listar_Por_Origem()
        {

            var service = _serviceFake.FakeEvent().Object;


            var esperado = _serviceFake.Mapper.Map<List<EventDTO>>(service.BuscarPorOrigem("104.0.1.2", "Dev"));

            var controle = new EventController(service, _serviceFake.Mapper);

            var resultado = controle.ListarPorOrigem("104.0.1.2", "Dev");


            Assert.IsType<OkObjectResult>(resultado.Result);

            var userAtual = (resultado.Result as OkObjectResult).Value as List<EventDTO>;

            Assert.IsType<List<EventDTO>>(userAtual);

            Assert.NotNull(userAtual);


            Assert.Equal(esperado.Count, userAtual.Count);
        }
       /* [Fact]
        public void Devera_Retornar_Get_Ordenar_Por_Level()
        {

            var service = _serviceFake.FakeEvent().Object;

            var expected = _serviceFake.GetDadosFake<List<EventDTO>>().First();
          //  expected.Id = 0;


            var controller = new EventController(service, _serviceFake.Mapper);

            var result = controller.OrdernarPorLevel(expected);

            Assert.IsType<OkObjectResult>(result.Result);


            var actual = (result.Result as OkObjectResult).Value as List<EventDTO>;

            Assert.NotNull(actual);

            
        }
        /*
        [Fact]
        public void Devera_Retornar_Ok_Arquivar_Post()
       
        //    Assert.Equal(esperado, userAtual, new EventIdDtoComparer());
        //}
        //[Fact]
        //public void Devera_Retornar_Ok_Arquivar_Post()
        //{
            

        //}
        //[Fact]
        //public void Devera_Retornar_Ok_Desarquivar_Post()
        //{



        }
        [Fact]
        public void Devera_Retornar_Ok_Delete(int id)
        {
            var service = _serviceFake.FakeEvent().Object;;

           var expected = _serviceFake.Mapper.Map<List<EventDTO>>(Deletar).First();


            var expected = service.Mapper.Map<CentralErros.Models.Environment>(fakeEnvironmentService.FindById(id));

            var contexto = new CentralErroContexto(fakes.FakeOptions);

            var controller = new EnvironmentController(fakeEnvironmentService,
                fakes.Mapper, contexto);

            var result = controller.Delete(id);

            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as CentralErros.Models.Environment;

            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new EnvironmentIdComparer());
        }
        
         */

        //}

    }
}
