using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMvc.Models;

namespace TiendaMvc.Controllers
{
    public class ProductoController : Controller
    {
        tiendaluisEntities db=new tiendaluisEntities();

        

        public ActionResult Index()
        {
            var data = db.Producto;

            return View(data);
        }

        public ActionResult Detalle(String nombre)
        {
            var nom = nombre.Replace("_", " ");

            var data = db.Producto.FirstOrDefault(o=>o.nombre==nom);
            if (data == null)
                return RedirectToAction("Index");
            return View(data);
        }

        // GET: Producto
        public ActionResult Alta()
        {
            return View(new Producto());
        }

        [HttpPost]
        public ActionResult Alta(Producto model)
        {

            if (ModelState.IsValid)
            {
                db.Producto.Add(model);
                db.SaveChanges();
                return View(new Producto());
            }

            return View(model);
        }
    }
}