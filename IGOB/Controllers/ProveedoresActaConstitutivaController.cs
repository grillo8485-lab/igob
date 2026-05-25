using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.Entidades;
using iGob.ReglasNegocios;

namespace IGOB.Controllers
{
    public class ProveedoresActaConstitutivaController : ValidaSession
    {
        private brProveedoresActaConstitutiva brProveedoresActaConstitutiva = new brProveedoresActaConstitutiva();
        private brProveedores brProveedores = new brProveedores();
        // GET: ProveedoresActaConstitutiva
        public ActionResult Index(int id)
        {
            List<beProveedoresActaConstitutiva> PACList = brProveedoresActaConstitutiva.listarTodos_ProveedoresActaConstitutivaGetAll().Where(x => x.IdProveedor == id).ToList();
            ViewBag.IdProveedor = id;
            TempData["tipoProv"] = ViewBag.Tipo = TempData["tipoProv"];
            return View(PACList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult GetActaConstitutiva(int id)
        {
            var r = brProveedoresActaConstitutiva.traerProveedoresActaConstitutiva_x_IdActaConstitutiva(id);

            //var s = brProveedores.traerProveedores_x_IdProveedor(r.IdProveedor).p;

            return Json(new { succes= true, message= r}, JsonRequestBehavior.AllowGet );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beProveedoresActaConstitutiva proveedoresActaConstitutiva) {
            if (ModelState.IsValid)
            {
                var resp = brProveedoresActaConstitutiva.guardarProveedoresActaConstitutiva(proveedoresActaConstitutiva);
                ViewBag.Result = " Agregado correctamente ";
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                ViewBag.Result = " No se ha podido agregar";
            }

            return Json(ViewBag.Result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            beProveedoresActaConstitutiva proveedorActaConstitutiva = brProveedoresActaConstitutiva.traerProveedoresActaConstitutiva_x_IdActaConstitutiva(id);

            if (proveedorActaConstitutiva != null)
            {
                brProveedoresActaConstitutiva.eliminarProveedoresActaConstitutiva(id);
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
        public JsonResult Edit(beProveedoresActaConstitutiva proveedoresActaConstitutiva)
        {

            beProveedoresActaConstitutiva proveedorActaConstitutiva = brProveedoresActaConstitutiva.traerProveedoresActaConstitutiva_x_IdActaConstitutiva(proveedoresActaConstitutiva.IdActaConstitutiva);

            if (proveedorActaConstitutiva != null)
            {
                brProveedoresActaConstitutiva.actualizarProveedoresActaConstitutiva(proveedoresActaConstitutiva);
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