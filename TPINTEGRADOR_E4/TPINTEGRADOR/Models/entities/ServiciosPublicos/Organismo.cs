using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using TPINTEGRADOR.Models;

namespace TPINTEGRADOR.Models
{
    public class Organismo : Identidad
    {
        public Organismo() { }
        public Organismo(TipoOrganismo tipoOrganismo, string nombre)
        {
            TipoOrganismo = tipoOrganismo;
            Nombre = nombre;
        }

        public TipoOrganismo TipoOrganismo { get; set; }

        public string Nombre;
        public int EncargadoId { get; set; }
        public ICollection<Entidad> Entidades { get; set; }

        [Column("TipoOrganismo")]
        public int TipoOrganismoValue
        {
            get { return (int)TipoOrganismo; }
            set { TipoOrganismo = (TipoOrganismo)value; }
        }
        [ForeignKey("Id")]
        public virtual Persona Encargado { get; set; }

        public object OrganismosForFront()
        {
            object organismosFront = new
            {
                tipoOrganismo = TipoOrganismoExtensions.GetNombre(TipoOrganismo),
                nombreOrganismo = Nombre,
            };

            return organismosFront;
        }

    }
}