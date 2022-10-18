using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class UpdateFilmeDto
    {
        [Required(ErrorMessage = "O campo Titulo eh obrigatorio")]
        public string? Titulo { get; set; }
        [Required(ErrorMessage = "O campo Diretor e obrigatorio")]
        public string? Diretor { get; set; }
        [StringLength(30, ErrorMessage = "O Gênero não pode passar de 30 caracteres")]
        public string? Genero { get; set; }
        [Range(1, 600, ErrorMessage = "A Duracao deve ser entre 1 e 600 minutos")]
        public int Duracao { get; set; } = 0;
    }
}
