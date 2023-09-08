﻿
using System.ComponentModel.DataAnnotations.Schema;

namespace TPINTEGRADOR.Models
{
    public class Incidente : Identidad
    {
        #region constructores
        public Incidente() {}
        public Incidente(SuperServicio servicio, DateTime fechaApertura, DateTime fechaCierre, Localizacion localizacion, string informe, string estado)
        {
            Servicio = servicio;
            FechaApertura = fechaApertura;
            FechaCierre = fechaCierre;
            Localizacion = localizacion;
            Informe = informe;
            Estado = estado;
        }
        #endregion

        #region propiedades
        public int ServicioId { get; set; }
        public int LocalizacionId { get; set; }
        public  string Informe { get; set; }
        public  string Estado { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime? FechaCierre { get; set; }

        [ForeignKey("Id")]
        public virtual SuperServicio Servicio { get; set; }
        [ForeignKey("Id")]
        public virtual Localizacion Localizacion { get; set; }
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
        #endregion
    }
}