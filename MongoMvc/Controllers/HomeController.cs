using MongoMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MongoMvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            PaisDB db = new PaisDB();

            Pais p = new Pais();
            p.Title = "Titulo";
            p.Body = "Texto";
            p.Created = DateTime.Now;
            p.Active = true;
            db.CriarPais(p);

            db.EditarPais();

            var list = db.PesquisaPais("o");

            db.DeletarPais();

            return View();
        }
    }
}