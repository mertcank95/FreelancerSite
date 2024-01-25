using AutoMapper;
using Entities.Dtos.User;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public CompanyService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<Company> CreateCompanyAsync(CompanyRegisterDto companydto)
        {
            var company = _mapper.Map<Company>(companydto);
            var  companyResult = await _manager.CompanyRepository.CreateCompanyAsync(company);
            return companyResult;
        }

    }
}
