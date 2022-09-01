using Microsoft.Build.Framework;

namespace CRUD_Web.Models
{
    public class ModelCliente
    {
        //Estas van a ser las columnas de nuestra tabla
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [Required]
        public string? Direccion { get; set; }

        [Required]
        public string? Poblacion { get; set; }

        [Required]
        public string?  Telefono { get; set; }
    }
}
