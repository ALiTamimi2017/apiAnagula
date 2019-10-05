using System.Threading.Tasks;
using apiAng.Api.Model;

namespace apiAng.Api.Data
{
    public interface IAuthRepository
    {  Task<User> Login(string UserName, string password);
        Task<User> Register(User UserName, string password);

        Task<bool> UserExsit(string UserName);

    }
}