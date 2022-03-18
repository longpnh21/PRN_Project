using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Worker.Jobs;

namespace UniClub.Worker
{
    public class QuartzHostedService : IHostedService
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IJobFactory _jobFactory;
        private IEnumerable<MyJob> _jobs;
        private readonly ILogger<QuartzHostedService> _logger;

        public QuartzHostedService(
            ISchedulerFactory schedulerFactory,
            IJobFactory jobFactory,
            IEnumerable<MyJob> myJobs,
            ILogger<QuartzHostedService> logger)
        {
            _schedulerFactory = schedulerFactory;
            _jobFactory = jobFactory;
            _jobs = myJobs;
            _logger = logger;
        }

        public IScheduler Scheduler { get; set; }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Common.Logs($"QuartzService started async at {DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss")}", $"QuartzHostedService-{DateTime.UtcNow.ToString("dd-MM-yyyy-HH-mm-ss")}");
            Scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
            Scheduler.JobFactory = _jobFactory;
            foreach (var myJob in _jobs)
            {
                var job = CreateJob(myJob);
                var trigger = CreateTrigger(myJob);
                await Scheduler.ScheduleJob(job, trigger, cancellationToken);
            }

            await Scheduler.Start(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Common.Logs($"QuartzHostedService stopped async at {DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss")}", $"QuartzHostedService-{DateTime.UtcNow.ToString("dd-MM-yyyy-HH-mm-ss")}");
            await Scheduler?.Shutdown(cancellationToken);
        }

        private static IJobDetail CreateJob(MyJob myJob)
        {
            var type = myJob.Type;
            return JobBuilder.Create(type)
                .WithIdentity(type.FullName)
                .WithDescription(type.Name)
                .Build();
        }

        private static ITrigger CreateTrigger(MyJob myJob)
        {
            return TriggerBuilder.Create()
                .WithIdentity($"{myJob.GetType().FullName}.trigger")
                .WithCronSchedule(myJob.Expression)
                .WithDescription(myJob.Expression)
                .Build();
        }
    }
}
