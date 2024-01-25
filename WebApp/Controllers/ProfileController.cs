using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Contracts;

namespace WebApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IServiceManager _serviceManager;
        public ProfileController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
           var user = _serviceManager.AutService.GetUserById(userId);
            return View(user);
        }
        [HttpPost]
        public IActionResult SenderEmail()
        {
            //string link = Url.Action("DogrulaEmail", "Kullanici", new { token = kullanici.EmailOnayToken }, Request.Scheme);
         
            return View("Index");
        }
    }
}
