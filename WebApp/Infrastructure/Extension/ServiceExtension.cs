using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.EFCore;
using Services.Contracts;
using Services;

namespace WebApp.Infrastructure.Extension
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ef-SqlConnection")
                    , b => b.MigrationsAssembly("WebApp"));
                options.EnableSensitiveDataLogging(true);//hasas bilgiler (developer mod için)
            });
        }


        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options => {

                options.SignIn.RequireConfirmedEmail = false;//e-mail onaylamadığı sürece oturum açma durumu
                options.User.RequireUniqueEmail = true; //e-mail adresleri gerekli olsun mu
                //şifre Oluşturma
                options.Password.RequireUppercase = false;//büyük harf gereksin mi
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false; //Rakam gereksin mi
                options.Password.RequiredLength = 6;//şifre uzunluğu

            }).AddEntityFrameworkStores<RepositoryContext>();
        }


        public static void ConfigureSession(this IServiceCollection services)
        {
            //Sesion
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = "WebApp.Session";
                options.IdleTimeout = TimeSpan.FromDays(1);
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//kullanıcıların sürekli bu nesneden üretmesine gerek yok
         
        }


        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
       
            services.AddScoped<IAutService, AutService>();
        }
    }





}
