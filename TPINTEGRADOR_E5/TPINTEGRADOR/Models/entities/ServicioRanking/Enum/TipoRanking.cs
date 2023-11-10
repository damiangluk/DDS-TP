namespace TPINTEGRADOR.Models
{
    public enum TipoRanking
    {
        TIEMPOPROMEDIO,
        MAYORCANTIDADINCIDENTES,
        MAYORIMPACTO
    }

    public static class TipoRankingExtensions
    {
        public static TipoRanking? GetType(string type)
        {
            switch (type)
            {
                case "TIEMPOPROMEDIO":
                    return TipoRanking.TIEMPOPROMEDIO;
                case "ENTIDADESMAYORCANTIDADDEINCIDENTES":
                    return TipoRanking.MAYORCANTIDADINCIDENTES;
                case "MAYORIMPACTO":
                    return TipoRanking.MAYORIMPACTO;
                default:
                    return null;

            }
        }

        public static string GetTipo(this TipoRanking type)
        {
            switch (type)
            {
                case TipoRanking.TIEMPOPROMEDIO:
                    return "TIEMPOPROMEDIO";
                case TipoRanking.MAYORCANTIDADINCIDENTES:
                    return "ENTIDADESMAYORCANTIDADDEINCIDENTES";
                case TipoRanking.MAYORIMPACTO:
                    return "MAYORIMPACTO";
                default:
                    return string.Empty;

            }
        }

        public static List<object> GetAll()
        {
            List<object> lista = new List<object>();
            foreach (TipoRanking tipo in Enum.GetValues(typeof(TipoRanking)))
            {
                lista.Add(new
                {
                    Id = (int)tipo,
                    Text = TipoRankingExtensions.GetTipo(tipo)
                });
            }
            return lista;
        }
    }
}
