using Quartz;
using ServicioRankingIncidentes.Models;
using TPINTEGRADOR.Models;
using TPINTEGRADOR.Models.entities.ServicioRanking;
using TPINTEGRADOR.Models.Sistema;

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
            var DB = DBContext.CreateDbContext();

            var ranking = Ranking.generarRankingImpactoIncidentes(DB);

            ImpactoIncidentes impactoSemanal = new ImpactoIncidentes();
            impactoSemanal.FechaRanking = DateTime.Now;
            impactoSemanal.Ranking = JsonHelper.SerializeObject(ranking, 2);
            DB.ImpactoIncidentes.Add(impactoSemanal);
            DB.SaveChanges();
            DB.Dispose();

            return Task.CompletedTask;
        }
    }
}