using Entities.Dtos.User;
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
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext context) : base(context)
        {
            
        }

        public async Task<Company> CreateCompanyAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
            return company;
        }


    }


}
