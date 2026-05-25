using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.ReglasNegocios;
using iGob.Entidades;
using IGOB.Areas.Catalogos.Models;

namespace IGOB.Controllers
{
    public class CertificacionesController : ValidaSession
    {
        private brCertificaciones obrCertificaciones = new brCertificaciones();
        // GET: Certificaciones

        public ActionResult index()
        {
            return View(obrCertificaciones.listarTodos_Certificaciones());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beCertificaciones certificaciones)
        {
            if (ModelState.IsValid)
            {
                var c = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                certificaciones.IdUsuarioRegistro = (int)c.id2;
                certificaciones.FechaRegistro = DateTime.Now;
                obrCertificaciones.guardarCertificaciones(certificaciones);
                return Json(new { success = true, m = "Certificación: <strong>"+ certificaciones.Certificacion +"</strong> agregada correctamente." },JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false, m = ModelState.Values.SelectMany(v => v.Errors) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            if (obrCertificaciones.traerCertificaciones_x_IdCertificacion(id) != null)
            {
                obrCertificaciones.eliminarCertificaciones(id);
                return Json(new { success = true, m = "Eliminado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false, m = "No se ha podido eliminar" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(beCertificaciones certificaciones)
        {

            var editCertificacion = obrCertificaciones.traerCertificaciones_x_IdCertificacion(certificaciones.IdCertificacion);
            if (editCertificacion != null)
            {
                editCertificacion.Certificacion = certificaciones.Certificacion;
                editCertificacion.NoCertificacion = certificaciones.NoCertificacion;
                obrCertificaciones.actualizarCertificaciones(editCertificacion);
                return Json(new { success = true, m = "Editado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false, m = "No se ha podido editar" }, JsonRequestBehavior.AllowGet);
        }
    }
}