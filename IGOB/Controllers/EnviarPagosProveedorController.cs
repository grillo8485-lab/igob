using IGOB.Areas.Catalogos.Models;
using IGOB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Controllers
{
    public class EnviarPagosProveedorController : ValidaSession
    {
        ClsListadoLicitacionesInvitacionAceptadasProveedor aceptadasProveedor = new ClsListadoLicitacionesInvitacionAceptadasProveedor();
        ListadoLicitacionesInvitacionAceptadasProveedor model = new ListadoLicitacionesInvitacionAceptadasProveedor();
        // GET: EnviarPagosProveedor
        public ActionResult Index(int IdInvitacion)
        {
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            var id = b.id6;
            
            model.oLicitacionesInvitacionProveedores= aceptadasProveedor.getLicitacionInvitacionProveddor(IdInvitacion);
            if ((int)b.id == 7) id = model.oLicitacionesInvitacionProveedores.IdProveedor;

                model.Titulo = aceptadasProveedor.getTitulo(id, IdInvitacion);
            model.IdPerfil = (int)b.id;
            model.extencionArvhico = Path.GetExtension(model.oLicitacionesInvitacionProveedores.UrlRecibo) ;
            model.lstEstatusPagos = new SelectList(aceptadasProveedor.getEstatusPagos(), "IdEstatusPago", "Estatus", model.oLicitacionesInvitacionProveedores.IdEstatusPago);
            model.lstMotivoRechazo = new SelectList(aceptadasProveedor.getEstatusPagos(), "IdEstatusPago", "Estatus", "");
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UploadFiles(string FolioOficial,DateTime FechaPago,int IdInvitacion)
        {
            try
            {
                if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    var pic = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];
                    
                    HttpPostedFileBase filebase = new HttpPostedFileWrapper(pic);
                    var fileName = Path.GetExtension(filebase.FileName);
                    fileName = "_Imagen_Requisicion_" + IdInvitacion.ToString()+ fileName;
                    var path = Path.Combine(Server.MapPath("~/Files/EnvioPagoProvedor/"), fileName);
                    filebase.SaveAs(path);
                    var a = aceptadasProveedor.getEnvioPagoProveedores(IdInvitacion);
                    a.FechaPago = FechaPago;
                    a.FolioPago = FolioOficial;
                    a.UrlRecibo = fileName;
                    a.IdEstatusPago = 2;
                    aceptadasProveedor.saveEnvioPagoProveedores(a);
                    return Json(new { success = true}, JsonRequestBehavior.AllowGet);
                }
                else {
                    return Json(new { success = false, Mensaje="No se envio archivo para guardar" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex) {
                return Json(new { success = false, Mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Valido(int IdInvitacion)
        {
            try
            {
                var a = aceptadasProveedor.getEnvioPagoProveedores(IdInvitacion);
                a.IdEstatusPago = 4;
                aceptadasProveedor.saveEnvioPagoProveedores(a);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, Mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult NoValido(int IdInvitacion)
        {
            try
            {
                var a = aceptadasProveedor.getEnvioPagoProveedores(IdInvitacion);
                a.IdEstatusPago = 3;
                aceptadasProveedor.saveEnvioPagoProveedores(a);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, Mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}