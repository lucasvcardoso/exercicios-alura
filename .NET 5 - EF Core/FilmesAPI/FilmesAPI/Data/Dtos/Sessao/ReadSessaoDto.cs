using FilmesAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.Sessao
{
    public class ReadSessaoDto
    {
        public int Id { get; set; }
        public Models.Filme Filme { get; set; }
        public Cinema Cinema { get; set; }
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }
    }
}
