
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPINTEGRADOR.Models
{
    public class Localizacion : Identidad
    {
        #region constructores
        public Localizacion() {}
        public Localizacion(TipoLocalizacion tipo, string nombre) 
        {
            TipoLocalizacion = tipo;
            Nombre = nombre;
        }
        #endregion

        #region propiedades
        [Column("TipoLocalizacion")]
        public TipoLocalizacion TipoLocalizacion { get; set; }
        public string Nombre { get; set; }
        [InverseProperty("Localizaciones")]
        public ICollection<Entidad> Entidades { get; set; }
        #endregion

    }
}
