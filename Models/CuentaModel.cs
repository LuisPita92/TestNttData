using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ntt.data.test.luis.pita.Models
{
    public class CuentaModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El número de cuenta es requerido.")]
        [Display(Name = "Número")]
        [StringLength(50)]
        public string Numero { get; set; }

        [Required(ErrorMessage = "El tipo es requerido.")]
        [Display(Name = "Tipo")]
        public int TipoCuentaId { get; set; }

        [ForeignKey("TipoCuentaId")]
        public virtual TipoCuentaModel TipoCuenta { get; set; }

        [Required(ErrorMessage = "El cliente es requerido.")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual ClienteModel Cliente { get; set; }

        [Required(ErrorMessage = "El saldo es requerido.")]
        [Range(0.00, 9999999.99)]
        public decimal Saldo { get; set; }

        [Required(ErrorMessage = "El estado es requerido.")]
        public bool Estado { get; set; } = true;



    }
}
