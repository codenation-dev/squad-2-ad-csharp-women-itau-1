using CentralDeErros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Services
{
    public interface IEventService
    {
        Event ProcurarPorId(int userId);
        IList<Event> BuscarPorAmbiente(string ambiente);
        IList<Event> BuscarPorLevel(string level, string ambiente);
        IList<Event> BuscarPorDescricao(string descricao, string ambiente);
        IList<Event> BuscarPorOrigem(string origem, string ambiente);
        IList<Event> OrdenarPorLevel(string ambiente);
        IList<Event> OrdenarPorFrequenciaDeLevel(string ambiente);
        Event ArquivarEvento(Event evento);
        Event DesarquivarEvento(Event evento);
        Event Deletar(Event evento);
        Event Salvar(Event evento);
    }
}
