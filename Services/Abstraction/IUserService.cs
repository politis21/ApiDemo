using ApiDemo.Data.Dto;
using ApiDemo.Data.Models;

namespace ApiDemo.Services.Abstraction
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
