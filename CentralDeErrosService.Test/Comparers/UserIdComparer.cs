using CentralDeErros.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErrosService.Test.Comparers
{
    public class UserIdComparer : IEqualityComparer<User>
    {
        public bool Equals(User x, User y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(User obj)
        {
            return obj.GetHashCode();
        }
    }
}
