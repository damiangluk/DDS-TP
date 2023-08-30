
using System.ComponentModel.DataAnnotations.Schema;

namespace TPINTEGRADOR.Models
{
    public class Incidente : Identidad
    {
        public Incidente() {}
        public Incidente(SuperServicio servicio, DateTime fechaApertura, DateTime fechaCierre, Localizacion localizacion, string informe, string estado)
        {
            Servicio = servicio;
            FechaApertura = fechaApertura;
            FechaCierre = fechaCierre;
            Localizacion = localizacion;
            Informe = informe;
            Estado = estado;
        }


        public SuperServicio Servicio;
        [ForeignKey("Id")]
        public virtual Localizacion Localizacion { get; set; }
        public  string Informe { get; set; }
        public  string Estado { get; set; }

        public DateTime FechaApertura { get; set; }
        public DateTime? FechaCierre { get; set; }


        public bool EstaAbierto()
        {
            return !FechaCierre.HasValue;
        }

        public int CalcularTiempoDeCierre()
        {
            TimeSpan diferencia = FechaCierre.Value - FechaApertura;
            return (int)diferencia.TotalSeconds;
        }

    }
}