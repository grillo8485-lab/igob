using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.ReglasNegocios;
using iGob.Entidades;

namespace IGOB.Controllers
{
    public class ModalidadRequisicionesController : ValidaSession
    {
        private brModalidadesRequisiciones obrModalidadesRequisiciones;
        // GET: Certificaciones

        public ModalidadRequisicionesController()
        {
            obrModalidadesRequisiciones = new brModalidadesRequisiciones();
        }
        // GET: ActividadesEconomicas
        public ActionResult index()
        {
            List<beModalidadesRequisiciones> Lista = obrModalidadesRequisiciones.listarTodos_ModalidadesRequisiciones();

            return View(Lista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beModalidadesRequisiciones modalidadesRequisiciones)
        {

            if (ModelState.IsValid)
            {
                var resp = obrModalidadesRequisiciones.guardarModalidadesRequisiciones(modalidadesRequisiciones);
                ViewBag.Result = "Agregado correctamente ";
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                ViewBag.Result = "No se ha podido agregar";
            }
            return Json(ViewBag.Result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            beModalidadesRequisiciones modalidadRequisicion = obrModalidadesRequisiciones.traerModalidadesRequisiciones_x_IdModalidadRequisicion(id);

            if (modalidadRequisicion != null)
            {
                obrModalidadesRequisiciones.eliminarModalidadesRequisiciones(id);
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
        public JsonResult Edit(beModalidadesRequisiciones modalidadesRequisiciones)
        {

            beModalidadesRequisiciones modalidadRequisicion = obrModalidadesRequisiciones.traerModalidadesRequisiciones_x_IdModalidadRequisicion(modalidadesRequisiciones.IdModalidadRequisicion);

            if (modalidadRequisicion != null)
            {
                obrModalidadesRequisiciones.actualizarModalidadesRequisiciones(modalidadesRequisiciones);
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