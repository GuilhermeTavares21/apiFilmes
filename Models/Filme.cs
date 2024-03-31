using System.ComponentModel.DataAnnotations;

namespace FilmesApiAlura.Models;

public class Filme
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(50,ErrorMessage = "Número máximo de 50 caracteres")]
    public string Titulo { get; set; }
    [Required]
    [MaxLength(12, ErrorMessage = "Número máximo de 12 caracteres")]
    public string Genero { get; set; }
    [Required]
    [Range(60,600, ErrorMessage ="A duração deverá ser entre 60 a 600 minutos")]
    public int Duracao { get; set; }
    
}
