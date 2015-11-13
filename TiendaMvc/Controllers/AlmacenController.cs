using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMvc.Models;

namespace TiendaMvc.Controllers
{
    public class AlmacenController : Controller
    {
        private tiendaluisEntities db=
            new tiendaluisEntities();

        // GET: Almacen
        public ActionResult Index()
        {
            var data = db.Almacen;
            return View(data);
        }

        public ActionResult Modificar(int id)
        {
            var data = db.Almacen.Find(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar(Almacen model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State=EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);

        }

        public ActionResult Borrar(int id)
        {
            var data = db.Almacen.Find(id);

            if (data.ProductoAlmacen.Any())
                db.ProductoAlmacen.RemoveRange(data.ProductoAlmacen);

            db.Almacen.Remove(data);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}