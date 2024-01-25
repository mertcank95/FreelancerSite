using Entities.Dtos.User;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IAutService _autservice;
        private readonly ICompanyService _companyservice;
        private readonly IJobService _jobservice;

        public ServiceManager(IAutService autservice, ICompanyService companyservice, IJobService jobservice)
        {
            _autservice = autservice;
            _companyservice = companyservice;
            _jobservice = jobservice;
        }
        public IAutService AutService => _autservice;
        public ICompanyService CompanyService => _companyservice;
        public IJobService JobService => _jobservice;
    }


}
