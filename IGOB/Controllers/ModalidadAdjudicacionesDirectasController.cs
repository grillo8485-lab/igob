using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.Entidades;
using iGob.ReglasNegocios;

namespace IGOB.Controllers
{
    public class ModalidadAdjudicacionesDirectasController : ValidaSession
    {
        private brTiposAdjudicacion ObrTiposAdjudicacion = new brTiposAdjudicacion();
        // GET: ModalidadAdjudicacionesDirectas
        public ActionResult Index()
        {
            List<beTiposAdjudicacion> TAList = ObrTiposAdjudicacion.listarTodos_TiposAdjudicacion().ToList();

            return View(TAList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beTiposAdjudicacion beTiposAdjudicacion) {

            if (ModelState.IsValid) {
                ObrTiposAdjudicacion.guardarTiposAdjudicacion(beTiposAdjudicacion);
                ViewBag.Result = "Se ha Agregado Correctamente";
            }
            else {
                ViewBag.Result = "No se ha podido Agregar";
            }

            return Json(ViewBag.Result,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(beTiposAdjudicacion beTiposAdjudicacion) {

            beTiposAdjudicacion tipoAdjudicacion = ObrTiposAdjudicacion.traerTiposAdjudicacion_x_IdTipoAdjudicacion(beTiposAdjudicacion.IdTipoAdjudicacion);

            if (tipoAdjudicacion != null)
            {
                ObrTiposAdjudicacion.actualizarTiposAdjudicacion(beTiposAdjudicacion);
                ViewBag.Result = "Se ha actualizado correctamente";
            }
            else {
                ViewBag.Result = "No se ha podido actualizar";
            }

            return Json(ViewBag.Result,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id) {

            beTiposAdjudicacion tipoAdjudicacion = ObrTiposAdjudicacion.traerTiposAdjudicacion_x_IdTipoAdjudicacion(id);

            if (tipoAdjudicacion != null)
            {
                ObrTiposAdjudicacion.eliminarTiposAdjudicacion(id);
                ViewBag.Result = "Se ha eliminado correctamente";
            }
            else
            {
                ViewBag.Result = "No se ha podido eliminar";
            }

            return Json(ViewBag.Result, JsonRequestBehavior.AllowGet);
        }
    }
}