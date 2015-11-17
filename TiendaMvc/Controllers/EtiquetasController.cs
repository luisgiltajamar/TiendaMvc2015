using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMvc.Filtros;
using TiendaMvc.Models;

namespace TiendaMvc.Controllers
{
    public class EtiquetasController : BaseController
    {
        
        tiendaluisEntities db=new tiendaluisEntities();
        // GET: Etiquetas
       // [FiltroTiempo]
        public ActionResult Index()
        {
            var data = db.Etiqueta;
            ViewBag.Almacenes = db.Almacen;
            return View(data);
        }
    }
}