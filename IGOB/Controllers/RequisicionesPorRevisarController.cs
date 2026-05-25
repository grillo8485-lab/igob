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
    public class RequisicionesPorRevisarController : ValidaSession
    {
        // GET: RequisicionesPorRevisar
        public ActionResult Index(int id, int IdRequisicion = 0)
        {
            Requisicion requisicion = new Requisicion();
            ClsRequisiciones requisiciones = new ClsRequisiciones();
            bePartidas partida = new bePartidas();
            List<bePartidas> partidas = new List<bePartidas>();
            ViewBag.ejercicioActual = requisiciones.getEjercicioFiscal();
            if (IdRequisicion != 0)
            {
                var f = (ClsGenerica)Session["ClsGenerico"];
                requisicion.IdPerfil = (int)f.id;
                requisicion.oRequisicones = requisiciones.getRequisicion(IdRequisicion);
                partida = requisiciones.getPartidad(requisicion.oRequisicones.IdPartida);
                partidas = requisiciones.getAllPartidas_x_IdCapitulo(partida.IdCapitulo);
                var dependencia = requisiciones.getDependencia_x_IdDependencia(requisicion.oRequisicones.IdDependencia);
                ViewBag.ejercicioActual = requisiciones.getEjercicioFiscal_x_IdEjercicioFiscal(requisicion.oRequisicones.IdEjercicioFiscal);
                requisicion.Titulo = "Solicitud: " + (requisicion.oRequisicones.NumeroLicitacion == 1 ? "Primera licitación" : (requisicion.oRequisicones.NumeroLicitacion == 2 ? "Segunda licitación" : "")) + " - " + requisicion.oRequisicones.RequisicionFolio + " - Procesando - " + dependencia;//+ Session["Dependencia"].ToString();
                requisicion.presupuestoLiquidez = requisiciones.getPresupuestoLiquidez(requisicion.oRequisicones.IdPartida, requisicion.oRequisicones.IdOrigenRecurso, requisicion.oRequisicones.IdDependencia, requisicion.oRequisicones);
                requisicion.lstCartas = requisiciones.getAllCartas_x_IdTipoSolicitud(requisicion.oRequisicones.IdTipoSolicitud, requisicion.oRequisicones.IdRequisicion);
                requisicion.Activar = requisicion.lstCartas.Where(s => s.IdEstatus == 0).ToList().Count == 0 ? false : true;
                requisicion.lstLiquidez = requisiciones.getAllLiquidez_x_IdRequisicion(IdRequisicion);
                requisicion.sumLiquidez = requisiciones.sumLiquidez(requisicion.lstLiquidez);
                requisicion.lstRequisicionLotesIdRequisicion = requisiciones.getAllRequisicionLotes_x_IdRequisicion(IdRequisicion);
                requisicion.sumRequisicionLote = requisiciones.sumRequisicionLote(requisicion.lstRequisicionLotesIdRequisicion);
                requisicion.condicionesDeEntrega = requisiciones.getAllRequisicionCondiconesDeEntrega_x_IdRequisicion(IdRequisicion);
                requisicion.lstRequisicionCondicionesEntregaDetalleConsulta = requisiciones.getAllCondicionesEntregasDetalles_x_IdRequisicionCondicionEntrega(requisicion.condicionesDeEntrega.IdRequisicionCondicionEntrega);
                requisicion.datosFacturacion = requisiciones.getDatosFacturacion((int)f.id4);
                requisicion.datos = requisiciones.getMunicipio_estado_pais(requisicion.datosFacturacion.IdMunicipio);
                requisicion.condicionPago = requisiciones.getCondiconPago_x_IdRequisicion(IdRequisicion);
                requisicion.condicionPagoDetalle = requisiciones.getAllCondicionesPagoDetalle_x_IdCondicionPago(requisicion.condicionPago.IdRequisicionCondicionPago);
                // seccion de firmantes
                ClsUsuario user = new ClsUsuario();
                var us = user.getUsuario_x_IdUsuario(requisicion.oRequisicones.IdUsuarioAsignante);
                var reqFirm = requisiciones.getFirmante(IdRequisicion);
                ViewBag.idUrsAut = f.id;
                ViewBag.idUsrSol = requisicion.oRequisicones.IdUsuarioRegistro;
                ViewBag.idRequisicion = requisicion.oRequisicones.IdRequisicion;
                ViewBag.NameAsignante = us.Nombres+" "+us.Apellidos;
                var persona = user.getUsuario_x_IdUsuario(requisicion.oRequisicones.IdUsuarioRevisor);
                ViewBag.NombreRevisor = persona.Nombres + " " + persona.Apellidos;
                switch(requisicion.IdPerfil)
                {
                    case 7:
                        switch (requisicion.oRequisicones.IdEstatusRequisicion)
                        {
                            case 80:
                                ViewBag.inactivo = "";
                                ViewBag.doc = "disabled";
                                reqFirm = null;
                                break;
                            case 90:
                            case 95:
                                ViewBag.inactivo = "disabled";
                                ViewBag.doc = "";
                                break;
                            default:
                                ViewBag.inactivo = "";
                                ViewBag.doc = "disabled";
                                break;
                        }
                        break;
                    case 5:
                        switch (requisicion.oRequisicones.IdEstatusRequisicion)
                        {
                            case 90:
                            case 95:
                                ViewBag.inactivo = "";
                                ViewBag.doc = "disabled";
                                break;
                            default:
                                ViewBag.inactivo = "disabled";
                                ViewBag.doc = "";
                                break;
                        }
                        break;
                }
                
                
                ViewBag.reqFirm = reqFirm;
                // Fin seccion  Firmantes
            }
            ViewBag.lstRequisicionesAbiertas = new SelectList(requisiciones.tiposRequisicionAbierta(), "IdTipoRequisicion", "TipoRequisicion", (IdRequisicion == 0 ? "0" : requisicion.oRequisicones.IdTipoRequisicion.ToString()));
            ViewBag.lstAbastecimiento = new SelectList(requisiciones.getAllAbastecimiento(), "IdFormaAbastecimiento", "FormaAbastecimiento", (IdRequisicion == 0 ? "0" : requisicion.oRequisicones.IdFormaAbastecimiento.ToString()));
            ViewBag.lstSolicitud = new SelectList(requisiciones.getAllTiposSolicitud(), "IdTipoSolicitud", "TipoSolicitud", (IdRequisicion == 0 ? "0" : requisicion.oRequisicones.IdTipoSolicitud.ToString()));
            ViewBag.lstCapitulos = new SelectList(requisiciones.getAllCapitulos(), "IdCapitulo", "Capitulo", (IdRequisicion == 0 ? "0" : partida.IdCapitulo.ToString()));
            ViewBag.lstPartidas = new SelectList(partidas, "IdPartida", "Descripcion", (IdRequisicion == 0 ? "0" : partida.IdPartida.ToString()));
            ViewBag.lstTiempos = new SelectList(requisiciones.getAllTiempos(), "IdTiempo", "Tiempo", (IdRequisicion == 0 ? "0" : requisicion.oRequisicones.IdTiempo.ToString()));
            ViewBag.lstMesesDe = new SelectList(requisiciones.getMeses(), "IdMes", "Mes");
            ViewBag.lstMesesAl = new SelectList(requisiciones.getMeses(), "IdMes", "Mes");
            ViewBag.lstFrecuencias = new SelectList(requisiciones.geteFrecuencias(), "IdFrecuencia", "Frecuencia");
            ViewBag.lstRequerimiento = new SelectList(requisiciones.getAllRequerimientos(), "IdMuestra", "Muestra");
            ViewBag.lstPlazoEntrega = new SelectList(requisiciones.getAllPlazosEntrega(), "IdPlazoEntrega", "PlazoEntrega", (IdRequisicion == 0 ? "0" : requisicion.condicionesDeEntrega.IdPlazoEntegra.ToString()));
            ViewBag.lstTiposEntrega = new SelectList(requisiciones.getAllTiposEntrega(), "IdTipoEntrega", "TipoEntrega", (IdRequisicion == 0 ? "0" : requisicion.condicionesDeEntrega.IdTipoEntrega.ToString()));
            ViewBag.lstPlazoTiempo = new SelectList(requisiciones.getAllPlazoTiempos(), "IdPlazoTiempo", "PlazozTiempo", (IdRequisicion == 0 ? "0" : requisicion.condicionesDeEntrega.IdPlazoTiempo.ToString()));
            ViewBag.lstTipoDia = new SelectList(requisiciones.getAllTiposDias(), "IdTipoDia", "TipoDia", (IdRequisicion == 0 ? "0" : requisicion.condicionesDeEntrega.IdTipoDia.ToString()));
            ViewBag.lstLugarEntregaFirma = new SelectList(requisiciones.getAllLugaresEntregaFirma(1), "IdLugarEntregaFirma", "Lugar");
            ViewBag.lstLugarPagoFirma = new SelectList(requisiciones.getAllLugaresEntregaFirma(2), "IdLugarEntregaFirma", "Lugar", (IdRequisicion == 0 ? "0" : requisicion.condicionPago.IdLugarFirma.ToString()));
            ViewBag.lstLotesPorAsignar = new SelectList(requisiciones.getRequisicionesCondicionesEntregasDetalles_x_IdRequisicion(IdRequisicion), "IdLote", "CantidadLotesxAsignar");
            ViewBag.lstCondicionPago = new SelectList(requisiciones.getCondicionesPagosEntrega(1), "IdCondicion", "Condicion", (IdRequisicion == 0 ? "0" : requisicion.condicionPago.IdTipoCondicionPago.ToString()));

            ViewBag.lstPais = new SelectList(requisiciones.getAllPaises(), "IdPais", "Pais", (IdRequisicion == 0 ? "0" : requisicion.datos.id.ToString()));
            ViewBag.lstEstado = new SelectList(requisiciones.getAllEstados((int)requisicion.datos.id), "ClaveEstado", "Estado", (IdRequisicion == 0 ? "0" : requisicion.datos.string2));
            ViewBag.lstMunicipio = new SelectList(requisiciones.getAllMunicipio(requisicion.datos.string2), "IdMunicipio", "Municipio", (IdRequisicion == 0 ? "0" : requisicion.datos.string1));
            ViewBag.lstAnticipo = new SelectList(requisiciones.getAllAnticipos(), "IdAnticipo", "AnticipoPorcentaje", (IdRequisicion == 0 ? "0" : requisicion.condicionPago.IdAnticipo.ToString()));
            ViewBag.lstPeriodicidad = new SelectList(requisiciones.getAllPeriodicidad(), "IdPeriodicidad", "Periodicidad", (IdRequisicion == 0 ? "0" : requisicion.condicionPago.IdPeriodicidad.ToString()));
            ViewBag.lstPlazoTiempoPago = new SelectList(requisiciones.getAllPlazoTiempos(), "IdPlazoTiempo", "PlazozTiempo", (IdRequisicion == 0 ? "0" : requisicion.condicionPago.IdPlazoTiempo.ToString()));
            ViewBag.lstTipoDiaPago = new SelectList(requisiciones.getAllTiposDias(), "IdTipoDia", "TipoDia", (IdRequisicion == 0 ? "0" : requisicion.condicionPago.IdTipoDia.ToString()));

            ViewBag.tipoRequisicion = id;
            ViewBag.idRequisicion = IdRequisicion;
            ViewBag.formulario = "DatosGenerales";

            return View(requisicion);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult getAllPartidas_x_IdCapitulo(int pIdCapitulo)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var b = requisiciones.getAllPartidas_x_IdCapitulo(pIdCapitulo);
                return Json(new { success = true, objeto = b }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult getPresupuestoPartida(int pIdPartida)
        {
            try
            {
                var f = (ClsGenerica)Session["ClsGenerico"];
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var b = requisiciones.getPresupuestosPartidas(f.id4, pIdPartida);
                return Json(new { success = true, objeto = b }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        

        [HttpPost]
        public JsonResult getProductos(string term, int IdPartida)
        {
            try
            {
                beGenerica pGenerico = new beGenerica();
                pGenerico.entero = IdPartida;
                pGenerico.string1 = term;
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var lst_ = requisiciones.getProductos(pGenerico);
                return Json(new { success = true, data = lst_ }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult getProducto(int IdBienServicio, int IdRequisicion)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var lst = requisiciones.getAllRequisicionLotes_x_IdRequisicion(IdRequisicion);
                var obj = lst.Where(s => s.IdBienServicio == IdBienServicio).ToList();

                if (obj.Count > 0)
                {

                    return Json(new { success = false, data = "Error el bien y/o servicio esta agregado esta requisición." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var objeto = requisiciones.getProducto(IdBienServicio);
                    return Json(new { success = true, data = objeto }, JsonRequestBehavior.AllowGet);
                }



            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }


       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult getRequisicionLote(beRequisicionesLotes pRequisicionLote)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();

                var lst = requisiciones.getAllRequisicionLotes_x_IdRequisicion(pRequisicionLote.IdRequisicion);
                var objeto_ = lst.Where(s => s.IdLote == pRequisicionLote.IdLote).First();
                return Json(new { success = true, objeto = objeto_ }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult getLugarEntrega_x_IdLugarEntrega(int IdLugarEntrega)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();


                var objeto_ = requisiciones.getLugaresEntregaFirma_x_IdLugarEntrega(IdLugarEntrega);

                return Json(new { success = true, objeto = objeto_ }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult getCondicionEntregaDetalle(int IdCondicionEntregaDetalle)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var objeto_ = requisiciones.getCondicionEntregaDetalle_x_IdCondicionEntregaDetalle(IdCondicionEntregaDetalle);

                return Json(new { success = true, objeto = objeto_ }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult eliminarCondicionEntregaDetalle(int IdCondicionEntregaDetalle, int IdRequisicionCondicionEntrega)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                requisiciones.eliminartRequisicionesCondicionesEntregasDetalles(IdCondicionEntregaDetalle);
                var lst_ = requisiciones.getAllCondicionesEntregasDetalles_x_IdRequisicionCondicionEntrega(IdRequisicionCondicionEntrega);
                return Json(new { success = true, lst = lst_ }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult getCantidad_x_Idlote(int IdRequisicionLote, int IdRequisicion)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var lst_ = requisiciones.getRequisicionesCondicionesEntregasDetalles_x_IdRequisicion(IdRequisicion);
                beRequisiciconesCondicionesDetallesIdRequisicion objeto_ = new beRequisiciconesCondicionesDetallesIdRequisicion();
                if (lst_.Where(s => s.IdLote == IdRequisicionLote).ToList().Count > 0)
                {
                    objeto_ = lst_.Where(s => s.IdLote == IdRequisicionLote).ToList().First();
                }
                return Json(new { success = true, objeto = objeto_ }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult getAnticipo(int IdAnticipo)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var lst_ = requisiciones.getAllAnticipos();
                var objeto_ = new beAnticipos();
                if (lst_.Where(s => s.IdAnticipo == IdAnticipo).ToList().Count > 0)
                {
                    objeto_ = lst_.Where(s => s.IdAnticipo == IdAnticipo).ToList().First();
                }

                return Json(new { success = true, objeto = objeto_ }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult getCalculoPartida(int IdPeriodicidad, int cantidadPagos, decimal importeRestante, decimal porcentajeAplicado, DateTime FechaInicioPago)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var lst_ = requisiciones.getCalculoPartida(IdPeriodicidad, cantidadPagos, importeRestante, porcentajeAplicado, FechaInicioPago);


                return Json(new { success = true, lst = lst_ }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult aceptarRequisicion(beRequisicionesFirmantes oFirmantes)
        {
            try
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
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var oRequisicion = requisiciones.getRequisicion(oFirmantes.IdRequisicion);
                oRequisicion.IdEstatusRequisicion = 90;
                oRequisicion.FechaAsignaRevisor = DateTime.Now;
                requisiciones.saveEditRequisicion(oRequisicion);
                var firmantes = requisiciones.getFirmante(oFirmantes.IdRequisicion);
                firmantes.ObservacionLotesRevisor = oFirmantes.ObservacionLotes == null ? "Sin Observación" : oFirmantes.ObservacionLotes;
                firmantes.ObservacionCondPagoRevisor = oFirmantes.ObservacionCondPagoRevisor == null ? "Sin Observación" : oFirmantes.ObservacionCondPagoRevisor;
                firmantes.ObservacionConEntregaRevisor = oFirmantes.ObservacionConEntregaRevisor == null ? "Sin Observación" : oFirmantes.ObservacionConEntregaRevisor;
                firmantes.ObservacionDoctosRevisor = oFirmantes.ObservacionDoctosRevisor == null ? "Sin Observación" : oFirmantes.ObservacionDoctosRevisor;

                firmantes.ValidaLotesRevisor = oFirmantes.ValidaLotes;
                firmantes.ValidaCondicionPagoRevisor = oFirmantes.ValidaCondicionPago;
                firmantes.ValidaCondicionEntregaRevisor = oFirmantes.ValidaCondicionEntrega;
                firmantes.ValidaDocumentosRevisor = true;
               
                requisiciones.saveRequisicionFirmante(firmantes);
                return Json(new { success = true}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult rechazoRequisicion(beRequisicionesFirmantes oFirmantes)
        {
            try
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
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var oRequisicion = requisiciones.getRequisicion(oFirmantes.IdRequisicion);
                oRequisicion.IdEstatusRequisicion = 95;
                oRequisicion.FechaAsignaRevisor = DateTime.Now;
                requisiciones.saveEditRequisicion(oRequisicion);
                var firmantes = requisiciones.getFirmante(oFirmantes.IdRequisicion);
                firmantes.ObservacionLotesRevisor = oFirmantes.ObservacionLotes==null?"Sin Observación": oFirmantes.ObservacionLotes;
                firmantes.ObservacionCondPagoRevisor = oFirmantes.ObservacionCondPagoRevisor == null ? "Sin Observación" : oFirmantes.ObservacionCondPagoRevisor;
                firmantes.ObservacionConEntregaRevisor = oFirmantes.ObservacionConEntregaRevisor == null ? "Sin Observación" : oFirmantes.ObservacionConEntregaRevisor;
                firmantes.ObservacionDoctosRevisor = oFirmantes.ObservacionDoctosRevisor == null ? "Sin Observación" : oFirmantes.ObservacionDoctosRevisor;

                firmantes.ValidaLotesRevisor = oFirmantes.ValidaLotes;
                firmantes.ValidaCondicionPagoRevisor = oFirmantes.ValidaCondicionPago;
                firmantes.ValidaCondicionEntregaRevisor = oFirmantes.ValidaCondicionEntrega;
                firmantes.ValidaDocumentosRevisor = oFirmantes.ValidaDocumentosRevisor;

                requisiciones.saveRequisicionFirmante(firmantes);
                return Json(new { success = true}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult autorizarRequisicionDirector(int pIdRequisicion)
        {
            try
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
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var oRequisicion = requisiciones.getRequisicion(pIdRequisicion);
                oRequisicion.IdEstatusRequisicion = 100;
                oRequisicion.FechaAutorizacion = DateTime.Now;
                requisiciones.saveEditRequisicion(oRequisicion);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult cancelarRequisicionDirector(int pIdRequisicion)
        {
            try
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
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var oRequisicion = requisiciones.getRequisicion(pIdRequisicion);
                oRequisicion.IdEstatusRequisicion = 85;
                oRequisicion.FechaAsignaRevisor = DateTime.Now;
                requisiciones.saveEditRequisicion(oRequisicion);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}