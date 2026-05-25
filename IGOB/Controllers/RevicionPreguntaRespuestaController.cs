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
    public class RevicionPreguntaRespuestaController : ValidaSession
    {
        ClsRespuestaPreguntaSolicitante respuestaPreguntaSolicitante = new ClsRespuestaPreguntaSolicitante();
        RespuestaPreguntaSolicitante model = new RespuestaPreguntaSolicitante();
        // GET: RevicionPreguntaRespuesta
        public ActionResult Index(int pIdRequisicion, int pIdlicitacion,int pidTipoProveso)
        {
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            var TituloLicitacion = (string)TempData["TituloPorProceso"];
            model.lstPreguntaRespuestaSolicitanteDependencia = respuestaPreguntaSolicitante.getAllPreguntaRespuesta_x_IdRequisicion(pIdRequisicion);
            model.Titulo = respuestaPreguntaSolicitante.getTitulo(pIdlicitacion, b.id4, pIdRequisicion, TituloLicitacion);
            model.IdRequisicion = pIdRequisicion;
            model.IdLicitacion = pIdlicitacion;
            model.IdTipoProveso = pidTipoProveso;
            model.IdEstatusRespues = respuestaPreguntaSolicitante.getEstatusRespuestaAutorizar(pIdRequisicion);
            TempData["TituloPorProceso"] = TituloLicitacion;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveAutoriazaRechaza(int pIdRespuesta, int pAutorizaRechaza, string pObservaciones)
        {
            try
            {
                var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                var respuesta = respuestaPreguntaSolicitante.getRespuesta(pIdRespuesta);

                if (pAutorizaRechaza == 1)
                {
                    respuesta.IdEstatusRespuesta = 4;
                    respuesta.Observaciones = pObservaciones;
                    respuesta.IdUsuarioRegistro = (int)b.id2;
                    respuesta.FechaRegistro = DateTime.Now;
                    respuesta.Observaciones = "";
                    respuestaPreguntaSolicitante.saveRespuesta(respuesta);
                }
                else
                {
                    var respuestaRechazo = new beRespuestasRechazadas();

                    respuestaRechazo.IdRespuestaRechazada = 0;
                    respuestaRechazo.IdRespuesta = respuesta.IdRespuesta;
                    respuestaRechazo.IdPregunta = respuesta.IdPregunta;
                    respuestaRechazo.IdEstatusRespuesta = respuesta.IdEstatusRespuesta;
                    respuestaRechazo.Respuesta = respuesta.Respuesta;
                    respuestaRechazo.Observaciones = respuesta.Observaciones;
                    respuestaRechazo.IdUsuarioRegistro = respuesta.IdUsuarioRegistro;
                    respuestaRechazo.FechaRegistro = respuesta.FechaRegistro;
                    respuestaPreguntaSolicitante.saveRechazo(respuestaRechazo);

                    respuesta.IdEstatusRespuesta = 3;
                    respuesta.Observaciones = pObservaciones;
                    respuesta.IdUsuarioRegistro = (int)b.id2;
                    respuestaPreguntaSolicitante.saveRespuesta(respuesta);
                }
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

                var b = respuestaPreguntaSolicitante.getAllPreguntaRespuesta_x_IdRequisicion(pIdRequisicion).Where(s => s.IdEstatusRespuesta == 2).ToList();
                if (b.Count() > 0)
                {
                    return Json(new { success = false, mensaje = "Faltan preguntas por autorizar/rechazar, favor de autorizar/rechazar las respuestas faltantes." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var idEstatus = 0;
                    b = respuestaPreguntaSolicitante.getAllPreguntaRespuesta_x_IdRequisicion(pIdRequisicion);
                    if(b.Where(s=> s.IdEstatusRespuesta == 3).Count() > 0)
                    {
                        idEstatus = 2;
                    }
                    if (b.Where(s => s.IdEstatusRespuesta == 4).Count() > 0)
                    {
                        idEstatus = 3;
                    }

                    foreach (var item in b)
                    {
                        var c = respuestaPreguntaSolicitante.getRespuesta(item.IdRespuesta);
                        c.IdEstatusRespuestaGeneral = idEstatus;
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
        public JsonResult getPreguntaResPuesta(int pIdPregunta, int pIdRequisicion)
        {
            try
            {

                var b = respuestaPreguntaSolicitante.getAllPreguntaRespuesta_x_IdRequisicion(pIdRequisicion).Where(s => s.IdPregunta == pIdPregunta).First();
                return Json(new { success = true, objeto = b }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}