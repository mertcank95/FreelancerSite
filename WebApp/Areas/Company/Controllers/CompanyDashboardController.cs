using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;

namespace WebApp.Areas.Company.Controllers
{
    [Area("Company")]
    public class CompanyDashboardController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public CompanyDashboardController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            var user = _serviceManager.AutService.GetIQueryableUser()
                .Include(u=>u.Company)
                .FirstOrDefault(u=>u.Id.Equals(userId));
            return View(user);
        }

    }
}
