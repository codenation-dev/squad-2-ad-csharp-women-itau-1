using System;
using System.Collections.Generic;
using System.Linq;
using CentralDeErros.Models;
using Microsoft.EntityFrameworkCore;

namespace CentralDeErros.Services
{
    public class EventService
    {
        private CentralErrosContext _context;

        public EventService(CentralErrosContext context)
        {
            _context = context;
        }

        public Event ProcurarPorId(int userId)
        {
            return _context.Event.Find(userId);
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
