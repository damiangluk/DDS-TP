
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPINTEGRADOR.Models
{
    public class Localizacion : Identidad
    {
        public Localizacion() {}
        public Localizacion(TipoLocalizacion tipo, string nombre) 
        {
            TipoLocalizacion = tipo;
            Nombre = nombre;
        }

        public TipoLocalizacion TipoLocalizacion { get; set; }
        public string Nombre { get; set; }
        [Column("TipoLocalizacion")]
        public int TipoLocalizacionValue
        {
            get { return (int)TipoLocalizacion; }
            set { TipoLocalizacion = (TipoLocalizacion)value; }
        }
    }
}
