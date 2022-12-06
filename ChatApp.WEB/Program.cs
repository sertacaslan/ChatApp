using ChatApp.Application;
using ChatApp.Infrastructure;
using ChatApp.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.Cookies;


var builder = WebApplication.CreateBuilder(args);

//katmanlar ekleniyor
//builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);



builder.Services.AddSignalR();
builder.Services.AddControllersWithViews();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Home/Login";
    x.LogoutPath = "/Home/Logout";
    x.ExpireTimeSpan = TimeSpan.FromDays(20);
    x.Cookie = new CookieBuilder()
    {
        Name = "ChatAppCookies",
        HttpOnly = true,
    };
});



var app = builder.Build();



app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();

//signalr için

app.MapHub<AppHub>("/apphub");
app.MapDefaultControllerRoute();

app.Run();
