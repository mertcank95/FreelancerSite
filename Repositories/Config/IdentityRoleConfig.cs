using Entities.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Config
{
    public class IdentityRoleConfig : IEntityTypeConfiguration<IdentityRole>
    {

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole() { Name = Role.None.ToString(), NormalizedName = Role.None.ToString().ToUpper() },
                new IdentityRole() { Name = Role.User.ToString(), NormalizedName = Role.User.ToString().ToUpper() },
                new IdentityRole() { Name = Role.Company.ToString(), NormalizedName = Role.Company.ToString().ToUpper() },
                new IdentityRole() { Name = Role.Admin.ToString(), NormalizedName = Role.Admin.ToString().ToUpper() });
        }

    }


}
