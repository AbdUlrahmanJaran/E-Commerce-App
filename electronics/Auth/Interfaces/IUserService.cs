using Electronics.Auth.Model.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Electronics.Auth.Interfaces
{
    public interface IUserService
    {
        public Task<UserDTO> Register(RegisterDTO data, ModelStateDictionary modelState);
        public Task<UserDTO> Authenticate(string username, string password);
        public Task<UserDTO> GetUser(ClaimsPrincipal principal);

        public Task LogOut();
    }
}
