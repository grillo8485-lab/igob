using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;

namespace IGOB.Controllers
{
    public class PresupuestosController : ValidaSession
    {
        private brPresupuestosPartidas ObrPresupuestosPartidas = new brPresupuestosPartidas();
        private brPartidas ObrPartidas = new brPartidas();
        private brCapitulos ObrCapitulos = new brCapitulos();
        private brEjerciciosFiscales ObrEjerciciosFiscales = new brEjerciciosFiscales();
        //private brPresupuestos ObrPresupuestos = new brPresupuestos();

        // GET: Presupuestos
        public ActionResult Index()
        {
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            ViewBag.IdDep = b.id4;

            var todos = ObrPresupuestosPartidas.PresupuestosPartidas_Traer_Dependencia(b.id4);
            return View(todos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(bePresupuestosPartidas presupuestos)
        {
            if (ModelState.IsValid)
            {

                var resp = ObrPresupuestosPartidas.guardarPresupuestosPartidas(presupuestos);
                ViewBag.Result = "Presupuesto Agregado correctamente ";
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                ViewBag.Result = " No se ha podido agregar el presupuesto";
            }

            return Json(ViewBag.Result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            bePresupuestosPartidas presupuestos = ObrPresupuestosPartidas.traerPresupuestosPartidas_x_IdPresupuestoPartida(id);

            if (presupuestos != null)
            {
                ObrPresupuestosPartidas.eliminarPresupuestosPartidas(id);
                ViewBag.Result = "Eliminado correctamente";
            }
            else
            {
                ViewBag.Result = "No se ha podido eliminar";
            }
            return Json(ViewBag.Result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(bePresupuestosPartidas presupuestos)
        {

            bePresupuestosPartidas presupuesto = ObrPresupuestosPartidas.traerPresupuestosPartidas_x_IdPresupuestoPartida(presupuestos.IdPresupuestoPartida);
            if (presupuesto != null)
            {
                ObrPresupuestosPartidas.actualizarPresupuestosPartidas(presupuestos);
                ViewBag.Result = "Editado correctamente";
            }
            else
            {
                ViewBag.Result = "No se ha podido editar";
            }

            return Json(ViewBag.Result, JsonRequestBehavior.AllowGet);
        }
    }
}