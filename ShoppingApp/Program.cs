using Microsoft.EntityFrameworkCore;
using ShoppingApp.Data;
using ShoppingApp.Repository;
using ShoppingApp.Repository.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DBConnection")) );
builder.Services.AddTransient(typeof(IRepository<>),typeof(MainRepository<>));
builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
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
    name: "area",
    pattern: "{area:exists}/{controller=Employee}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
