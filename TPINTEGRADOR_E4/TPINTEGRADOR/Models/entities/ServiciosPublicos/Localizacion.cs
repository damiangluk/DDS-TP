
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPINTEGRADOR.Models
{
    public class Localizacion : Identidad
    {
        #region constructores
        public Localizacion() {}
        public Localizacion(TipoLocalizacion tipo, string nombre, Entidad entidad) 
        {
            TipoLocalizacion = tipo;
            Nombre = nombre;
            Entidad = entidad;
        }
        #endregion

        #region propiedades
        public TipoLocalizacion TipoLocalizacion { get; set; }
        public string Nombre { get; set; }
        public int EntidadId { get; set; }

        [Column("TipoLocalizacion")]
        public int TipoLocalizacionValue { get { return (int)TipoLocalizacion; } set { TipoLocalizacion = (TipoLocalizacion)value; } }
        public virtual Entidad? Entidad { get; set; }
        #endregion

    }
}
