using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using CentralDeErros.DTO;
using CentralDeErros.Models;
using CentralDeErros.Services;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CentralDeErros.Controllers
{

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        //// GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            var user = _userService.ProcurarPorId(id);

            if (user != null)
            {
                var retorno = _mapper.Map<UserDTO>(user);
                
                return Ok(retorno);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost("cadastrar")]
        public ActionResult<UserDTO> Post([FromBody]UserDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _mapper.Map<User>(value);

            var retorno = _userService.Salvar(user);

            return Ok(_mapper.Map<UserDTO>(retorno));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<UserDTO> Put([FromBody]UserDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var user = _mapper.Map<User>(value);

            var retorno = _userService.Salvar(user);

            return Ok(_mapper.Map<UserDTO>(retorno));


        }

        [HttpPost("deletar")]
        public ActionResult Deletar([FromBody]List<UserDTO> users)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            foreach (var item in users)
            {

                var user = _userService.ProcurarPorId(item.Id);

                if (user == null)
                    return NotFound(item);

                 _userService.Deletar(user);

            }

            return Ok();
        }

        [HttpGet("getToken")]
        public async Task<ActionResult<TokenResponse>> GetToken([FromBody]TokenDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // async request - await para aguardar retorno
            var disco = await DiscoveryClient.GetAsync("http://localhost:5000");

            // nesta parte, temos um exemplo de requisição com o tipo "password" 
            // esta é a forma mais comum
            var httpClient = new HttpClient();

            var tokenResponse = await httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "codenation.api_client",
                ClientSecret = "codenation.api_secret",
                UserName = value.UserName,
                Password = value.Password,
                Scope = "codenation"
            });

            // Se não tiver tiver um erro retornar token
            if (!tokenResponse.IsError)
            {
                return Ok(tokenResponse);
            }

            //retorna não autorizado e descrição do erro
            return Unauthorized(tokenResponse.ErrorDescription);
        }

    }
}
