using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;
using IGOB.Models;

namespace IGOB.Controllers
{
    public class RequisicionFirmanteController : ValidaSession
    {
        private brRequisicionesFirmantes ObrReqFirmantes = new brRequisicionesFirmantes();
        private brRequisiciones ObrRequisiciones = new brRequisiciones();

        // GET: RequisicionFirmante
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beRequisicionesFirmantes ReqFirmantes)
        {
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            
            if (TempData["keyAcceso"] == null)
            {
                return Json(new { success = false, mensaje = "<span class='fa fa-exclamation-triangle fa-1x'></span><strong>Debe intorducir token antes de poder guardar.</strong>" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (TempData["keyAcceso"].ToString().Trim() != b.string6.Trim())
                {
                    return Json(new { success = false, mensaje = "<span class='fa fa-exclamation-triangle fa-1x'></span><strong>Debe intorducir token antes de poder guardar.</strong>" }, JsonRequestBehavior.AllowGet);
                }
            }
            var Result = "";
            if (ModelState.IsValid)
            {
                var regFirm = ObrReqFirmantes.listarTodos_RequisicionesFirmantes().Where(s=> s.IdRequisicion == ReqFirmantes.IdRequisicion).FirstOrDefault();
                if (regFirm == null)
                {
                    var result = ObrReqFirmantes.guardarRequisicionesFirmantes(new ClsRequisicionFirmante().validarCamposStatus(ReqFirmantes));
                    Result = "Agregado correctamente";
                }
                else
                {
                    var validacion = new ClsRequisicionFirmante().validarCamposStatus(ReqFirmantes);

                    regFirm.ObservacionLotes = validacion.ObservacionLotes ;
                    regFirm.ObservacionCondicionPago = validacion.ObservacionCondicionPago;
                    regFirm.OnservacionCondicionEntrega = validacion.OnservacionCondicionEntrega;

                    var result = ObrReqFirmantes.actualizarRequisicionesFirmantes(regFirm);
                    Result = "Agregado correctamente";
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                Result = "No se Pudo Agregar";
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
    }
}