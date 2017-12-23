using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using System.Text;
using System.Threading.Tasks;

namespace Loja.Infra
{
    public class NHibernateHelper
    {
        private static ISessionFactory fabrica = CriaSessionFactory();

        private static ISessionFactory CriaSessionFactory()
        {
            Configuration cfg = RecuperaConfiguracao();
            return cfg.BuildSessionFactory();
        }

        /// <summary>
        /// Recupera o arquivo de configuração do NHibernate, carregas as cofigs e adiciona os assemblies em execução
        /// </summary>
        /// <returns></returns>
        public static Configuration RecuperaConfiguracao()
        {
            Configuration cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(Assembly.GetExecutingAssembly());

            return cfg;
        }

        /// <summary>
        /// Pega a configuração gerada e cria o schema na base de dados, utilizando os mappings criados nos .XML
        /// </summary>
        public static void GeraSchema()
        {
            Configuration cfg = RecuperaConfiguracao();
            new SchemaExport(cfg).Create(useStdOut:true, execute:true);
        }

        public static ISession AbreSession()
        {
            return fabrica.OpenSession();
        }
    }
}
