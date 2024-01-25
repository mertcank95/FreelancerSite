using Entities.Dtos.User;
using Entities.Enum;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Contracts;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManger;
        private readonly SignInManager<User> _signInManager;
        private readonly IServiceManager _serviceManger;
        public AccountController(UserManager<User> userManger,
            SignInManager<User> signInManager,
            IServiceManager serviceManger)
        {
            _userManger = userManger;
            _signInManager = signInManager;
            _serviceManger = serviceManger;
        }
        [AllowAnonymous]
        public IActionResult Login([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
        {
            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl
            });
           
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginUser([FromForm] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManger.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    await _signInManager.SignOutAsync();//aktif oturum varsa sonlandı
                    if ((await _signInManager.PasswordSignInAsync(user, model.Password, model.IsPersistent, false)).Succeeded)
                    {
                        var roles = await _serviceManger.AutService.GetUserRole(user);
                        foreach (var role in roles)
                        {
                            if (role.Equals(Role.Admin.ToString()))
                            {
                                return RedirectToAction("Index", "AdminDashboard", new { area = "Admin" });

                            }else if(role.Equals(Role.Company.ToString()))
                            {
                                return RedirectToAction("Index", "CompanyDashboard", new { area = "Company" });
                            }
                        }
                        return RedirectToAction("Index", "Profile");

                    }
                }
                ModelState.AddModelError("Error", "Invalid username or password");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser([FromForm] RegisterDto model)
        {
            try
            {
                var result = await SaveUser(model);
               if (result.result.Succeeded)
               {
                    return RedirectToAction("Login", new { ReturnUrl = "/" });
               }
                else
                {
                    foreach (var err in result.result.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }
               // var result = await _serviceManger.AutService.CreateUser(model);
              /*  if (result.result.Succeeded)
                {

                    var callbackUrl = Url.Action("EmailVerification", "Account", new { userId = result.userId, token = result.verificationToken }, Request.Scheme);
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
                    await service.SendEmailAsync(email);
                    return RedirectToAction("Login", new { ReturnUrl = "/" });
                }
                else
                {
                    foreach (var err in result.result.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }*/
            }
            catch (Exception)
            {

                throw;
            }
           
            return View();
        }


        [AllowAnonymous]
        public IActionResult SignUpCompany()
        {
            return View();
        }
        [AllowAnonymous]
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

        public async Task<(IdentityResult result, User user)> SaveUser(RegisterDto model)
        {
            var result = await _serviceManger.AutService.CreateUser(model);
            if (result.result.Succeeded)
            {

                var callbackUrl = Url.Action("EmailVerification", "Account", new { userId = result.user.Id, token = result.user.VerificationToken }, Request.Scheme);
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
                await service.SendEmailAsync(email);
            }
            return result;
        }

        public async Task SaveCompany(CompanySaveViewModel model)
        {
            try
            {
                var company = await _serviceManger.CompanyService.CreateCompanyAsync(model.CompanyDto);
                model.RegisterDto.Company = company;
                var result = await SaveUser(model.RegisterDto);
                if (result.result.Succeeded)
                {
                    var roleResult = await _userManger.AddToRoleAsync(result.user, Role.Company.ToString().ToUpper());
                }

            }
            catch (Exception)
            {

                //throw;
            }
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }


    }
}
