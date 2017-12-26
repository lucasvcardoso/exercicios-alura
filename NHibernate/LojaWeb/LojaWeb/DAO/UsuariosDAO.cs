using LojaWeb.Entidades;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.DAO
{
    public class UsuariosDAO
    {
        private ISession _session;

        public UsuariosDAO(ISession session)
        {
            this._session = session;
        }

        public void Adiciona(Usuario usuario)
        {
            _session.Save(usuario);
        }

        public void Remove(Usuario usuario)
        {

        }

        public void Atualiza(Usuario usuario)
        {
            _session.Merge(usuario);
        }

        public Usuario BuscaPorId(int id)
        {
            return _session.Get<Usuario>(id);
        }

        public IList<Usuario> Lista()
        {
            return new List<Usuario>();
        }
    }
}