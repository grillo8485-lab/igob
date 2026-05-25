using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IGOB.Areas.Catalogos.Models;
using IGOB.Models;
using iGob.ReglasNegocios;
using iGob.Entidades;

namespace IGOB.Controllers
{
    public class AdjudicacionesAutorizadasConsultaController : ValidaSession
    {
        private brAdjudicacionConsulta ObrAdjudicacionConsulta = new brAdjudicacionConsulta();
        private brAdjudicaciones ObrAdjudicaciones = new brAdjudicaciones();
        // GET: AdjudicacionesAutorizadasConsulta
        public ActionResult Index(int id=0)
        {
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            var a = ObrAdjudicacionConsulta.ListarAdjudicacionPerfilAdjudicacionEstatusAutorizadas(id, (int)b.id, b.id4);//pIdLista,pIdPerfil,pIdDependencia
            ViewBag.tipoAdjudicacion = id;
            ViewBag.IdPerfil = b.id;
            return View(a);
        }

        public ActionResult RecibirPropuestaTecnica(int id)
        {
            TempData["TipoPropuesta"] = 1;
            return RedirectToAction("Index", "AdjudicacionesPropuestas", new { id = id });
        }

        public ActionResult RecibirPropuestaEconomica(int id)
        {
            TempData["TipoPropuesta"] = 2;
            return RedirectToAction("Index", "AdjudicacionesPropuestas", new { id = id });
        }

