
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
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
        [EnumDataType(typeof(TipoLocalizacion))]
        [Column(TypeName = "int")]
        public TipoLocalizacion TipoLocalizacion { get; set; }
        public string Nombre { get; set; }
        public ICollection<Entidad> Entidades { get; set; }
        #endregion

    }
}
