﻿namespace TaxiDinamica.Web
{
    using System.Reflection;

    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using TaxiDinamica.Common;
    using TaxiDinamica.Data;
    using TaxiDinamica.Data.Common;
    using TaxiDinamica.Data.Common.Repositories;
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Data.Repositories;
    using TaxiDinamica.Data.Seeding;
    using TaxiDinamica.Services.Cloudinary;
    using TaxiDinamica.Services.Data.Appointments;
    using TaxiDinamica.Services.Data.Categories;
    using TaxiDinamica.Services.Data.Cities;
    using TaxiDinamica.Services.Data.Parameters;
    using TaxiDinamica.Services.Data.Directions;
    using TaxiDinamica.Services.Data.Partners;
    using TaxiDinamica.Services.Data.PartnerServicesServices;
    using TaxiDinamica.Services.Data.Schedules;
    using TaxiDinamica.Services.Data.Services;
    using TaxiDinamica.Services.Data.Tours;
    using TaxiDinamica.Services.DateTimeParser;
    using TaxiDinamica.Services.Mapping;
    using TaxiDinamica.Services.Messaging;
    using TaxiDinamica.Web.ViewModels;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(
                    this.configuration.GetConnectionString("DefaultConnection"),
                    providerOptions => providerOptions.EnableRetryOnFailure()));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            services.AddControllersWithViews();
            //services.AddRazorRuntimeCompilation();
           
            services.AddRazorPages();

            services.AddSingleton(this.configuration);

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // // External Login Setups
            // services.AddAuthentication().AddFacebook(facebookOptions =>
            // {
            //     facebookOptions.AppId = this.configuration["Authentication:Facebook:AppId"];
            //     facebookOptions.AppSecret = this.configuration["Authentication:Facebook:AppSecret"];
            // });

            // Cloudinary Setup
            Cloudinary cloudinary = new Cloudinary(new Account(
                GlobalConstants.CloudName, // this.configuration["Cloudinary:CloudName"],
                this.configuration["Cloudinary:ApiKey"],
                this.configuration["Cloudinary:ApiSecret"]));
            services.AddSingleton(cloudinary);

            // Application services
            services.AddTransient<IEmailSender, NullMessageSender>();
            services.AddTransient<IEmailSenderSmtp, EmailSenderSmtp>();
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IServicesService, ServicesService>();
            services.AddTransient<ICitiesService, CitiesService>();
            services.AddTransient<IParametersService, ParametersService>();
            services.AddTransient<IPartnersService, PartnersService>();
            services.AddTransient<IPartnerServicesService, PartnerServicesService>();
            services.AddTransient<IAppointmentsService, AppointmentsService>();
            services.AddTransient<IDateTimeParserService, DateTimeParserService>();
            services.AddTransient<IToursService, ToursService>();
            services.AddTransient<ISchedulesService, SchedulesService>();
            services.AddTransient<IDirectionsService, DirectionsService>();
            services.AddTransient<ICloudinaryService, CloudinaryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                    });
        }
    }
}
