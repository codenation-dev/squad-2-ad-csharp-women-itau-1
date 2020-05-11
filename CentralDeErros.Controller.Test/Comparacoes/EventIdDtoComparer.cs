using System;
using System.Collections.Generic;
using CentralDeErros.DTO;

namespace CentralDeErros.Controller.Test.Comparacoes
{
    public class EventIdDtoComparer : IEqualityComparer<EventDTO>
    {
        public bool Equals(EventDTO x, EventDTO y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(EventDTO obj)
        {
            return obj.GetHashCode();
        }
    }
}
