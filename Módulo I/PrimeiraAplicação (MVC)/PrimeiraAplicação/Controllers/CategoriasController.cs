using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrimeiraAplicação.Models;
using PrimeiraAplicação.Context;
using System.Net;
using System.Data.Entity;

namespace PrimeiraAplicação.Controllers
{
    public class CategoriasController : Controller
    {
        EFContext context = new EFContext();

        // GET
        public ActionResult Index()
        {
            return View(context.Categorias.OrderBy(c => c.Nome));
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                context.Categorias.Add(categoria);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoria);

        }

        // GET
        public ActionResult Edit(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Categoria categoria = context.Categorias.Find(id);

            if (categoria == null)
                return HttpNotFound();

            return View(categoria);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            context.Entry(categoria).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET
        public ActionResult Delete(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Categoria categoria = context.Categorias.Find(id);

            if (categoria == null)
                return HttpNotFound();

            return View(categoria);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Categoria categoria = context.Categorias.Find(id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET
        public ActionResult Details(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Categoria categoria = context.Categorias.Find(id);

            if (categoria == null)
                return HttpNotFound();

            return View(categoria);
        }
    }
}