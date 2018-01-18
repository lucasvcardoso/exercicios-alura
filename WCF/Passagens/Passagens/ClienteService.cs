using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passagens
{
    public class ClienteService : IClienteService
    {
        public void Add(Cliente c)
        {
            ClienteDAO dao = new Passagens.ClienteDAO();
            dao.Add(c);
        }

        public Cliente Buscar(string nome)
        {
            ClienteDAO dao = new Passagens.ClienteDAO();
            return dao.Buscar(nome);
        }
    }
}
