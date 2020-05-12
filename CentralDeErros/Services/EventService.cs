using System;
using System.Collections.Generic;
using System.Linq;
using CentralDeErros.Models;
using Microsoft.EntityFrameworkCore;

namespace CentralDeErros.Services
{
    public class EventService : IEventService
    {
        private CentralErrosContext _context;

        public EventService(CentralErrosContext context)
        {
            _context = context;
        }

        public Event ProcurarPorId(int eventId)
        {
            return _context.Events.Find(eventId);
        }

        public IList<Event> BuscarPorAmbiente(string ambiente)
        {
            return _context.Events.Where(x => x.Environment == ambiente).ToList();
        }

        public IList<Event> BuscarPorLevel(string level, string ambiente)
        {
            return _context.Events.Where(x => x.Level == level && x.Environment == ambiente).ToList();
        }

        public IList<Event> BuscarPorDescricao(string descricao, string ambiente)
        {
            return _context.Events.Where(x => x.Description == descricao && x.Environment == ambiente).ToList();
        }

        public IList<Event> BuscarPorOrigem(string origem, string ambiente)
        {
            return _context.Events.Where(x => x.Origin == origem && x.Environment == ambiente).ToList();
        }

        public IList<Event> OrdenarPorLevel(List<Event> eventos)
        {
            return eventos.OrderBy(x => x.Level).ToList();  
        }

        public IList<Event> OrdenarPorFrequenciaDeLevel(List<Event> eventos)
        {
            var ordenacao = eventos.GroupBy(x => x.Level).Select(group => new
            {
                Level = group.Key,
                Quantidade = group.Count()
            }).OrderByDescending(x => x.Quantidade).ToList();

            var ordenacaoLevels = ordenacao.Select(x => x.Level).ToList();

            var retorno = eventos.OrderBy(x => ordenacaoLevels.IndexOf(x.Level)).ToList();

            return retorno;

        }

        public Event ArquivarEvento(Event evento)
        {
            evento.Arquivar();

            return Salvar(evento);
        }

        public Event DesarquivarEvento(Event evento)
        {
            evento.Desarquivar();

            return Salvar(evento);
        }

        public Event Deletar(Event evento)
        {
            _context.Events.Remove(evento);

            _context.SaveChanges();

            return evento;

        }

        public Event Salvar(Event evento)
        {
            var estado = evento.Id == 0 ? EntityState.Added : EntityState.Modified;

            //setar estado do entity
            _context.Entry(evento).State = estado;

            //persistir os dados
            _context.SaveChanges();

            //retornar o objeto
            return evento;

        }

    }

}
