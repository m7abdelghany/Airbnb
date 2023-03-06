using Airbnb.Models;
using Airbnbfinal.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Stripe;

namespace Airbnbfinal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDbContext<Graduationproject1Context>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
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
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();


            //WebHost.CreateDefaultBuilder(args)
            ////   UseUrls("http://0.0.0.0:4242").
            ////  UseWebRoot("public").
            //// UseStartup<Startup>()
            // .Build();
            

            app.Run();
        }
        public class Startup
        {
            public void ConfigurationServices(IServiceCollection services)
            {
                services.AddMvc();
            }
            public void configure(IApplicationBuilder app, IWebHostEnvironment environment)
            {
                StripeConfiguration.ApiKey = "sk_test_51Mi93ZBg5knc7RZACnawaUcCGuGpBTthOglNgOIg1IkdrYQe1u6XntEmdRbdoNBYJJ4HnYWg9mnxHWZE0Xy4b82i00gyZ5enqQ";
                if (environment.IsDevelopment()) app.UseDeveloperExceptionPage();
                app.UseRouting();
                app.UseStaticFiles();
                app.UseEndpoints(endpoints=> endpoints.MapControllers());

            }
        }
    }
}