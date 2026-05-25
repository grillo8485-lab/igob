using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.Entidades;
using iGob.ReglasNegocios;

namespace IGOB.Controllers
{
    public class DiasInhabilesController : ValidaSession
    {
        private brDiasInhabiles ObrDiasInhabiles = new brDiasInhabiles();
        // GET: DiasInhabiles
        public ActionResult Index()
        {
            var DiasIList = ObrDiasInhabiles.listarTodos_DiasInhabiles();

            return View(DiasIList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beDiasInhabiles diasInhabiles)
        {
            if (ModelState.IsValid)
            {
                var resp = ObrDiasInhabiles.guardarDiasInhabiles(diasInhabiles);
                ViewBag.Result = diasInhabiles.Evento + " Agregado correctamente ";
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                ViewBag.Result = diasInhabiles.Evento + " No se ha podido agregar";
            }

            return Json(ViewBag.Result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            beDiasInhabiles diaInhabil = ObrDiasInhabiles.traerDiasInhabiles_x_IdDiaInhabil(id);

            if (diaInhabil != null)
            {
                ObrDiasInhabiles.eliminarDiasInhabiles(id);
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
        public JsonResult Edit(beDiasInhabiles diasInhabiles)
        {

            beDiasInhabiles diaInhabil = ObrDiasInhabiles.traerDiasInhabiles_x_IdDiaInhabil(diasInhabiles.IdDiaInhabil);
            if (diaInhabil != null)
            {
                ObrDiasInhabiles.actualizarDiasInhabiles(diasInhabiles);
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