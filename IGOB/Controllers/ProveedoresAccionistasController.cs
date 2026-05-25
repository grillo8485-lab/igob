using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.Entidades;
using iGob.ReglasNegocios;

namespace IGOB.Controllers
{
    public class ProveedoresAccionistasController : ValidaSession
    {
        private brProveedoresAccionistas ObrProveedoresAccionistas = new brProveedoresAccionistas();
        private brDatosPersonas ObrDatosPersonas = new brDatosPersonas();
        private brProveedores brProveedores = new brProveedores();
        private brTiposRepresentacion brTiposRepresentacion = new brTiposRepresentacion();
        // GET: ProveedoresAccionistas
        public ActionResult Index(int id)
        {
            List<beProveedoresAccionistas> PAList = ObrProveedoresAccionistas.listarTodos_ProveedoresAccionistas_GetAll().Where(x => x.IdProveedor == id).ToList();

            List<beTiposRepresentacion> TRList = brTiposRepresentacion.listarTodos_TiposRepresentacion().ToList();
            ViewBag.TRList = new SelectList(TRList, "IdTipoRepresentacion", "TipoRepresentacion");
            ViewBag.IdProveedor = id;
            TempData["tipoProv"] = ViewBag.Tipo = TempData["tipoProv"];
            return View(PAList);
        }

        public JsonResult getPersonas(string term)
        {
            var resultado = ObrDatosPersonas.listarTodos_DatosPersonas().Where(x => x.Nombres.Contains(term)).Take(5).ToList();

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getProveedores(string term)
        {
            brProveedores b = new brProveedores();
            var resultado = b.listarTodos_Proveedores().Where(x => x.NombreComercial.Contains(term.ToUpper())).Select(x => new { x.IdProveedor, x.NombreComercial }).Take(5).ToList();

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Create(beProveedoresAccionistas proveedoresAccionistas)
        {

            if (ModelState.IsValid)
            {
                ObrProveedoresAccionistas.guardarProveedoresAccionistas(proveedoresAccionistas);
                ViewBag.Result = "Se ha guardado correctamente";
            }
            else
            {
                ViewBag.Result = "No se ha podido guardar";
            }

            return Json(ViewBag.Result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Edit(beProveedoresAccionistas proveedoresAccionistas)
        {

            beProveedoresAccionistas proveedorAccionista = ObrProveedoresAccionistas.traerProveedoresAccionistas_x_IdProveedorAccionista(proveedoresAccionistas.IdProveedorAccionista);

            if (proveedorAccionista != null)
            {
                ObrProveedoresAccionistas.actualizarProveedoresAccionistas(proveedoresAccionistas);
                ViewBag.Result = "Se ha guardado la actividad económica";
            }
            else
            {
                ViewBag.Result = "No se ha podido guardar la actividad económica";
            }

            return Json(ViewBag.Result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int Id)
        {
            beProveedoresAccionistas proveedorAccionista = ObrProveedoresAccionistas.traerProveedoresAccionistas_x_IdProveedorAccionista(Id);

            if (proveedorAccionista != null)
            {
                ObrProveedoresAccionistas.eliminarProveedoresAccionistas(Id);
                ViewBag.Result = "Eliminado correctamente";
            }
            else
            {
                ViewBag.Result = "No se ha podido eliminar";
            }
            return Json(ViewBag.Result, JsonRequestBehavior.AllowGet);
        }
    }

}
