using WebApp.Infrastructure.Extension;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureSession();

builder.Services.ConfigureServiceRegistration();
builder.Services.ConfigureRepositoryRegistration();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
            //.AllowCredentials();
        });
});
var app = builder.Build();



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();



app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
       name: "Admin",
       areaName: "Admin",
       pattern: "Admin/{controller=AdminDashboard}/{action=Index}/{id?}");

    endpoints.MapAreaControllerRoute(
      name: "Company",
      areaName: "Company",
      pattern: "Company/{controller=CompanyDashboard}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=index}/{id?}");

    endpoints.MapControllers();

    //endpoints.MapRazorPages();

    //endpoints.MapControllers();
});

app.ConfigureAndCheckMigration();
app.ConfigureLocalization();
app.ConfigureAdminUser();
app.UseCors("AllowAll");
app.Run();
