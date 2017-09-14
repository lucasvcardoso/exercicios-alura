using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.CaixaEletronico.Sistema
{
    static class StringUtils
    {
        /// <summary>
        /// Exemplo de utilização de extension method
        /// para estender a funcionalidade da classe String.
        /// Só é possível estender comportamentos da interface pública da classe.
        /// </summary>
        /// <param name="palavra"></param>
        /// <returns></returns>
        public static string Pluralize(this string palavra)
        {
            if(palavra.EndsWith("s"))
            {
                return palavra;
            }
            else
            {
                return palavra + "s";
            }
        }
    }
}
