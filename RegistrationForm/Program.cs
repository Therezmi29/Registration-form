using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using RegistrationForm.Data;
using RegistrationForm.IoC.Repository;
using RegistrationForm.IoC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Context
builder.Services.AddDbContext<AccountContext>(options =>
options.UseSqlServer("Data Source =.;Initial Catalog=RegistrationForm_DB;Integrated Security=true")
);
#endregion

#region IoC
builder.Services.AddScoped<ISignUpRepository, SignUpRepository>();
builder.Services.AddScoped<ILogInRepository, LogInRepository>();

#endregion

#region Athentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/LogIn/Login";
        option.LogoutPath = "/LogIn/Logout";
        option.ExpireTimeSpan = TimeSpan.FromDays(1);
    });
#endregion
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
