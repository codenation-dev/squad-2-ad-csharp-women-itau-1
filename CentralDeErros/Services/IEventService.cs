using CentralDeErros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Services
{
    interface IEventService
    {
        Event ProcurarPorId(int userId);

        Event Salvar(Event evento);
    }
}
