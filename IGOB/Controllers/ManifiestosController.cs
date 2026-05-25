using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.Entidades;
using iGob.ReglasNegocios;

namespace IGOB.Controllers
{
    public class ManifiestosController : ValidaSession
    {
        private brManifiestos ObrManifiestos = new brManifiestos();
        private brGobierno ObrGobierno = new brGobierno();
        // GET: Manifiestos
        public ActionResult Index()
        {
            List<beManifiestos> manifiestosList = ObrManifiestos.listarTodos_Manifiestos_GetAll().ToList();

            List<beGobierno> gobList = ObrGobierno.listarTodos_Gobierno().ToList();
            ViewBag.gobList = new SelectList(gobList, "IdGobierno","Gobierno");

            return View(manifiestosList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beManifiestos manifiestos)
        {
            if (ModelState.IsValid)
            {
                ObrManifiestos.guardarManifiestos(manifiestos);
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
        public JsonResult Edit(beManifiestos manifiestos) {

            beManifiestos manifiesto = ObrManifiestos.traerManifiestos_x_IdManifiesto(manifiestos.IdManifiesto);

            if (manifiesto != null) {
                ObrManifiestos.actualizarManifiestos(manifiestos);
                ViewBag.Result = "Editado correctamente ";

            }else{
                ViewBag.Result = "No se ha podido editar";
            }

            return Json(ViewBag.Result, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int Id) {
            beManifiestos manifiesto = ObrManifiestos.traerManifiestos_x_IdManifiesto(Id);

            if (manifiesto != null)
            {
                ObrManifiestos.eliminarManifiestos(Id);
                ViewBag.Result = "Eliminado correctamente";
            }
            else {
                ViewBag.Result = "No se ha podido eliminar";
            }

            return Json(ViewBag.Result, JsonRequestBehavior.AllowGet);
        }
    }
}