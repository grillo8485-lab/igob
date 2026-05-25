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
    public class RepDependenciasEntidadesController : ValidaSession
    {
        // GET: RepDependenciasEntidades
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListaDependencias(string descripcion)
        {
            brRptAppEjecutivosLicitaciones obrRep = new brRptAppEjecutivosLicitaciones();
            List<beRptAppEjecutivosLicitaciones> resultado = obrRep.ListaDependencias(descripcion);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult ReportePresupuesto(int IdDependencia)
        {
            //obtenemos los datos necesarios

            brRptAppEjecutivosLicitaciones obrRep = new brRptAppEjecutivosLicitaciones();
            beRptAppEjecutivosLicitaciones obeRep = obrRep.RepPresupuestoDep(IdDependencia);
            
            ViewBag.obeRep = obeRep;

            return PartialView("~/Views/RepDependenciasEntidades/RepPresupuesto.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult ReporteAdquisiciones(int IdDependencia)
        {
            //obtenemos los datos necesarios

            brRptAppEjecutivosLicitaciones obrRep = new brRptAppEjecutivosLicitaciones();
            beRptAppEjecutivosLicitaciones obeRep = obrRep.RepAdquisicionesDep(IdDependencia);

            ViewBag.obeRep = obeRep;

            return PartialView("~/Views/RepDependenciasEntidades/RepAdquisiciones.cshtml");
        }
    }
}