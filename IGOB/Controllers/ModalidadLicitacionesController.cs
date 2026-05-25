using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.ReglasNegocios;
using iGob.Entidades;

namespace IGOB.Controllers
{
    public class ModalidadLicitacionesController : ValidaSession
    {
        private brModalidadesLicitaciones obrModalidadesLicitaciones;
        //GET: Certificaciones

        public ModalidadLicitacionesController()
        {
            obrModalidadesLicitaciones = new brModalidadesLicitaciones();
        }
        // GET: ActividadesEconomicas
        public ActionResult index()
        {
            List<beModalidadesLicitaciones> Lista = obrModalidadesLicitaciones.listarTodos_ModalidadesLicitaciones();

            return View(Lista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beModalidadesLicitaciones modalidadesLicitaciones)
        {

            if (ModelState.IsValid)
            {
                var resp = obrModalidadesLicitaciones.guardarModalidadesLicitaciones(modalidadesLicitaciones);
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
            beModalidadesLicitaciones modalidadLicitacion = obrModalidadesLicitaciones.traerModalidadesLicitaciones_x_IdModalidadLicitacion(id);

            if (modalidadLicitacion != null)
            {
                obrModalidadesLicitaciones.eliminarModalidadesLicitaciones(id);
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
        public JsonResult Edit(beModalidadesLicitaciones modalidadesLicitaciones)
        {

            beModalidadesLicitaciones modalidadLicitacion = obrModalidadesLicitaciones.traerModalidadesLicitaciones_x_IdModalidadLicitacion(modalidadesLicitaciones.IdModalidadLicitacion);

            if (modalidadLicitacion != null)
            {
                obrModalidadesLicitaciones.actualizarModalidadesLicitaciones(modalidadesLicitaciones);
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