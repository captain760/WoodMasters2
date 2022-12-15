using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WoodMasters2.Core.Contracts;
using WoodMasters2.Core.Data;
using WoodMasters2.Core.Data.Configurations;
using WoodMasters2.Core.Data.Entities;
using WoodMasters2.Core.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WMDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<Master>(options =>
{
    options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:RequireConfirmedAccount");
    options.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity:RequiredLength"); ;
    options.Password.RequireDigit = builder.Configuration.GetValue<bool>("Identity:RequireDigit"); ;
    options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Identity:RequireUppercase"); ;
    options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:RequireNonAlphanumeric"); ;
    options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Identity:RequireLowercase"); ;

})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<WMDbContext>();    
    

builder.Services.ConfigureApplicationCookie(options =>
{
       options.LoginPath = "/User/Login";
       options.Cookie.SameSite = SameSiteMode.Strict;
});
builder.Services.AddControllersWithViews();
builder.Services.AddMvc(options=>options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
builder.Services.AddScoped<IMasterPieceService, MasterPieceService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IRatingService, RatingService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode = {0}");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapAreaControllerRoute(
     name: "Administration",
     areaName: "Administration",
     pattern: "Administration/{controller=Users}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();


app.Run();

