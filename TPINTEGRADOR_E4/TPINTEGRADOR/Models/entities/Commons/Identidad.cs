using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TPINTEGRADOR.Models
{
    public class Identidad
    {
        [Key]
        public int Id { get; set; }

        public bool Equals(object obj)
        {
            return obj != null && obj is Identidad castObj && !Id.Equals(0) && Id.Equals(castObj.Id);
        }
    }
}
