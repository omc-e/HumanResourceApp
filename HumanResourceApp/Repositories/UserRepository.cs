using HumanResourceApp.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourceApp.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser = false;
            using (var context = new RepositoryBase())
            {
                context.Database.EnsureCreated();

                var user = context.User.Where(s => s.Username == credential.UserName && s.Password == credential.Password);
                if(user == null)
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
