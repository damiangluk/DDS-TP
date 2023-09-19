using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using TPINTEGRADOR.Models;

namespace TPINTEGRADOR.Models
{
    public class Ubicacion : Identidad
    {
        #region constructores
        public Ubicacion() { }
        public Ubicacion(double latitud, double longitud)
        {
            Latitud = latitud;
            Longitud = longitud;
        }
        #endregion

        #region propiedades
        public double Latitud{ get; set; }
        public double Longitud { get; set; }
        #endregion
    }
}