using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection;

namespace Repositories.EFCore
{
    public class RepositoryContext : IdentityDbContext<User>
    { 
        public DbSet<Company> Companies { get; set; }
        public DbSet<JobPost> JobPosts { get; set; }
        public RepositoryContext(DbContextOptions options) :
          base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}