using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroMora.Models
{
    public class MoraDetalle
    {
        [Key]
        public int MoraDetalleId { get; set; }
        public int MoraId { get; set; }
        public int PrestamoId { get; set; }
        public decimal Monto { get; set; }

        public MoraDetalle()
        {
            MoraDetalleId = 0;
            MoraId = 0;
            PrestamoId = 0;
            Monto = 0;
        }

        public MoraDetalle(int moraId, int prestamoId, decimal monto)
        {
            MoraDetalleId = 0;
            MoraId = moraId;
            PrestamoId = prestamoId;
            Monto = monto;
        }
    }
}
