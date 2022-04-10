using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ntt.data.test.luis.pita.Models
{
    public class ClienteModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La persona es requerida.")]
        [Display(Name = "Persona")]
        public int PersonaId { get; set; }

        [ForeignKey("PersonaId")]
        public virtual PersonaModel Persona { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida.")]
        [StringLength(50)]
        [Display(Name = "Contraseña")]
        public string Contrasenia { get; set; }

        [Required(ErrorMessage = "El estado es requerido.")]
        public bool Estado { get; set; } = true;
    }
}