        public ActionResult AsignarRevisorIndex(int id, int tipo)
        {
            ClsAdquisicion adquisicion = new ClsAdquisicion();
            Adjudicacion adjudicacion = new Adjudicacion();
            brAdjudicaciones ObrAdjudicaciones = new brAdjudicaciones();
            brCapitulos capitulo = new brCapitulos();

            ViewBag.TipoPropuesta = TempData.ContainsKey("TipoPropuesta") ? int.Parse(TempData["TipoPropuesta"].ToString()) : 0;
            var c = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            ViewBag.IdPerfil = c.id;
            ViewBag.Dependencia = adquisicion.GetDependencia_x_IdDependencia(c.id4);
            ViewBag.tipoAdjudicacion = tipo;
            ViewBag.IdAdjudicacion = id;

            /* DATOS GENERALES */
            ViewBag.TiposAdjudicaciones = new SelectList(adquisicion.getTiposAdjudicacion(), "IdTipoAdjudicacion", "TipoAdjudicacion", tipo);
            ViewBag.ejercicioActual = adquisicion.getEjercicioFiscal();
            
            /* Attr ADJUDICACION */
            adjudicacion.oAdjudicaciones = ObrAdjudicaciones.traerAdjudicaciones_x_IdAdjudicacion(id);
            if (adjudicacion.oAdjudicaciones.IdAdjudicacion != 0)
            {
                ViewBag.SolList = new SelectList(adquisicion.TiposSolicitud(), "IdTipoSolicitud", "TipoSolicitud", adjudicacion.oAdjudicaciones.IdTipoSolicitud);
                ViewBag.OrigenAdjudicacion = adquisicion.GetOrigenRecurso_x_IdAdjudicacion(adjudicacion.oAdjudicaciones.IdOrigenRecurso);
                ViewBag.EjercicioAdjudicacion = adquisicion.GetEjercicioFiscal_x_IdAdjudicacion(adjudicacion.oAdjudicaciones.IdEjercicioFiscal);
                ViewBag.Partida = adquisicion.GetPartida_x_Id(adjudicacion.oAdjudicaciones.IdPartida);
                ViewBag.OrigenRecurso = adquisicion.GetOrigenRecurso_x_IdAdjudicacion(adjudicacion.oAdjudicaciones.IdOrigenRecurso);
                var t = adquisicion.getCapitulo_x_IdPartida(adjudicacion.oAdjudicaciones.IdPartida);
                ViewBag.CapList = t;
                ViewBag.Solicitante = new brDependencias().traerDependencias_x_IdDependencia(adjudicacion.oAdjudicaciones.IdDependencia).Dependencia;
                ViewBag.UsuarioSolicitante = new brSysUsuarios().traerSysUsuarios_x_IdUsuario(adjudicacion.oAdjudicaciones.IdUsuarioRegistro);
                ViewBag.adjudicacionefirmante = new brAdjudicacionesFirmantes().listarTodos_AdjudicacionesFirmantes().FirstOrDefault(x=>x.IdAdjudicacion==adjudicacion.oAdjudicaciones.IdAdjudicacion);
                switch (c.id)
                {
                    case 5:
                        if (adjudicacion.oAdjudicaciones.IdEstatusAdjudicacion == 130)
                        {
                            ViewBag.Activo = (adjudicacion.oAdjudicaciones.IdUsuarioAsignante != 0 && adjudicacion.oAdjudicaciones.IdUsuarioRevisor != 0) ? "disabledClick" : "";
                        }
                        else if (adjudicacion.oAdjudicaciones.IdEstatusAdjudicacion != 90)
                        {
                            ViewBag.Activo = "disabledClick";
                        }
                        break;
                    case 7:
                        ViewBag.Activo = (adjudicacion.oAdjudicaciones.IdEstatusAdjudicacion == 80) ? "" : "disabledClick";
                        break;
                }
                ViewBag.ActivoRevisor = adjudicacion.oAdjudicaciones.IdEstatusAdjudicacion;
            }
            //funciones Asignacion de Revisor
            ViewBag.ComboRevisor = new SelectList(new ClsUsuario().Usuarios_Traer_IdPerfil(7), "IdUsuario", "Usuario", (adjudicacion.oAdjudicaciones.IdUsuarioRevisor != 0) ? adjudicacion.oAdjudicaciones.IdUsuarioRevisor.ToString() : "");
            
            return View(adjudicacion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateDirectorAdquisicion(beAdjudicaciones Oadj, int tipo=0)
        {
            var Result = "";
            try
            {
                var adj = ObrAdjudicaciones.traerAdjudicaciones_x_IdAdjudicacion(Oadj.IdAdjudicacion);
                if (tipo == 1 && Oadj.IdAdjudicacion!= 0 && Oadj.IdUsuarioRevisor == 0 && Oadj.IdUsuarioAsignante == 0)
                {
                    adj.IdEstatusAdjudicacion = 100;
                    adj.AcuerdoAutorizacionComite = Oadj.AcuerdoAutorizacionComite;
                    var adjResult = ObrAdjudicaciones.actualizarAdjudicaciones(adj);
                    Result = (adjResult == 0 ? "Se asignó número de acuerdo de comité" : "No se pudo asignar número de comité");
                    var tablapedido = new brAdjudicacionesPedidos().listarTodos_AdjudicacionesPedidos().FirstOrDefault(x => x.IdAdjudicacion == Oadj.IdAdjudicacion);
                    if (tablapedido == null)
                    {
                        var estate = new brAdjudicacionLiberarPedido().GenerarPedidosAdjudicaciones_x_IdAdjudicacion(Oadj.IdAdjudicacion);
                    }
                }
                else{
                    adj.IdUsuarioRevisor = Oadj.IdUsuarioRevisor;
                    adj.IdUsuarioAsignante = Oadj.IdUsuarioAsignante;
                    adj.FechaAsignaRevisor = DateTime.Now;
                    adj.IdEstatusAdjudicacion = 80;
                    var adjResult = ObrAdjudicaciones.actualizarAdjudicaciones(adj);
                    Result = (adjResult == 0 ? "Se asignó revisor" : "No se pudo asignar el revisor");
                }
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                Result = "Error: " + e.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateAdjudicacionAutorizaRevisor(int id, beAdjudicacionesFirmantes ObrAdjudicacionesFirmantes,int tipo=0)
        {
            var Result = "";
            brAdjudicacionesFirmantes updateFirmante = new brAdjudicacionesFirmantes();
            try
            {
                var OAdjFirma = updateFirmante.traerAdjudicacionesFirmantes_x_IdAdjudicacionFirmante(ObrAdjudicacionesFirmantes.IdAdjudicacionFirmante);
                OAdjFirma.ObservacionCondPagoRevisor = ObrAdjudicacionesFirmantes.ObservacionCondPagoRevisor;
                OAdjFirma.ObservacionConEntregaRevisor = ObrAdjudicacionesFirmantes.ObservacionConEntregaRevisor;
                OAdjFirma.ObservacionLotesRevisor = ObrAdjudicacionesFirmantes.ObservacionLotesRevisor;
                OAdjFirma.ValidaLotesRevisor = ObrAdjudicacionesFirmantes.ValidaLotesRevisor;
                OAdjFirma.ValidaCondicionPagoRevisor = ObrAdjudicacionesFirmantes.ValidaCondicionPagoRevisor;
                OAdjFirma.ValidaCondicionEntregaRevisor = ObrAdjudicacionesFirmantes.ValidaCondicionEntregaRevisor;
                var statusadjudicacionfirmante = updateFirmante.actualizarAdjudicacionesFirmantes(OAdjFirma);
                var adj = ObrAdjudicaciones.traerAdjudicaciones_x_IdAdjudicacion(id);
                if (tipo == 1) {
                    adj.IdEstatusAdjudicacion = 90;
                    var adjResult = ObrAdjudicaciones.actualizarAdjudicaciones(adj);
                    Result = (adjResult == 0 ? "Revisión guardada" : "No se pudo guardar la revisión");
                }
                else if(tipo == 2){
                    adj.IdEstatusAdjudicacion = 50;
                    var adjResult = ObrAdjudicaciones.actualizarAdjudicaciones(adj);
                    Result = (adjResult == 0 ? "Revisión rechazada" : "No se pudo rechazar");
                }
                else
                {
                    Result = "La acción no se pudo realizar";
                }
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Result = "Error: " + e.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ElaborarPedido(int id)
        {
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            //liberacion de pedido
            var adjudicacionpedido = new brAdjudicacionesPedidos().listarTodos_AdjudicacionesPedidos().FirstOrDefault(x => x.IdAdjudicacion == id);
            var adjudicacionpedidodetalle = new brAdjudicacionesPedidosDetalles().listarTodos_AdjudicacionesPedidosDetalles().Where(x => x.IdAdjudicacionPedido == adjudicacionpedido.IdAdjudicacionPedido).ToList();
            var adjudicacion = ObrAdjudicaciones.traerAdjudicaciones_x_IdAdjudicacion(id);
            ViewBag.adjudicacionpedido = adjudicacionpedido;
            List<beAdjudicacionesPedidosFirmantes> adjudicacionpedidoFirmante = new brAdjudicacionesPedidosFirmantes().listarTodos_AdjudicacionesPedidosFirmantes().Where(x => x.IdAdjudicacionPedido == adjudicacionpedido.IdAdjudicacionPedido).ToList();
            ViewBag.adjudicacionpedidodetalle = adjudicacionpedidodetalle;
            ViewBag.Titulo = "Liberación de pedido: " + adjudicacionpedido.Folio + " adjudicación " + adjudicacion.AdjudicacionFolio + " - " + (new brDependencias().traerDependencias_x_IdDependencia(adjudicacion.IdDependencia).Dependencia) + " liberar pedido";
            //botones 
            var disabledbuttons = "";
            if (b.id == 4 || b.id == 8 || b.id == 5)
            {
                var adjpedido = new brAdjudicacionesPedidosFirmantes().listarTodos_AdjudicacionesPedidosFirmantes().FirstOrDefault(x => x.IdAdjudicacionPedido == adjudicacionpedido.IdAdjudicacionPedido && x.IdPerfil == b.id);
                ViewBag.adjudicacionpedidofirmante = adjpedido;
                disabledbuttons = (adjpedido != null ? (adjpedido.IdUsuarioFirmante > 0 && adjudicacion.IdEstatusAdjudicacion == 140 ? "disabled" : "") : "");
            }
            ViewBag.disabled = disabledbuttons;
            var jfdp = adjudicacionpedidoFirmante[0].IdEstatusFirmaPedido;//4
            var sccm = adjudicacionpedidoFirmante[1].IdEstatusFirmaPedido;//5 director adquisiciones=secretario comité
            var prov = adjudicacionpedidoFirmante[2].IdEstatusFirmaPedido;//8
            var disabledFirmante = true;
            switch ((int)b.id)
            {
                case 4:
                    break;
                case 5:
                    disabledFirmante = (jfdp == 2 ? true : false);
                    break;
                case 8:
                    disabledFirmante = (sccm == 2 ? true : false);
                    break;
            }
            ViewBag.OrdenFirmante = disabledFirmante;
            //datos proveedor
            var adjudicacionproveedor = new brAdjudicacionesProveedores().traerAdjudicacionesProveedores_x_IdAdjudicacionProveedor(adjudicacionpedido.IdAdjudicacionProveedor);
            var proveedor = new brProveedores().traerProveedores_x_IdProveedor(adjudicacionproveedor.IdProveedor);
            var municipio = new brEF_Municipios().traerEF_Municipios_x_IdMunicipio(proveedor.IdMunicipio);
            var estado = new brEF_EntidadesFederativas().traerEF_EntidadesFederativas_x_ClaveEstado(municipio.ClaveEstado);
            ViewBag.proveedor = proveedor;
            ViewBag.Estado = estado;
            ViewBag.Municipio = municipio;
            ViewBag.Pais = new brEF_Paises().traerEF_Paises_x_IdPais(estado.IdPais);
            //partida concepto
            ViewBag.Partida = new ClsAdquisicion().GetPartida_x_Id(adjudicacion.IdPartida);

            //entrega pago
            var condicionespagoentrega = new brCondicionesPagosEntrega().listarTodos_CondicionesPagosEntrega();
            var plazotiempos = new brPlazosTiempos().listarTodos_PlazosTiempos();
            var tiposdias = new brTiposDias().listarTodos_TiposDias();

            //datos entrega
            ViewBag.Dependencia = new brDependencias().traerDependencias_x_IdDependencia(adjudicacion.IdDependencia);
            var adjudicacionentrega = new brAdjudicacionesCondicionesEntregas().listarTodos_AdjudicacionesCondicionesEntregas().FirstOrDefault(x => x.IdAdjudicacion == adjudicacion.IdAdjudicacion);
            ViewBag.AdjEntrega = adjudicacionentrega;
            ViewBag.AdjEntreDetalle = new brAdjudicacionesCondicionesEntregasDetalles().listarTodos_AdjudicacionesCondicionesEntregasDetalles().FirstOrDefault(x => x.IdAdjudicacionCondicionEntrega == adjudicacionentrega.IdAdjudicacionCondicionEntrega);
            ViewBag.condicionentrega = new brTiposEntregas().traerTiposEntregas_x_IdTipoEntrega(adjudicacionentrega.IdTipoEntrega);
            ViewBag.PlazosTiemposEntrega = plazotiempos.FirstOrDefault(x => x.IdPlazoTiempo == adjudicacionentrega.IdPlazoTiempo);
            ViewBag.TiposDiasEntrega = tiposdias.FirstOrDefault(x => x.IdTipoDia == adjudicacionentrega.IdTipoDia);
            ViewBag.PlazoEntrega = new brPlazosEntregas().traerPlazosEntregas_x_IdPlazoEntrega(adjudicacionentrega.IdPlazoEntegra);

            //datos pago
            var adjudicacionpago = new brAdjudicacionesCondicionesPagos().listarTodos_AdjudicacionesCondicionesPagos().FirstOrDefault(x => x.IdAdjudicacion == adjudicacion.IdAdjudicacion);
            var tipocondicionpago = condicionespagoentrega.FirstOrDefault(x=>x.IdCondicion==adjudicacionpago.IdTipoCondicionPago && x.Activo==true);
            ViewBag.Adjudicacionpago = adjudicacionpago;
            ViewBag.AdjPagoDetalle = new brAdjudicacionesCondicionesPagosDetalles().listarTodos_AdjudicacionesCondicionesPagosDetalles().FirstOrDefault(x => x.IdAdjudicacionCondicionPago == adjudicacionpago.IdAdjudicacionCondicionPago);
            ViewBag.PlazosTiemposPago = plazotiempos.FirstOrDefault(x => x.IdPlazoTiempo == adjudicacionpago.IdPlazoTiempo);
            ViewBag.TiposDiasPago = tiposdias.FirstOrDefault(x => x.IdTipoDia == adjudicacionpago.IdTipoDia);
            ViewBag.tipocondicionpago = tipocondicionpago;
            
            //tabla adjudicaciones condiciones de entrega detalle
            var ListadoLotesAdjudicacionesLiberarPedido = new brAdjudicacionLiberarPedido().ListadoLotesAdjudicacionesLiberarPedido(adjudicacionpedido.IdAdjudicacionPedido);
            ViewBag.SubTotal = ListadoLotesAdjudicacionesLiberarPedido.Sum(s => s.TotalPeriodo);//s.Importe 
            ViewBag.Impuesto = ListadoLotesAdjudicacionesLiberarPedido.Sum(s => s.ImpuestoImporte);//s.ImporteIva
            ViewBag.Total = ViewBag.SubTotal + ViewBag.Impuesto;

            ViewBag.ListAdjCondEntDet = ListadoLotesAdjudicacionesLiberarPedido;
            ViewBag.IdPerfil = b.id;
            ViewBag.IdAdjudicacion = id;
            return View(adjudicacion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateAdjudicacionLiberarPedido(int id)
        {
            var resultado = "";
            try
            {
                //var estate = new brAdjudicacionLiberarPedido().GenerarPedidosAdjudicaciones_x_IdAdjudicacion(id);
                var adj = ObrAdjudicaciones.traerAdjudicaciones_x_IdAdjudicacion(id);
                adj.IdEstatusAdjudicacion = 140;
                var upsate = ObrAdjudicaciones.actualizarAdjudicaciones(adj);
                resultado = (upsate == 0 ? "Pedido liberado" : "No se pudo liberar el pedido");
            }
            catch (Exception e)
            {
                resultado = e.Message;
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateLiberarPedidoFirma(int id)
        {
            var resultado = "";
            try
            {
                var c = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                var Oap = new brAdjudicacionesPedidos();
                var adjpedidoF = new brAdjudicacionesPedidosFirmantes().listarTodos_AdjudicacionesPedidosFirmantes().FirstOrDefault(x=>x.IdAdjudicacionPedido==id && x.IdPerfil == c.id);
                adjpedidoF.IdEstatusFirmaPedido = 2;
                adjpedidoF.IdUsuarioFirmante = (int)c.id2;
                adjpedidoF.FechaFirma = DateTime.Now;
                if (c.id == 8) {
                    var oadjpedido = Oap.traerAdjudicacionesPedidos_x_IdAdjudicacionPedido(adjpedidoF.IdAdjudicacionPedido);
                    oadjpedido.IdEstatusPedido = 2;
                    oadjpedido.IdUsuarioRegistro = (int)c.id2;
                    var adjpedido = Oap.actualizarAdjudicacionesPedidos(oadjpedido);
                }
                var upsate = new brAdjudicacionesPedidosFirmantes().actualizarAdjudicacionesPedidosFirmantes(adjpedidoF);
                resultado = (upsate == 0 ? "Pedido autorizado" : "No se pudo autorizar el pedido");
            }
            catch (Exception e)
            {
                resultado = e.Message;
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DescargaPedido(int IdAdjudicacionPedido)
        {
            ClsImprimirRepAdjudicacionPedido Print = new ClsImprimirRepAdjudicacionPedido();
            byte[] abytes = Print.PrepararReporte(IdAdjudicacionPedido);
            return File(abytes, "application/pdf");
        }
    }
}