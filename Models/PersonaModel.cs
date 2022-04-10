using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ntt.data.test.luis.pita.Models
{
    public class PersonaModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [Display(Name = "Nombres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El genero es obligatorio.")]
        [StringLength(1)]
        public string Genero { get; set; }

        [Required(ErrorMessage = "La edad es obligatorio.")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "La identificación es obligatorio.")]
        [Display(Name = "Identificación")]
        [StringLength(20)]
        public string Identificacion { get; set; }
        
        [Display(Name = "Dirección")]
        [StringLength(200)]
        public string Direccion { get; set; }
        
        [Display(Name = "Teléfono")]
        [StringLength(20)]
        public string Telefono { get; set; }
    }
}
