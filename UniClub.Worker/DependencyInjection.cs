using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using UniClub.Worker.Jobs;

namespace UniClub.Worker
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddWorkers(this IServiceCollection services)
        {
            services.AddHostedService<QuartzHostedService>();
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            services.AddSingleton(new MyJob(type: typeof(UpdateClubMemberCountJob), expression: "0 0 0 ? * SUN"));

            return services;
        }
    }
}
