using Microsoft.AspNetCore.Identity;
using PayrollManagementSys.Data.Context;
using PayrollManagementSys.Data.Extensions;
using PayrollManagementSys.Entity.Entities;

var builder = WebApplication.CreateBuilder(args);



builder.Services.LoadDataLayerExtensions(builder.Configuration);



// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireLowercase = false;
})
    .AddRoleManager<RoleManager<AppRole>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();


builder.Services.ConfigureExternalCookie(config =>
{
    config.LoginPath = new PathString("/Auth/Login");
    config.LogoutPath = new PathString("/Auth/Logout");
    config.Cookie = new CookieBuilder
    {
        SecurePolicy = CookieSecurePolicy.SameAsRequest,
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        Name = "PayrollManagement"

    };
    config.SlidingExpiration = true;
    config.ExpireTimeSpan = TimeSpan.FromDays(7);
    config.AccessDeniedPath = new PathString("/Auth/AccessDenied");
});





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
