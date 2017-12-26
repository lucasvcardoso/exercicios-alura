using Loja.Entidades;
using Loja.Infra;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.DAO
{
    public class UsuarioDAO
    {
        private ISession _session;

        public UsuarioDAO(ISession session)
        {
            this._session = session;
        }

        public void Adiciona(Usuario usuario)
        {
            //Cria uma transação e salva o usuario informado
            ITransaction transacao = _session.BeginTransaction();
            _session.Save(usuario);
            transacao.Commit();
        }

        public void Remove(Usuario usuario)
        {
            //Cria uma transação e salva o usuario informado
            ITransaction transacao = _session.BeginTransaction();
            _session.Delete(usuario);
            transacao.Commit();
        }

        public Usuario BuscaPorId(int id)
        {
            //Busca um Usuario filtrando pelo id informado
            return _session.Get<Usuario>(id);
        }

        public void TestaPersistent()
        {
            ITransaction trans = _session.BeginTransaction();

            Usuario user = _session.Get<Usuario>(6);

            user.Nome = "Lucas Vieira Cardoso";

            trans.Commit();
        }
    }
}
