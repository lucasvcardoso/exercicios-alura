using CaelumEstoque.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.App_Start
{
    /// <summary>    
    ///Para registrar os filtros que devem ser utilizados por TODA a aplicação
    ///criamos esta classe, e registramos no método RegisterGlobalFilters todos os filtros a serem utilizados
    ///por todas as actions da aplicação. Além disso, o método RegisterGlobelFilters tem que ser chamado de dentro 
    ///da classe Global.asax
    /// </summary>
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AutorizacaoFilterAttribute());
        }
    }
}