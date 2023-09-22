using Microsoft.Extensions.Options;
using Quartz;

namespace ServicioRankingIncidentes.Scheduler
{
    public class RankingImpactoIncidentesJobSetup : IConfigureOptions<QuartzOptions>
    {
        public void Configure(QuartzOptions options)
        {
            var jobKey = JobKey.Create(nameof(RankingImpactoIncidentesJob));
            options
                .AddJob<RankingImpactoIncidentesJob>(jobBuilder => jobBuilder.WithIdentity(jobKey))
                .AddTrigger(trigger => trigger.ForJob(jobKey).WithSimpleSchedule(schedule => schedule.WithIntervalInSeconds(5).RepeatForever()));

            //.WithSchedule(CronScheduleBuilder.CronSchedule("0 0 9 ? * MON"))
        }
    }
}