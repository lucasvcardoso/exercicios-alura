using LojaWeb.DAO;
using LojaWeb.Entidades;
using LojaWeb.Infra;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaWeb.Controllers
{
    public class UsuariosController : Controller
    {
        //
        // GET: /Usuarios/

        private UsuariosDAO _dao;

        public UsuariosController(UsuariosDAO dao)
        {
            _dao = dao;
        }

        public ActionResult Index()
        {
            IList<Usuario> usuarios = new List<Usuario>();
            return View(usuarios);
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(Usuario usuario)
        {
            _dao.Adiciona(usuario);
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(int id)
        {
            Usuario usuario = _dao.BuscaPorId(id);
            return View(usuario);
        }

        public ActionResult Atualiza(Usuario usuario)
        {
            _dao.Atualiza(usuario);
            return RedirectToAction("Index");
        }

    }
}
