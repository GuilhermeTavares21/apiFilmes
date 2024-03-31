using System.ComponentModel.DataAnnotations;

namespace FilmesApiAlura.Dto
{
    public class CreateFilmeDtos
    {

        [Required]
        public string Titulo { get; set; }
        [Required]
        [StringLength(12, ErrorMessage = "Número máximo de 12 caracteres")]
        public string Genero { get; set; }
        [Required]
        [Range(50, 600, ErrorMessage = "A duração deverá ser entre 60 a 600 minutos")]
        public int Duracao { get; set; }

    }
}
