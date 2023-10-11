using Quartz;
using TPINTEGRADOR.Models.daos.auxClasses;
using TPINTEGRADOR.Models.entities.ServicioRanking;

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

            var rankingGenerator = new RankingMayorImpacto();
            var ranking = rankingGenerator.GenerarRanking();

            DataFactory.RankingDao.Insert(ranking);

            _logger.LogInformation("Tarea terminada: {UtcNow}", DateTime.UtcNow);

            return Task.CompletedTask;
        }
    }
}