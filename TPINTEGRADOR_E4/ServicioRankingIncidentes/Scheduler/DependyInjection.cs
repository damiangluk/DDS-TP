using Quartz;

namespace ServicioRankingIncidentes.Scheduler
{
    public static class DependyInjection
    {
        public static void AddInfraestructure(this IServiceCollection services)
        {
            services.AddQuartz(options =>
            {
                options.UseMicrosoftDependencyInjectionJobFactory();
            });

            services.AddQuartzHostedService(options =>
            {
                options.WaitForJobsToComplete = true;
            });

            services.ConfigureOptions<RankingImpactoIncidentesJob>();
        }
    }
}