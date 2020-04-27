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
            return _context.Event.Find(eventId);
        }

        public IList<Event> BuscarPorLevel(string level)
        {
            return _context.Event.Where(x => x.Level == level).ToList();
        }

        public IList<Event> BuscarPorDescricao(string descricao)
        {
            return _context.Event.Where(x => x.Description == descricao).ToList();
        }

        public IList<Event> BuscarPorOrigem(string origem, string ambiente)
        {
            return _context.Event.Where(x => x.Origin == origem && x.Environment == ambiente).ToList();
        }

        public IList<Event> OrdenarPorLevel(List<Event> eventos)
        {            
            return eventos.OrderBy(x => x.Level).ToList();
        }

        //public IList<Event> OrdenarPorFrequencia(int frequencia)
        //{
        //    var eventsCount =
        //    var topEvents = _context.Event.OrderByDescending(x => x.)
        //    return
        //} archive, remover evento

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
