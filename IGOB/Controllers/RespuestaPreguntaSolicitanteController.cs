using iGob.Entidades;
using IGOB.Areas.Catalogos.Models;
using IGOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Controllers
{
    public class RespuestaPreguntaSolicitanteController : ValidaSession
    {
        ClsRespuestaPreguntaSolicitante respuestaPreguntaSolicitante = new ClsRespuestaPreguntaSolicitante();
        RespuestaPreguntaSolicitante model = new RespuestaPreguntaSolicitante();
        // GET: RespuestaPreguntaSolicitante
        public ActionResult Index(int pIdRequisicion, int pIdlicitacion)
        {
            var IdInvitacion =  TempData["IdInvitacion"];
            var TituloLicitacion = (string)TempData["TituloPorProceso"];
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            model.lstPreguntaRespuestaSolicitanteDependencia = respuestaPreguntaSolicitante.getAllPreguntaRespuesta_x_IdRequisicion(pIdRequisicion);
            model.Titulo = respuestaPreguntaSolicitante.getTitulo(pIdlicitacion,b.id4,pIdRequisicion, TituloLicitacion);
            model.IdRequisicion = pIdRequisicion;
            model.IdLicitacion = pIdlicitacion;
            model.IdEstatusRespues = respuestaPreguntaSolicitante.getEstatusRespuesta(pIdRequisicion);
            TempData["IdInvitacion"] = IdInvitacion;
            TempData["TituloPorProceso"] = TituloLicitacion;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult getPreguntaResPuesta(int pIdPregunta, int pIdRequisicion)
        {
            try
            {
                
                var b = respuestaPreguntaSolicitante.getAllPreguntaRespuesta_x_IdRequisicion(pIdRequisicion).Where(s=> s.IdPregunta== pIdPregunta).First() ;
                return Json(new { success = true, objeto = b }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult setEnviarRespuestas(int pIdRequisicion)
        {
            try
            {

                var b = respuestaPreguntaSolicitante.getAllPreguntaRespuesta_x_IdRequisicion(pIdRequisicion).Where(s => s.Respuesta == "").ToList();
                if (b.Count() > 0)
                {
                    return Json(new { success = false, mensaje = "Faltan preguntas por contestar, favor de completar todas las respuestas para poder enviar." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    b = respuestaPreguntaSolicitante.getAllPreguntaRespuesta_x_IdRequisicion(pIdRequisicion);
                    foreach (var item in b)
                    {
                        var c = respuestaPreguntaSolicitante.getRespuesta(item.IdRespuesta);
                        c.IdEstatusRespuesta = 2;
                        c.IdEstatusRespuestaGeneral = 2;
                        respuestaPreguntaSolicitante.saveRespuesta(c);
                    }
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult savePreguntaResPuesta(int pIdRespuesta, string pRespuesta)
        {
            try
            {
                var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                var respuesta = respuestaPreguntaSolicitante.getRespuesta(pIdRespuesta);
                respuesta.Respuesta = pRespuesta;
                respuesta.IdEstatusRespuesta = 1;
                respuesta.IdEstatusRespuestaGeneral = 1;
                respuesta.FechaRegistro = DateTime.Now;
                respuesta.IdUsuarioRegistro = (int)b.id2;
                respuesta.Observaciones = "";
                respuestaPreguntaSolicitante.saveRespuesta(respuesta);
                return Json(new { success = true, objeto = b }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        
    }
}