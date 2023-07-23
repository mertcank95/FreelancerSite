using WebApp.Infrastructure.Extension;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureSession();

builder.Services.ConfigureServiceRegistration();
builder.Services.AddAutoMapper(typeof(Program));

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
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=index}/{id?}");

    //endpoints.MapRazorPages(); //razer page i�in

    //endpoints.MapControllers();//Api end pointleri i�in
});

app.ConfigureAndCheckMigration();//migrationlari uygular
app.ConfigureLocalization();//dil destegi
app.Run();
