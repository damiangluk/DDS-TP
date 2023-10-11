using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPINTEGRADOR.Models
{
    public class Identidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool Equals(object obj)
        {
            return obj != null && obj is Identidad castObj && !Id.Equals(0) && Id.Equals(castObj.Id);
        }
    }
}
