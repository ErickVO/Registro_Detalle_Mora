using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroMora.Models
{
    public class Mora
    {
        [Key]
        [Required(ErrorMessage ="Este campo no puede estar vacio.")]
        public int MoraId { get; set; }
        
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage ="Este campo no puede estar vacio.")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage ="Este campo no puede estar vacio")]
        public decimal Total { get; set; }

        [ForeignKey("MoraId")]
        public virtual List<MoraDetalle> MoraDetalle { get; set; }

        public Mora()
        {
            MoraId = 0;
            Fecha = DateTime.Now;
            Total = 0;
            MoraDetalle = new List<MoraDetalle>();
        }

        public Mora(int moraId, DateTime fecha, decimal total)
        {
            MoraId = moraId;
            Fecha = fecha;
            Total = total;
        }
    }
}
