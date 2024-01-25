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
    public class JobPostRepository : RepositoryBase<JobPost>,IJobPostRepository
    {
        public JobPostRepository(RepositoryContext context) : base(context)
        {

        }

        public void SaveJobPost(JobPost jobPost)
        {
           Create(jobPost);
           _context.SaveChanges();
        }
        public IQueryable<JobPost> GetAllJobs()
        {
           return FindAll(true);
        }
    }

}
