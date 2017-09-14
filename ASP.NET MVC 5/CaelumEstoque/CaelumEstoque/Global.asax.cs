using CaelumEstoque.App_Start;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CaelumEstoque
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //Desta forma registramos os filtros globais, chamando o método RegisterGlobalFilters e passando para ele
            //a propriedade Filters da classe GlobalFilters
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}
