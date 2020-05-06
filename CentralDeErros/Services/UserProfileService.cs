using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CentralDeErros.Models;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;

namespace CentralDeErros.Services
{
    public class UserProfileService : IProfileService
    {
        private  CentralErrosContext _context;

        // utilizar o mesmo banco atual
        public UserProfileService(CentralErrosContext context)
        {
            _context = context;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            // cast token to objeto
            var request = context.ValidatedRequest as ValidatedTokenRequest;

            // verificar se o token � nulo
            if (request != null)
            {
                // buscar o usu�rio na base e add as respectivas claims
                var user = _context.Users.FirstOrDefault(x => x.Login == request.UserName);
                if (user != null)
                    context.AddRequestedClaims(GetUserClaims(user));
            }

            return Task.CompletedTask;
        }

        //set contexto ativo
        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }

        //add claims
        public static Claim[] GetUserClaims(User user)
        {
            return new []
            {
                new Claim(ClaimTypes.Name, user.Name ?? ""),
                new Claim(ClaimTypes.Email, user.Login.TrimEnd() ?? ""),
                new Claim(ClaimTypes.Role, "user")
            };
        }

    }
}