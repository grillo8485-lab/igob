using iGob.Entidades;
using iGob.ReglasNegocios;
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
    public class PropuestaTecnicaEconomicaController : ValidaSession
    {
        // GET: PropuestaTecnicaEconomica
        public ActionResult Index()
        {
            var IdRequisicion = (int)TempData["IdRequisicion"];
            var IdProveedorRqInvitacion = (int)TempData["IdProveedorRqInvitacion"];
            var titulo = TempData["TituloPorProceso"];
            ViewBag.IdProveedorRqInvitacion = IdProveedorRqInvitacion;
            var idPerfil = 0;
            var btnActivoRevisor = 0;
            Requisicion requisicion = new Requisicion();
            requisicion.IdTipoPropuesta = (int)TempData["IdTipoProceso"];
            ClsRequisiciones requisiciones = new ClsRequisiciones();
            List<bePartidas> partidas = new List<bePartidas>();
            ViewBag.ejercicioActual = requisiciones.getEjercicioFiscal();
            if (IdRequisicion != 0)
            {
                var f = (ClsGenerica)Session["ClsGenerico"];

                requisicion.oRequisicones = requisiciones.getRequisicion(IdRequisicion);
                var partida = requisiciones.getPartidad(requisicion.oRequisicones.IdPartida);

                requisicion.Titulo = titulo + " - " + requisicion.oRequisicones.RequisicionFolio + " - " + partida.ClavePartida.Trim() + " - " + partida.Partida.Trim();
                requisicion.presupuestoLiquidez = requisiciones.getPresupuestoLiquidez(requisicion.oRequisicones.IdPartida, requisicion.oRequisicones.IdOrigenRecurso, requisicion.oRequisicones.IdDependencia, requisicion.oRequisicones);
                requisicion.oProveedoresRequisicionesInvitacion = requisiciones.getProveedoresRequisicionesInvitacion(IdProveedorRqInvitacion);
                requisicion.lstCartas = requisiciones.listar_Cartas_x_IdProveedorRqInvitacion(IdProveedorRqInvitacion);
                requisicion.lstRequisicionLotesIdRequisicion = requisiciones.getAllRequisicionLotes_x_IdProveedorRqInvitacion(IdProveedorRqInvitacion);
                switch (requisicion.IdTipoPropuesta)
                {
                    case 2:
                    case 4:
                    case 3:
                    case 5:
                    case 6:
                        requisicion.lstRequisicionLotesIdRequisicion = requisiciones.getAllRequisicionLotes_x_IdProveedorRqInvitacion(IdProveedorRqInvitacion).Where(x => x.LoteOfertado == true).ToList();
                        break;
                }

                
                requisicion.condicionesDeEntrega = requisiciones.getAllRequisicionCondiconesDeEntrega_x_IdRequisicion(IdRequisicion);
                requisicion.oManifiestosProveedores = requisiciones.getManifiestosProveedores_x_IdProveedorRqInvitacion(IdProveedorRqInvitacion);
                requisicion.lstManifiestoProveedoresClientes = requisiciones.getAllManifiestosProveedores_x_IdManifiestoProveedor(requisicion.oManifiestosProveedores.IdManifiestoProveedor);
                requisicion.lstManifiestoProveedoresDeclaratorias = requisiciones.getAllManifiestoProveedoresDeclaratorias_x_IdManifiestoProveedor(requisicion.oManifiestosProveedores.IdManifiestoProveedor);
                btnActivoRevisor = requisicion.oProveedoresRequisicionesInvitacion.IdEstatusEnvioPropuestaEconomica;
                if (requisicion.condicionesDeEntrega.FechaLimite == DateTime.MinValue)
                {
                    requisicion.condicionesDeEntrega.FechaLimite = DateTime.Now;
                }

                requisicion.lstRequisicionCondicionesEntregaDetalleConsulta = requisiciones.getAllCondicionesEntregasDetalles_x_IdRequisicionCondicionEntrega(requisicion.condicionesDeEntrega.IdRequisicionCondicionEntrega);
                requisicion.datosFacturacion = requisiciones.getDatosFacturacion(requisicion.oRequisicones.IdDependencia);
                requisicion.datos = requisiciones.getMunicipio_estado_pais(requisicion.datosFacturacion.IdMunicipio);
                requisicion.condicionPago = requisiciones.getCondiconPago_x_IdRequisicion(IdRequisicion);
                if (requisicion.condicionPago.FechaInicioPago == DateTime.MinValue)
                {
                    requisicion.condicionPago.FechaInicioPago = DateTime.Now;
                }
                requisicion.condicionPagoDetalle = requisiciones.getAllCondicionesPagoDetalle_x_IdCondicionPago(requisicion.condicionPago.IdRequisicionCondicionPago);
                idPerfil = (int)f.id;
            }
            ViewBag.lstRequisicionesAbiertas = new SelectList(requisiciones.tiposRequisicionAbierta(), "IdTipoRequisicion", "TipoRequisicion", (IdRequisicion == 0 ? "0" : requisicion.oRequisicones.IdTipoRequisicion.ToString()));
            ViewBag.lstAbastecimiento = new SelectList(requisiciones.getAllAbastecimiento(), "IdFormaAbastecimiento", "FormaAbastecimiento", (IdRequisicion == 0 ? "0" : requisicion.oRequisicones.IdFormaAbastecimiento.ToString()));
            ViewBag.lstSolicitud = new SelectList(requisiciones.getAllTiposSolicitud(), "IdTipoSolicitud", "TipoSolicitud", (IdRequisicion == 0 ? "0" : requisicion.oRequisicones.IdTipoSolicitud.ToString()));
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

            ViewBag.tipoRequisicion = 0;
            ViewBag.idRequisicion = IdRequisicion;
            ViewBag.idPerfil = idPerfil;
            ViewBag.btnActivoRevisor = btnActivoRevisor;
            requisicion.visibleTecnicaSolicitante = "verSeccion";
            requisicion.visibleTecnicaRevisor = "verSeccion";
            requisicion.activarTecnicaSolicitante = "";
            requisicion.activarTecnicaRevisor = "";
            requisicion.visibleTecnica = "verSeccion";
            requisicion.visibleEconimica = "verSeccion";
            switch (requisicion.IdTipoPropuesta)
            {

                case 1:
                    requisicion.activar = "";
                    requisicion.activarLotes = "";
                    
                    if (requisicion.oProveedoresRequisicionesInvitacion.IdEstatusEnvioPropuestaTecnica >= 2)
                    {
                        requisicion.activar = "disabledClick";
                        requisicion.activarLotes = "disabledClick";

                    }
                   
                    requisicion.visibleTecnica = "";
                    requisicion.visibleEconimica = "verSeccion";
                    break;
                case 2:
                    requisicion.activar = "";
                    requisicion.activarLotes = "";
                    if (requisicion.oProveedoresRequisicionesInvitacion.IdEstatusEnvioPropuestaEconomica >= 2)
                    {
                        requisicion.activar = "disabledClick";
                        requisicion.activarLotes = "disabledClick";
                    }
                   
                    requisicion.visibleTecnica = "verSeccion";
                    requisicion.visibleEconimica = "";

                    break;
                case 3:
                    requisicion.activar = "";
                    requisicion.activarLotes = "disabledClick";
                    if (requisicion.oProveedoresRequisicionesInvitacion.IdEstatusEnvioPropuestaTecnica >= 3)
                    {
                        requisicion.activar = "disabledClick";
                    }
                    requisicion.visibleTecnica = "verSeccion";
                    requisicion.visibleEconimica = "verSeccion";

                    break;
                case 4:
                    requisicion.activar = "disabledClick";
                    requisicion.activarLotes = "disabledClick";
                    if (requisicion.oProveedoresRequisicionesInvitacion.IdEstatusEnvioPropuestaEconomica == 3)
                    {
                        requisicion.activar = "disabledClick";
                    }
                    requisicion.visibleTecnica = "verSeccion";
                    requisicion.visibleEconimica = "";

                    break;
                case 5:
                    requisicion.activar = "";
                    requisicion.activar = "disabledClick";
                    requisicion.visibleTecnicaSolicitante = "";
                    requisicion.visibleTecnicaRevisor = "verSeccion";
                    requisicion.activarTecnicaSolicitante = "disabledClick";
                    requisicion.activarTecnicaRevisor = "disabledClick";
                    requisicion.activarLotes = "disabledClick";
                    requisicion.visibleTecnica = "verSeccion";
                    requisicion.visibleEconimica = "verSeccion";
                    switch (requisicion.oProveedoresRequisicionesInvitacion.IdEstatusEnvioPropuestaTecnica)
                    {
                        case 4:
                            requisicion.activar = "disabledClick";
                            requisicion.visibleTecnicaSolicitante = "";
                            requisicion.visibleTecnicaRevisor = "verSeccion";
                            requisicion.activarTecnicaSolicitante = "";
                            requisicion.activarLotes = "";
                            requisicion.activarTecnicaRevisor = "disabledClick";
                            break;
                        
                    }

                    break;
                case 6:
                    requisicion.activar = "";
                   
                    requisicion.visibleTecnicaSolicitante = "";
                    requisicion.visibleTecnicaRevisor = "";
                    requisicion.activarTecnicaSolicitante = "disabledClick";
                    requisicion.activarTecnicaRevisor = "disabledClick";
                    requisicion.activarLotes = "disabledClick";
                    requisicion.visibleTecnica = "verSeccion";
                    switch (requisicion.oProveedoresRequisicionesInvitacion.IdEstatusEnvioPropuestaTecnica)
                    {
                        case 5:
                            requisicion.activar = "disabledClick";
                            requisicion.visibleTecnicaSolicitante = "";
                            requisicion.visibleTecnicaRevisor = "";
                            requisicion.activarTecnicaSolicitante = "disabledClick";
                            requisicion.activarTecnicaRevisor = "";
                            requisicion.activarLotes = "";
                            break;

                    }
                    break;
            }

            TempData["IdRequisicion"] = IdRequisicion;
            TempData["IdTipoProceso"] = requisicion.IdTipoPropuesta;
            TempData["IdProveedorRqInvitacion"] = IdProveedorRqInvitacion;
            TempData["TituloPorProceso"]= titulo;
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
        [ValidateAntiForgeryToken]
        public JsonResult saveRequisiciones(beRequisiciones pRequisiciones)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                pRequisiciones.FechaAsignaRevisor = DateTime.Now;
                pRequisiciones.FechaAutorizacion = DateTime.Now;
                pRequisiciones.FechaRegistro = DateTime.Now;
                pRequisiciones.FechaRequisicion = DateTime.Now;
                pRequisiciones.IdDependencia = a.id4;
                pRequisiciones.IdUsuarioRegistro = (int)a.id2;
                pRequisiciones.ObservacionesRechazo = "";
                pRequisiciones.NumeroLicitacion = 1;
                if (pRequisiciones.Observaciones == null)
                    pRequisiciones.Observaciones = "";
                var b = requisiciones.saveRequisicion(pRequisiciones);
                var objeto = requisiciones.getRequisicion(b);
                return Json(new { success = true, objeto = objeto }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveCarta(beCartas pCartas)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                pCartas.FechaRegistro = DateTime.Now;
                pCartas.IdGobierno = a.id5;
                pCartas.IdUsuarioRegistro = (int)a.id2;
                var IdCarta = requisiciones.saveCarta(pCartas);
                // seccion dar de alta a requisicion Carta....
                requisiciones.saveRequisicionCarta(IdCarta, pCartas.IdRequisicion, (int)a.id2);

                var lst_ = requisiciones.getAllCartas_x_IdTipoSolicitud(pCartas.IdTipoSolicitud, pCartas.IdRequisicion);
                return Json(new { success = true, data = lst_.ToArray() }, JsonRequestBehavior.AllowGet);
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

                    return Json(new { success = false, data = "Error el bien y/o servicio esta agregado esta requisición" }, JsonRequestBehavior.AllowGet);
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
        public JsonResult saveLote(beRequisicionesLotes pRequisicionLote)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                pRequisicionLote.FechaRegistro = DateTime.Now;
                pRequisicionLote.IdUsuarioRegistro = (int)a.id2;
                requisiciones.saveRequisionLote(pRequisicionLote);
                var lst = requisiciones.getAllRequisicionLotes_x_IdRequisicion(pRequisicionLote.IdRequisicion);
                return Json(new { success = true, data = lst }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult deleteLote(beRequisicionesLotes pRequisicionLote)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var lst_ = requisiciones.getRequisicionesCondicionesEntregasDetalles_x_IdRequisicion(pRequisicionLote.IdRequisicion);
                if (lst_.Where(s => s.IdLote == pRequisicionLote.IdLote && s.CantidadLoteAsignado > 0).ToList().Count() == 0)
                {
                    requisiciones.deleteLote(pRequisicionLote.IdLote);
                    var lst = requisiciones.getAllRequisicionLotes_x_IdRequisicion(pRequisicionLote.IdRequisicion);
                    return Json(new { success = true, data = lst }, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    var lst = requisiciones.getAllRequisicionLotes_x_IdRequisicion(pRequisicionLote.IdRequisicion);
                    return Json(new { success = false, Mensaje = lst }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveEditLote(beRequisicionesLotes pRequisicionLote)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                var b = requisiciones.getRequisicionLote_x_IdLote(pRequisicionLote.IdLote);
                pRequisicionLote.FechaRegistro = b.FechaRegistro;
                pRequisicionLote.IdUsuarioRegistro = b.IdUsuarioRegistro;
                pRequisicionLote.NoLote = b.NoLote;
                requisiciones.saveEditRequisionLote(pRequisicionLote);
                var lst = requisiciones.getAllRequisicionLotes_x_IdRequisicion(pRequisicionLote.IdRequisicion);
                return Json(new { success = true, data = lst }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveCondiconesDeEntrega(beRequisicionesCondicionesEntregas pCondcionesDeEntrega)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];

                pCondcionesDeEntrega.FechaRegistro = DateTime.Now;
                pCondcionesDeEntrega.IdUsuarioRegistro = (int)a.id2;
                if (pCondcionesDeEntrega.NotaEspecial == null)
                    pCondcionesDeEntrega.NotaEspecial = "";
                requisiciones.saveCondcionesDeEntrega(pCondcionesDeEntrega);

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveEditCondiconesDeEntrega(beRequisicionesCondicionesEntregas pCondcionesDeEntrega)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                var b = requisiciones.getRequisicionCondicionEntrega_x_IdRequisicionCondicionEntrega(pCondcionesDeEntrega.IdRequisicionCondicionEntrega);
                pCondcionesDeEntrega.FechaRegistro = b.FechaRegistro;
                pCondcionesDeEntrega.IdUsuarioRegistro = b.IdUsuarioRegistro;
                if (pCondcionesDeEntrega.NotaEspecial == null)
                    pCondcionesDeEntrega.NotaEspecial = "";
                requisiciones.updateCondcionesDeEntrega(pCondcionesDeEntrega);

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
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
        public JsonResult saveCondicionesDeEntregaDetalle(beRequisicionesCondicionesEntregasDetalles oRequisicionesCondicionesEntregasDetalles)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                requisiciones.saveRequisicionesCondicionesEntregasDetalles(oRequisicionesCondicionesEntregasDetalles);
                var lst_ = requisiciones.getAllCondicionesEntregasDetalles_x_IdRequisicionCondicionEntrega(oRequisicionesCondicionesEntregasDetalles.IdRequisicionCondicionEntrega);
                return Json(new { success = true, lst = lst_ }, JsonRequestBehavior.AllowGet);
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
        public JsonResult saveEditCondicionesDeEntregaDetalle(beRequisicionesCondicionesEntregasDetalles oRequisicionesCondicionesEntregasDetalles)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                requisiciones.saveEditRequisicionesCondicionesEntregasDetalles(oRequisicionesCondicionesEntregasDetalles);
                var lst_ = requisiciones.getAllCondicionesEntregasDetalles_x_IdRequisicionCondicionEntrega(oRequisicionesCondicionesEntregasDetalles.IdRequisicionCondicionEntrega);
                return Json(new { success = true, lst = lst_ }, JsonRequestBehavior.AllowGet);
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
        public JsonResult saveCondicionesPago(beRequisicionesCondicionesPagos condiconPago)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];

                condiconPago.FechaRegistro = DateTime.Now;
                condiconPago.IdUsuarioRegistro = (int)a.id2;
                condiconPago.Observaciones = "";
                int id = requisiciones.saveCondicionPago(condiconPago);
                var lst_ = requisiciones.getCalculoPartida(condiconPago.IdPeriodicidad, condiconPago.NumeroPagos, condiconPago.ImporteTotalPagos, condiconPago.PorcentajeAnticipo, condiconPago.FechaInicioPago);

                foreach (var item in lst_)
                {
                    beRequisicionesCondicionesPagosDetalles b = new beRequisicionesCondicionesPagosDetalles();
                    b.IdRequiscionCondicionPago = id;
                    b.FechaPago = (DateTime)item.DateTime1;
                    b.PorcentajePago = item.decimal2;
                    b.NumeroPago = (int)item.id;
                    b.ImportePago = item.decimal1;
                    item.bool1 = true;
                    var f = (new brRequisicionesCondicionesPagosDetalles()).guardarRequisicionesCondicionesPagosDetalles(b);
                }

                return Json(new { success = true, lst = lst_ }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveEditCondicionPago(beRequisicionesCondicionesPagos condiconPago)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var b = requisiciones.getCondicionPago_x_IdCondcionPago(condiconPago.IdRequisicionCondicionPago);
                condiconPago.IdUsuarioRegistro = b.IdUsuarioRegistro;
                condiconPago.FechaRegistro = b.FechaRegistro;
                condiconPago.Observaciones = "";
                (new brRequisicionesCondicionesPagosDetalles()).eliminarRequisicionesCondicionesPagosDetalles_x_IdRequiscionCondicionPago(condiconPago.IdRequisicionCondicionPago);
                requisiciones.saveEditCondicionPago(condiconPago);
                int id = b.IdRequisicionCondicionPago;
                var lst_ = requisiciones.getCalculoPartida(condiconPago.IdPeriodicidad, condiconPago.NumeroPagos, condiconPago.ImporteTotalPagos, condiconPago.PorcentajeAnticipo, condiconPago.FechaInicioPago);

                foreach (var item in lst_)
                {
                    beRequisicionesCondicionesPagosDetalles c = new beRequisicionesCondicionesPagosDetalles();
                    c.IdRequiscionCondicionPago = id;
                    c.FechaPago = (DateTime)item.DateTime1;
                    c.PorcentajePago = item.decimal2;
                    c.NumeroPago = (int)item.id;
                    c.ImportePago = item.decimal1;
                    item.bool1 = true;
                    var f = (new brRequisicionesCondicionesPagosDetalles()).guardarRequisicionesCondicionesPagosDetalles(c);
                }

                return Json(new { success = true, lst = lst_ }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveEditCondcionPagoDetalle(beRequisicionesCondicionesPagosDetalles condiconPagoDetalle)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var b = requisiciones.getCondicionPagoDetalle_x_IdCondcionPagoDetalle(condiconPagoDetalle.IdRqCondicionPagoDetalle);
                b.ImportePago = condiconPagoDetalle.ImportePago;
                requisiciones.saveEditCondiconPagoDetalle(b);
                var lst_ = requisiciones.getAllCondicionesPagoDetalle_x_IdCondicionPago(condiconPagoDetalle.IdRequiscionCondicionPago);
                return Json(new { success = true, lst = lst_ }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveFirmantes(int IdRequisicion)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var lotesRequisicion = requisiciones.getRequisicionesCondicionesEntregasDetalles_x_IdRequisicion(IdRequisicion);
                if (lotesRequisicion.Count() == 0)
                {
                    return Json(new { success = false, mensaje = "Aun no acapturado lotes." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var lotes = lotesRequisicion.Where(s => s.CantidadxAsignar > 0).ToList();
                    if (lotes.Count() == 0)
                    {
                        var condiconPago = requisiciones.getCondiconPago_x_IdRequisicion(IdRequisicion);
                        if (condiconPago.IdTipoCondicionPago != 0)
                        {
                            var b = requisiciones.getRequisicion(IdRequisicion);
                            b.IdEstatusRequisicion = 60;

                            requisiciones.saveEditRequisicion(b);
                            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { success = false, mensaje = "Falta capturar condicones de pago." }, JsonRequestBehavior.AllowGet);
                        }

                    }
                    else
                    {
                        return Json(new { success = false, mensaje = "Aun hay lotes pendientes por asignar a las condiciones de entrega." }, JsonRequestBehavior.AllowGet);
                    }
                }


            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult getRequisicionLote(int pIdProveedorRqInvitacion, int pIdPropuestaTecnicaEconomica, int pIdRequisicion)
        {
            try
            {
                var IdRequisicion = pIdRequisicion;
                var IdProveedorRqInvitacion = pIdProveedorRqInvitacion;
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                Requisicion requisicion = new Requisicion();
                requisicion.oRequisicones = requisiciones.getRequisicion(pIdRequisicion);
                var lst = requisiciones.getAllRequisicionLotes_x_IdProveedorRqInvitacion(pIdProveedorRqInvitacion);
                var objeto_ = lst.Where(s => s.IdPropuestaTecnicaEconomica == pIdPropuestaTecnicaEconomica).First();
                requisicion.IdTipoPropuesta = (int)TempData["IdTipoProceso"];
                requisicion.oLotePropuestaTecnicaEconomica = objeto_;
                //ViewBag.IdMuestra =  requisicion.oLotePropuestaTecnicaEconomica.IdMuestra;
                requisicion.oProveedoresRequisicionesInvitacion = requisiciones.getProveedoresRequisicionesInvitacion(IdProveedorRqInvitacion);
                requisicion.extencionArchivoCatalogo = Path.GetExtension(requisicion.oLotePropuestaTecnicaEconomica.URLFileMuestraCatalogo);
                requisicion.extencionArchivoCertificacicon = Path.GetExtension(requisicion.oLotePropuestaTecnicaEconomica.URLFileCertificacion);
                ViewBag.lstMesesDe = new SelectList(requisiciones.getMeses(), "IdMes", "Mes", objeto_.MesInicial);
                ViewBag.lstMesesAl = new SelectList(requisiciones.getMeses(), "IdMes", "Mes", objeto_.MesFinal);
                ViewBag.lstFrecuencias = new SelectList(requisiciones.geteFrecuencias(), "IdFrecuencia", "Frecuencia", objeto_.Frecuencia);
                ViewBag.lstRequerimiento = new SelectList(requisiciones.getAllRequerimientos(), "IdMuestra", "Muestra", objeto_.IdMuestra);

                requisicion.visibleTecnicaSolicitante = "verSeccion";
                requisicion.visibleTecnicaRevisor = "verSeccion";
                requisicion.activarTecnicaSolicitante = "";
                requisicion.activarTecnicaRevisor = "";
                requisicion.visibleTecnica = "verSeccion";
                requisicion.visibleEconimica = "";
                var f = (ClsGenerica)Session["ClsGenerico"];
                ViewBag.idPerfil = (int)f.id;
                switch (requisicion.IdTipoPropuesta)
                {

                    case 1:
                        requisicion.activar = "";
                        requisicion.activarLotes = "";
                        if (requisicion.oProveedoresRequisicionesInvitacion.IdEstatusEnvioPropuestaTecnica >= 2)
                        {
                            requisicion.activar = "disabledClick";
                            requisicion.activarLotes = "disabledClick";

                        }
                        requisicion.visibleTecnica = "";
                        requisicion.visibleEconimica = "verSeccion";
                        break;
                    case 2:
                        requisicion.activar = "";
                        requisicion.activarLotes = "";
                        if (requisicion.oProveedoresRequisicionesInvitacion.IdEstatusEnvioPropuestaEconomica >= 2)
                        {
                            requisicion.activar = "disabledClick";
                            requisicion.activarLotes = "disabledClick";
                        }
                        requisicion.visibleTecnica = "verSeccion";
                        requisicion.visibleEconimica = "";

                        break;
                    case 3:
                        requisicion.activar = "";
                        requisicion.activarLotes = "disabledClick";
                        if (requisicion.oProveedoresRequisicionesInvitacion.IdEstatusEnvioPropuestaTecnica >= 3)
                        {
                            requisicion.activar = "disabledClick";
                        }
                        requisicion.visibleTecnica = "verSeccion";
                        requisicion.visibleEconimica = "verSeccion";

                        break;
                    case 4:
                        requisicion.activar = "disabledClick";
                        requisicion.activarLotes = "disabledClick";
                        if (requisicion.oProveedoresRequisicionesInvitacion.IdEstatusEnvioPropuestaEconomica == 3)
                        {
                            requisicion.activar = "disabledClick";
                        }
                        requisicion.visibleTecnica = "verSeccion";
                        requisicion.visibleEconimica = "";

                        break;
                    case 5:
                        requisicion.activar = "disabledClick";
                        requisicion.visibleTecnica = "verSeccion";
                        requisicion.visibleEconimica = "verSeccion";
                        requisicion.activarLotes = "";
                        requisicion.visibleTecnicaRevisor = "verSeccion";
                        requisicion.visibleTecnicaSolicitante = "";
                        switch (requisicion.oProveedoresRequisicionesInvitacion.IdEstatusEnvioPropuestaTecnica)
                        {
                            
                            case 5:
                                requisicion.visibleTecnicaSolicitante = "";
                                requisicion.activarTecnicaSolicitante = "disabledClick";
                                requisicion.activarLotes = "disabledClick";
                                break;
                           
                        }
                        break;
                    case 6:
                        requisicion.activar = "";
                        requisicion.activar = "disabledClick";
                        requisicion.visibleTecnicaSolicitante = "";
                        requisicion.visibleTecnicaRevisor = "";
                        requisicion.activarTecnicaSolicitante = "disabledClick";
                        requisicion.activarTecnicaRevisor = "";
                        requisicion.activarLotes = "";
                        requisicion.visibleEconimica = "verSeccion";
                        switch (requisicion.oProveedoresRequisicionesInvitacion.IdEstatusEnvioPropuestaTecnica)
                        {
                            case 6:
                                requisicion.activar = "disabledClick";
                                requisicion.visibleTecnicaSolicitante = "";
                                requisicion.visibleTecnicaRevisor = "";
                                requisicion.activarTecnicaSolicitante = "disabledClick";
                                requisicion.activarTecnicaRevisor = "";
                                requisicion.activarLotes = "";
                                break;

                        }
                        break;
                }
                //var lote = requisiciones.getRequisicionLote_x_IdLote(a.IdLote);
                TempData["IdTipoProceso"] = requisicion.IdTipoPropuesta;
                TempData["IdProveedorRqInvitacion"] = IdProveedorRqInvitacion;
                TempData["IdRequisicion"] = IdRequisicion;

                return PartialView("Componentes/EditLote", requisicion);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult savePropuestaTecnica(bePropuestasTecnicaEconomicaLotes pPropuestasTecnicaEconomicaLotes)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();

                var a = requisiciones.getPropuestasTecnicaEconomicaLotes(pPropuestasTecnicaEconomicaLotes.IdPropuestaTecnicaEconomica);
                var lote = requisiciones.getRequisicionLote_x_IdLote(a.IdLote);
                var bienServicio = requisiciones.getBienesServicios(lote.IdBienServicio);
                var oRequisicones = requisiciones.getRequisicion(pPropuestasTecnicaEconomicaLotes.IdRequisicion);
                // seccion para validar url catalogos
                var fileNameURLFileMuestraCatalogo = "";
                if (lote.IdMuestra != 3)
                {

                    
                    if (pPropuestasTecnicaEconomicaLotes.URLFileMuestraCatalogo != null)
                    {
                        if (System.Web.HttpContext.Current.Request.Files["URLFileMuestraCatalogo"] != null)
                        {
                            var URLFileMuestraCatalogo = System.Web.HttpContext.Current.Request.Files["URLFileMuestraCatalogo"];
                            HttpPostedFileBase filebaseURLFileMuestraCatalogo = new HttpPostedFileWrapper(URLFileMuestraCatalogo);
                            fileNameURLFileMuestraCatalogo = Path.GetExtension(filebaseURLFileMuestraCatalogo.FileName);
                            fileNameURLFileMuestraCatalogo = "_Imagen_URLFileMuestraCatalogo_" + pPropuestasTecnicaEconomicaLotes.IdPropuestaTecnicaEconomica.ToString() + fileNameURLFileMuestraCatalogo;
                            var pathURLFileMuestraCatalogo = Path.Combine(Server.MapPath("~/Files/EnvioPagoProvedor/"), fileNameURLFileMuestraCatalogo);
                            filebaseURLFileMuestraCatalogo.SaveAs(pathURLFileMuestraCatalogo);
                        }
                        {
                            fileNameURLFileMuestraCatalogo = pPropuestasTecnicaEconomicaLotes.URLFileMuestraCatalogo;
                        }
                    }
                    else
                    {
                        if (System.Web.HttpContext.Current.Request.Files["URLFileMuestraCatalogo"] != null)
                        {
                            var URLFileMuestraCatalogo = System.Web.HttpContext.Current.Request.Files["URLFileMuestraCatalogo"];
                            HttpPostedFileBase filebaseURLFileMuestraCatalogo = new HttpPostedFileWrapper(URLFileMuestraCatalogo);
                            fileNameURLFileMuestraCatalogo = Path.GetExtension(filebaseURLFileMuestraCatalogo.FileName);
                            fileNameURLFileMuestraCatalogo = "_Imagen_URLFileMuestraCatalogo_" + pPropuestasTecnicaEconomicaLotes.IdPropuestaTecnicaEconomica.ToString() + fileNameURLFileMuestraCatalogo;
                            var pathURLFileMuestraCatalogo = Path.Combine(Server.MapPath("~/Files/EnvioPagoProvedor/"), fileNameURLFileMuestraCatalogo);
                            filebaseURLFileMuestraCatalogo.SaveAs(pathURLFileMuestraCatalogo);
                        }
                        else
                        {
                            return Json(new { success = false, Mensaje = "No se envio catalogo para guardar" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
                else
                {
                    fileNameURLFileMuestraCatalogo = "";
                }
                


                // seccion para validar url Certificados
                var fileNameURLFileCertificacion = "";
                if (bienServicio.IdCertificacion == 1)
                {
                    if (pPropuestasTecnicaEconomicaLotes.URLFileMuestraCatalogo != null)
                    {
                        if (System.Web.HttpContext.Current.Request.Files["URLFileCertificacion"] != null)
                        {
                            var URLFileCertificacion = System.Web.HttpContext.Current.Request.Files["URLFileCertificacion"];
                            HttpPostedFileBase filebaseURLFileMuestraCatalogo = new HttpPostedFileWrapper(URLFileCertificacion);
                            fileNameURLFileCertificacion = Path.GetExtension(filebaseURLFileMuestraCatalogo.FileName);
                            fileNameURLFileCertificacion = "_Imagen_URLFileMuestraCatalogo_" + pPropuestasTecnicaEconomicaLotes.IdPropuestaTecnicaEconomica.ToString() + fileNameURLFileCertificacion;
                            var pathURLFileCertificacion = Path.Combine(Server.MapPath("~/Files/EnvioPagoProvedor/"), fileNameURLFileCertificacion);
                            filebaseURLFileMuestraCatalogo.SaveAs(pathURLFileCertificacion);
                        }
                        else
                        {
                            fileNameURLFileMuestraCatalogo = pPropuestasTecnicaEconomicaLotes.URLFileMuestraCatalogo;
                        }
                    }
                    else
                    {
                        if (System.Web.HttpContext.Current.Request.Files["URLFileCertificacion"] != null)
                        {
                            var URLFileCertificacion = System.Web.HttpContext.Current.Request.Files["URLFileCertificacion"];
                            HttpPostedFileBase filebaseURLFileMuestraCatalogo = new HttpPostedFileWrapper(URLFileCertificacion);
                            fileNameURLFileCertificacion = Path.GetExtension(filebaseURLFileMuestraCatalogo.FileName);
                            fileNameURLFileCertificacion = "_Imagen_URLFileMuestraCatalogo_" + pPropuestasTecnicaEconomicaLotes.IdPropuestaTecnicaEconomica.ToString() + fileNameURLFileCertificacion;
                            var pathURLFileCertificacion = Path.Combine(Server.MapPath("~/Files/EnvioPagoProvedor/"), fileNameURLFileCertificacion);
                            filebaseURLFileMuestraCatalogo.SaveAs(pathURLFileCertificacion);
                        }
                        else
                        {
                            return Json(new { success = false, Mensaje = "No se envio certificado para guardar" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
                else{
                    fileNameURLFileCertificacion = "";
                }

                if (oRequisicones.IdFormaAbastecimiento == 1)
                {
                    var lstRequisicionLotesIdRequisicion = requisiciones.getAllRequisicionLotes_x_IdProveedorRqInvitacion(pPropuestasTecnicaEconomicaLotes.IdProveedorRqInvitacion);
                    
                    foreach (var item in lstRequisicionLotesIdRequisicion)
                    {
                        var b = requisiciones.getPropuestasTecnicaEconomicaLotes(item.IdPropuestaTecnicaEconomica);
                        b.Mejora = pPropuestasTecnicaEconomicaLotes.EstatusMejora == 0 ? "" : pPropuestasTecnicaEconomicaLotes.Mejora;
                        b.LoteOfertado = pPropuestasTecnicaEconomicaLotes.LoteOfertado;
                        b.EstatusMejora = pPropuestasTecnicaEconomicaLotes.EstatusMejora;
                        b.URLFileCertificacion = fileNameURLFileCertificacion;
                        b.URLFileMuestraCatalogo = fileNameURLFileMuestraCatalogo;
                        b.DependenciaCumple = false;
                        b.FundamentoLegal = "";
                        b.AdquisicionCumple = false;
                        b.AdquisicionObserva = "";
                        b.ValidaEconomica = 0;

                        requisiciones.savePropuestasTecnicaEconomicaLotes(b);
                    }
                   
                    
                }
                else
                {
                    a.Mejora = pPropuestasTecnicaEconomicaLotes.EstatusMejora == 0 ? "" : pPropuestasTecnicaEconomicaLotes.Mejora;
                    a.LoteOfertado = pPropuestasTecnicaEconomicaLotes.LoteOfertado;
                    a.EstatusMejora = pPropuestasTecnicaEconomicaLotes.EstatusMejora;
                    a.URLFileCertificacion = fileNameURLFileCertificacion;
                    a.URLFileMuestraCatalogo = fileNameURLFileMuestraCatalogo;
                    a.DependenciaCumple = false;
                    a.FundamentoLegal = "";
                    a.AdquisicionCumple = false;
                    a.AdquisicionObserva = "";
                    a.ValidaEconomica = 0;

                    requisiciones.savePropuestasTecnicaEconomicaLotes(a);
                }
                

                TempData["IdProveedorRqInvitacion"] = pPropuestasTecnicaEconomicaLotes.IdProveedorRqInvitacion;
                TempData["IdRequisicion"] = pPropuestasTecnicaEconomicaLotes.IdRequisicion;
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult saveAceptarCarta(beProveedoresRequisicionesCartas aceptarCartas)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();

                var ProveedoresRequisicionesCarta = requisiciones.getProveedoresRequisicionesCarta(aceptarCartas.IdProveedorCarta);

                ProveedoresRequisicionesCarta.AceptacionCarta = aceptarCartas.AceptacionCarta;
                ProveedoresRequisicionesCarta.FechaAceptacion = DateTime.Now;
                requisiciones.saveProveedoresRequisicionesCarta(ProveedoresRequisicionesCarta);
                TempData["IdProveedorRqInvitacion"] = aceptarCartas.IdProveedorRqInvitacion;
                TempData["IdRequisicion"] = aceptarCartas.IdRequisicion;
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult getManifiestoProveedoresClientes(beManifiestoProveedoresClientes pManifiestoProveedoresClientes)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var ManifiestoProveedoresClientes = requisiciones.getManifiestoProveedoresClientes(pManifiestoProveedoresClientes.IdManifiestoProveedorCliente);
                ManifiestoProveedoresClientes.IdManifiestoProveedor = pManifiestoProveedoresClientes.IdManifiestoProveedor;
                ManifiestoProveedoresClientes.IdRequisicion = pManifiestoProveedoresClientes.IdRequisicion;
                ManifiestoProveedoresClientes.IdProveedorRqInvitacion = pManifiestoProveedoresClientes.IdProveedorRqInvitacion;
                Requisicion requisicion = new Requisicion();
                requisicion.oManifiestoProveedoresClientes = ManifiestoProveedoresClientes;
                TempData["IdProveedorRqInvitacion"] = pManifiestoProveedoresClientes.IdProveedorRqInvitacion;
                TempData["IdRequisicion"] = pManifiestoProveedoresClientes.IdRequisicion;
                return PartialView("Componentes/EditCLiente", requisicion);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult saveManifiestoProveedor(beManifiestosProveedores pManifiestosProveedores)
        {
            try
            {
           
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var ManifiestosProveedores = requisiciones.getManifiestosProveedores(pManifiestosProveedores.IdManifiestoProveedor);
                ManifiestosProveedores.CapitalContable = pManifiestosProveedores.AplicaCapitalContable == 1 ? pManifiestosProveedores.CapitalContable : 0;
                ManifiestosProveedores.Infraestructura = pManifiestosProveedores.Infraestructura;
                ManifiestosProveedores.AnnioExperiencia = pManifiestosProveedores.AnnioExperiencia;
                ManifiestosProveedores.NumeroEmpleados = pManifiestosProveedores.NumeroEmpleados;
                ManifiestosProveedores.Domicilio = pManifiestosProveedores.Domicilio;
                ManifiestosProveedores.AplicaCapitalContable = pManifiestosProveedores.AplicaCapitalContable;
                ManifiestosProveedores.IngresosUltimoAnnio = pManifiestosProveedores.IngresosUltimoAnnio;
                ManifiestosProveedores.FechaRegistro = DateTime.Now;
                requisiciones.saveManifiestosProveedores(ManifiestosProveedores);

                TempData["IdProveedorRqInvitacion"] = pManifiestosProveedores.IdProveedorRqInvitacion;

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult saveManifiestoProveedorCliente(beManifiestoProveedoresClientes pManifiestoProveedoresClientes)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();

                if (pManifiestoProveedoresClientes.IdManifiestoProveedorCliente == 0)
                    requisiciones.saveManifiestoProveedorCliente(pManifiestoProveedoresClientes);
                else
                    requisiciones.saveEditManifiestoProveedorCliente(pManifiestoProveedoresClientes);
                TempData["IdProveedorRqInvitacion"] = pManifiestoProveedoresClientes.IdProveedorRqInvitacion;

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult deleteManifiestoProveedorCliente(beManifiestoProveedoresClientes pManifiestoProveedoresClientes)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                requisiciones.deleteManifiestoProveedorCliente(pManifiestoProveedoresClientes.IdManifiestoProveedorCliente);
                TempData["IdProveedorRqInvitacion"] = pManifiestoProveedoresClientes.IdProveedorRqInvitacion;

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult saveAceptarManifiestoProveedoresDeclaratorias(beManifiestoProveedoresDeclaratorias pManifiestoProveedoresDeclaratoria)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var a = requisiciones.getManifiestoProveedoresDeclaratorias(pManifiestoProveedoresDeclaratoria.IdManifiestoProveedorDeclaratoria);
                a.Aceptacion = pManifiestoProveedoresDeclaratoria.Aceptacion;
                requisiciones.saveManifiestoProveedoresDeclaratorias(a);

                TempData["IdProveedorRqInvitacion"] = pManifiestoProveedoresDeclaratoria.IdProveedorRqInvitacion;
                TempData["IdRequisicion"] = pManifiestoProveedoresDeclaratoria.IdRequisicion;
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult validarPropuestaTecnica()
        {

            try
            {
                var IdRequisicion = (int)TempData["IdRequisicion"];
                var IdProveedorRqInvitacion = (int)TempData["IdProveedorRqInvitacion"];

                Requisicion requisicion = new Requisicion();
                ClsRequisiciones requisiciones = new ClsRequisiciones();

                if (IdRequisicion != 0)
                {
                    requisicion.lstCartas = requisiciones.listar_Cartas_x_IdProveedorRqInvitacion(IdProveedorRqInvitacion);
                    requisicion.lstRequisicionLotesIdRequisicion = requisiciones.getAllRequisicionLotes_x_IdProveedorRqInvitacion(IdProveedorRqInvitacion);
                    requisicion.oManifiestosProveedores = requisiciones.getManifiestosProveedores_x_IdProveedorRqInvitacion(IdProveedorRqInvitacion);
                    requisicion.lstManifiestoProveedoresClientes = requisiciones.getAllManifiestosProveedores_x_IdManifiestoProveedor(requisicion.oManifiestosProveedores.IdManifiestoProveedor);
                    requisicion.lstManifiestoProveedoresDeclaratorias = requisiciones.getAllManifiestoProveedoresDeclaratorias_x_IdManifiestoProveedor(requisicion.oManifiestosProveedores.IdManifiestoProveedor);
                }
                var canidadCartasSinAceptar = requisicion.lstCartas.Where(s => s.AceptacionCarta == false).Count();
                var cantidadRequisicionLotesSinAceptar = requisicion.lstRequisicionLotesIdRequisicion.Where(s => s.LoteOfertado == false).Count();
                var manifiestoProvedores = requisicion.oManifiestosProveedores.IdManifiestoProveedor == 0 ? "<div class='alert alert-danger' role='alert' style='margin-bottom: .2rem !important;'><span class='fa fa-exclamation-triangle fa-2x'></span><strong>Falta manifiesto por capturar</strong></div>" : "";
                var manifiestoProvedoreslst = requisicion.lstManifiestoProveedoresClientes.Count() == 0 ? "<div class='alert alert-danger' role='alert' style='margin-bottom: .2rem !important;'><span class='fa fa-exclamation-triangle fa-2x'></span><strong>Aún no se han capturado principales clientes de los últimos 2 ejercicios </strong></div>" : "";
                var cantiadManifiestoProveedoresDeclaratorias = requisicion.lstManifiestoProveedoresDeclaratorias.Where(s => s.Aceptacion == false).Count();
                var cadena = "";
                if (canidadCartasSinAceptar != 0)
                    cadena = "<div class='alert alert-danger' role='alert' style='margin-bottom: .2rem !important;'><span class='fa fa-exclamation-triangle fa-2x'></span>Faltan <strong>" + canidadCartasSinAceptar.ToString() + "</strong> cartas de cumplimiento por aceptar </div>";
                if (cantidadRequisicionLotesSinAceptar != 0)
                    cadena += "<div class='alert alert-danger' role='alert' style='margin-bottom: .2rem !important;'><span class='fa fa-exclamation-triangle fa-2x'></span>Faltan <strong>" + cantidadRequisicionLotesSinAceptar.ToString() + "</strong> lotes por ofertar</div>";
                if (manifiestoProvedores != "")
                    cadena += manifiestoProvedores;
                if (manifiestoProvedoreslst != "")
                    cadena += manifiestoProvedoreslst;
                if (cantiadManifiestoProveedoresDeclaratorias != 0)
                    cadena += "<div class='alert alert-danger' role='alert' style='margin-bottom: .2rem !important;'><span class='fa fa-exclamation-triangle fa-2x'></span>Faltan <strong>" + cantiadManifiestoProveedoresDeclaratorias.ToString() + "</strong> cartas declaratorias del solicitante por aceptar</div>";
                if (cadena == "")
                {
                    TempData["IdRequisicion"] = IdRequisicion;
                    TempData["IdProveedorRqInvitacion"] = IdProveedorRqInvitacion;
                    return Json(new { success = true, mensaje = "" }, JsonRequestBehavior.AllowGet);


                }

                else
                {
                    TempData["IdRequisicion"] = IdRequisicion;
                    TempData["IdProveedorRqInvitacion"] = IdProveedorRqInvitacion;
                    return Json(new { success = false, mensaje = cadena }, JsonRequestBehavior.AllowGet);

                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult savevalidarPropuestaTecnica()
        {

            try
            {
                var IdRequisicion = (int)TempData["IdRequisicion"];
                var IdProveedorRqInvitacion = (int)TempData["IdProveedorRqInvitacion"];
                var f = (ClsGenerica)Session["ClsGenerico"];
                ClsRequisiciones requisiciones = new ClsRequisiciones();

                var a = requisiciones.getProveedoresRequisicionesInvitacion(IdProveedorRqInvitacion);
                a.IdUsuaroEnviaPropuestaTecnica = (int)f.id2;
                a.FechaEnvioPropuestaTecnica = DateTime.Now;
                a.IdEstatusEnvioPropuestaTecnica = 2;
                requisiciones.saveProveedoresRequisicionesInvitacion(a);
                TempData["IdRequisicion"] = IdRequisicion;
                TempData["IdProveedorRqInvitacion"] = IdProveedorRqInvitacion;
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveEditLotePropuestaEconomica(beRequisicionesLotes pRequisicionLote)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                //var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                //pRequisicionLote.FechaRegistro = DateTime.Now;
                //pRequisicionLote.IdUsuarioRegistro = (int)a.id2;
                var a = requisiciones.getPropuestasTecnicaEconomicaLotes(pRequisicionLote.IdRequisicion);
                a.PrecioUnitarioOfertado = pRequisicionLote.PrecioUnitario;
                a.ImporteOfertado = pRequisicionLote.Cantidad * pRequisicionLote.PrecioUnitario;
                a.ImpuestoImporte = a.ImporteOfertado * a.ImpuestoPorcentaje;
                a.TotalOfertado = pRequisicionLote.ImporteMesnsualCImpuesto;
                if (pRequisicionLote.MesesServicio > 0)
                {
                    a.ImportePeriodo = a.ImporteOfertado * pRequisicionLote.MesesServicio;
                    a.ImpuestoPeriodo = a.ImportePeriodo * a.ImpuestoPorcentaje;
                    a.TotalPeriodo = (a.ImpuestoPeriodo + a.ImportePeriodo);
                }
                requisiciones.savePropuestasTecnicaEconomicaLotes(a);
                var lst = requisiciones.getAllRequisicionLotes_x_IdRequisicion(pRequisicionLote.IdRequisicion);
                return Json(new { success = true, data = lst }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult validarPropuestaEconomica()
        {

            try
            {
                var IdRequisicion = (int)TempData["IdRequisicion"];
                var IdProveedorRqInvitacion = (int)TempData["IdProveedorRqInvitacion"];

                Requisicion requisicion = new Requisicion();
                ClsRequisiciones requisiciones = new ClsRequisiciones();

                if (IdRequisicion != 0)
                {

                    requisicion.lstRequisicionLotesIdRequisicion = requisiciones.getAllRequisicionLotes_x_IdProveedorRqInvitacion(IdProveedorRqInvitacion).Where(s=> s.LoteOfertado== true).ToList();

                }

                var cantidadRequisicionLotesSinAceptar = requisicion.lstRequisicionLotesIdRequisicion.Where(s => s.PrecioUnitarioOfertado == 0).Count();

                var cadena = "";

                if (cantidadRequisicionLotesSinAceptar != 0)
                    cadena += "Faltan " + cantidadRequisicionLotesSinAceptar.ToString() + " lotes por ofertar</br>";

                if (cadena == "")
                {
                    TempData["IdRequisicion"] = IdRequisicion;
                    TempData["IdProveedorRqInvitacion"] = IdProveedorRqInvitacion;
                    return Json(new { success = true, mensaje = "" }, JsonRequestBehavior.AllowGet);


                }

                else
                {
                    TempData["IdRequisicion"] = IdRequisicion;
                    TempData["IdProveedorRqInvitacion"] = IdProveedorRqInvitacion;
                    return Json(new { success = false, mensaje = cadena }, JsonRequestBehavior.AllowGet);

                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult savePropuestaEconomica()
        {

            try
            {
                var IdRequisicion = (int)TempData["IdRequisicion"];
                var IdProveedorRqInvitacion = (int)TempData["IdProveedorRqInvitacion"];
                var f = (ClsGenerica)Session["ClsGenerico"];
                ClsRequisiciones requisiciones = new ClsRequisiciones();

                var a = requisiciones.getProveedoresRequisicionesInvitacion(IdProveedorRqInvitacion);
                a.IdUsuaroEnviaPropuestaEconomica = (int)f.id2;
                a.FechaEnvioPropuestaEconomica = DateTime.Now;
                a.IdEstatusEnvioPropuestaEconomica = 2;
                requisiciones.saveProveedoresRequisicionesInvitacion(a);
                TempData["IdRequisicion"] = IdRequisicion;
                TempData["IdProveedorRqInvitacion"] = IdProveedorRqInvitacion;
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult AutorizarRevisorPropuestaTecnicaEconomica(int id, int tipo)
        {
            try
            {
                //IdProveedorRqInvitacion
                if (id != 0)
                {
                    var brProvReqIn = new brProveedoresRequisicionesInvitacion();
                    var ProvRqIn = brProvReqIn.traerProveedoresRequisicionesInvitacion_x_IdProveedorRqInvitacion(id);
                    var result = "";
                    if (tipo == 3)
                    {
                        ProvRqIn.IdEstatusEnvioPropuestaTecnica = 3;
                        result = (brProvReqIn.actualizarProveedoresRequisicionesInvitacion(ProvRqIn) == 0 ? "Se ha recibido correctamente la propuesta técnica" : "No se ha podido recibir la propuesta técnica");
                    }
                    else if (tipo == 4)
                    {
                        ProvRqIn.IdEstatusEnvioPropuestaEconomica = 3;
                        result = (brProvReqIn.actualizarProveedoresRequisicionesInvitacion(ProvRqIn) == 0 ? "Se ha recibido correctamente la propuesta económica" : "No se ha podido recibir la propuesta económica");
                    }
                    else
                    {
                        result = "Ha ocurrido un error durante la recepción de la propuesta";
                    }
                    TempData["IdTipoProceso"] = tipo;
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    return Json("Datos no válidos", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult saveDictamenPropuestaTecnicaSolictante(beProveedoresRequisicionesInvitacion oProveedoresRequisicionesInvitacion)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, mensaje = ModelState.Values.SelectMany(b=>b.Errors) }, JsonRequestBehavior.AllowGet);
                }
                ClsRequisiciones requisiciones = new ClsRequisiciones();

                var a = requisiciones.getProveedoresRequisicionesInvitacion(oProveedoresRequisicionesInvitacion.IdProveedorRqInvitacion);

                a.CartasDependenciaCumple = oProveedoresRequisicionesInvitacion.CartasDependenciaCumple;
                a.CartaFundamento = oProveedoresRequisicionesInvitacion.CartasDependenciaCumple == false ? oProveedoresRequisicionesInvitacion.CartaFundamento == null ? "" : oProveedoresRequisicionesInvitacion.CartaFundamento : "";
                a.CartaAdquisicionCumple = oProveedoresRequisicionesInvitacion.CartaAdquisicionCumple;
                a.CartasAdqObservacion = oProveedoresRequisicionesInvitacion.CartaAdquisicionCumple == true ? oProveedoresRequisicionesInvitacion.CartasAdqObservacion==null?"": oProveedoresRequisicionesInvitacion.CartasAdqObservacion : "";
                a.CondicionEntregaDependenciaCumple = oProveedoresRequisicionesInvitacion.CondicionEntregaDependenciaCumple;
                a.CondicionEntregaFundamento = !a.CondicionEntregaDependenciaCumple == false ? oProveedoresRequisicionesInvitacion.CondicionEntregaFundamento==null?"": oProveedoresRequisicionesInvitacion.CondicionEntregaFundamento : "";
                a.CondicionEntregaAdquisicionCumple = oProveedoresRequisicionesInvitacion.CondicionEntregaAdquisicionCumple;
                a.CondicionEntregaAdqObservacion = !a.CondicionEntregaAdquisicionCumple == true ? oProveedoresRequisicionesInvitacion.CondicionEntregaAdqObservacion==null? "": oProveedoresRequisicionesInvitacion.CondicionEntregaAdqObservacion : "";
                a.CondicionPagoDependenciaCumple = oProveedoresRequisicionesInvitacion.CondicionPagoDependenciaCumple;
                a.CondicionPagoFundamento = !a.CondicionPagoDependenciaCumple == false ? oProveedoresRequisicionesInvitacion.CondicionPagoFundamento==null?"": oProveedoresRequisicionesInvitacion.CondicionPagoFundamento : "";
                a.CondicionPagoAdquisicionCumple = oProveedoresRequisicionesInvitacion.CondicionPagoAdquisicionCumple;
                a.CondicionPagoAdqObservacion = !a.CondicionPagoAdquisicionCumple == true ? oProveedoresRequisicionesInvitacion.CondicionPagoAdqObservacion==null?"": oProveedoresRequisicionesInvitacion.CondicionPagoAdqObservacion : "";
                a.ManifiestoDependenciaCumple = oProveedoresRequisicionesInvitacion.ManifiestoDependenciaCumple;
                a.ManifiestoFundamento = !a.ManifiestoDependenciaCumple == false ? oProveedoresRequisicionesInvitacion.ManifiestoFundamento== null?"": oProveedoresRequisicionesInvitacion.ManifiestoFundamento : "";
                a.ManifiestoAdquisicionCumple = oProveedoresRequisicionesInvitacion.ManifiestoAdquisicionCumple;
                a.ManifiestoAdqObservacion = !a.ManifiestoAdquisicionCumple == true ? oProveedoresRequisicionesInvitacion.ManifiestoAdqObservacion==null?"": oProveedoresRequisicionesInvitacion.ManifiestoAdqObservacion : "";
                requisiciones.saveProveedoresRequisicionesInvitacion(a);

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveEditLoteDictamenPropuestaTecnicaSolicitante(bePropuestasTecnicaEconomicaLotes pRequisicionLote)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var a = requisiciones.getPropuestasTecnicaEconomicaLotes(pRequisicionLote.IdPropuestaTecnicaEconomica);
                a.DependenciaCumple = pRequisicionLote.DependenciaCumple;
                a.FundamentoLegal = pRequisicionLote.DependenciaCumple ? "" : pRequisicionLote.FundamentoLegal==null?"": pRequisicionLote.FundamentoLegal;
                a.AdquisicionCumple = pRequisicionLote.AdquisicionCumple;
                a.AdquisicionObserva = pRequisicionLote.AdquisicionCumple ? "" : pRequisicionLote.AdquisicionObserva==null?"": pRequisicionLote.AdquisicionObserva;
                requisiciones.savePropuestasTecnicaEconomicaLotes(a);
                var lst = requisiciones.getAllRequisicionLotes_x_IdRequisicion(pRequisicionLote.IdRequisicion);
                return Json(new { success = true, data = lst }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult saveEnviarDictamenPropuestaTecnicaSolictante(beProveedoresRequisicionesInvitacion oProveedoresRequisicionesInvitacion)
        {

            try
            {

                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var f = (ClsGenerica)Session["ClsGenerico"];
                var a = requisiciones.getProveedoresRequisicionesInvitacion(oProveedoresRequisicionesInvitacion.IdProveedorRqInvitacion);
                a.IdEstatusEnvioPropuestaEconomica = 5;
                a.IdEstatusEnvioPropuestaTecnica = 5;
                a.IdUsuaroEnviaPropuestaEconomica = (int)f.id2;
                a.IdUsuaroEnviaPropuestaTecnica = (int)f.id2;
                a.FechaEnvioPropuestaTecnica = DateTime.Now;
                a.FechaEnvioPropuestaEconomica = DateTime.Now;
                requisiciones.saveProveedoresRequisicionesInvitacion(a);

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult saveAceptarDictamenTecnico(beProveedoresRequisicionesInvitacion oProveedoresRequisicionesInvitacion)
        {

            try
            {

                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var f = (ClsGenerica)Session["ClsGenerico"];
                var a = requisiciones.getProveedoresRequisicionesInvitacion(oProveedoresRequisicionesInvitacion.IdProveedorRqInvitacion);
                a.IdEstatusEnvioPropuestaEconomica = oProveedoresRequisicionesInvitacion.IdEstatusEnvioPropuestaEconomica;
                a.IdEstatusEnvioPropuestaTecnica = oProveedoresRequisicionesInvitacion.IdEstatusEnvioPropuestaTecnica;
                a.IdUsuaroEnviaPropuestaEconomica = (int)f.id2;
                a.IdUsuaroEnviaPropuestaTecnica = (int)f.id2;
                a.FechaEnvioPropuestaTecnica = DateTime.Now;
                a.FechaEnvioPropuestaEconomica = DateTime.Now;
                requisiciones.saveProveedoresRequisicionesInvitacion(a);

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        
    }

}