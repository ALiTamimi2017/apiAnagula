using System.Threading.Tasks;
using apiAng.Api.Model;

namespace apiAng.Api.Data
{
    public interface IAuthRepository
    {  Task<User> Login(User user, string password);
        Task<User> Register(string UserName, string password);

        Task<bool> UserExsit(string UserName);

    }
}