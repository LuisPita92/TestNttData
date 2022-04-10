using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ntt.data.test.luis.pita.Models
{
    public class MovimientoModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha es requerida.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El tipo es requerido.")]
        [StringLength(1)]
        public string TipoMovimiento { get; set; }

        [Required(ErrorMessage = "La cuenta es requerido.")]
        public int CuentaId { get; set; }

        [ForeignKey("CuentaId")]
        public CuentaModel Cuenta { get; set; }

        [Required(ErrorMessage = "El valor es requerido.")]
        [Display(Name = "Movimiento")]
        [Range(0.00, 9999999.99)]
        public decimal Valor { get; set; }

        public decimal Saldo { get; set; }

        [Display(Name = "Saldo Inicial")]
        public decimal SaldoInicial { get; set; }
    }
}
