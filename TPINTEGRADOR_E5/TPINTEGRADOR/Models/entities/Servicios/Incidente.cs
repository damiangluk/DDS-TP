
using System.ComponentModel.DataAnnotations.Schema;

namespace TPINTEGRADOR.Models
{
    public class Incidente : Identidad
    {
        #region constructores
        public Incidente() {}
        public Incidente(SuperServicio servicio, Localizacion localizacion, string informe, string estado)
        {
            Servicio = servicio;
            Localizacion = localizacion;
            Informe = informe;
            FechaApertura = DateTime.Now;
            Estado = estado;
        }
        #endregion

        #region propiedades
        public int ServicioId { get; set; }
        public int LocalizacionId { get; set; }
        public int? ProveedorId { get; set; }
        public  string Informe { get; set; }
        public  string Estado { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime? FechaCierre { get; set; }

        [ForeignKey("ServicioId")]
        public virtual SuperServicio Servicio { get; set; }
        [ForeignKey("LocalizacionId")]
        public virtual Localizacion Localizacion { get; set; }
        [ForeignKey("ProveedorId")]
        public virtual ProveedorDeServicio? Proveedor { get; set; }
        public virtual ICollection<Comunidad> Comunidades { get; set; }
        #endregion

        #region metodos
        public bool EstaAbierto()
        {
            return !FechaCierre.HasValue;
        }

        public int CalcularTiempoDeCierre()
        {
            TimeSpan diferencia = FechaCierre.Value - FechaApertura;
            return (int)diferencia.TotalSeconds;
        }

        public bool ImpactoEnLaSemana() => EstaAbierto() || (FechaCierre.Value > DateTime.Now.AddDays(-7));
        #endregion
    }
}