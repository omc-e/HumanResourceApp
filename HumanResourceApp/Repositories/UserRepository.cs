using HumanResourceApp.Model;
using System.Linq;
using System.Net;

namespace HumanResourceApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private RepositoryBase context;



        public UserRepository(RepositoryBase dbContext)
        {
            context = dbContext;
        }
        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser = false;


            var user = context.User.Where(s => s.Username == credential.UserName && s.Password == credential.Password).FirstOrDefault();
            if (user == null)
            {
                validUser = false;
            }
            else
            {
                validUser = true;
            }
            return validUser;
        }
    }
}
