using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.CaixaEletronico.Contas
{
    public class ContaCorrente : Conta
    {
        public override void Saca(double valor)
        {
            this.Saldo -= valor;
        }
    }
}
