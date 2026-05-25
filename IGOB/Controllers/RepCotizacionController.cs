using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;
using IGOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Controllers
{
    public class RepCotizacionController : ValidaSession
    {
        // GET: RepCotizacion
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListaProductos(string descripcion)
        {
            brRptAppEjecutivosLicitaciones obrRep = new brRptAppEjecutivosLicitaciones();
            List<beRptAppEjecutivosLicitaciones> resultado = obrRep.ListaProductos(descripcion);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult PrecioProducto(int pIdBienServicio)
        {
            //obtenemos los datos necesarios

            brRptAppEjecutivosLicitaciones obrRep = new brRptAppEjecutivosLicitaciones();
            beRptAppEjecutivosLicitaciones obeRep = obrRep.PrecioProducto(pIdBienServicio);

            ViewBag.obeRep = obeRep;

            return PartialView("~/Views/RepCotizacion/PrecioProducto.cshtml");
        }
    }
}