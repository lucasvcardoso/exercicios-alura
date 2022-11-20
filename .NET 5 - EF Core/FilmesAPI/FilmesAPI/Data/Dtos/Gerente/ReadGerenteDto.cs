using FilmesAPI.Models;

namespace FilmesAPI.Data.Dtos
{
    public class ReadGerenteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual List<Cinema> Cinemas { get; set; }
    }
}
