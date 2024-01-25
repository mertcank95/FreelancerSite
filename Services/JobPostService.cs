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
    public class JobPostService : IJobService
    {
        private readonly IRepositoryManager _repositoryManager;
        public JobPostService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public bool SaveJobPost(JobPost jobPost)
        {
            try
            {
                _repositoryManager.JobPostRepository.SaveJobPost(jobPost);
               
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }


        public List<JobPost> GetAllJobPosts() 
        {
            return _repositoryManager.JobPostRepository.GetAllJobs().ToList();
        }




    }
}
