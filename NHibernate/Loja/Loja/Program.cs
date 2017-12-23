using Loja.DAO;
using Loja.Entidades;
using Loja.Infra;
using NHibernate;
using NHibernate.Cfg;
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

            TestaAdiciona();
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

            Console.Read();
        }

        private static void TestaAdiciona()
        {
            ISession session = NHibernateHelper.AbreSession();

            UsuarioDAO usuarioDao = new UsuarioDAO(session);

            Usuario novoUsuario = new Usuario() { Nome = "Murilo" };

            usuarioDao.Adiciona(novoUsuario);

            session.Close();

            Console.Read();
        }

        public static void TestaDelete()
        {
            ISession session = NHibernateHelper.AbreSession();

            UsuarioDAO usuarioDao = new UsuarioDAO(session);

            Usuario novoUsuario = usuarioDao.BuscaPorId(1);

            usuarioDao.Remove(novoUsuario);

            session.Close();

            Console.Read();
        }
    }
}
