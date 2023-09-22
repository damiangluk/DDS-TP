using System.Collections.Generic;
using System.Security.Cryptography.Xml;
using TPINTEGRADOR.Models;
using TPINTEGRADOR.Models.Sistema;


namespace ServicioRankingIncidentes.Models
{
    public class Ranking
    {
        public List<Entidad> generarRanking()
        {


            using (var DB = new DBContext())
            {
               // List<Entidad> entidades_ordenadas = new List<Entidad>();
               // DBContext sistema_servicios = SistemaServiciosPublicos.GetInstance;
            }





            return entidades_ordenadas;
        }

    }
}
