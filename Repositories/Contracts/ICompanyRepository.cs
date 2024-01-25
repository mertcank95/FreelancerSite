using Entities.Dtos.User;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface ICompanyRepository : IRepositoryBase<Company>
    {
        Task<Company> CreateCompanyAsync(Company company);
    }
}
