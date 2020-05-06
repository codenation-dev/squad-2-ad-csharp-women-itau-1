using CentralDeErros.Models;
using CentralDeErros.Services;
using CentralDeErrosService.Test.Comparers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CentralDeErrosService.Test
{
    public class EventServiceTest

    {
        private CentralErrosContext _context;
        private BaseContext _baseContext { get; }

        private EventService _eventService;

        public EventServiceTest()
        {
            _baseContext = new BaseContext();
            _context = new CentralErrosContext(_baseContext.Options);
            _eventService = new EventService(_context);
        }

        [Fact]
        public void Devera_Add_Event()  
        {
            var fakeEvent = _baseContext.GetTestData<Event>().First();
            fakeEvent.Id = 0;

            var atual = new Event();

            //metodo de teste
            var service = new EventService(_context);
            atual = service.Salvar(fakeEvent);

            //Assert
            Assert.NotEqual(0, fakeEvent.Id);
        }

        [Fact]
        public void Devera_retornar_Evento()
        {
            var expectedEvent = _baseContext.GetTestData<Event>().First();
            expectedEvent.Id = 1;

            var atual = new Event();

            var service = new EventService(_context);
            atual = service.ProcurarPorId(expectedEvent.Id);

            Assert.Equal(expectedEvent, atual, new EventIdComparer());
        }

        [Fact]
        public void Exibir_Busca_por_Ambiente()
        {
            var ambiente = _baseContext.GetTestData<Event>().Find(x => x.Environment == "Produção");

            var listaPorAmbiente = _eventService.BuscarPorAmbiente(ambiente.Environment);


            Assert.NotNull(listaPorAmbiente);
        }

        [Fact]
        public void Exibir_Busca_por_Level()
        {
            var ambiente = _baseContext.GetTestData<Event>().Find(x => x.Environment == "Homologação");
            var level = _baseContext.GetTestData<Event>().Find(x => x.Level == "debug");

            var listaPorAmbiente = _eventService.BuscarPorLevel(level.Level, ambiente.Environment);
            
            Assert.NotNull(listaPorAmbiente);
        }

        [Fact]
        public void Exibir_Busca_por_Descricao()
        {
            var ambiente = _baseContext.GetTestData<Event>().Find(x => x.Environment == "Homologação");
            var descricao = _baseContext.GetTestData<Event>().Find(x => x.Description == "acceleration.Detail<not_found>");

            var listaPorAmbiente = _eventService.BuscarPorDescricao(descricao.Description, ambiente.Environment);

            Assert.NotNull(listaPorAmbiente);
        }

        [Fact]
        public void Exibir_Busca_por_Origem()
        {
            var ambiente = _baseContext.GetTestData<Event>().Find(x => x.Environment == "Produção");
            var origem = _baseContext.GetTestData<Event>().Find(x => x.Origin == "127.0.0.1");

            var listaPorAmbiente = _eventService.BuscarPorOrigem(origem.Origin, ambiente.Environment);

            Assert.NotNull(listaPorAmbiente);
        }

        //[Fact]
        //public void Ordenar_por_Level()
        //{

        //}

        //[Fact]
        //public void Ordenar_por_Frequencia()
        //{

        //}

        [Fact]
        public void Arquivar()
        {
            var expectedEvent = _baseContext.GetTestData<Event>().First();
            expectedEvent.Id = 3;

            var atual = new Event();

            var service = new EventService(_context);
            atual = service.ArquivarEvento(expectedEvent);

            Assert.Equal(expectedEvent, atual, new EventIdComparer());
        }

        [Fact]
        public void Desarquivar()
        {
            var expectedEvent = _baseContext.GetTestData<Event>().First();
            expectedEvent.Id = 3;

            var atual = new Event();

            var service = new EventService(_context);
            atual = service.DesarquivarEvento(expectedEvent);

            Assert.Equal(expectedEvent, atual, new EventIdComparer());
        }

        [Fact]
        public void Deletar()
        {
            var fakeEvent = _baseContext.GetTestData<Event>().First();
            fakeEvent.Id = 1;

            var atual = new Event();

            //metodo de teste
            var service = new EventService(_context);
            atual = service.Deletar(fakeEvent);

            //Assert
            Assert.NotEqual(0, fakeEvent.Id);
        }


    }
}
