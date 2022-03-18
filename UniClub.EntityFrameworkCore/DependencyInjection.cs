using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniClub.Application.Interfaces;
using UniClub.Domain.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.EntityFrameworkCore.Identity;
using UniClub.EntityFrameworkCore.Repositories;
using UniClub.Repositories.Interfaces;

namespace UniClub.EntityFrameworkCore
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEntityFrameworkCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UniClubContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(UniClubContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<UniClubContext>());

            services.AddIdentity<Person, IdentityRole>()
                .AddEntityFrameworkStores<UniClubContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IIdentityService, IdentityService>();

            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 0;
            });

            services.AddTransient<IUniversityRepository, UniversityRepository>();
            services.AddTransient<IClubRepository, ClubRepository>();
            services.AddTransient<IClubPeriodRepository, ClubPeriodRepository>();
            services.AddTransient<IClubRoleRepository, ClubRoleRepository>();
            services.AddTransient<IClubTaskRepository, ClubTaskRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IPostImageRepository, PostImageRepository>();
            services.AddTransient<IMemberRoleRepository, MemberRoleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}
