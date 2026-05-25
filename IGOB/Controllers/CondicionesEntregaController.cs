using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.Entidades;
using iGob.ReglasNegocios;

namespace iGob.Controllers
{
    public class CondicionesEntregaController : ValidaSession
    {
        private brTiposCondiciones ObrTiposCondiciones = new brTiposCondiciones();
        private brCondicionesPagosEntrega ObrCondicionesPagosEntrega = new brCondicionesPagosEntrega();
        // GET: Catalogos/CondicionesEntrega
        public ActionResult Index()
        {
            //List<beTiposCondiciones> listTipoCond = ObrTiposCondiciones.listarTodos_TiposCondiciones();
            //ViewBag.ListaTipoConsiciones = new SelectList(listTipoCond, "IdDependencia", "Dependencia"); ;

            List<beCondicionesPagosEntrega> listCondicionesEntregaPago = ObrCondicionesPagosEntrega.listarTodos_CondicionesPagosEntrega().Where(x => x.IdTipoCondicion == 2).ToList();
            return View(listCondicionesEntregaPago);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beCondicionesPagosEntrega condEntPag)
        {
            var Result = "";
            if (ModelState.IsValid)
            {
                var result = ObrCondicionesPagosEntrega.guardarCondicionesPagosEntrega(condEntPag);
                Result = condEntPag.Condicion + " Agregado correctamente ";
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                Result = condEntPag.Condicion + "No se Pudo Agregar";
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var Result = "";
            var result = ObrCondicionesPagosEntrega.eliminarCondicionesPagosEntrega(id);
            Result = "Se elimino correctamente ";
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(beCondicionesPagosEntrega condEntPag)
        {
            var Result = "";
            if (ModelState.IsValid)
            {
                var result = ObrCondicionesPagosEntrega.actualizarCondicionesPagosEntrega(condEntPag);
                Result = condEntPag.Condicion + " Agregado correctamente ";
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                Result = condEntPag.Condicion + "No se Pudo Agregar";
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
    }
}