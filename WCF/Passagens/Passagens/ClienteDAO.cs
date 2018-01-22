using Passagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passagens
{
    public class ClienteDAO
    {
        private static List<Cliente> clientes = new List<Cliente>();

        public void Add (Cliente c)
        {
            ClienteDAO.clientes.Add(c);
        }

        public Cliente Buscar(string nome)
        {
            var resultado = ClienteDAO.clientes.Where(c => c.Nome.Equals(nome)).FirstOrDefault();
            return (Cliente)resultado;
        }
    }
}
