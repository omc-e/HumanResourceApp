using HumanResourceApp.Factory;
using HumanResourceApp.Repositories;
using System.Linq;
using System.Net;

namespace HumanResourceApp.Services
{
    public class LoginProvider
    {
        private readonly DataBaseContextFactory _dbContextFactory;

        public LoginProvider(DataBaseContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser = false;
            using (RepositoryBase context = _dbContextFactory.CreateDbContext())
            {
                var user = context.User.Where(s => s.Username == credential.UserName && s.Password == credential.Password).FirstOrDefault();
                if (user == null)
                {
                    validUser = false;
                }
                else
                {
                    validUser = true;
                }

            }
            return validUser;
        }


    }


}
