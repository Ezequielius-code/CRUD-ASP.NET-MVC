using System.ComponentModel.DataAnnotations;

namespace CrudWebNetCore.Models
{
    public class ModelCliente
    {
        public int IdContacto { get; set; }

        [Required(ErrorMessage = "*El campo 'nombre' es obligatorio.")]
        public string? nombre { get; set; }

        [Required(ErrorMessage = "*El campo 'dirección' es obligatorio.")]
        public string? direccion { get; set; }

        [Required(ErrorMessage = "*El campo 'población' es obligatorio.")]
        public string? poblacion { get; set; }

        [Required(ErrorMessage = "*El campo 'teléfono' es obligatorio.")]
        public string? telefono { get; set; }
    }
}
