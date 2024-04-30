using E_Learning.DataSeeding;
using ELearning.BLL.Interfaces;
using ELearning.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Store.Repository.BasketRepository;
using Store.Repository.Interfaces;
using Store.Repository.Repositories;
using System;

namespace E_Learning
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ELearningDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ICacheRepository, CacheRepository>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.AddTransient<IConnectionMultiplexer>(config =>
            {
                var configuraion = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"));
                return ConnectionMultiplexer.Connect(configuraion);
            });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
            {
                option.Password.RequireDigit = true;
                option.Password.RequireLowercase = true;
                option.Password.RequireUppercase = true;
                option.Password.RequireNonAlphanumeric = true;
                // confirm email
                option.SignIn.RequireConfirmedAccount = false;
                // max attempts
                // option.Lockout.MaxFailedAccessAttempts = 20;

            }).AddEntityFrameworkStores<ELearningDbContext>()
                .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);


            var app = builder.Build();
            await UserRoleInitializer.Initialize(app);

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
                pattern: "{controller=Account}/{action=Login}/{id?}");

            //app.MapControllerRoute(
            //    name: "Admin",
            //    pattern: "{controller=Admin}/{action=Dashboard}/{id?}");

            app.Run();
        }
    }
}   
