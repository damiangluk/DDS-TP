using System.ComponentModel.DataAnnotations.Schema;
using TPINTEGRADOR.Models.daos;
using TPINTEGRADOR.Models.daos.auxClasses;

namespace TPINTEGRADOR.Models
{
    public class Comunidad : Identidad
    {
        #region constructores
        public Comunidad() { }

        public Comunidad(List<SuperServicio> intereses, int cantidadMiembrosAfectados, Persona administrador) 
        {
            Intereses = intereses;
            CantidadMiembrosAfectados = cantidadMiembrosAfectados;
            Administrador = administrador;
        }

        #endregion

        #region propiedades
        public int CantidadMiembrosAfectados { get; set; }
        public int AdministradorId { get; set; }
        [ForeignKey("AdministradorId")]
        public virtual Persona Administrador { get; set; }

        public virtual ICollection<Participacion> Miembros { get; set; }
        public virtual ICollection<SuperServicio> Intereses { get; set; }

        public virtual ICollection<Incidente> Incidentes{ get; set; }
        #endregion

        #region metodos
        public void AvisoCambioLocalizacion(Persona persona)
        {  
            List<Incidente> incidentes = Intereses.SelectMany(interes => interes.Incidentes).ToList();
            incidentes = incidentes.Where(i => i.Localizacion == persona.LocalizacionActual).ToList();
            //incidentes.ForEach(i => sugerirInforme(persona,i));
        }

        public void AgregarUsuario(Persona persona, Rol rol, Medio medio)
        {
            Participacion participacion = new Participacion(persona, this, rol, medio);
            //Miembros.Add(participacion);
            //persona.Participaciones.Add(participacion);
            DataFactory.ParticipacionDao.Insert(participacion);
        }

        public void EliminiarUsuario(int idPersona)
        {
            Participacion participacion = Miembros.ToList().Find(p => p.Persona.Id == idPersona);
            //Miembros.Remove(participacion);
            //participacion.Persona.Participaciones.Remove(participacion);
            DataFactory.ParticipacionDao.Delete(participacion);
        }

        public int calcularCantMiembrosAfectados()
        {
            return Miembros.Count(miembro => miembro.Rol == Rol.USUARIOAFECTADO);
        }

        public void NotificarMiembros(Incidente incidente)
        {
            foreach (var miembro in Miembros)
            {
                miembro.NotificarIncidente(incidente);
            }
        }
        #endregion
    }
}
