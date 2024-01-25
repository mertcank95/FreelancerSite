using Entities.Models;
using Repositories.Contracts;
using Repositories.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext context) : base(context)
        {

        }

        public User GetUserById(string id)
        {
           return FindAll(true).FirstOrDefault(u=>u.Id.Equals(id));
        }
    }
}
