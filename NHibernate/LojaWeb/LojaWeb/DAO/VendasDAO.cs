using LojaWeb.Entidades;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.DAO
{
    public class VendasDAO
    {
        ISession _session;

        public VendasDAO(ISession session)
        {
            _session = session;
        }

        public void Adiciona(Venda venda)
        {
            _session.Save(venda);
        }

        public IList<Venda> Lista()
        {
            return new List<Venda>();
        }

        public Venda BuscaPorId(int id)
        {
            return _session.Get<Venda>(id);
        }

        public void Atualiza(Venda venda)
        {
            _session.Merge(venda);
        }

    }
}