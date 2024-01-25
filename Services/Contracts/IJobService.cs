using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IJobService
    {
        bool SaveJobPost(JobPost jobPost);
        List<JobPost> GetAllJobPosts();
    }
}
