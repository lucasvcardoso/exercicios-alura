using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaWeb.Filters
{
    public class TransactionFilter : ActionFilterAttribute
    {
        private ISession _session;

        public TransactionFilter(ISession session)
        {
            _session = session;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _session.BeginTransaction();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                _session.Transaction.Rollback();
                _session.Close();
            }
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (filterContext.Exception == null)
            {
                _session.Transaction.Commit();
            }
            else
            {
                _session.Transaction.Rollback();
            }
            _session.Close();
        }
    }
}