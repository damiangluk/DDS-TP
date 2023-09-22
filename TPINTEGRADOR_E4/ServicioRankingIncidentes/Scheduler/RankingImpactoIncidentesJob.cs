using Quartz;

namespace ServicioRankingIncidentes.Scheduler
{
    public class RankingImpactoIncidentesJob : IJob
    {
        private readonly ILogger<RankingImpactoIncidentesJob> _logger;

        public RankingImpactoIncidentesJob(ILogger<RankingImpactoIncidentesJob> logger)
        {
            _logger = logger;
        }


        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Iniciando tarea: {UtcNow}", DateTime.UtcNow);

            return Task.CompletedTask;
        }
    }
}