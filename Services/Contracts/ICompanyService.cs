using Entities.Dtos.User;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICompanyService
    {
        Task<Company> CreateCompanyAsync(CompanyRegisterDto company);
    }
}
