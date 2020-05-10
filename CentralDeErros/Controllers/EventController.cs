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
                return BadRequest();

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

            if(eventos != null)
            {
                var retorno = _mapper.Map<EventDTO>(eventos);
           

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
                var retorno = _mapper.Map<EventDTO>(eventos);
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

        [HttpGet("listarPorDescricao")]
        public ActionResult<IEnumerable<EventDTO>> ListarPorDescricao(string descricao, string ambiente)
        {
            var eventos = _eventService.BuscarPorDescricao(descricao, ambiente);

           // var retorno = new List<EventDTO>();

            if (eventos != null)
            {
                var retorno = _mapper.Map<EventDTO>(eventos);
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
                var retorno = _mapper.Map<EventDTO>(eventos);
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

        //[HttpGet]
        //public ActionResult<IEnumerable<EventDTO>> OrdenarListaPorLevel(List<Event> eventos)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest();

        //    var retorno = new List<EventDTO>();


        //    foreach (var item in eventos)
        //    {

        //        var evento = _eventService.ProcurarPorId(item.Id);

        //        if (evento == null)
        //            return NotFound(item);

        //        var eventoAtual = _eventService.OrdenarPorLevel(eventos);

        //        retorno.Add(new EventDTO()
        //        {
        //            Id = eventoAtual.Id,
        //            Level = eventoAtual.Level,
        //            Archived = eventoAtual.Archived,
        //            CollectedBy = eventoAtual.CollectedBy,
        //            Data = eventoAtual.Data,
        //            Description = eventoAtual.Description,
        //            Environment = eventoAtual.Environment,
        //            Log = eventoAtual.Log,
        //            LogId = eventoAtual.LogId,
        //            Origin = eventoAtual.Origin,
        //            Title = eventoAtual.Title
        //        });
        //    }

        //    return Ok(retorno);
        //}

        //[HttpGet]
        //public ActionResult<IEnumerable<EventDTO>> OrdenarListaPorFrequencia(int frequencia)
    
        //{

        //}


        [HttpPost]
        public ActionResult<EventDTO> Arquivar([FromBody]List<EventDTO> eventos)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var desarquivar = _mapper.Map<Event>(eventos);


            //  var retorno = new List<EventDTO>();

            foreach (var item in eventos)
            {

                var evento = _eventService.ProcurarPorId(item.Id);

                if (evento == null)
                    return NotFound(item);

                var retorno = _eventService.DesarquivarEvento(desarquivar);
            }

            return Ok(_mapper.Map<List<EventDTO>>(eventos));


        
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
                return BadRequest();

            var desarquivar = _mapper.Map<Event>(eventos);


           //  var retorno = new List<EventDTO>();

            foreach (var item in eventos)
            {

                var evento = _eventService.ProcurarPorId(item.Id);

                if (evento == null)
                    return NotFound(item);

                var retorno = _eventService.DesarquivarEvento(desarquivar);
            }

            return Ok(_mapper.Map<List<EventDTO>>(eventos));

            /*

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
            });*/
        }

    }


        [HttpPost("deletar")]
        public ActionResult<EventDTO> Deletar([FromBody]List<EventDTO> eventos)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            foreach (var item in eventos)
            {
                var evento = _eventService.ProcurarPorId(item.Id);

                if (evento == null)
                    return NotFound(item);

                _eventService.Deletar(evento);
            }

            return Ok();
        }
        // Esse comentario é apenas um teste para controle de versao 
    }
}
