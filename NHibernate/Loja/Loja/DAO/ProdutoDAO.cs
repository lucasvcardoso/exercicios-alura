using Loja.Entidades;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.DAO
{
    public class ProdutoDAO
    {
        private ISession _session;

        public ProdutoDAO(ISession session)
        {
            _session = session;
        }

        public void Adiciona(Produto produto)
        {
            ITransaction trans = _session.BeginTransaction();
            _session.Save(produto);
            trans.Commit();
        }

        public void Remove(Produto produto)
        {
            ITransaction trans = _session.BeginTransaction();
            _session.Delete(produto);
            trans.Commit();
        }

        public Produto BuscaPorId(int id)
        {
            return _session.Get<Produto>(id);
        }

        public IList<Produto> BuscaPorNomePrecoMinimoECategoria(string nome, decimal precoMinimo, string nomeCategoria)
        {

            ICriteria criteriaProduto = _session.CreateCriteria<Produto>();
            //Podemos setar o resultado de queries com Criteria como cacheable também
            criteriaProduto.SetCacheable(true);
            
            if(!String.IsNullOrEmpty(nome))
            {
                criteriaProduto.Add(Restrictions.Eq("Nome", nome));
            }
            if(precoMinimo > 0)
            {
                criteriaProduto.Add(Restrictions.Ge("Preco", precoMinimo));
            }
            if(!string.IsNullOrEmpty(nomeCategoria))
            {
                //Desta forma buscamos a categoria com o nome informado
                ICriteria criteriaCategoria = criteriaProduto.CreateCriteria("Categoria");
                criteriaCategoria.Add(Restrictions.Eq("Nome", nomeCategoria));
            }
            return criteriaProduto.List<Produto>();
        }
    }
}
