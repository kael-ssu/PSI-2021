using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modelo.Cadastros;
using Servico.Cadastros;

namespace PrimeiraAplicação.Areas.Cadastros.Controllers
{
    public class FabricantesController : Controller
    {
        FabricanteServico fabricanteServico = new FabricanteServico();

        private ActionResult GravarFabricante(Fabricante fabricante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    fabricanteServico.GravarFabricante(fabricante);
                    return RedirectToAction("Index");
                }
                return View(fabricante);
            }
            catch
            {
                return View(fabricante);
            }
        }

        private ActionResult ObterVisaoFabricantePorId(long id)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Fabricante fabricante = fabricanteServico.ObterFabricantePorId(id);

            if (fabricante == null)
                return HttpNotFound();

            return View(fabricante);
        }

        // GET
        public ActionResult Index()
        {
            return View(fabricanteServico.ObterFabricantesClassificadosPorNome());
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            return GravarFabricante(fabricante);
        }

        // GET
        public ActionResult Edit(long? id)
        {
            return ObterVisaoFabricantePorId((long)id);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            return GravarFabricante(fabricante);
        }

        // GET
        public ActionResult Delete(long? id)
        {
            return ObterVisaoFabricantePorId((long) id);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Fabricante fabricante = fabricanteServico.EliminarFabricantePorId(id);
                TempData["Message"] = "Fabricante " + fabricante.Nome.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET
        public ActionResult Details(long? id)
        {
            return ObterVisaoFabricantePorId((long) id);
        }

    }
}