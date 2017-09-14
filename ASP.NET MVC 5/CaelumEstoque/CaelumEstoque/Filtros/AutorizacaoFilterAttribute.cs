using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CaelumEstoque.Filtros
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(IgnoraAutorizacaoFilterAttribute), false).Any())
            {
                /*Para tratarmos a requisição para a página de Login, temos que marca-la com o atributo IgnoraAutorizacaoFilter
                 e testar para ver se a requisição é descrita com este atributo.
                 Caso seja, retornamos, sem fazer nada.*/
                return;
            }


            //A requisição manda o filter context, de onde podemos pegar a Session de dentro da
            //propriedade HttpContext
            object usuario = filterContext.HttpContext.Session["usuarioLogado"];
            //Para autorizar a passagem da requisição pelo filtro, basta não fazer nada.
            //Sendo assim, vamos conferir se o usuário existe, e caso não exista, redirecionamos para a página de 
            //login novamente.
            if (usuario == null)
            {
                //Para fazermos o redirect, temos que atribuir à propriedade Result do filterContext
                //um novo objeto do tipo RedirectToRouteResult, que recebe no construtor um RouteValueDictionary, que recebe no construtor
                //um objeto anônimo com o nome do controller e o nome da action
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { controller = "Login", action = "Index" }
                        )
                    );
            }
        }

    }

}
