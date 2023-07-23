using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApp.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SenderEmail()
        {
            //string link = Url.Action("DogrulaEmail", "Kullanici", new { token = kullanici.EmailOnayToken }, Request.Scheme);
         
            return View("İndex");
        }
    }
}
