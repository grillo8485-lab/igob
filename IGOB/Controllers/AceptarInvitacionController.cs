using IGOB.Areas.Catalogos.Models;
using IGOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Controllers
{
    public class AceptarInvitacionController : ValidaSession
    {
        // GET: AceptarInvitacion
        public ActionResult Index(int IdLicitacion)
        {
            var f = (ClsGenerica)Session["ClsGenerico"];
            AceptarInvitacion modelo = new AceptarInvitacion();
            ClsAceptarInvitacion aceptacion = new ClsAceptarInvitacion();
            modelo.oAceptarInvitacion = aceptacion.getAceptarInvitacion_x_IdLicitacion_IdProveedor(IdLicitacion,f.id6);
            var licitacion = aceptacion.getLicitacion(IdLicitacion);
            modelo.lstNumeroUnidadLicitatotia = new SelectList(aceptacion.getAllUnidadesLicitadoras(f.id4), "IdUnidadLicitadora", "UnidadLicitadora", licitacion.IdUnidadLicitadora);
            
            return View(modelo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveAceptacionInvitacion(int pIdInvitacion,bool pAceptacion)
        {
            try
            {
                ClsAceptarInvitacion aceptacion = new ClsAceptarInvitacion();
                var b = aceptacion.getLicitacionesInvitacionProveedores(pIdInvitacion);
                b.Aceptacion = pAceptacion;
                b.FechaAceptacion = DateTime.Now;
                b.FolioPago = "";
                b.FechaPago = DateTime.Now;
                b.UrlRecibo = "";
                b.Observaciones = "";
                b.FechaValidaPago = DateTime.Now;
                b.IdRazonRechazo =0;
                aceptacion.saveLicitacionesInvitacionProveedores(b);

                return Json(new { success = true}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ImprimirBases(int pIdLic)
        {
            try
            {
                ClsLicitacionesImprimirBases ReqSol = new ClsLicitacionesImprimirBases(Server.MapPath("~/Files/Reportes/"), Server.MapPath("~/Files/Plantillas/"));

                //obtenemos el gobierno
                var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                int IdGobierno = usuario.id5;

                string Archivo = ReqSol.ImprimeArchivo(pIdLic, IdGobierno);

                return Json(new { success = true, Descarga = Archivo }, JsonRequestBehavior.AllowGet); ;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ImprimirConvocatoria(int pIdLic)
        {
            try
            {
                ClsLicitacionesImprimirConvocatoria ReqSol = new ClsLicitacionesImprimirConvocatoria(Server.MapPath("~/Files/Reportes/"), Server.MapPath("~/Files/Plantillas/"));

                //obtenemos el gobierno
                var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                int IdGobierno = usuario.id5;

                string Archivo = ReqSol.ImprimeArchivo(pIdLic, IdGobierno);

                return Json(new { success = true, Descarga = Archivo }, JsonRequestBehavior.AllowGet); ;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}