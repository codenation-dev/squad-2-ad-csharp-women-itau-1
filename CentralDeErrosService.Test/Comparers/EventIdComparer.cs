using CentralDeErros.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErrosService.Test.Comparers
{
    class EventIdComparer : IEqualityComparer<Event>
    {
        public bool Equals(Event x, Event y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Event obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
