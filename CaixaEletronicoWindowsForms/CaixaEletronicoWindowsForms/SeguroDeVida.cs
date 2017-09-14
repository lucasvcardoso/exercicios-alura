using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.CaixaEletronico
{
    class SeguroDeVida : ITributavel
    {
        public double CalculaTributo()
        {
            return 43.0;
        }
    }
}
