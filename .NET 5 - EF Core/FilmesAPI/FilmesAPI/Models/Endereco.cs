using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }

        /// <summary>
        /// Dessa forma indicamos que um <see cref="Endereco"/> possui um <see cref="Cinema"/>, pois para inserir um <see cref="Cinema"/>
        /// é necessário ter uma FK apontando para um <see cref="Endereco"/> existente.
        /// Porem, manter uma propriedade do tipo de <see cref="Cinema"/>, causa uma exception de referência cíclica
        /// com a classe <seealso cref="Endereco"/>
        /// Um possível workaround poderia ser marcar a propriedade Cinema como <see cref="JsonIgnoreAttribute"/>
        /// o que faz com que <see cref="Cinema"/> carregue <see cref="Endereco"/>, mas essa nao faça referencia
        /// circular de volta pra Cinema
        /// </summary>
        [JsonIgnore]
        public virtual Cinema Cinema { get; set; }//Marcar a propriedade como virtual habilita o lazy loading no EF Core
    }
}
