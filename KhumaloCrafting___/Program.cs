using KhumaloCrafting___.Data;
using KhumaloCrafting___.Models;
using KhumaloCrafting___.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<KhumaloCraft_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("KhumaloCraft_Context")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<KhumaloCraft_Context>()
        .AddDefaultTokenProviders();


builder.Services.AddTransient<IRoleInitializer, RoleInitializer>();

builder.Services.AddScoped<ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var roleInitializer = serviceProvider.GetRequiredService<IRoleInitializer>();
    roleInitializer.InitializeAsync().Wait();
}

app.Run();
