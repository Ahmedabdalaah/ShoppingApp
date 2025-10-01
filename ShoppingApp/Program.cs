using Microsoft.EntityFrameworkCore;
using ShoppingApp.Data;
using ShoppingApp.Repository;
using ShoppingApp.Repository.Base;

var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel to listen on port 80 inside the container
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(80); // مهم للاتصال من Docker
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));
builder.Services.AddTransient(typeof(IRepository<>), typeof(MainRepository<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// app.UseHttpsRedirection(); // علقناها للـ Docker
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "area",
    pattern: "{area:exists}/{controller=Employee}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
