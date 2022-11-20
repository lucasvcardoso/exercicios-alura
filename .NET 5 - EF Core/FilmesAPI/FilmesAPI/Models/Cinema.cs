using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }

        /// <summary>
        /// Dessa forma indicamos que um <see cref="Endereco"/> possui um <see cref="Cinema"/>, pois para inserir um <see cref="Cinema"/>
        /// é necessário ter uma FK apontando para um <see cref="Endereco"/> existente.
        /// Porem, manter uma propriedade do tipo de <see cref="Endereco"/>, causa uma exception de referência cíclica
        /// com a classe <seealso cref="Cinema"/>.        
        /// </summary>
        public virtual Endereco Endereco { get; set; }//Marcar a propriedade como virtual habilita o lazy loading no EF Core
        public int EnderecoId { get; set; }

        [JsonIgnore]
        public virtual Gerente Gerente { get; set; }
        [JsonIgnore]
        public int GerenteId { get; set; }
    }
}