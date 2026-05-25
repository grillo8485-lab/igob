using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.Entidades;
using iGob.ReglasNegocios;

namespace iGob.Controllers
{
    public class CondicionesPagoController : ValidaSession
    {
        private brTiposCondiciones ObrTiposCondiciones = new brTiposCondiciones();
        private brCondicionesPagosEntrega ObrCondicionesPagosEntrega = new brCondicionesPagosEntrega();
        // GET: Catalogos/CondicionesEntrega
        public ActionResult Index()
        {
            return View(ObrCondicionesPagosEntrega.listarTodos_CondicionesPagosEntrega().Where(x => x.IdTipoCondicion == 1).ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beCondicionesPagosEntrega condEntPag)
        {
            condEntPag.Activo = true;
            condEntPag.IdTipoCondicion = 1;

            if (ModelState.IsValid)
            {
                ObrCondicionesPagosEntrega.guardarCondicionesPagosEntrega(condEntPag);
                return Json(new { success = true, m = "Condición de entrega <strong>" + condEntPag.Condicion + "</strong> agregada correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = true, m = ModelState.Values.SelectMany(v => v.Errors) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            if (ObrCondicionesPagosEntrega.traerCondicionesPagosEntrega_x_IdCondicion(id) != null)
            {
                ObrCondicionesPagosEntrega.eliminarCondicionesPagosEntrega(id);
                return Json(new { success = true, m = "Condición de entrega eliminada correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = true, m = "No se ha podido eliminar" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(beCondicionesPagosEntrega condEntPag)
        {
            if (ObrCondicionesPagosEntrega.traerCondicionesPagosEntrega_x_IdCondicion(condEntPag.IdCondicion) != null)
            {
                ObrCondicionesPagosEntrega.actualizarCondicionesPagosEntrega(condEntPag);
                return Json(new { success = true, m = "Condición de entrega editada correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = true, m = "No se ha podido editar" }, JsonRequestBehavior.AllowGet);
        }
    }
}