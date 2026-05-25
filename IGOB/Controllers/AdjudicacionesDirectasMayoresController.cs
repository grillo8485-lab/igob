using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.Controllers;
using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;
using IGOB.Models;
using System.IO;

namespace IGOB.Controllers
{
    public class AdjudicacionesDirectasMayoresController : ValidaSession
    {
        // GET: AdjudicacionesDirectasMayores
        ClsAdquisicion adquisicion = new ClsAdquisicion();
        Adjudicacion adjudicacion = new Adjudicacion();
        brAdjudicaciones ObrAdjudicaciones = new brAdjudicaciones();

        public ActionResult Index(int id, int tipo)//propuesta 1=Tecnica, 2=Economica
        {
            ViewBag.TipoPropuesta = TempData.ContainsKey("TipoPropuesta") ? int.Parse(TempData["TipoPropuesta"].ToString()) : 0;
            var c = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            ViewBag.IdPerfil = c.id;
            ViewBag.Dependencia = adquisicion.GetDependencia_x_IdDependencia(c.id4);
            ViewBag.tipoAdjudicacion = tipo;
            ViewBag.Formulario = "DatosGenerales";

            /* DATOS GENERALES */
            ViewBag.TiposAdjudicaciones = new SelectList(adquisicion.getTiposAdjudicacion(), "IdTipoAdjudicacion", "TipoAdjudicacion", tipo);

            ViewBag.CapList = new SelectList(adquisicion.getAllCapitulos(), "IdCapitulo", "Capitulo");
            ViewBag.SolList = new SelectList(adquisicion.TiposSolicitud(), "IdTipoSolicitud", "TipoSolicitud");
            ViewBag.lstPartidas = new SelectList(new List<bePartidas>(), "IdCapitulo", "Capitulo");
            ViewBag.ejercicioActual = adquisicion.getEjercicioFiscal();
            ViewBag.Diferencia = 0;

            /* Attr ADJUDICACION */

            adjudicacion.oAdjudicaciones = ObrAdjudicaciones.traerAdjudicaciones_x_IdAdjudicacion(id);

            if (adjudicacion.oAdjudicaciones.IdAdjudicacion != 0)
            {
                ViewBag.SolList = new SelectList(adquisicion.TiposSolicitud(), "IdTipoSolicitud", "TipoSolicitud", adjudicacion.oAdjudicaciones.IdTipoSolicitud);
                ViewBag.Diferencia = adjudicacion.oAdjudicaciones.MontoAproximado - adjudicacion.oAdjudicaciones.MontoAproximadoAutorizado;

                ViewBag.EjercicioAdjudicacion = adquisicion.GetEjercicioFiscal_x_IdAdjudicacion(adjudicacion.oAdjudicaciones.IdEjercicioFiscal);
                ViewBag.OrigenAdjudicacion = adquisicion.GetOrigenRecurso_x_IdAdjudicacion(adjudicacion.oAdjudicaciones.IdOrigenRecurso);


                /* PRESUPUESTO Y LIQUIDEZ */

                ViewBag.totalMontoComprometido = adquisicion.Sum_MontoComprometido_x_IdAdjudicacion(adjudicacion.oAdjudicaciones.IdAdjudicacion);
                ViewBag.Dependencia = adquisicion.GetDependencia_x_IdDependencia(adjudicacion.oAdjudicaciones.IdDependencia);
                ViewBag.MontoPresupuestadoAutorizado = adquisicion.GetMontoPresupuestadoAutorizado_x_IdAdjudicacion(adjudicacion.oAdjudicaciones.IdAdjudicacion);

                /* Presupuesto */
                ViewBag.Partida = adquisicion.GetPartida_x_Id(adjudicacion.oAdjudicaciones.IdPartida);
                ViewBag.MontoSolicitado = adquisicion.Monto_Solicitado(adjudicacion.oAdjudicaciones.IdAdjudicacion);
                ViewBag.SaldoPartida = adquisicion.Saldo_Presupuestado_Autorizado(adjudicacion.oAdjudicaciones.IdPartida, adjudicacion.oAdjudicaciones.IdDependencia);
                ViewBag.MontoAutorizado = adquisicion.Monto_Aproximado_Autorizado(adjudicacion.oAdjudicaciones.IdAdjudicacion);

                /* Claves Presupuestales */
                var IdPartida = adquisicion.GetIdPartida_x_IdAdjudicacion(adjudicacion.oAdjudicaciones.IdAdjudicacion);
                //var PresupuestosPartidas = adquisicion.GetPresupuestoPartida_x_IdPartida_IdDependencia_IdEjercicioFiscal(IdPartida, c.id4, adjudicacion.oAdjudicaciones.IdEjercicioFiscal);

                var PresupuestosPartidas = new bePresupuestosPartidas();
                if ((int)c.id != 3)
                {
                    PresupuestosPartidas = adquisicion.GetPresupuestoPartida_x_IdPartida_IdDependencia_IdEjercicioFiscal(IdPartida, adjudicacion.oAdjudicaciones.IdDependencia, adjudicacion.oAdjudicaciones.IdEjercicioFiscal);
                }
                else
                {
                    PresupuestosPartidas = adquisicion.GetPresupuestoPartida_x_IdPartida_IdDependencia_IdEjercicioFiscal(IdPartida, c.id4, adjudicacion.oAdjudicaciones.IdEjercicioFiscal);
                }

                ViewBag.ODetalles = adquisicion.OClavesPresupuestalesDetalles(PresupuestosPartidas.IdPresupuestoPartida);
                ViewBag.Noministracion = PresupuestosPartidas.NumeroMinistracion;

                /* Liquidez */
                var ORList = adquisicion.listarTodos_OrigenRecurso().ToList();

                ViewBag.ORList = new SelectList(ORList, "IdOrigenRecurso", "OrigenRecurso");
                ViewBag.Licitaciones = adquisicion.TraerLiquidez_x_IdAdjudicacion(adjudicacion.oAdjudicaciones.IdAdjudicacion);
                ViewBag.IdEstatusAdjudicacion = adjudicacion.oAdjudicaciones.IdEstatusAdjudicacion;


                /* LOTES */


                if (TempData.ContainsKey("TipoPropuesta") && c.id == 8)
                {
                    if (int.Parse(TempData["TipoPropuesta"].ToString()) == 2)
                    {
                        adjudicacion.lstAdjudicacionLotes_x_IdAdjudicacion = adquisicion.getAllAdjudicacionesProveedoresLotes_x_IdAdjudicacion(adjudicacion.oAdjudicaciones.IdAdjudicacion).Where(x=>x.IdProveedor==c.id6).Where(x=>x.ActivoLote==true).ToList();
                    }
                    if (int.Parse(TempData["TipoPropuesta"].ToString()) == 1)
                    {
                        adjudicacion.lstAdjudicacionLotes_x_IdAdjudicacion = adquisicion.getAllAdjudicacionesProveedoresLotes_x_IdAdjudicacion(adjudicacion.oAdjudicaciones.IdAdjudicacion).Where(x => x.IdProveedor == c.id6).ToList();
                    }
                }
                else
                {
                    adjudicacion.lstAdjudicacionLotes_x_IdAdjudicacion = adquisicion.getAllAdjudicacionLotes_x_IdAdjudicacion(adjudicacion.oAdjudicaciones.IdAdjudicacion);
                }
                ViewBag.redirecthere = "id=" + id + "&tipo=" + tipo;
                ViewBag.lstMesesDe = new SelectList(adquisicion.getMeses(), "IdMes", "Mes");
                ViewBag.lstMesesAl = new SelectList(adquisicion.getMeses(), "IdMes", "Mes");
                ViewBag.lstFrecuencias = new SelectList(adquisicion.geteFrecuencias(), "IdFrecuencia", "Frecuencia");
                ViewBag.lstRequerimiento = new SelectList(adquisicion.getAllRequerimientos(), "IdMuestra", "Muestra");

                adjudicacion.lstLiquidez = adquisicion.getallLiquidez_x_IdAdjudicacion(id);
                adjudicacion.sumLiquidez = adquisicion.sumLiquidez(adjudicacion.lstLiquidez);
                adjudicacion.sumAdjudicacionLote = adquisicion.sumAdjudicacionLote(adjudicacion.lstAdjudicacionLotes_x_IdAdjudicacion);

                /* CONDICIONES DE ENTREGA*/

                adjudicacion.condicionesDeEntrega = adquisicion.getAllAdjudicacionCondiconesDeEntrega_x_IdAdjudicacion(id);

                if (adjudicacion.condicionesDeEntrega != null)
                {
                    if (adjudicacion.condicionesDeEntrega.FechaLimite == DateTime.MinValue)
                    {
                        adjudicacion.condicionesDeEntrega.FechaLimite = DateTime.Now;
                    }
                    adjudicacion.lstAdjudicacionCondicionesEntregaDetalleConsulta = adquisicion.getAllCondicionesEntregasDetalles_x_IdAdjudicacionCondicionEntrega(adjudicacion.condicionesDeEntrega.IdAdjudicacionCondicionEntrega);

                }
                else {
                    adjudicacion.condicionesDeEntrega = new beAdjudicacionesCondicionesEntregas();

                }

                ViewBag.lstPlazoEntrega = new SelectList(adquisicion.getAllPlazosEntrega(), "IdPlazoEntrega", "PlazoEntrega", (id == 0 ? "0" : adjudicacion.condicionesDeEntrega.IdPlazoEntegra.ToString()));
                ViewBag.lstPlazoTiempo = new SelectList(adquisicion.getAllPlazoTiempos(), "IdPlazoTiempo", "PlazozTiempo", (id == 0 ? "0" : adjudicacion.condicionesDeEntrega.IdPlazoTiempo.ToString()));
                ViewBag.lstTiposEntrega = new SelectList(adquisicion.getAllTiposEntrega(), "IdTipoEntrega", "TipoEntrega", (id == 0 ? "0" : adjudicacion.condicionesDeEntrega.IdTipoEntrega.ToString()));
                ViewBag.lstTipoDia = new SelectList(adquisicion.getAllTiposDias(), "IdTipoDia", "TipoDia", (id == 0 ? "0" : adjudicacion.condicionesDeEntrega.IdTipoDia.ToString()));

                ViewBag.lstLotesPorAsignar = new SelectList(adquisicion.getAdjudicacionesCondicionesEntregasDetallesFaltantes_x_IdAdjudicacion(id), "IdLote", "CantidadLotesxAsignar");
                ViewBag.lstLugarEntregaFirma = new SelectList(adquisicion.getAllLugaresEntregaFirma(1), "IdLugarEntregaFirma", "Lugar");


                /* CONDICIONES DE PAGO */



                adjudicacion.datosFacturacion = adquisicion.getDatosFacturacion(adjudicacion.oAdjudicaciones.IdDependencia);
                adjudicacion.datos = adquisicion.getMunicipio_estado_pais(adjudicacion.datosFacturacion.IdMunicipio);
                adjudicacion.condicionPago = adquisicion.getCondiconPago_x_IdAdjudicacion(id);
                if (adjudicacion.condicionPago.FechaInicioPago == DateTime.MinValue)
                {
                    adjudicacion.condicionPago.FechaInicioPago = DateTime.Now;
                }
                adjudicacion.condicionPagoDetalle = adquisicion.getAllCondicionesPagoDetalle_x_IdCondicionPago(adjudicacion.condicionPago.IdAdjudicacionCondicionPago);

                ViewBag.lstPlazoTiempoPago = new SelectList(adquisicion.getAllPlazoTiempos(), "IdPlazoTiempo", "PlazozTiempo", (id == 0 ? "0" : adjudicacion.condicionPago.IdPlazoTiempo.ToString()));
                ViewBag.lstTipoDiaPago = new SelectList(adquisicion.getAllTiposDias(), "IdTipoDia", "TipoDia", (id == 0 ? "0" : adjudicacion.condicionPago.IdTipoDia.ToString()));
                ViewBag.lstCondicionPago = new SelectList(adquisicion.getCondicionesPagosEntrega(1), "IdCondicion", "Condicion", (id == 0 ? "0" : adjudicacion.condicionPago.IdTipoCondicionPago.ToString()));
                ViewBag.lstLugarPagoFirma = new SelectList(adquisicion.getAllLugaresEntregaFirma(2), "IdLugarEntregaFirma", "Lugar", (id == 0 ? "0" : adjudicacion.condicionPago.IdLugarFirma.ToString()));
                ViewBag.lstPais = new SelectList(adquisicion.getAllPaises(), "IdPais", "Pais", (id == 0 ? "0" : adjudicacion.datos.id.ToString()));
                ViewBag.lstEstado = new SelectList(adquisicion.getAllEstados((int)adjudicacion.datos.id), "ClaveEstado", "Estado", (id == 0 ? "0" : adjudicacion.datos.string2));
                ViewBag.lstMunicipio = new SelectList(adquisicion.getAllMunicipio(adjudicacion.datos.string2), "IdMunicipio", "Municipio", (id == 0 ? "0" : adjudicacion.datos.string1));
                ViewBag.lstAnticipo = new SelectList(adquisicion.getAllAnticipos(), "IdAnticipo", "AnticipoPorcentaje", (id == 0 ? "0" : (Convert.ToInt32(adjudicacion.condicionPago.PorcentajeAnticipo * 10 +1)).ToString()));
                ViewBag.lstPeriodicidad = new SelectList(adquisicion.getAllPeriodicidad(), "IdPeriodicidad", "Periodicidad", (id == 0 ? "0" : adjudicacion.condicionPago.IdPeriodicidad.ToString()));


                /* ASIGNAR PROVEEDORES*/

                adjudicacion.lstProveedoresxAsignar = adquisicion.getAllProveedores(adjudicacion.oAdjudicaciones.IdAdjudicacion, adjudicacion.oAdjudicaciones.IdPartida);


                /* FIRMANTES */

                ClsUsuario user = new ClsUsuario();
                var us = user.getUsuario_x_IdUsuario(adjudicacion.oAdjudicaciones.IdUsuarioRegistro);
                var adjFirm = adquisicion.getFirmante(adjudicacion.oAdjudicaciones.IdAdjudicacion);
                ViewBag.idUrsAut = c.id;
                ViewBag.idUsrSol = adjudicacion.oAdjudicaciones.IdUsuarioRegistro;
                ViewBag.idAdjudicacion = adjudicacion.oAdjudicaciones.IdAdjudicacion;
                ViewBag.NameSol = us.Nombres+" "+us.Apellidos;
                if (adjFirm == null)
                {
                    ViewBag.inactivo = "";
                    ViewBag.doc = "disabled";
                }
                else
                {
                    ViewBag.inactivo = "disabled";
                    ViewBag.doc = "";
                }
                ViewBag.adjFirm = adjFirm;

                /* PROVEEDORES */
                if ((int)c.id == 8)
                {
                    var IdAdjudicacionProveedor = adquisicion.getIdAdjudicacionProveedor_x_IdAdjudicacion_x_IdProveedor(id, c.id6);
                    var IdEstatusPropuesta = adquisicion.getIdEstatusEnvioPropuesta(IdAdjudicacionProveedor);
                    adjudicacion.isCheckTec = IdEstatusPropuesta.IdUsuaroEnviaPropuestaTecnica;
                    adjudicacion.isCheckEco = IdEstatusPropuesta.IdEstatusEnvioPropuestaEconomica;
                }
                
            }
            
            return View(adjudicacion);
        }

