using System.ComponentModel.DataAnnotations;

namespace CRUDCORE.Models
{
    public class AlumnosModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo Nombres es obligatorio")]
        public string Nombres { get; set; } = null!;
        [Required(ErrorMessage = "El campo Apellidos es obligatorio")]
        public string Apellidos { get; set;} = null!;
        [Required(ErrorMessage = "El campo Genero es obligatorio")]
        public string Genero { get; set;} = null!;
        [Required(ErrorMessage = "El campo Fecha Registro es obligatorio")]
        public DateTime FechaRegistro  { get; set;}
    }
}
