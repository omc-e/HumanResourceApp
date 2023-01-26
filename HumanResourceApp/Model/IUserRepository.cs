using System.Net;

namespace HumanResourceApp.Model
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);

    }
}
