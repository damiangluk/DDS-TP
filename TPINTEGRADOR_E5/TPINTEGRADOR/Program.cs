using Auth0.AspNetCore.Authentication;
using Castle.Core.Resource;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
using System.Web.Razor.Parser.SyntaxTree;
using TPINTEGRADOR.Models;
using TPINTEGRADOR.Models.Sistema;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(options =>{ options.JsonSerializerOptions.PropertyNamingPolicy = null;});

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                     .RequireAuthenticatedUser()
                     .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});


builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// builder.Services.AddControllersWithViews();

builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = "nicogol.us.auth0.com";
    options.ClientId = "BsXXrfUk3nQtje73B3iyOUIeXtydkSna";
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://localhost:44385")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
var app = builder.Build();
using(var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DBContext>();
    context.Database.Migrate();
}

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
app.UseCors();
app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
