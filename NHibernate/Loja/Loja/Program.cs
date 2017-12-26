using Loja.DAO;
using Loja.Entidades;
using Loja.Infra;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja
{
    class Program
    {
        public static void Main(string[] args)
        {
            //NHibernateHelper.GeraSchema();

            //TestaAdicionaProdutoComCategoriaVazia("Camiseta", 10);
            //TestaAdicionaProdutoComCategoriaVazia("Short", 25)
            //TestaManyToOne("Uma Categoria", "Camiseta", 10);
            //TestaCarregaProdutosCategoria(1);
            //TestaAdicionaProdutoComCategoriaVazia("Calça", 25);
            //TestaSelectTudoHql();
            //TestaSelectOrderByHql();
            //TestaSelectWhereComPlaceHolderHql();
            //TestaSelectWhereComNamedParamHql();
            //TestaSelectComWhereAnd();
            //TestaSelectComGroupBy();
            //TestaHqlGroupBy();
            //TestaJoinFetchProdutos();
            //TestaJoinFetchCategorias();
            //TestaSearchComCriteriaDinamica();
            TestaCacheNivel2();
            //TestaQueryCache();

            Console.ReadLine();

        }

        private static void TestaQueryCache()
        {
            ISession session = NHibernateHelper.AbreSession();
            ISession session2 = NHibernateHelper.AbreSession();

            //Uma vez setado o NHibernate para cachear resultados de queries, utilizamos o SetCacheable(true) para cachear o resultado da query
            //a entidade consultada também deve ser configurada para usar o cache, caso contrário o NHibernate só guarda os IDs no cache
            session.CreateQuery("from Usuario").SetCacheable(true).List<Usuario>();
            session2.CreateQuery("from Usuario").SetCacheable(true).List<Usuario>();
        }

        private static void TestaCacheNivel2()
        {
            ISession session = NHibernateHelper.AbreSession();
            ISession session2 = NHibernateHelper.AbreSession();

            Categoria c = session.Get<Categoria>(1);
            Categoria c2 = session.Get<Categoria>(1);

            Console.WriteLine(c.Produtos.Count);
            Console.WriteLine(c2.Produtos.Count);

            session.Close();
            session2.Close();
        }

        private static void TestaSearchComCriteriaDinamica()
        {
            ISession session = NHibernateHelper.AbreSession();

            ProdutoDAO dao = new ProdutoDAO(session);
            //Para buscar corretamente utilizando a Categoria, tem que ser lazy load, senão ele multiplica o número de linhas pelo número de produtos na
            //categoria, por causa do INNER JOIN
            IList<Produto> produtos = dao.BuscaPorNomePrecoMinimoECategoria("Camiseta", 0, "");

            foreach (var produto in produtos)
            {
                Console.WriteLine("Nome: " + produto.Nome + " Preco: " + produto.Preco.ToString() + " Categoria: " + produto.Categoria.Nome + "\n");
            }

            session.Close();
        }


        /// <summary>
        /// Utilizamos select distinct, pois o join traz uma linha para cada produto de cada categoria
        /// </summary>
        private static void TestaJoinFetchCategorias()
        {
            ISession session = NHibernateHelper.AbreSession();
            string hql = "select distinct c from Categoria c join fetch c.Produtos";
            IQuery query = session.CreateQuery(hql);

            IList<Categoria> categorias = query.List<Categoria>();

            foreach (Categoria categoria in categorias)
            {
                Console.WriteLine(categoria.Nome + " - " + categoria.Produtos.Count);
            }

            session.Close();
        }

        /// <summary>
        /// Join fetch para nos ajudar a evitar o problema de SELECT N+1
        /// </summary>
        private static void TestaJoinFetchProdutos()
        {
            ISession session = NHibernateHelper.AbreSession();
            string hql = "from Produto p join fetch p.Categoria";
            IQuery query = session.CreateQuery(hql);

            IList<Produto> produtos = query.List<Produto>();

            foreach (Produto produto in produtos)
            {
                Console.WriteLine(produto.Nome + " - " + produto.Categoria.Nome);
            }

            session.Close();
        }

        private static void TestaHqlGroupBy()
        {
            ISession session = NHibernateHelper.AbreSession();
            //HQL não funciona, pois não gera agrupamento corretamente
            string hql = "select p.Categoria.Nome as Categoria, count(p) as NumeroDePedidos from Produto p group by p.Categoria.Nome, p.Categoria.Id";
            //string hql = "select p.Categoria.Nome, count(p) from Produto p group by p.Categoria.Nome";
            IQuery query = session.CreateQuery(hql);

            query.SetResultTransformer(Transformers.AliasToBean<ProdutosPorCategoriaComClasse>());

            IList<ProdutosPorCategoriaComClasse> relatorio = query.List<ProdutosPorCategoriaComClasse>();

            session.Close();
        }

        private static void TestaSelectComGroupBy()
        {
            ISession session = NHibernateHelper.AbreSession();
            string hql = "select p.Categoria.Nome, count(p) from Produto p group by p.Categoria.Nome";
            IQuery query = session.CreateQuery(hql);

            IList<Object[]> resultados = query.List<Object[]>();

            IList<ProdutosPorCategoria> relatorio = new List<ProdutosPorCategoria>();
            ProdutosPorCategoria p = new ProdutosPorCategoria();

            foreach (Object[] resultado in resultados)
            {
                p.NomeCategoria = (string)resultado[0];
                p.NumeroDePedidos = (long)resultado[1];

                relatorio.Add(p);
            }

             session.Close();
        }

        private static void TestaSelectComWhereAnd()
        {
            ISession session = NHibernateHelper.AbreSession();
            string hql = "from Produto p where p.Preco > :minimo and p.Categoria.Nome = :categoria";
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("minimo", 10);
            query.SetParameter("categoria", "Uma Categoria");
            IList<Produto> produtos = query.List<Produto>();
            foreach (Produto prod in produtos)
            {
                Console.WriteLine(prod.Nome);
            }
            session.Close();
        }

        private static void TestaSelectWhereComNamedParamHql()
        {
            ISession session = NHibernateHelper.AbreSession();
            string hql = "from Produto p where p.Preco > :minimo";
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("minimo", 10);
            IList<Produto> produtos = query.List<Produto>();
            foreach (Produto prod in produtos)
            {
                Console.WriteLine(prod.Nome);
            }
            session.Close();
        }

        private static void TestaSelectWhereComPlaceHolderHql()
        {
            ISession session = NHibernateHelper.AbreSession();
            string hql = "from Produto p where p.Preco > ?";            
            IQuery query = session.CreateQuery(hql);
            query.SetParameter(0, 10);
            IList<Produto> produtos = query.List<Produto>();
            foreach (Produto prod in produtos)
            {
                Console.WriteLine(prod.Nome);
            }
            session.Close();
        }

        private static void TestaSelectOrderByHql()
        {
            ISession session = NHibernateHelper.AbreSession();
            string hql = "from Produto p order by p.Nome";
            IQuery query = session.CreateQuery(hql);
            IList<Produto> produtos = query.List<Produto>();
            foreach (Produto prod in produtos)
            {
                Console.WriteLine(prod.Nome);
            }
            session.Close();
        }

        private static void TestaSelectTudoHql()
        {
            ISession session = NHibernateHelper.AbreSession();
            string hql = "from Produto";
            IQuery query = session.CreateQuery(hql);
            IList<Produto> produtos = query.List<Produto>();
            foreach (Produto prod in produtos)
            {
                Console.WriteLine(prod.Nome);
            }
            session.Close();
        }

        public static void TestaCarregaProdutosCategoria(int id)
        {
            ISession session = NHibernateHelper.AbreSession();
            ITransaction trans = session.BeginTransaction();

            Categoria categoria = session.Load<Categoria>(id);
            IList<Produto> produtos = categoria.Produtos;

            Console.WriteLine(categoria.Produtos.Count);

            trans.Commit();
            session.Close();
        }

        public static void TestaManyToOne(string nomeCategoria, string nomeProduto, decimal precoProduto)
        {
            Categoria umaCategoria = new Categoria() { Nome=nomeCategoria};
            Produto produto = new Produto() { Nome = nomeProduto, Preco = precoProduto, Categoria = umaCategoria };

            ISession session = NHibernateHelper.AbreSession();
            ITransaction trans = session.BeginTransaction();

            session.Save(umaCategoria);
            session.Save(produto);

            trans.Commit();
            session.Close();
            
        }

        public static void TestaAdicionaProdutoComCategoriaVazia(string nome, decimal preco)
        {
            ISession session = NHibernateHelper.AbreSession();

            ProdutoDAO dao = new ProdutoDAO(session);

            Produto novoProduto = new Produto() { Nome = nome, Preco = preco, Categoria = new Categoria() { Id = 1,Nome = "Uma categoria" } };

            dao.Adiciona(novoProduto);

            session.Close();
        }


        public static void TestaAdicionaProduto(string nome, decimal preco)
        {
            ISession session = NHibernateHelper.AbreSession();

            ProdutoDAO dao = new ProdutoDAO(session);

            Produto novoProduto = new Produto() { Nome = nome, Preco = preco };

            dao.Adiciona(novoProduto);

            session.Close();
        }

        public static void InsereUsuarioCriandoFactorySessionTransaction()
        {
            Configuration cfg = NHibernateHelper.RecuperaConfiguracao();
            ISessionFactory sessionFactory = cfg.BuildSessionFactory();

            ISession session = sessionFactory.OpenSession();

            Usuario novoUsuario = new Usuario() { Nome = "Murilo" };

            ITransaction transacao = session.BeginTransaction();

            session.Save(novoUsuario);

            transacao.Commit();

            session.Close();

        }

        private static void TestaAdicionaUsuario(string nome)
        {
            ISession session = NHibernateHelper.AbreSession();

            UsuarioDAO usuarioDao = new UsuarioDAO(session);

            Usuario novoUsuario = new Usuario() { Nome = nome };

            usuarioDao.Adiciona(novoUsuario);

            session.Close();

        }

        public static void TestaRemoveUsuario(int id)
        {
            ISession session = NHibernateHelper.AbreSession();

            UsuarioDAO usuarioDao = new UsuarioDAO(session);

            Usuario novoUsuario = usuarioDao.BuscaPorId(id);

            usuarioDao.Remove(novoUsuario);

            session.Close();

        }

        public static void TestaPersistentUsuario()
        {
            ISession session = NHibernateHelper.AbreSession();

            UsuarioDAO dao = new UsuarioDAO(session);

            dao.TestaPersistent();

            session.Close();
        }
    }

    internal class ProdutosPorCategoriaComClasse
    {
        public Categoria Categoria { get; set; }
        public long NumeroDePedidos { get; set; }
    }

    public class ProdutosPorCategoria
    {
        public string NomeCategoria { get; set; }
        public long NumeroDePedidos { get; set; }
    }
}

