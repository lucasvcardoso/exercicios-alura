using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Gerente
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        [JsonIgnore]//Workaround pra carregar Gerente sem gerar referência cíclica
        public virtual List<Cinema> Cinemas { get; set; }
    }
}
