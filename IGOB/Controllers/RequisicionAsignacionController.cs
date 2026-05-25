using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;
using IGOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Controllers
{
    public class RequisicionAsignacionController : ValidaSession
    {
        // GET: RequisicionAsignacion
        public ActionResult Index(int id, int IdRequisicion = 0)
        {
            Requisicion requisicion = new Requisicion();
            ClsRequisiciones requisiciones = new ClsRequisiciones();
            bePartidas partida = new bePartidas();
            List<bePartidas> partidas = new List<bePartidas>();
            ViewBag.ejercicioActual = requisiciones.getEjercicioFiscal();
            ViewBag.idEstatusreq = 0;
            if (IdRequisicion != 0)
            {
                var f = (ClsGenerica)Session["ClsGenerico"];
                requisicion.oRequisicones = requisiciones.getRequisicion(IdRequisicion);
                partida = requisiciones.getPartidad(requisicion.oRequisicones.IdPartida);
                partidas = requisiciones.getAllPartidas_x_IdCapitulo(partida.IdCapitulo);
                var dependencia = requisiciones.getDependencia_x_IdDependencia(requisicion.oRequisicones.IdDependencia);
                ViewBag.ejercicioActual = requisiciones.getEjercicioFiscal_x_IdEjercicioFiscal(requisicion.oRequisicones.IdEjercicioFiscal);
                requisicion.Titulo = "Solicitud: " + (requisicion.oRequisicones.NumeroLicitacion == 1 ? "Primera licitación" : (requisicion.oRequisicones.NumeroLicitacion == 2 ? "Segunda licitación" : "")) + " - " + requisicion.oRequisicones.RequisicionFolio + " - Procesando - " + dependencia;
                ViewBag.idUrsAut =(int)f.id2;
                ViewBag.idRequisicion = requisicion.oRequisicones.IdRequisicion;
                ViewBag.idEstatusreq = requisicion.oRequisicones.IdEstatusRequisicion;
            }
            ViewBag.lstRequisicionesAbiertas = new SelectList(requisiciones.tiposRequisicionAbierta(), "IdTipoRequisicion", "TipoRequisicion", (IdRequisicion == 0 ? "0" : requisicion.oRequisicones.IdTipoRequisicion.ToString()));
            ViewBag.lstAbastecimiento = new SelectList(requisiciones.getAllAbastecimiento(), "IdFormaAbastecimiento", "FormaAbastecimiento", (IdRequisicion == 0 ? "0" : requisicion.oRequisicones.IdFormaAbastecimiento.ToString()));
            ViewBag.lstSolicitud = new SelectList(requisiciones.getAllTiposSolicitud(), "IdTipoSolicitud", "TipoSolicitud", (IdRequisicion == 0 ? "0" : requisicion.oRequisicones.IdTipoSolicitud.ToString()));
            ViewBag.lstCapitulos = new SelectList(requisiciones.getAllCapitulos(), "IdCapitulo", "Capitulo", (IdRequisicion == 0 ? "0" : partida.IdCapitulo.ToString()));
            ViewBag.lstPartidas = new SelectList(partidas, "IdPartida", "Descripcion", (IdRequisicion == 0 ? "0" : partida.IdPartida.ToString()));
            ViewBag.lstTiempos = new SelectList(requisiciones.getAllTiempos(), "IdTiempo", "Tiempo", (IdRequisicion == 0 ? "0" : requisicion.oRequisicones.IdTiempo.ToString()));
            ViewBag.tipoRequisicion = id;
            ViewBag.idRequisicion = IdRequisicion;
            ViewBag.formulario = "DatosGenerales";
            
            //funciones Asignacion de Revisor
            ViewBag.ComboRevisor = new SelectList(new ClsUsuario().Usuarios_Traer_IdPerfil(7), "IdUsuario", "Usuario", (requisicion.oRequisicones.IdUsuarioRevisor != 0) ? requisicion.oRequisicones.IdUsuarioRevisor.ToString() : "");

            return View(requisicion);
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult asignarRevisor(int IdUsuarioRevisor,int IdUsuarioAsignante,int IdRequisicion)
        {
            var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];

            if (TempData["keyAcceso"] == null)
            {
                return Json("<span class='fa fa-exclamation-triangle fa-1x'></span><strong>Debe intorducir token antes de poder guardar.</strong>", JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (TempData["keyAcceso"].ToString().Trim() != a.string6.Trim())
                {
                    return Json("<span class='fa fa-exclamation-triangle fa-1x'></span><strong>Debe intorducir token antes de poder guardar.</strong>", JsonRequestBehavior.AllowGet);
                }
            }

            var respuesta = "";
            if (IdUsuarioRevisor>0 && IdUsuarioAsignante>0 && IdRequisicion>0)
            {
                brRequisiciones ObrRequisiciones = new brRequisiciones();
                beRequisiciones obreq = ObrRequisiciones.traerRequisiciones_x_IdRequisicion(IdRequisicion);
                obreq.IdUsuarioAsignante = IdUsuarioAsignante;
                obreq.IdUsuarioRevisor = IdUsuarioRevisor;
                obreq.IdEstatusRequisicion = 80;
                ObrRequisiciones.actualizarRequisiciones(obreq);
                respuesta = "Se asignó revisor";
            }
            else
            {
                respuesta = "No se pudo asignar revisor";
            }
            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }
    }
}