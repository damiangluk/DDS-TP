using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TPINTEGRADOR.Models;

namespace TPINTEGRADOR.Models
{
    public class Organismo : Identidad
    {
        #region constructores
        public Organismo() { }
        public Organismo(TipoOrganismo tipoOrganismo, string nombre)
        {
            TipoOrganismo = tipoOrganismo;
            Nombre = nombre;
        }
        #endregion

        #region propiedades
        public int EncargadoId { get; set; }
        public string Nombre { get; set; }
        [EnumDataType(typeof(TipoOrganismo))]
        [Column(TypeName = "int")]
        public TipoOrganismo TipoOrganismo { get; set; }
        public ICollection<Entidad> Entidades { get; set; }
        [ForeignKey("EncargadoId")]
        public virtual Persona Encargado { get; set; }
        #endregion

        #region metodos
        public object OrganismosForFront()
        {
            object organismosFront = new
            {
                tipoOrganismo = TipoOrganismoExtensions.GetNombre(TipoOrganismo),
                nombreOrganismo = Nombre,
            };

            return organismosFront;
        }
        #endregion
    }
}