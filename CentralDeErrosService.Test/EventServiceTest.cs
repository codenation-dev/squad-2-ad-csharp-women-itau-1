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
            _context = new CentralErrosContext(_baseContext.Options);
            _baseContext = new BaseContext();
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
            var eventoEsperado = _baseContext.GetTestData<Event>().Find(x => x.Id == 1);
            eventoEsperado.Id = 4;

            //metodo de teste
            var eventoAtual = _eventService.ProcurarPorId(eventoEsperado.Id);


            //Assert 
            //comparação de referencia de objetos
            Assert.Equal(eventoEsperado, eventoAtual, new EventIdComparer());
        }

        [Fact]
        public void Exibir_Busca_por_Ambiente()
        {
            var ambiente = _baseContext.GetTestData<Event>().Find(x => x.Environment == "producao");
            //metodo de teste
            var listaPorAmbiente = _eventService.BuscarPorAmbiente(ambiente.Environment);

            //Assert
            Assert.NotNull(listaPorAmbiente);
        }
    }
}
