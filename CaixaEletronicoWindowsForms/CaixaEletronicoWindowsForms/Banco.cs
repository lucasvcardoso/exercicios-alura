using Caelum.CaixaEletronico.Contas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.CaixaEletronico
{
    class Banco
    {
        Conta[] contas = new Conta[100];
        int posicaoAtual = 0;

        public void Adiciona(Conta conta)
        {
            contas[posicaoAtual] = conta;
            posicaoAtual++;
        }
    }
}
