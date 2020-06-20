using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroMora.Models
{
    public class Prestamos
    {
        [Key]
        public int PrestamoId { get; set; }

        [Required(ErrorMessage = "Introduzca una Fecha")]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [Range(minimum: 1, maximum: 2000000000, ErrorMessage ="Se requiere un Id mayor a 0")]
        [Required(ErrorMessage = "El campo no puede estar vacio")]
        public int PersonaId { get; set; }

        [MinLength(5, ErrorMessage ="El concepto no puede tener menos de 5 caracteres")]
        [MaxLength(60, ErrorMessage ="Ha alcanzado el limite permitido de caracteres")]
        [Required(ErrorMessage = "Este campo no puede estar vacio")]
        public string Concepto { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio")]
        public decimal Balance { get; set; }

        public Prestamos()
        {
            PrestamoId = 0;
            Fecha = DateTime.Now;
            PersonaId = 0;
            Concepto = string.Empty;
            Monto = 0;
            Balance = 0;
        }
    }
}
