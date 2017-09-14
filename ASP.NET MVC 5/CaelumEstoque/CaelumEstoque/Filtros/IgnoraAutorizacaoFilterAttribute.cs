using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace CaelumEstoque.Filtros
{
    /// <summary>
    /// Atributo especial criado somente para marcar as requisições para a página de Login,
    /// para que o atributo de autorização possa ser usado globalmente 
    /// sem no entanto criar problemas para acessar a página de login
    /// </summary>
    public class IgnoraAutorizacaoFilterAttribute : ActionFilterAttribute
    {
    }
}