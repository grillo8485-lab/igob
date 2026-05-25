using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.Entidades;
using iGob.ReglasNegocios;

namespace IGOB.Controllers
{
    public class UnidadesLicitadorasController : ValidaSession
    {
        private brUnidadesLicitadoras ObrUnidadesLicitadoras = new brUnidadesLicitadoras();
        private brDependencias ObrDependencias = new brDependencias();
        // GET: UnidadesLicitadoras
        public ActionResult Index()
        {
            ViewBag.dependenciasList = new SelectList(ObrDependencias.listarTodos_Dependencias().ToList(), "IdDependencia", "Dependencia");

           return View(ObrUnidadesLicitadoras.listarTodos_UnidadesLicitadoras_GetAll().ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beUnidadesLicitadoras unidadesLicitadoras)
        {

            if (ModelState.IsValid)
            {
                unidadesLicitadoras.Activo = true;
                var resp = ObrUnidadesLicitadoras.guardarUnidadesLicitadoras(unidadesLicitadoras);
                return Json(new { success = true, m = "Unidad licitadora: <strong>"+ unidadesLicitadoras.UnidadLicitadora + "</strong> agregada correctamente."  }, JsonRequestBehavior.AllowGet);
            }
            else         
                return Json(new { success = false, m = ModelState.Values.SelectMany(v => v.Errors) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(beUnidadesLicitadoras unidadesLicitadoras)
        {
            if (ObrUnidadesLicitadoras.traerUnidadesLicitadoras_x_IdUnidadLicitadora(unidadesLicitadoras.IdUnidadLicitadora) != null)
            {
                ObrUnidadesLicitadoras.actualizarUnidadesLicitadoras(unidadesLicitadoras);
                return Json(new { success = true, m = "Unidad licitadora editada correctamente" }, JsonRequestBehavior.AllowGet);
            }         
            else
                return Json(new { success = false, m = ModelState.Values.SelectMany(v => v.Errors) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int Id)
        {

            beUnidadesLicitadoras unidadLicitadora = ObrUnidadesLicitadoras.traerUnidadesLicitadoras_x_IdUnidadLicitadora(Id);
            if (unidadLicitadora != null)
            {
                ObrUnidadesLicitadoras.eliminarUnidadesLicitadoras(Id);
                return Json(new { success= true, m = "Eliminado correctamente"}, JsonRequestBehavior.AllowGet);
            }
            else            
                return Json(new { success = false , m = "No se ha podido eliminar" } , JsonRequestBehavior.AllowGet);
        }
    }
}