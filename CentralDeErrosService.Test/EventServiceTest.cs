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
        //private CentralErrosContext _context;
        //private BaseContext _baseContext { get; }

        //private EventService _eventService;

        //public EventServiceTest()
        //{
        //    _baseContext = new BaseContext();
        //    _context = new CentralErrosContext(_baseContext.Options);
        //    _eventService = new EventService(_context);
        //}

        //[Fact]
        //public void Devera_Add_Event()  
        //{
        //    var fakeEvent = _baseContext.GetTestData<Event>().Where(x => x.Id == 5).FirstOrDefault();
        //    fakeEvent.Id = 0;

        //    var atual = new Event();

        //    //metodo de teste
        //    var service = _eventService;
        //    atual = service.Salvar(fakeEvent);

        //    //Assert
        //    Assert.NotEqual(0, fakeEvent.Id);
        //}

        //[Fact]
        //public void Devera_retornar_Evento()
        //{
        //    var expectedEvent = _baseContext.GetTestData<Event>().Where(x => x.Id == 3).FirstOrDefault();
        //    expectedEvent.Id = 1;

        //    var atual = new Event();

        //    var service = _eventService;
        //    atual = service.ProcurarPorId(expectedEvent.Id);

        //    Assert.Equal(expectedEvent, atual, new EventIdComparer());
        //}

        //[Fact]
        //public void Exibir_Busca_por_Ambiente()
        //{
        //    var ambiente = _baseContext.GetTestData<Event>().Where(x => x.Environment == "Dev").FirstOrDefault();

        //    var listaPorAmbiente = _eventService.BuscarPorAmbiente(ambiente.Environment);

        //   Assert.NotNull(listaPorAmbiente);
        //}

        //[Fact]
        //public void Exibir_Busca_por_Level()
        //{
        //    var ambiente = _baseContext.GetTestData<Event>().Where(x => x.Environment == "Producao").FirstOrDefault();
        //    var level = _baseContext.GetTestData<Event>().Where(x => x.Level == "warning").FirstOrDefault();

        //    var listaPorLevel = _eventService.BuscarPorLevel(level.Level, ambiente.Environment);
            
        //    Assert.NotNull(listaPorLevel);
        //}

        //[Fact]
        //public void Exibir_Busca_por_Descricao()
        //{
        //    var ambiente = _baseContext.GetTestData<Event>().Where(x => x.Environment == "Homologacao").FirstOrDefault();
        //    var descricao = _baseContext.GetTestData<Event>().Where(x => x.Description == "acceleration.Detail<not_found>").FirstOrDefault();

        //    var listaPorDescricao = _eventService.BuscarPorDescricao(descricao.Description, ambiente.Environment);

        //    Assert.NotNull(listaPorDescricao);
        //}

        //[Fact]
        //public void Exibir_Busca_por_Origem()
        //{
        //    var ambiente = _baseContext.GetTestData<Event>().Where(x => x.Environment == "Homologacao").FirstOrDefault();
        //    var origem = _baseContext.GetTestData<Event>().Where(x => x.Origin == "10.0.1.1").FirstOrDefault();

        //    var listaPorOrigem = _eventService.BuscarPorOrigem(origem.Origin, ambiente.Environment);

        //    Assert.NotNull(listaPorOrigem);
        //}

        //[Fact]
        //public void Ordenar_por_Level()
        //{
        //    var expectedEvents = _baseContext.GetTestData<Event>().ToList();

        //    var ordenacao = _eventService.OrdenarPorLevel(expectedEvents);

        //    Assert.NotNull(ordenacao);
        //}

        //[Fact]
        //public void Ordenar_por_Frequencia()
        //{
        //    var expectedEvents = _baseContext.GetTestData<Event>().ToList();

        //    var ordenacao = _eventService.OrdenarPorFrequenciaDeLevel(expectedEvents);

        //    Assert.NotNull(ordenacao);
        //}

        //[Fact]
        //public void Arquivar()
        //{
        //    var expectedEvent = _baseContext.GetTestData<Event>().First();
        //    expectedEvent.Id = 1006;

        //    var atual = new Event();

        //    var service = _eventService;
        //    atual = service.ArquivarEvento(expectedEvent);

        //    Assert.Equal(expectedEvent, atual, new EventIdComparer());
        //}

        //[Fact]
        //public void Desarquivar()
        //{
        //    var expectedEvent = _baseContext.GetTestData<Event>().First();
        //    expectedEvent.Id = 1006;

        //    var atual = new Event();

        //    var service = _eventService;
        //    atual = service.DesarquivarEvento(expectedEvent);

        //    Assert.Equal(expectedEvent, atual, new EventIdComparer());
        //}

        //[Fact]
        //public void Deletar()
        //{
        //    var fakeEvent = _baseContext.GetTestData<Event>().First();
        //    fakeEvent.Id = 2003;

        //    var atual = new Event();

        //    var service = _eventService;
        //    atual = service.Deletar(fakeEvent);

        //    Assert.NotEqual(0, fakeEvent.Id);
        //}


    }
}
