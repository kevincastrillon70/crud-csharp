using System.ComponentModel.DataAnnotations;

namespace CrudClientes.Models
{
    public class ClienteModel
    {
        [Required]
        public int idCli { get;  set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string? nombre { get; set; }
        [Required(ErrorMessage = "El email es obligatorio")]
        public string? email { get; set; }
        [Required(ErrorMessage = "El direccion es obligatorio")]
        public string? direccion  { get; set; }
        [Required(ErrorMessage = "El telefono es obligatorio")]
        public string? telefono  { get; set; }
        [Required(ErrorMessage = "El cedula es obligatorio")]
        public string? cedula  { get; set; }
        [Required(ErrorMessage = "El Fecha nacimiento es obligatorio")]
        public string? fecha_nac  { get; set; }
        [Required(ErrorMessage = "El estado es obligatorio")]
        public int estado { get; set; }


    }
}
