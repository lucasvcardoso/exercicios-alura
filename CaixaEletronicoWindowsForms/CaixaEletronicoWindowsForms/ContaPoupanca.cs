using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.CaixaEletronico.Contas
{
    class ContaPoupanca : Conta, ITributavel
    {
        public override void Saca(double valor)
        {
            this.Saldo -= valor;
           
        }

        public double CalculaTributo()
        {
            return this.Saldo * 0.02;
        }
    }
}
