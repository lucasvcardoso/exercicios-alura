using Caelum.CaixaEletronico.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Caelum.CaixaEletronico.Contas
{
        
    public abstract class Conta
    {
        public static int TotalDeContas { get; private set; }

        public double Saldo { get; set; }

        public int Numero { get; set; }

        public int Agencia { get; set; }

        public Cliente Titular { get; set; }

        public string stringTitular { get; set; }

        public static int ProximoNumero()
        {
            return Conta.TotalDeContas + 1;
        }

        public abstract void Saca(double valor);
       /* {
            /*if (valor > 0 && valor <= this.Saldo)
            {
                //if (Titular.EhMaiorDeIdade)
                if(true)
                {
                    this.Saldo -= valor;
                    return true;
                }
                else
                {
                    if (valor <= 200.0)
                    {
                        this.Saldo -= 200.0;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            
        }*/

        public void Deposita(double valor)
        {
            this.Saldo += valor;
        }

        public void Transfere(double valor, Conta destino)
        {
            this.Saca(valor);
            destino.Deposita(valor);
        }
    }
}
