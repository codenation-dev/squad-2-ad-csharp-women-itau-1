using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentralDeErros.DTO;
using CentralDeErros.Models;
using CentralDeErros.Services;
using Microsoft.AspNetCore.Mvc;

namespace CentralDeErros.Controllers
{
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<EventDTO> Get(int id)
        {
            var evento = _eventService.ProcurarPorId(id);

            if (evento != null)
            {
                var retorno = new EventDTO()
                {
                    Id = evento.Id,
                    Level = evento.Level,
                    Archived = evento.Archived,
                    CollectedBy = evento.CollectedBy,
                    Data = evento.Data,
                    Description = evento.Description,
                    Environment = evento.Environment,
                    Log = evento.Log,
                    LogId = evento.LogId,
                    Origin = evento.Origin,
                    Title = evento.Title
                };
                return Ok(retorno);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult<EventDTO> Post([FromBody]EventDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var evento = new Event()
            {
                Id = value.Id,
                Level = value.Level,
                Archived = value.Archived,
                CollectedBy = value.CollectedBy,
                Data = value.Data,
                Description = value.Description,
                Environment = value.Environment,
                Log = value.Log,
                LogId = value.LogId,
                Origin = value.Origin,
                Title = value.Title
            };

            var retorno = _eventService.Salvar(evento);
            return Ok(retorno);
        }
    }
}