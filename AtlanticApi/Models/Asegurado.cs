using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtlanticApi.Models
{
    public class Asegurado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "El número de identificación es obligatorio.")]
        public int NumeroIdentificacion { get; set; }

        [Required(ErrorMessage = "El primer nombre es obligatorio.")]
        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        [Required(ErrorMessage = "El primer apellido es obligatorio.")]
        public string PrimerApellido { get; set; }

        [Required(ErrorMessage = "El segundo apellido es obligatorio.")]
        public string SegundoApellido { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        public string Telefono { get; set; }

        [Required, EmailAddress(ErrorMessage = "El email no es válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El valor estimado es obligatorio.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorEstimado { get; set; }

        public string Observaciones { get; set; }
    }
}
