using Microsoft.EntityFrameworkCore;
using MVCAuth.Interfaces;
using MVCAuth.Models;
using MVCAuth.Services;

namespace MVCAuth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
           builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MVCAuthDbContext>(
        options => options.UseSqlServer("name=ConnectionStrings:dbConnection"));
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(1); // Set session timeout
            });

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

            app.UseSession();
            app.Run();
        }
    }
}