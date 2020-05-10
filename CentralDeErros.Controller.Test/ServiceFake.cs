using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CentralDeErros.DTO;
using CentralDeErros.Models;
using CentralDeErros.Services;
using Moq;
using Newtonsoft.Json;

namespace CentralDeErros.Controller.Test
{

    public class ServiceFake
    {
        private Dictionary<Type, string> FileDataNames { get; } = new Dictionary<Type, string>();
        public IMapper Mapper { get; }

        public ServiceFake()
        {

            FileDataNames.Add(typeof(User), $"DadosFake{Path.DirectorySeparatorChar}users.json");
            FileDataNames.Add(typeof(Event), $"DadosFake{Path.DirectorySeparatorChar}events.json");

            FileDataNames.Add(typeof(EventDTO), $"DadosFake{Path.DirectorySeparatorChar}events.json");
            FileDataNames.Add(typeof(UserDTO), $"DadosFake{Path.DirectorySeparatorChar}users.json");

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>().ReverseMap();
                cfg.CreateMap<Event, EventDTO>().ReverseMap();

            });

            this.Mapper = configuration.CreateMapper();
        }

        private string FileName<T>()
        {
            var retorno = FileDataNames[typeof(T)];

            return retorno;
        }

        public List<T> GetDadosFake<T>()
        {
            string content = File.ReadAllText(FileName<T>());

            var retorno = JsonConvert.DeserializeObject<List<T>>(content);

            return retorno;
        }

        #region servico user

        public Mock<IUserService> FakeUser()
        {
            var service = new Mock<IUserService>();

            service.Setup(x => x.ProcurarPorId(It.IsAny<int>())).
                Returns((int id) => GetDadosFake<User>().FirstOrDefault(x => x.Id == id));

            service.Setup(x => x.procurarPorLogin(It.IsAny<string>())).
               Returns((string login) => GetDadosFake<User>().Where(x => x.Login == login).ToList());


            service.Setup(x => x.Salvar(It.IsAny<User>())).
               Returns((User user) =>
               {

                   if (user.Id == 0)
                   {
                       user.Id = 999;

                   }
                   return user;
               });




            service.Setup(x => x.Deletar(It.IsAny<User>())).
             Returns((User user) => GetDadosFake<User>().FirstOrDefault());

            /*service.Setup(x => x.Deletar(It.IsAny<User>())).
                           Returns((User user) => {

                              // var users = GetDadosFake<User>().Select(user).ToList();

                               if (user.Id == 0)
                               {
                                   user.Id = 999;

                               }
                               return user;
                           });

    
                 service.Setup(x => x.Deletar(It.IsAny<User>())).
                    Returns((User user) => GetDadosFake<User>().Remove(user));
                     */

            return service;

        }
            #endregion

            #region service event

           public Mock<IEventService> FakeEvent()
            {
                var service = new Mock<IEventService>();

                 service.Setup(x => x.ProcurarPorId(It.IsAny<int>())).
                    Returns((int id) => GetDadosFake<Event>().FirstOrDefault(x => x.Id == id));

                 service.Setup(x => x.BuscarPorAmbiente(It.IsAny<string>())).
                    Returns((string ambiente) => GetDadosFake<Event>().Where(x => x.Environment == ambiente).ToList());

                 service.Setup(x => x.BuscarPorLevel(It.IsAny<string >(), It.IsAny<string>())).
                  Returns((string level, string ambiente) => GetDadosFake<Event>().Where(x => x.Level == level && x.Environment == ambiente).ToList());

                 service.Setup(x => x.BuscarPorDescricao(It.IsAny<string>(), It.IsAny<string>())).
                  Returns((string descricao, string ambiente) => GetDadosFake<Event>().Where(x => x.Description == descricao && x.Environment == ambiente).ToList());

                 service.Setup(x => x.BuscarPorOrigem(It.IsAny<string>(), It.IsAny<string>())).
                  Returns((string origem, string ambiente) => GetDadosFake<Event>().Where(x => x.Origin == origem && x.Environment == ambiente).ToList());

                 service.Setup(x => x.OrdenarPorLevel(It.IsAny<List<Event>>())).
                   Returns((List<Event> events) => GetDadosFake<Event>().OrderBy(x => x.Level).ToList());

                 service.Setup(x => x.ArquivarEvento(It.IsAny<Event>())).
                   Returns((Event events) =>
                   {

                       events.Arquivar();
                       
                       return events;
                   });

                 service.Setup(x => x.Salvar(It.IsAny<Event>())).
                   Returns((Event evento) =>
                               {
                                   if (evento.Id == 0)
                                   {
                                       evento.Id = 999;

                                   }
                                   return evento;
                               });
               //  service.Setup(x => x.Deletar(It.IsAny<Event>())).
                 //   Returns((Event  event) => GetDadosFake<Event>().FirstOrDefault());

            return service;

            }








            #endregion 
        }
    }
}