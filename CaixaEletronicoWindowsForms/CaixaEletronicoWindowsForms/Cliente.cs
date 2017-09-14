using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Caelum.CaixaEletronico.Usuarios
{
    public class Cliente
    {
        public string nome;
        public string rg;
        public string cpf;
        public string endereco;
        public int Idade { get; set; }
        public bool EhMaiorDeIdade
        {
            get
            {
                return (this.Idade >= 18);
            }
        }

        public bool EEmancipado { get; set; }

        public bool PodeAbrirConta()
        {
            var maiorDeIdade = (this.Idade >= 18);
            var emancipado = (this.EEmancipado);
            var temCpf = !string.IsNullOrEmpty(this.cpf);

            return (maiorDeIdade || emancipado) && temCpf;
        }
    }
}
