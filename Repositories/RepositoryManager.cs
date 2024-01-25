
using Repositories.Contracts;
using Repositories.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserRepository _userRepository;
        private readonly IJobPostRepository _jobPostRepository;
        public RepositoryManager(RepositoryContext context, ICompanyRepository companyRepository, IUserRepository userRepository, IJobPostRepository jobPostRepository)
        {
            _context = context;
            _companyRepository = companyRepository;
            _userRepository = userRepository;
            _jobPostRepository = jobPostRepository;
        }
        public ICompanyRepository CompanyRepository => _companyRepository;
        public IUserRepository UserRepository => _userRepository;
        public IJobPostRepository JobPostRepository => _jobPostRepository;
    }
}
