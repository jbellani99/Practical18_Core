using Microsoft.EntityFrameworkCore;
using Practical18_Core.Infrastructure;
using Practical18_Core.Models;
using Practical18_Core.Repository;
using AutoMapper;
using Practical18_Core.Mapping;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IEmployee, Employeerepo>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EmpContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(options => options.AddProfile<MappingProfile>());

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
