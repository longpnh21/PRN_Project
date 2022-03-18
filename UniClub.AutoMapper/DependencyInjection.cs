using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace UniClub.AutoMapper
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMappingProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
