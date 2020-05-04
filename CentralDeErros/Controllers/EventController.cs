using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CentralDeErros.DTO;
using CentralDeErros.Models;
using CentralDeErros.Services;
using Microsoft.AspNetCore.Mvc;

namespace CentralDeErros.Controllers
{
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private IMapper _mapper;
        private IEventService _eventService;

        public EventController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<EventDTO> Get(int id)
        {
            var evento = _eventService.ProcurarPorId(id);
           
            if (evento != null)
            {
               // var retorno = _mapper.Map<UserDTO>(evento);
                 var retorno =  new EventDTO()
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

        /* POST api/values
        [HttpPost]
        public ActionResult<EventDTO> Post([FromBody]EventDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var evento = _mapper.Map<Event>(value);
         

            var retorno = _eventService.Salvar(evento);

            return Ok(_mapper.Map<EventDTO>(retorno));
        }*/
    }
}