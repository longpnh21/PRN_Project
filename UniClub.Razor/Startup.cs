using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UniClub.Application.Interfaces;
using UniClub.Application;
using UniClub.Commands;
using UniClub.EntityFrameworkCore;
using UniClub.Queries;
using UniClub.Services.Interfaces;
using UniClub.Razor.Utils;
using UniClub.Razor.Filters;
using UniClub.Razor.Services;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using FluentValidation.AspNetCore;

namespace UniClub.Razor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkCore(Configuration);
            services.AddApplication();
            //services.AddRedis(Configuration);
            //services.AddWorkers();
            services.AddMediaRCommands();
            services.AddMediaRQueries();

            services.AddRazorPages().AddRazorRuntimeCompilation()
                .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddSingleton<IJwtUtils, JwtUtils>();
            services.AddHttpContextAccessor();

            string rootPath;
            if (!string.IsNullOrEmpty(System.Environment.GetEnvironmentVariable("HOME")))

                rootPath = Path.Combine(System.Environment.GetEnvironmentVariable("HOME"), "site", "wwwroot");
            else
                rootPath = ".";

            string firebaseSdkPath = Path.Combine(rootPath, Configuration["Firebase:FileOptions"]);

            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile(firebaseSdkPath)
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.Authority = Configuration["Jwt:Firebase:ValidIssuer"];
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        RequireExpirationTime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Firebase:ValidIssuer"],
                        ValidAudience = Configuration["Jwt:Firebase:ValidAudience"]
                    };
                });

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
