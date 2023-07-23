using Entities.Dtos.User;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManger;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManger,
            SignInManager<IdentityUser> signInManager)
        {
            _userManger = userManger;
            _signInManager = signInManager;
        }
        public IActionResult Login([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
        {
            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManger.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    await _signInManager.SignOutAsync();//aktif oturum varsa sonlandı
                    if ((await _signInManager.PasswordSignInAsync(user, model.Password, false, false)).Succeeded)
                    {
                        return Redirect(model.ReturnUrl ?? "/");
                        //returUrl varsa oraya gitcek aksi halde ana sayfaya gitcek
                        //mesela alışverişi yaptı ödeme gitcek önce logine sonra ödemeye gitcek
                    }
                }
                ModelState.AddModelError("Error", "Invalid username or password");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] RegisterDto model)
        {
            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                VerificationToken = "token1"
            };

            var result = await _userManger
                .CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                /*var roleResult = await _userManger
                    .AddToRoleAsync(user, "User");*/
                // if (roleResult.Succeeded)
                var callbackUrl = Url.Action("EmailVerification", "Account", new { userId = user.Id, token = "token1" }, Request.Scheme);
                Email email = new()
                {
                    SmtpHost = "smtp.gmail.com",
                    SmtPort = 587,
                    SenderEmail = "kiratlimertcan@gmail.com",
                    Password = "hdnsvixsrcbdeejl",
                    ToEmail = model.Email,
                    Subject = "test email",
                    Body = "<h1>This is a test email.</h1><p>Hello, this is a test email sent from the EmailService class.</p> </br> doğrulama link : " + callbackUrl
                };
                EmailService service = new EmailService();
                service.SendEmailAsync(email);

                return RedirectToAction("Login", new { ReturnUrl = "/" });
            }
            else
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }

            return View();
        }


        public IActionResult Register()
        {
            return View();
        }


        public async Task<IActionResult> EmailVerification(string userId, string token)
        {
            var user = await _userManger.FindByIdAsync(userId);
            user.EmailConfirmed = true;
            await _userManger.UpdateAsync(user);
            return View();
        }


    }
}
