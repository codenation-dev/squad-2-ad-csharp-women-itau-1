using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CentralDeErros.DTO;
using CentralDeErros.Models;
using CentralDeErros.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CentralDeErros.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
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
                var retorno = _mapper.Map<EventDTO>(evento);

                return Ok(retorno);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost("cadastrar")]
        public ActionResult<EventDTO> Post([FromBody]EventDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var evento = _mapper.Map<Event>(value);

            var retorno = _eventService.Salvar(evento);

            return Ok(_mapper.Map<EventDTO>(retorno));
        }

        [HttpPut("atualizar")]
        public ActionResult<EventDTO> Put([FromBody]EventDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var evento = _mapper.Map<Event>(value);

            /*  var evento = new Event()
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
              };*/

            var retorno = _eventService.Salvar(evento);
            return Ok(_mapper.Map<EventDTO>(retorno));
        }

        [HttpGet("listar")]
        public ActionResult<IEnumerable<EventDTO>> ListarPorAmbiente(string ambiente)
        {
            var eventos = _eventService.BuscarPorAmbiente(ambiente);

            if (eventos != null)
            {
                var retorno = _mapper.Map<List<EventDTO>>(eventos);


                return Ok(retorno);
            }

            return NotFound();
        }

        [HttpGet("listarPorLevel")]
        public ActionResult<IEnumerable<EventDTO>> ListarPorLevel(string level, string ambiente)
        {
            var eventos = _eventService.BuscarPorLevel(level, ambiente);

            //var retorno = new List<EventDTO>();

            if (eventos != null)
            {
                var retorno = _mapper.Map<List<EventDTO>>(eventos);
                return Ok(retorno);
            }

            return NotFound();
        }

        

        [HttpGet("listarPorDescricao")]
        public ActionResult<IEnumerable<EventDTO>> ListarPorDescricao(string descricao, string ambiente)
        {
            var eventos = _eventService.BuscarPorDescricao(descricao, ambiente);

            // var retorno = new List<EventDTO>();

            if (eventos != null)
            {
                var retorno = _mapper.Map<List<EventDTO>>(eventos);
                /* foreach (var item in eventos)
                 {
                     var retornoAux = new EventDTO()
                     {
                         Id = item.Id,
                         Level = item.Level,
                         Archived = item.Archived,
                         CollectedBy = item.CollectedBy,
                         Data = item.Data,
                         Description = item.Description,
                         Environment = item.Environment,
                         Log = item.Log,
                         LogId = item.LogId,
                         Origin = item.Origin,
                         Title = item.Title
                     };

                     retorno.Add(retornoAux);
                 } */

                return Ok(retorno);
            }

            return NotFound();
        }

        [HttpGet("listarPorOrigem")]
        public ActionResult<IEnumerable<EventDTO>> ListarPorOrigem(string origem, string ambiente)
        {

            var eventos = _eventService.BuscarPorOrigem(origem, ambiente);

            // var retorno = new List<EventDTO>();

            if (eventos != null)
            {
                var retorno = _mapper.Map<List<EventDTO>>(eventos);
                /*foreach (var item in eventos)
                {
                    var retornoAux = new EventDTO()
                    {
                        Id = item.Id,
                        Level = item.Level,
                        Archived = item.Archived,
                        CollectedBy = item.CollectedBy,
                        Data = item.Data,
                        Description = item.Description,
                        Environment = item.Environment,
                        Log = item.Log,
                        LogId = item.LogId,
                        Origin = item.Origin,
                        Title = item.Title
                    };

                    retorno.Add(retornoAux);
                } */

                return Ok(retorno);
            }

            return NotFound();

        }

        [HttpGet("OrdernarPorLevel")]
        public ActionResult<EventDTO> OrdernarPorLevel(string ambiente)
        {
           if (!ModelState.IsValid)
                return BadRequest();

            //var eventos = _eventService.BuscarPorAmbiente(ambiente);
                 
            //var ordenar = _mapper.Map<List<Event>>(eventos);

            var eventos = _eventService.OrdenarPorLevel(ambiente);

            return Ok(_mapper.Map<List<EventDTO>>(eventos));

            
        }

        [HttpGet("OrdernarPorFrequenciaDeLevel")]
        public ActionResult<List<EventDTO>> OrdenarPorFrequenciaDeLevel(string ambiente)

        {
            if (!ModelState.IsValid)
                return BadRequest();

            //var eventos = _eventService.BuscarPorAmbiente(ambiente);

            //var ordenar = _mapper.Map<List<Event>>(eventos);

            var eventos = _eventService.OrdenarPorFrequenciaDeLevel(ambiente);

            return Ok(_mapper.Map<List<EventDTO>>(eventos));

        }
        
        [HttpPost("Arquivar")]
        public ActionResult<EventDTO> Arquivar([FromBody]List<EventDTO> eventos)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); 

            var arquivar = _mapper.Map<List<Event>>(eventos);

           // eventos = new List<EventDTO>();

            foreach (var item in arquivar)
            {
                var evento = _eventService.ProcurarPorId(item.Id);

                if (evento == null)
                    return NotFound(item);

                _eventService.ArquivarEvento(evento);
            }

            return Ok(_mapper.Map<List<EventDTO>>(arquivar));



        
            /* var retorno = new List<EventDTO>();

             foreach (var item in eventos)
             {

                 var evento = _eventService.ProcurarPorId(item.Id);

                 if (evento == null)
                     return NotFound(item);

                 var eventoAtual = _eventService.ArquivarEvento(evento);

                 retorno.Add(new EventDTO()
                 {
                     Id = eventoAtual.Id,
                     Level = eventoAtual.Level,
                     Archived = eventoAtual.Archived,
                     CollectedBy = eventoAtual.CollectedBy,
                     Data = eventoAtual.Data,
                     Description = eventoAtual.Description,
                     Environment = eventoAtual.Environment,
                     Log = eventoAtual.Log,
                     LogId = eventoAtual.LogId,
                     Origin = eventoAtual.Origin,
                     Title = eventoAtual.Title
                 });
             }*/
        }

        [HttpPost("desarquivar")]
        public ActionResult<EventDTO> Desarquivar([FromBody]List<EventDTO> eventos)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var desarquivar = _mapper.Map<List<Event>>(eventos);

           // eventos = new List<List<EventDTO>>();

            foreach (var item in desarquivar)
            {
                var evento = _eventService.ProcurarPorId(item.Id);

                if (evento == null)
                    return NotFound(item);

                _eventService.DesarquivarEvento(evento);
            }

            return Ok(_mapper.Map<List<EventDTO>>(desarquivar));        
        }

    


       [HttpPost("deletar")]
        public ActionResult<EventDTO> Deletar([FromBody]List<EventDTO> eventos)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var maper = _mapper.Map<List<Event>>(eventos);

            //eventos = new List<EventDTO>();

            foreach (var item in maper)
            {
                var evento = _eventService.ProcurarPorId(item.Id);

                if (evento == null)
                    return NotFound(item);

                _eventService.Deletar(evento);
            }

            return Ok(_mapper.Map<List<EventDTO>>(maper));
        }

        // Esse comentario é apenas um teste para controle de versao        
    }
}
