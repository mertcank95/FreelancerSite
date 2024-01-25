using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    public class CompanyDashboardController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }

    }
}
