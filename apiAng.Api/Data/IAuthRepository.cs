using System.Threading.Tasks;
using apiAng.Api.Model;

namespace apiAng.Api.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
    }
}