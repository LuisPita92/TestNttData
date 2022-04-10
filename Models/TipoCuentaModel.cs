using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ntt.data.test.luis.pita.Models
{
    public class TipoCuentaModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El valor es requerida.")]
        [Display(Name = "Tipo")]
        public string Valor{ get; set; }

        [Required(ErrorMessage = "El estado es requerido.")]
        public bool Estado { get; set; } = true;



    }
}