        [HttpGet]
        public ActionResult Tecnica(int id, int tipo)
        {
            TempData["TipoPropuesta"] = 1;
            return RedirectToAction("Index", "AdjudicacionesDirectasMayores", new { id = id, tipo = tipo });
        }

        [HttpGet]
        public ActionResult Economica(int id, int tipo)
        {
            TempData["TipoPropuesta"] = 2;
            return RedirectToAction("Index", "AdjudicacionesDirectasMayores", new { id = id, tipo = tipo });
        }

        [HttpGet]
        public JsonResult getAllPartidas_x_IdCapitulo(int pIdCapitulo)
        {
            try
            {
                var b = adquisicion.getAllPartidas_x_IdCapitulo(pIdCapitulo);
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
                var c = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];

                var b = adquisicion.getPresupuestosPartidas(pIdPartida, c.id4);
                return Json(new { success = true, objeto = b }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveAdjudicacion(beAdjudicaciones adjudicacion) {
            try
            {
                var c = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                var b = 0;
                var r = "No se pudo completar la operación seleccionada";
                switch (c.id) {
                    case 2:
                        var adj = adquisicion.TraerAdjudicacion_x_IdAdjudicacion(adjudicacion.IdAdjudicacion);

                        adj.MontoAproximadoAutorizado = adjudicacion.MontoAproximadoAutorizado;
                        adj.SaldoPartida = adjudicacion.SaldoPartida;
                        adj.IdEstatusAdjudicacion = 20;
                        r = "Se rechazó el presupuesto para la adjudicación: <strong>"+adj.AdjudicacionFolio+"</strong>";
                        if (adjudicacion.isApprove)
                        {
                            var checkOrigenRecurso = adquisicion.getAllOrigenRecurso_x_IdAdjudicacion(adjudicacion.IdAdjudicacion);

                            adj.IdOrigenRecurso = checkOrigenRecurso;
                            adj.IdOrigenRecursoAutorizado = checkOrigenRecurso;
                            adj.IdEstatusAdjudicacion = 30;

                            if (adj.IdTipoAdjudicacion == 1){
                                adj.IdEstatusAdjudicacion = 50;
                            }
                            r = "Se autorizó el presupuesto para la adjudicación: <strong>"+adj.AdjudicacionFolio+" </strong>";
                        }

                        b = adquisicion.Autorizar(adj);
                        break;
                    case 3:
                        adj = adquisicion.TraerAdjudicacion_x_IdAdjudicacion(adjudicacion.IdAdjudicacion);

                        if (adjudicacion.isApprove && adjudicacion.IdEstatusAdjudicacion == 60)
                        {

                            var lotesAdjudicacion = adquisicion.getAdjudicacionesCondicionesEntregasDetalles_x_IdAdjudicacion(adjudicacion.IdAdjudicacion);
                            if (lotesAdjudicacion.Count() == 0)
                            {
                                return Json(new { success = false, mensaje = "Aún no se han acapturado lotes." }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                var lotes = lotesAdjudicacion.Where(s => s.CantidadxAsignar > 0).ToList();
                                if (lotes.Count() == 0)
                                {
                                    var condiconPago = adquisicion.getCondiconPago_x_IdAdjudicacion(adjudicacion.IdAdjudicacion);
                                    if (condiconPago.IdTipoCondicionPago != 0)
                                    {
                                        adj.IdEstatusAdjudicacion = 60;
                                        adj.CantidadLotes = adjudicacion.CantidadLotes;
                                        adj.ImporteTotalLotes = adjudicacion.ImporteTotalLotes;
                                        adj.TotalLiquidez = adjudicacion.TotalLiquidez;
                                        b = adquisicion.Autorizar(adj);
                                        r = "Se envió la adjudicación <strong>" + adj.AdjudicacionFolio + "</strong> para su autorización.";
                                        break;
                                    }
                                    else
                                    {
                                        return Json(new { success = false, mensaje = "Falta por asignar condiciones de pago." }, JsonRequestBehavior.AllowGet);
                                    }

                                }
                                else
                                {
                                    return Json(new { success = false, mensaje = "Falta por asignar lotes a las condiciones de entrega." }, JsonRequestBehavior.AllowGet);
                                }
                            }

                        }
                        else if (!adjudicacion.isApprove && adjudicacion.IdEstatusAdjudicacion == 60)
                        {
                            adj.IdEstatusAdjudicacion = 50;
                            b = adquisicion.Autorizar(adj);
                            r = "No puede entrar";
                            break;
                        }
                        else
                        {                       
                            // Primera vez que se genera 
                            if (adjudicacion.IdEstatusAdjudicacion == 10)
                            {
                                adjudicacion.FechaAsignaRevisor = DateTime.Now;
                                adjudicacion.FechaAutorizacion = DateTime.Now;
                                adjudicacion.IdDependencia = c.id4;
                                adjudicacion.IdUsuarioRegistro = (int)c.id2;

                                adjudicacion.IdAdjudicacion = 0;
                                adjudicacion.FechaRegistro = DateTime.Now;
                                adjudicacion.FechaAdjudicacion = DateTime.Now;
                                adjudicacion.NumeroOficioSolicitud = "0";


                                var getTipoAdj = adquisicion.getTipoAdjudicacion_x_IdTipoAdjudicacion(adjudicacion.IdTipoAdjudicacion);

                                if (getTipoAdj.MontoMinimo <= adjudicacion.MontoAproximado && getTipoAdj.MontoMaximo >= adjudicacion.MontoAproximado)
                                {
                                    b = adquisicion.saveAdjudicacion(adjudicacion);

                                    var NewAdj = adquisicion.TraerAdjudicacion_x_IdAdjudicacion(b);
                                    r = "Adjudicación generada con el folio: <strong>" + NewAdj.AdjudicacionFolio + "</strong>";
                                    //return Json(new { success = false, mensaje = r }, JsonRequestBehavior.AllowGet);
                                }
                                else
                                {
                                    return Json(new { success = false, mensaje = "El valor aproximado no se encuentra dentro del rango del tipo de adjudicación seleccionado." }, JsonRequestBehavior.AllowGet);
                                }
                                
                            }
                            else {
                                //Ya han sido generadas pero se rechazó en presupuesto y liquidez
                                adjudicacion.FechaAsignaRevisor = DateTime.Now;
                                adjudicacion.FechaAutorizacion = DateTime.Now;
                                adjudicacion.IdDependencia = c.id4;
                                adjudicacion.IdUsuarioRegistro = (int)c.id2;

                                b = adquisicion.saveAdjudicacion(adjudicacion);

                                var NewAdj = adquisicion.TraerAdjudicacion_x_IdAdjudicacion(b);
                                r = "Adjudicación modificada con el folio: <strong>" + NewAdj.AdjudicacionFolio + "</strong>";
                            }
                        }


                        break;
                    case 6:
                        adj = adquisicion.TraerAdjudicacion_x_IdAdjudicacion(adjudicacion.IdAdjudicacion);
                        adj.IdEstatusAdjudicacion = 40;
                        r = "Presupuesto rechazado para la adjudicación: <strong>" + adj.AdjudicacionFolio + "</strong>";

                        if (adjudicacion.isApprove)
                        {
                            adj.IdEstatusAdjudicacion = 50;
                            r = "Presupuesto autorizado para la adjudicación: <strong>" + adj.AdjudicacionFolio + "</strong>";
                        }

                        b = adquisicion.Autorizar(adj);
                        break;
                    case 4:
                        adj = adquisicion.TraerAdjudicacion_x_IdAdjudicacion(adjudicacion.IdAdjudicacion);
                        adj.IdEstatusAdjudicacion = 50;
                        r = "Adjudicación <strong>" + adj.AdjudicacionFolio + "</strong> autorizada";

                        if (adjudicacion.isApprove)
                        {
                            adj.IdEstatusAdjudicacion = 70;
                            r = "Adjudicación <strong>" + adj.AdjudicacionFolio + "</strong> rechazada";
                        }

                        b = adquisicion.Autorizar(adj);

                        break;
                }
                return Json(new { success = true, mensaje = r }, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveFirmantes(beAdjudicacionesFirmantes adjudicacionesFirmantes) {
            try
            {
                var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                brAdjudicacionesFirmantes ObrAdjFirmantes = new brAdjudicacionesFirmantes();
                var Result = "";

                if (ModelState.IsValid)
                {
                    var result = ObrAdjFirmantes.guardarAdjudicacionesFirmantes(adquisicion.validarCamposStatus(adjudicacionesFirmantes));
                    Result = "Agregado correctamente";
                }
                else
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    Result = "No se pudo agregar";
                }
                return Json(Result, JsonRequestBehavior.AllowGet);
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

                var lst_ = adquisicion.getProductos(pGenerico);
                return Json(new { success = true, data = lst_ }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult getProducto(int IdBienServicio, int IdAdjudicacion)
        {
            try
            {
                var lst = adquisicion.getAllAdjudicacionLotes_x_IdAdjudicacion(IdAdjudicacion);
                var obj = lst.Where(s => s.IdBienServicio == IdBienServicio).ToList();

                if (obj.Count > 0)
                {

                    return Json(new { success = false, data = "El bien y/o servicio se encuentra agregado en esta adjudicación." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var objeto = adquisicion.getProducto(IdBienServicio);
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
        public JsonResult saveLote(beAdjudicacionesLotes adjudicacionesLotes)
        {
            try
            {
                var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];

                adjudicacionesLotes.FechaRegistro = DateTime.Now;
                adjudicacionesLotes.IdUsuarioRegistro = (int)a.id2;
                adquisicion.saveAdjudicacionLote(adjudicacionesLotes);
                var lst = adquisicion.getAllAdjudicacionLotes_x_IdAdjudicacion(adjudicacionesLotes.IdAdjudicacion);
                return Json(new { success = true, data = lst }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult getAdjudicacionLote(beAdjudicacionesLotes pAdjudicacionLote)
        {
            try
            {
                var lst = adquisicion.getAllAdjudicacionLotes_x_IdAdjudicacion(pAdjudicacionLote.IdAdjudicacion);
                var objeto_ = lst.Where(s => s.IdLote == pAdjudicacionLote.IdLote).First();
                return Json(new { success = true, objeto = objeto_ }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult getAdjudicacionLoteProv(beAdjudicacionesLotes pAdjudicacionLote)
        {
            try
            {
                var c = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];

                var lst = adquisicion.getAllAdjudicacionLotes_x_IdAdjudicacion(pAdjudicacionLote.IdAdjudicacion);
                var objeto_ = lst.Where(s => s.IdLote == pAdjudicacionLote.IdLote).First();

                var tlsp = adquisicion.getDataAdjudicacionesPropuestasTecnicaEconomica_x_IdAdjudicacion_x_IdProveedor(pAdjudicacionLote.IdAdjudicacion, (int)c.id6, pAdjudicacionLote.IdLote);

                return Json(new { success = true, objeto = objeto_ , dp= tlsp}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveEditLote(beAdjudicacionesLotes adjudicacionesLotes)
        {
            try
            {
                var b = adquisicion.getAdjudicacionLote_x_IdLote(adjudicacionesLotes.IdLote);
                adjudicacionesLotes.FechaRegistro = b.FechaRegistro;
                adjudicacionesLotes.IdUsuarioRegistro = b.IdUsuarioRegistro;
                adquisicion.saveEditAdjudicacionLote(adjudicacionesLotes);
                var lst = adquisicion.getAllAdjudicacionLotes_x_IdAdjudicacion(adjudicacionesLotes.IdAdjudicacion);
                return Json(new { success = true, data = lst }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult deleteLote(beAdjudicacionesLotes adjudicacionesLotes)
        {
            try
            {
                var lst_ = adquisicion.getAdjudicacionesCondicionesEntregasDetalles_x_IdAdjudicacion(adjudicacionesLotes.IdAdjudicacion);
                if (lst_.Where(s => s.IdLote == adjudicacionesLotes.IdLote && s.CantidadLoteAsignado == 0).FirstOrDefault() != null)
                {
                    adquisicion.deleteLote(adjudicacionesLotes.IdLote);
                }

                var r = adquisicion.getAllAdjudicacionLotes_x_IdAdjudicacion(adjudicacionesLotes.IdAdjudicacion);
                return Json(new { success = true, data = r }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveLiquidez(beAdjudicacionesLiquidez adjudicacionesLiquidez)
        {
            try
            {
                var c = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];

                adjudicacionesLiquidez.FechaRegistro = DateTime.Now;
                adjudicacionesLiquidez.IdUsuarioRegistro = (int)c.id2;

                var b = adquisicion.saveLiquidez(adjudicacionesLiquidez);

                return Json(new { success = true, objeto = b }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteAdjudicacionLiquidez(int idAdjudicacionLiquidez)
        {
            try
            {
                var d = adquisicion.DeleteAdjudicacionLiquidez(idAdjudicacionLiquidez);

                return Json(new { success = true, mensaje = d }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult TraerAdjudicacionLiquidez(int idAdjudicacionLiquidez)
        {
            try
            {
                var t = adquisicion.GetAdjudicacionesLiquidez_x_IdAdjudicacionLiquidez(idAdjudicacionLiquidez);

                return Json(new { success = true, mensaje = t }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = true, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateAdjudicacionLiquidez(beAdjudicacionesLiquidez adjudicacionesLiquidez)
        {

            try
            {
                var r = adquisicion.GetAdjudicacionesLiquidez_x_IdAdjudicacionLiquidez(adjudicacionesLiquidez.IdAdjudicacionLiquidez);

                r.IdOrigenRecurso = adjudicacionesLiquidez.IdOrigenRecurso;
                r.IdCuentaBancaria = adjudicacionesLiquidez.IdCuentaBancaria;
                r.NumeroOperacion = adjudicacionesLiquidez.NumeroOperacion;
                r.SaldoIgob = adjudicacionesLiquidez.SaldoIgob;
                r.MontoComprometido = adjudicacionesLiquidez.MontoComprometido;
                r.FechaDeposito = adjudicacionesLiquidez.FechaDeposito;

                var u = adquisicion.UpdateAdjudicacionLiquidez(r);

                return Json(new { success = true, mensaje = u }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = true, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveCondicionesDeEntrega(beAdjudicacionesCondicionesEntregas oCondcionesDeEntrega)
        {

            try
            {
                var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];

                oCondcionesDeEntrega.FechaRegistro = DateTime.Now;
                oCondcionesDeEntrega.IdUsuarioRegistro = (int)a.id2;

                var condcionesDeEntrega = (new brAdjudicacionesCondicionesEntregas()).guardarAdjudicacionesCondicionesEntregas(oCondcionesDeEntrega);

                return Json(new { success = true, m = condcionesDeEntrega, id = condcionesDeEntrega }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveEditCondiconesDeEntrega(beAdjudicacionesCondicionesEntregas pCondcionesDeEntrega)
        {
            try
            {
                var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];

                var b = adquisicion.getAdjudicacionCondicionEntrega_x_IdAdjudicacionCondicionEntrega(pCondcionesDeEntrega.IdAdjudicacionCondicionEntrega);

                pCondcionesDeEntrega.FechaRegistro = b.FechaRegistro;
                pCondcionesDeEntrega.IdUsuarioRegistro = b.IdUsuarioRegistro;
                adquisicion.updateCondcionesDeEntrega(pCondcionesDeEntrega);

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveCondicionesDeEntregaDetalle(beAdjudicacionesCondicionesEntregasDetalles oAdjudicacionesCondicionesEntregasDetalles)
        {
            try
            {
                adquisicion.saveAdjudicacionesCondicionesEntregasDetalles(oAdjudicacionesCondicionesEntregasDetalles);
                var lst_ = adquisicion.getAllCondicionesEntregasDetalles_x_IdAdjudicacionCondicionEntrega(oAdjudicacionesCondicionesEntregasDetalles.IdAdjudicacionCondicionEntrega); //
                return Json(new { success = true, lst = lst_ }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveEditCondicionesDeEntregaDetalle(beAdjudicacionesCondicionesEntregasDetalles oAdjudicacionesCondicionesEntregasDetalles)
        {
            try
            {
                adquisicion.saveEditAdjudicacionesCondicionesEntregasDetalles(oAdjudicacionesCondicionesEntregasDetalles);
                var lst_ = adquisicion.getAllCondicionesEntregasDetalles_x_IdAdjudicacionCondicionEntrega(oAdjudicacionesCondicionesEntregasDetalles.IdAdjudicacionCondicionEntrega);
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
                var objeto_ = adquisicion.getCondicionEntregaDetalle_x_IdCondicionEntregaDetalle(IdCondicionEntregaDetalle);

                return Json(new { success = true, objeto = objeto_ }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult eliminarCondicionEntregaDetalle(int IdCondicionEntregaDetalle, int IdAdjudicacionCondicionEntrega)
        {
            try
            {
                adquisicion.eliminartAdjudicacionesCondicionesEntregasDetalles(IdCondicionEntregaDetalle);
                var lst_ = adquisicion.getAllCondicionesEntregasDetalles_x_IdAdjudicacionCondicionEntrega(IdAdjudicacionCondicionEntrega);
                return Json(new { success = true, lst = lst_ }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult getCantidad_x_Idlote(int IdAdjudicacionLote, int IdAdjudicacion)
        {
            try
            {
                var lst_ = adquisicion.getAdjudicacionesCondicionesEntregasDetalles_x_IdAdjudicacion(IdAdjudicacion);
                beAdjudicacionesCondicionesDetallesIdAdjudicacion objeto_ = new beAdjudicacionesCondicionesDetallesIdAdjudicacion();
                if (lst_.Where(s => s.IdLote == IdAdjudicacionLote).ToList().Count > 0)
                {
                    objeto_ = lst_.Where(s => s.IdLote == IdAdjudicacionLote).ToList().First();
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
        public JsonResult getLugarEntrega_x_IdLugarEntrega(int IdLugarEntrega)
        {
            try
            {
                var objeto_ = adquisicion.getLugaresEntregaFirma_x_IdLugarEntrega(IdLugarEntrega);

                return Json(new { success = true, objeto = objeto_ }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveCondicionesPago(beAdjudicacionesCondicionesPagos condiconPago)
        {
            try
            {
                var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];

                condiconPago.FechaRegistro = DateTime.Now;
                condiconPago.IdUsuarioRegistro = (int)a.id2;
                condiconPago.Observaciones = "";
                int id = adquisicion.saveCondicionPago(condiconPago);
                var lst_ = adquisicion.getCalculoPartida(condiconPago.IdPeriodicidad, condiconPago.NumeroPagos, condiconPago.ImporteTotalPagos, condiconPago.PorcentajeAnticipo, condiconPago.FechaInicioPago);

                foreach (var item in lst_)
                {
                    beAdjudicacionesCondicionesPagosDetalles b = new beAdjudicacionesCondicionesPagosDetalles();
                    b.IdAdjudicacionCondicionPago = id;
                    b.FechaPago = (DateTime)item.DateTime1;
                    b.PorcentajePago = item.decimal2;
                    b.NumeroPago = (int)item.id;
                    b.ImportePago = item.decimal1;
                    item.bool1 = true;
                    var f = (new brAdjudicacionesCondicionesPagosDetalles()).guardarAdjudicacionesCondicionesPagosDetalles(b);
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
        public JsonResult saveEditCondicionPago(beAdjudicacionesCondicionesPagos condiconPago)
        {
            try
            {
                var b = adquisicion.getCondicionPago_x_IdCondcionPago(condiconPago.IdAdjudicacionCondicionPago);
                condiconPago.IdUsuarioRegistro = b.IdUsuarioRegistro;
                condiconPago.FechaRegistro = b.FechaRegistro;
                condiconPago.Observaciones = "";
                (new brAdjudicacionesCondicionesPagosDetalles()).eliminarAdjudicacionesCondicionesPagosDetalles_x_IdAdjudicacionCondicionPago(condiconPago.IdAdjudicacionCondicionPago); //FALTA PROCEDIMIENTO ALMACENADO
                adquisicion.saveEditCondicionPago(condiconPago);
                int id = b.IdAdjudicacionCondicionPago;
                var lst_ = adquisicion.getCalculoPartida(condiconPago.IdPeriodicidad, condiconPago.NumeroPagos, condiconPago.ImporteTotalPagos, condiconPago.PorcentajeAnticipo, condiconPago.FechaInicioPago);

                foreach (var item in lst_)
                {
                    beAdjudicacionesCondicionesPagosDetalles c = new beAdjudicacionesCondicionesPagosDetalles();
                    c.IdAdjudicacionCondicionPago = id;
                    c.FechaPago = (DateTime)item.DateTime1;
                    c.PorcentajePago = item.decimal2;
                    c.NumeroPago = (int)item.id;
                    c.ImportePago = item.decimal1;
                    item.bool1 = true;
                    var f = (new brAdjudicacionesCondicionesPagosDetalles()).guardarAdjudicacionesCondicionesPagosDetalles(c);
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
        public JsonResult saveEditCondicionPagoDetalle(beAdjudicacionesCondicionesPagosDetalles condicionPagoDetalle)
        {
            try
            {
                var b = adquisicion.getCondicionPagoDetalle_x_IdCondcionPagoDetalle(condicionPagoDetalle.IdAdCondicionPagoDetalle);
                b.ImportePago = condicionPagoDetalle.ImportePago;
                adquisicion.saveEditCondicionPagoDetalle(b);
                var lst_ = adquisicion.getAllCondicionesPagoDetalle_x_IdCondicionPago(condicionPagoDetalle.IdAdjudicacionCondicionPago);
                return Json(new { success = true, lst = lst_ }, JsonRequestBehavior.AllowGet);
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
                var lst_ = adquisicion.getCalculoPartida(IdPeriodicidad, cantidadPagos, importeRestante, porcentajeAplicado, FechaInicioPago);

                return Json(new { success = true, lst = lst_ }, JsonRequestBehavior.AllowGet);
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
                var lst_ = adquisicion.getAllAnticipos();
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
        public JsonResult AsignarProveedor(beAdjudicacionesProveedores adjudicacionesProveedores)
        {
            try
            {
                var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];

                brAdjudicacionesProveedores proveedores = new brAdjudicacionesProveedores();

                adjudicacionesProveedores.FechaEnvioPropuestaEconomica = DateTime.Now;
                adjudicacionesProveedores.FechaEnvioPropuestaTecnica = DateTime.Now;
                adjudicacionesProveedores.FechaEnvioPropuestaEconomica = DateTime.Now;
                adjudicacionesProveedores.CartaFundamento = "";
                adjudicacionesProveedores.CartasAdqObservacion = "";
                adjudicacionesProveedores.CondicionEntregaFundamento = "";
                adjudicacionesProveedores.CondicionEntregaAdqObservacion = "";
                adjudicacionesProveedores.CondicionPagoFundamento = "";
                adjudicacionesProveedores.CondicionPagoAdqObservacion = "";
                adjudicacionesProveedores.ManifiestoFundamento = "";
                adjudicacionesProveedores.ManifiestoAdqObservacion = "";
                adjudicacionesProveedores.ObservacionConEntregaRevisor = "";
                adjudicacionesProveedores.ObservacionCondPagoRevisor = "";
                adjudicacionesProveedores.ObservacionDoctosRevisor = "";

                adjudicacionesProveedores.FechaRegistro = DateTime.Now;
                adjudicacionesProveedores.IdUsuarioRegistro = (int)a.id2;

                var r = proveedores.guardarAdjudicacionesProveedores(adjudicacionesProveedores);

                return Json(new { succes = true, mensaje = r }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult QuitarProveedor(int IdAdjudicacionProveedor)
        {
            try
            {
                brAdjudicacionesProveedores p = new brAdjudicacionesProveedores();
                var r = p.eliminarAdjudicacionesProveedores(IdAdjudicacionProveedor);

                return Json(new { succes = true, mensaje = r }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult updateEstatusPropuestaTecnicaEconomica(int IdAdjudicacion)
        {
            try
            {
                var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                var idProv = a.id6;
                var r = "";

                brAdjudicacionesProveedores adjudicacionesProveedores = new brAdjudicacionesProveedores();
                brAdjudicaciones adjudicaciones = new brAdjudicaciones();
                brAdjudicacionesPropuestasTecnicaEconomica tecnicaEconomica = new brAdjudicacionesPropuestasTecnicaEconomica();

                var AdjudicacionProveedor = adquisicion.getAdjudicacionProveedor_x_IdAdjudicacion_x_IdProveedor(IdAdjudicacion, idProv);

                if (AdjudicacionProveedor.IdEstatusEnvioPropuestaTecnica == 0)
                {
                    AdjudicacionProveedor.IdUsuaroEnviaPropuestaTecnica = (int)a.id2;
                    AdjudicacionProveedor.IdEstatusEnvioPropuestaTecnica = 10;

                    adjudicacionesProveedores.actualizarAdjudicacionesProveedores(AdjudicacionProveedor);

                    r = "Propuesta técnica enviada, faltando por enviar la propuesta económica";
                }
                else if (AdjudicacionProveedor.IdEstatusEnvioPropuestaEconomica == 0)
                {
                    AdjudicacionProveedor.IdUsuaroEnviaPropuestaEconomica = (int)a.id2;
                    AdjudicacionProveedor.IdEstatusEnvioPropuestaEconomica = 10;
                    AdjudicacionProveedor.IdEstatusAdjudicacionProveedor = 15;


                    adjudicacionesProveedores.actualizarAdjudicacionesProveedores(AdjudicacionProveedor);

                    r = "Propuesta económica enviada";

                }


                return Json(new { success = false, mensaje = r }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult savePropuestaEconomica(beAdjudicacionesPropuestasTecnicaEconomica propuestasEconomica)
        {
            try
            {
                var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                var idProv = a.id6;
                brAdjudicacionesPropuestasTecnicaEconomica t = new brAdjudicacionesPropuestasTecnicaEconomica();

                var IdAdjudicacionProveedor = adquisicion.getIdAdjudicacionProveedor_x_IdAdjudicacion_x_IdProveedor(propuestasEconomica.IdAdjudicacion, idProv);

                var AdjudicacionPropuestaTecEco = adquisicion.getAdjudicacionPropuestaTecEco_x_IdAdjudicacionProveedor_x_IdLote(IdAdjudicacionProveedor, propuestasEconomica.IdLote);

                AdjudicacionPropuestaTecEco.PrecioUnitarioOfertado = propuestasEconomica.PrecioUnitarioOfertado;
                AdjudicacionPropuestaTecEco.PrecioUnitarioRefencia = propuestasEconomica.PrecioUnitarioRefencia;
                AdjudicacionPropuestaTecEco.ImpuestoPorcentaje = propuestasEconomica.ImpuestoPorcentaje;
                AdjudicacionPropuestaTecEco.ImporteOfertado = propuestasEconomica.ImporteOfertado;
                AdjudicacionPropuestaTecEco.ImpuestoImporte = propuestasEconomica.ImpuestoImporte;
                AdjudicacionPropuestaTecEco.TotalOfertado = propuestasEconomica.TotalOfertado;

                AdjudicacionPropuestaTecEco.ImportePeriodo = propuestasEconomica.ImportePeriodo;
                AdjudicacionPropuestaTecEco.ImpuestoPeriodo = propuestasEconomica.ImpuestoPeriodo;
                AdjudicacionPropuestaTecEco.TotalPeriodo = propuestasEconomica.TotalPeriodo;
                AdjudicacionPropuestaTecEco.IdMesInicial = propuestasEconomica.IdMesInicial;
                AdjudicacionPropuestaTecEco.IdMesFinal = propuestasEconomica.IdMesFinal;


                var r = t.actualizarAdjudicacionesPropuestasTecnicaEconomica(AdjudicacionPropuestaTecEco);

                return Json(new { succes = true, mensaje = t }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { succes = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult savePropuestaTecnica(int IdAdjudicionPropuestaTecEco, string Mejora, int EstatusMejora)
        {
            try
            {
                var result = "";
                brAdjudicacionesPropuestasTecnicaEconomica t = new brAdjudicacionesPropuestasTecnicaEconomica();
                var ActualizarObj = t.traerAdjudicacionesPropuestasTecnicaEconomica_x_IdAdjudicionPropuestaTecEco(IdAdjudicionPropuestaTecEco);
                ActualizarObj.Mejora = Mejora;
                ActualizarObj.EstatusMejora = EstatusMejora;
                if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    if (ActualizarObj != null)
                    {
                        var pdf = System.Web.HttpContext.Current.Request.Files["ArchivoUno"];
                        if (pdf!=null)
                        {
                            HttpPostedFileBase filebase = new HttpPostedFileWrapper(pdf);
                            var fileName = Path.GetExtension(filebase.FileName);
                            fileName = "MuestraCatalogoA_" + IdAdjudicionPropuestaTecEco.ToString() + fileName;
                            var path = Path.Combine(Server.MapPath("~/Files/CertificacionesMuestras/"), fileName);
                            filebase.SaveAs(path);
                            ActualizarObj.URLFileMuestraCatalogo = "/Files/CertificacionesMuestras/" + fileName;
                        }
                        var pdf2 = System.Web.HttpContext.Current.Request.Files["ArchivoDos"];
                        if (pdf2 != null)
                        {
                            HttpPostedFileBase filebase2 = new HttpPostedFileWrapper(pdf2);
                            var fileName2 = Path.GetExtension(filebase2.FileName);
                            fileName2 = "CertificacionA_" + IdAdjudicionPropuestaTecEco.ToString() + fileName2;
                            var path2 = Path.Combine(Server.MapPath("~/Files/CertificacionesMuestras/"), fileName2);
                            filebase2.SaveAs(path2);
                            ActualizarObj.URLFileCertificacion = "/Files/CertificacionesMuestras/" + fileName2;
                        }
                        result = (t.actualizarAdjudicacionesPropuestasTecnicaEconomica(ActualizarObj) == 0) ? "Se agregaron los datos corretamente al lote ofertado" : "No se pudieron agregar los datos al lote ofertado";
                    }
                }
                else
                {
                    result = (t.actualizarAdjudicacionesPropuestasTecnicaEconomica(ActualizarObj) == 0) ? "Se agregaron los datos corretamente al lote ofertado" : "No se pudieron agregar los datos al lote ofertado";
                }
                return Json(new { succes = true, mensaje = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { succes = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
     
        public JsonResult savePropuestaTecnicaEconomicaCheckBox(int id,int idAdj)
        {
            try
            {
                var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                var idProv = a.id6;
                beAdjudicacionesPropuestasTecnicaEconomica ObjPropTecEco = new beAdjudicacionesPropuestasTecnicaEconomica();

                var idadjprov = adquisicion.getIdAdjudicacionProveedor_x_IdAdjudicacion_x_IdProveedor(idAdj, idProv);

                ObjPropTecEco.IdAdjudicionPropuestaTecEco = 0;
                ObjPropTecEco.IdAdjudicacionProveedor = idadjprov;
                ObjPropTecEco.IdLote = id;
                ObjPropTecEco.Mejora = "";
                ObjPropTecEco.EstatusMejora = 0;
                ObjPropTecEco.PrecioUnitarioRefencia = 0;
                ObjPropTecEco.PrecioUnitarioOfertado = 0;
                ObjPropTecEco.ImporteOfertado = 0;
                ObjPropTecEco.ImpuestoPorcentaje = 0;
                ObjPropTecEco.ImpuestoImporte = 0;
                ObjPropTecEco.TotalOfertado = 0;
                ObjPropTecEco.IdEstatusPropuesta = 0;
                ObjPropTecEco.URLFileMuestraCatalogo = "";
                ObjPropTecEco.URLFileCertificacion = "";
                ObjPropTecEco.DependenciaCumple = 0;
                ObjPropTecEco.FundamentoLegal = "";
                ObjPropTecEco.AdquisicionCumple = 0;
                ObjPropTecEco.AdquisicionObserva = "";
                ObjPropTecEco.ProveedorGanador = 0;
                ObjPropTecEco.ValidaEconomica = 0;
                ObjPropTecEco.ImportePeriodo = 0;
                ObjPropTecEco.ImpuestoPeriodo = 0;
                ObjPropTecEco.TotalPeriodo = 0;
                ObjPropTecEco.IdMesInicial = 0;
                ObjPropTecEco.IdMesFinal = 0;

                brAdjudicacionesPropuestasTecnicaEconomica t = new brAdjudicacionesPropuestasTecnicaEconomica();
                var result = (t.guardarAdjudicacionesPropuestasTecnicaEconomica(ObjPropTecEco) > 0) ? "Se agregó el lote correctamente" : "No se ha podido agregar el lote";

                return Json(new { succes = true, mensaje = result }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { succes = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        
        public JsonResult deletePropuestaTecnicaEconomicaCheckBox(int id)
        {
            try
            {
                brAdjudicacionesPropuestasTecnicaEconomica t = new brAdjudicacionesPropuestasTecnicaEconomica();
                var result = (t.eliminarAdjudicacionesPropuestasTecnicaEconomica(id)==0) ? "Lote eliminado" : "No se pudo eliminar el lote asignado";
                return Json(new { succes = true, mensaje = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { succes = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult buscarPropuestaEconomica(int id)
        {
            brAdjudicacionesPropuestasTecnicaEconomica t = new brAdjudicacionesPropuestasTecnicaEconomica();
            var ActualizarObj = t.traerAdjudicacionesPropuestasTecnicaEconomica_x_IdAdjudicionPropuestaTecEco(id);
            return Json(ActualizarObj, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult getImporteTotalConImpuesto(int IdAdjudicacion) {
            try
            {
                var AdjudicacionLotes = adquisicion.getAllAdjudicacionLotes_x_IdAdjudicacion(IdAdjudicacion);

                var ImporteTotalCImpuesto = adquisicion.sumAdjudicacionLote(AdjudicacionLotes);

                return Json(new { success = true, m = ImporteTotalCImpuesto }, JsonRequestBehavior.AllowGet); 
            }
            catch (Exception ex )
            {
                return Json(new { success = false, m = ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult getLstLotesPorAsignar(int IdAdjudicacion) {
            try
            {
                var r = new SelectList(adquisicion.getAdjudicacionesCondicionesEntregasDetallesFaltantes_x_IdAdjudicacion(IdAdjudicacion), "IdLote", "CantidadLotesxAsignar");

                return Json(new { success = true, m = r }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, m = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}