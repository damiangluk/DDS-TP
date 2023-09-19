using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using TPINTEGRADOR.Models;

namespace TPINTEGRADOR.Models
{
    public class Sucursal : Identidad
    {
        #region constructores
        public Sucursal() { }
        public Sucursal(Entidad entidad, Establecimiento establecimiento, int numeroSucursal)
        {
            Entidad = entidad;
            Establecimiento = establecimiento;
            NumeroSucursal = numeroSucursal;
        }
        #endregion

        #region propiedades
        public int EstablecimientoId { get; set; }
        public int EntidadId { get; set; }
        public int NumeroSucursal { get; set; }
        
        [ForeignKey("Id")]
        public virtual Entidad Entidad { get; set; }
        [ForeignKey("Id")]
        public virtual Establecimiento Establecimiento { get; set; }
        #endregion
    }
}