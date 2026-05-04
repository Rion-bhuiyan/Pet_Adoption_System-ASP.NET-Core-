using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using project.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
     .AddRoles<IdentityRole>()

    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();


app.MapControllerRoute(
    name: "em",
    pattern: "em",
    defaults: new { controller = "Pets", action = "Index" }
);
app.MapControllerRoute(
    name: "am",
    pattern: "am",
    defaults: new { controller = "Adopters", action = "Index" }
);
app.MapControllerRoute(
    name: "rm",
    pattern: "rm",
    defaults: new { controller = "Role", action = "Index" }
);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();

