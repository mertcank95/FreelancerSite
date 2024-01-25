using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.EFCore;
using Services.Contracts;
using Services;
using Entities.Models;
using Repositories.Contracts;
using Repositories;

namespace WebApp.Infrastructure.Extension
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DatabaseConnection")
                     /*b  b.MigrationsAssembly("WebApp")*/);
                options.EnableSensitiveDataLogging(true);
            });
        }


        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(options => {

                options.SignIn.RequireConfirmedEmail = false;//e-mail onaylamadığı sürece oturum açma durumu
                options.User.RequireUniqueEmail = true; 
                //şifre Oluşturma
                options.Password.RequireUppercase = true;//büyük harf gereksin mi
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true; //Rakam gereksin mi
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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
         
        }


        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager,ServiceManager>();
            services.AddScoped<IAutService, AutService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IJobService, JobPostService>();
        }

        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IJobPostRepository, JobPostRepository>();
        }


    }





}
