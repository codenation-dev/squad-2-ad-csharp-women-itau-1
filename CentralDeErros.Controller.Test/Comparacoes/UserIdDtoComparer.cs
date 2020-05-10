using System;
using System.Collections.Generic;
using CentralDeErros.DTO;


namespace CentralDeErros.Controller.Test.Comparacoes
{
    public class UserIdDtoComparer : IEqualityComparer<UserDTO>
    {
        public bool Equals(UserDTO x, UserDTO y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(UserDTO obj)
        {
            return obj.GetHashCode();
        }
    }
}
