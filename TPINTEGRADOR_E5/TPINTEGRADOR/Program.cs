using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
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

/*builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = "Auth0";
})
.AddCookie()
.AddOpenIdConnect("Auth0", options =>
{
    options.Authority = "https://nicogol.us.auth0.com";
    options.ClientId = "BsXXrfUk3nQtje73B3iyOUIeXtydkSna";
    options.ClientSecret = "PhVeWsiZnO-W5PLXZLvW_iBuNI8IDbuZEKKk29dKnMdmyUVo7F0_d6Q4c2v7-7ia";
    options.ResponseType = "code";
    options.Scope.Add("openid");
    options.Scope.Add("profile");
    options.CallbackPath = new PathString("/");
    //options.AccessDeniedPath = "/";
    //options.RemoteSignOutPath = "/";
    //options.SignedOutRedirectUri = new PathString("/Login/Login");
    options.ClaimsIssuer = "Auth0";
    options.SaveTokens = true;
});*/

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
