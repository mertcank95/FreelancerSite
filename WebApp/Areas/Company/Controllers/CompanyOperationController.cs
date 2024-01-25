using AutoMapper;
using Entities.Dtos.User;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;

namespace WebApp.Areas.Company.Controllers
{
    [Area("Company")]
    public class CompanyOperationController : Controller
    {
        
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;
        public CompanyOperationController(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public IActionResult PostJob()
        {
            var jobs = _serviceManager.JobService.GetAllJobPosts();
            return View(jobs);
        }

        //int id,string title,string description,string shortDescription,double money, bool isActive

        [HttpPost]
        public bool SaveOrUpdateCompany(JobPostDto data)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            var user = _serviceManager.AutService.GetIQueryableUser()
                .Include(u => u.Company)
                .FirstOrDefault(u => u.Id.Equals(userId));
            var jobData =_mapper.Map<JobPost>(data);
            jobData.Company = user.Company;
            var result = _serviceManager.JobService.SaveJobPost(jobData);
            return result;
        }

        [HttpGet]
        public JsonResult GetAllJob()
        {
            var jobs = _serviceManager.JobService.GetAllJobPosts();
            return Json(jobs);
        }


        public IActionResult Users()
        {
            
            return View();
        }



    }
}
