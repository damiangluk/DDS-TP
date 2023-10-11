
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPINTEGRADOR.Models
{
    public class Prestacion : Identidad
    {
        #region constructores
        public Prestacion() { }
        public Prestacion(SuperServicio servicio, Establecimiento establecimiento, bool habilitado) 
        {
            Servicio = servicio;
            Establecimiento = establecimiento;
            Habilitado = habilitado;
        }
        #endregion

        #region propiedades
        public bool Habilitado { get; set; }
        public int ServicioId { get; set; }
        public int EstablecimientoId { get; set; }

        [ForeignKey("ServicioId")]
        public virtual SuperServicio Servicio { get; set; }
        [ForeignKey("EstablecimientoId")]
        public virtual Establecimiento Establecimiento { get; set; }
        #endregion
    }
}
