using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repositories.EFCore
{
    public class RepositoryContext : IdentityDbContext<IdentityUser>
    { 
        
        public RepositoryContext(DbContextOptions options) :
          base(options)
        {

        }
    }
}