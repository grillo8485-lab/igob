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
    public class RequisicionesController : ValidaSession
    {
        // GET: Requisiciones
        public ActionResult Index(int id,int IdRequisicion=0)
        {
            
            if (TempData["Historial"] == null)
            {
                ViewBag.Back = "RequisicionesSegundaVueltaConsulta";
                ViewBag.ActivoHistorial = 0;
            }
            else
            {
                
                if ((bool)TempData["Historial"])
                {
                    ViewBag.Back = "RequisicionHistorial";
                    ViewBag.ActivoHistorial = 1;
                }
                else
                {
                    ViewBag.Back = "RequisicionConsulta";
                    ViewBag.ActivoHistorial = 0;
                }
                ViewBag.Historial = TempData["Historial"];
            }
            Requisicion requisicion = new Requisicion();
            ClsRequisiciones requisiciones = new ClsRequisiciones();
            bePartidas partida = new bePartidas();
            List<bePartidas> partidas = new List<bePartidas>();
            ViewBag.ejercicioActual = requisiciones.getEjercicioFiscal();
            var f = (ClsGenerica)Session["ClsGenerico"];
            if (IdRequisicion != 0)
            {
               
                requisicion.oRequisicones = requisiciones.getRequisicion(IdRequisicion);
                ViewBag.Diferencia = requisicion.oRequisicones.MontoAproximado - requisicion.oRequisicones.MontoAproximadoAutorizado;
                partida = requisiciones.getPartidad(requisicion.oRequisicones.IdPartida);
                partidas = requisiciones.getAllPartidas_x_IdCapitulo(partida.IdCapitulo);
                ViewBag.ejercicioActual = requisiciones.getEjercicioFiscal_x_IdEjercicioFiscal(requisicion.oRequisicones.IdEjercicioFiscal);
                requisicion.Titulo = "Solicitud: " + (requisicion.oRequisicones.NumeroLicitacion==1? "Primera licitación" : (requisicion.oRequisicones.NumeroLicitacion == 2? "Segunda licitación": "")) + " - " + requisicion.oRequisicones.RequisicionFolio + " - Procesando "+((int)f.id!=3? " - " + Session["Dependencia"].ToString(): "");
                requisicion.presupuestoLiquidez = requisiciones.getPresupuestoLiquidez(requisicion.oRequisicones.IdPartida, requisicion.oRequisicones.IdOrigenRecurso, requisicion.oRequisicones.IdDependencia, requisicion.oRequisicones);
                requisicion.lstCartas = requisiciones.getAllCartas_x_IdTipoSolicitud(requisicion.oRequisicones.IdTipoSolicitud, requisicion.oRequisicones.IdRequisicion);
                requisicion.Activar = requisicion.lstCartas.Where(s => s.Activo == 0).ToList().Count == 0 ? false : true;
                requisicion.lstLiquidez = requisiciones.getAllLiquidez_x_IdRequisicion(IdRequisicion);
                requisicion.sumLiquidez = requisiciones.sumLiquidez(requisicion.lstLiquidez);
                requisicion.lstRequisicionLotesIdRequisicion = requisiciones.getAllRequisicionLotes_x_IdRequisicion(IdRequisicion);
                requisicion.sumRequisicionLote = requisiciones.sumRequisicionLote(requisicion.lstRequisicionLotesIdRequisicion);
                requisicion.condicionesDeEntrega = requisiciones.getAllRequisicionCondiconesDeEntrega_x_IdRequisicion(IdRequisicion);
                if(requisicion.condicionesDeEntrega.FechaLimite== DateTime.MinValue)
                {
                    requisicion.condicionesDeEntrega.FechaLimite = DateTime.Now;
                }
                    
                requisicion.lstRequisicionCondicionesEntregaDetalleConsulta = requisiciones.getAllCondicionesEntregasDetalles_x_IdRequisicionCondicionEntrega(requisicion.condicionesDeEntrega.IdRequisicionCondicionEntrega);
                requisicion.datosFacturacion = requisiciones.getDatosFacturacion((int)f.id4);
                requisicion.datos = requisiciones.getMunicipio_estado_pais(requisicion.datosFacturacion.IdMunicipio);
                requisicion.condicionPago = requisiciones.getCondiconPago_x_IdRequisicion(IdRequisicion);
                if (requisicion.condicionPago.FechaInicioPago == DateTime.MinValue)
                {
                    requisicion.condicionPago.FechaInicioPago = DateTime.Now;
                }
                requisicion.condicionPagoDetalle = requisiciones.getAllCondicionesPagoDetalle_x_IdCondicionPago(requisicion.condicionPago.IdRequisicionCondicionPago);
                // seccion de firmantes
                ClsUsuario user = new ClsUsuario();
                var us = user.getUsuario_x_IdUsuario(requisicion.oRequisicones.IdUsuarioRegistro);
                var reqFirm = requisiciones.getFirmante(IdRequisicion);
                ViewBag.idUrsAut = f.id2;
                ViewBag.idUsrSol = requisicion.oRequisicones.IdUsuarioRegistro;
                ViewBag.idRequisicion = requisicion.oRequisicones.IdRequisicion;
                ViewBag.NameSol = us.Nombres+" "+us.Apellidos;
               
                if (reqFirm == null)
                {
                    ViewBag.inactivo = "";
                    ViewBag.doc = "disabled";
                }
                else
                {
                    if ((requisicion.oRequisicones.IdEstatusRequisicion == 60 || requisicion.oRequisicones.IdEstatusRequisicion == 75) && (int)f.id == 4)
                    {
                        ViewBag.inactivo = "";
                        ViewBag.doc = "disabled";
                        //if(requisicion.oRequisicones.IdEstatusRequisicion == 60)
                        //reqFirm = null;
                    }
                    else
                    {
                        ViewBag.inactivo = "disabled";
                        ViewBag.doc = "";
                    }
                    
                }
                ViewBag.reqFirm = reqFirm;
                // Fin seccion  Firmantes
                /* ASIGNAR PROVEEDORES*/
                if (id == 2)
                {
                    requisicion.lstProveedoresxAsignar = requisiciones.getAllProveedores(requisicion.oRequisicones.IdRequisicion, requisicion.oRequisicones.IdPartida);
                }
                


            }
            ViewBag.lstRequisicionesAbiertas = new SelectList(requisiciones.tiposRequisicionAbierta().Where(s=> s.IdTipoRequisicion!=3).ToList(), "IdTipoRequisicion", "TipoRequisicion",(IdRequisicion==0? "0":requisicion.oRequisicones.IdTipoRequisicion.ToString()));
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
            ViewBag.lstPeriodicidad  = new SelectList(requisiciones.getAllPeriodicidad(), "IdPeriodicidad", "Periodicidad", (IdRequisicion == 0 ? "0" : requisicion.condicionPago.IdPeriodicidad.ToString()));
            ViewBag.lstPlazoTiempoPago = new SelectList(requisiciones.getAllPlazoTiempos(), "IdPlazoTiempo", "PlazozTiempo", (IdRequisicion == 0 ? "0" : requisicion.condicionPago.IdPlazoTiempo.ToString()));
            ViewBag.lstTipoDiaPago = new SelectList(requisiciones.getAllTiposDias(), "IdTipoDia", "TipoDia", (IdRequisicion == 0 ? "0" : requisicion.condicionPago.IdTipoDia.ToString()));

            ViewBag.tipoRequisicion = id;
            ViewBag.idRequisicion = IdRequisicion;
            ViewBag.formulario = "DatosGenerales";
            ViewBag.IdPerfil = (int)f.id;
            if (TempData["Historial"] != null)
            {
                TempData["Historial"] = ViewBag.Historial;
            }
            
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
            catch(Exception ex)
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
                var b = requisiciones.getPresupuestosPartidas(f.id4,pIdPartida);
                return Json(new { success = true, objeto = b }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false,mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveRequisiciones(beRequisiciones pRequisiciones)
        {
            try
            {
                var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                if (TempData["keyAcceso"] == null)
                {
                    return Json(new { success = false, mensaje = "<span class='fa fa-exclamation-triangle fa-1x'></span><strong>Debe intorducir token antes de poder guardar.</strong>" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    if (TempData["keyAcceso"].ToString().Trim() != a.string6.Trim())
                    {
                        return Json(new { success = false, mensaje = "<span class='fa fa-exclamation-triangle fa-1x'></span><strong>Debe intorducir token antes de poder guardar.</strong>" }, JsonRequestBehavior.AllowGet);
                    }
                }

                
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var objeto = new beRequisiciones();
                if (pRequisiciones.IdRequisicion == 0)
                {
                    pRequisiciones.FechaAsignaRevisor = DateTime.Now;
                    pRequisiciones.FechaAutorizacion = DateTime.Now;
                    pRequisiciones.FechaRegistro = DateTime.Now;
                    pRequisiciones.FechaRequisicion = DateTime.Now;
                    pRequisiciones.IdDependencia = a.id4;
                    pRequisiciones.IdUsuarioRegistro = (int)a.id2;
                    pRequisiciones.ObservacionesRechazo = "";
                    pRequisiciones.ColorTiempoRestante = "#46b8da";
                    pRequisiciones.NumeroLicitacion = 1;
                    if (pRequisiciones.Observaciones == null)
                        pRequisiciones.Observaciones = "";
                    var b = requisiciones.saveRequisicion(pRequisiciones);
                    objeto = requisiciones.getRequisicion(b);
                }
                else
                {
                    objeto = requisiciones.getRequisicion(pRequisiciones.IdRequisicion);
                    objeto.IdEstatusRequisicion = pRequisiciones.IdEstatusRequisicion;
                    objeto.MontoAproximado = pRequisiciones.MontoAproximado;
                    objeto.MontoAproximadoAutorizado = pRequisiciones.MontoAproximadoAutorizado;
                    requisiciones.updateRequision(objeto);
                    objeto = requisiciones.getRequisicion(pRequisiciones.IdRequisicion);
                } 
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
        public JsonResult getProductos(string term,int IdPartida)
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
                return Json(new { success = true,data =lst }, JsonRequestBehavior.AllowGet);
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
                if(lst_.Where(s=> s.IdLote == pRequisicionLote.IdLote && s.CantidadLoteAsignado>0).ToList().Count() ==  0)
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
        public JsonResult getRequisicionLote(beRequisicionesLotes pRequisicionLote)
        {
            try
            {
                ClsRequisiciones requisiciones = new ClsRequisiciones();
                
                var lst = requisiciones.getAllRequisicionLotes_x_IdRequisicion(pRequisicionLote.IdRequisicion);
                var objeto_ = lst.Where(s=> s.IdLote == pRequisicionLote.IdLote).First();
                return Json(new { success = true, objeto = objeto_ }, JsonRequestBehavior.AllowGet);
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
                
                return Json(new { success = true}, JsonRequestBehavior.AllowGet);
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

                return Json(new { success = true,objeto = objeto_}, JsonRequestBehavior.AllowGet);
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
                return Json(new { success = true, lst= lst_ }, JsonRequestBehavior.AllowGet);
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
                var objeto_=requisiciones.getCondicionEntregaDetalle_x_IdCondicionEntregaDetalle(IdCondicionEntregaDetalle);

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
        public JsonResult eliminarCondicionEntregaDetalle(int IdCondicionEntregaDetalle,int IdRequisicionCondicionEntrega)
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
                if (lst_.Where(s=> s.IdLote == IdRequisicionLote).ToList().Count>0)
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
                if(lst_.Where(s=> s.IdAnticipo== IdAnticipo).ToList().Count > 0)
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
        
        public JsonResult getCalculoPartida(int IdPeriodicidad, int cantidadPagos,decimal importeRestante,decimal porcentajeAplicado,DateTime FechaInicioPago)
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
                condiconPago.ImporteAnticipo = condiconPago.ImporteAnticipo;
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
                condiconPago.ImporteAnticipo = condiconPago.ImporteAnticipo;
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

                return Json(new { success = true, lst = lst_}, JsonRequestBehavior.AllowGet);
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
                var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                if (TempData["keyAcceso"] == null)
                {
                    return Json(new { success = false, mensaje = "<span class='fa fa-exclamation-triangle fa-1x'></span><strong>Debe intorducir token antes de poder guardar.</strong>" }, JsonRequestBehavior.AllowGet);
                    
                }
                else
                {
                    if (TempData["keyAcceso"].ToString().Trim() != a.string6.Trim())
                    {
                        return Json(new { success = false, mensaje = "<div class='alert alert-danger' role='alert' style='margin-bottom: .2rem !important;'><span class='fa fa-exclamation-triangle fa-1x'></span><strong>Debe intorducir token antes de poder guardar.</strong></div>" }, JsonRequestBehavior.AllowGet);
                    }
                }
                var r = requisiciones.getRequisicion(IdRequisicion);
                /* ASIGNAR PROVEEDORES*/
                if (r.IdTipoRequisicion == 2)
                {
                    var lst = requisiciones.getAllProveedores(r.IdRequisicion, r.IdPartida);
                    if(lst.Where(s=> s.Seleccion>0).ToList().Count < 3)
                    {
                        return Json(new { success = false, mensaje = "Debe seleccionar como minimo 3 proveedores, para poder continuar." }, JsonRequestBehavior.AllowGet);
                    }
                }

                var lotesRequisicion = requisiciones.getRequisicionesCondicionesEntregasDetalles_x_IdRequisicion(IdRequisicion);
                if (lotesRequisicion.Count() == 0)
                {
                    return Json(new { success = false, mensaje = "Aún no se ha acapturado lotes." }, JsonRequestBehavior.AllowGet);
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
                            return Json(new { success = false, mensaje = "Falta por asignar condiciones de pago." }, JsonRequestBehavior.AllowGet);
                        }
                        
                    }
                    else
                    {
                        return Json(new { success = false, mensaje = "Falta por asignar lotes a las condiciones de entrega." }, JsonRequestBehavior.AllowGet);
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
        public JsonResult ImprimirSolicitud(int pIdRequisicion)
        {
            try
            {
                ClsRequisicionesImprimirSolicitud ReqSol = new ClsRequisicionesImprimirSolicitud(Server.MapPath("~/Files/Reportes/"), Server.MapPath("~/Files/Plantillas/"));

                //obtenemos el gobierno
                var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                int IdGobierno = usuario.id5;

                string Archivo = ReqSol.ImprimeArchivo(pIdRequisicion, IdGobierno);

                return Json(new { success = true, Descarga = Archivo }, JsonRequestBehavior.AllowGet); ;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AsignarProveedor(beRequisicionesProveedoresInvitacionRestringida adjudicacionesProveedores)
        {
            try
            {
                var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];

                brRequisicionesProveedoresInvitacionRestringida proveedores = new brRequisicionesProveedoresInvitacionRestringida();


                adjudicacionesProveedores.FechaRegistro = DateTime.Now;
                adjudicacionesProveedores.IdUsuarioRegistro = (int)a.id2;

                var r = proveedores.guardarRequisicionesProveedoresInvitacionRestringida(adjudicacionesProveedores);

                return Json(new { succes = true, mensaje = r }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult QuitarProveedor(int IdRequisicionProveedorInvitacion)
        {
            try
            {
                brRequisicionesProveedoresInvitacionRestringida proveedores = new brRequisicionesProveedoresInvitacionRestringida();
                var r = proveedores.eliminarRequisicionesProveedoresInvitacionRestringida(IdRequisicionProveedorInvitacion);

                return Json(new { succes = true, mensaje = r }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveRequisicionSegundaVuelta(beRequisiciones pRequisiciones)
        {
            try
            {
                var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                
                if (TempData["keyAcceso"] == null)
                {
                    return Json(new { success = false, mensaje = "<span class='fa fa-exclamation-triangle fa-1x'></span><strong>Debe intorducir token antes de poder guardar.</strong>" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    if (TempData["keyAcceso"].ToString().Trim() != a.string6.Trim())
                    {
                        return Json(new { success = false, mensaje = "<span class='fa fa-exclamation-triangle fa-1x'></span><strong>Debe intorducir token antes de poder guardar.</strong>" }, JsonRequestBehavior.AllowGet);
                    }
                }

                ClsRequisiciones requisiciones = new ClsRequisiciones();
                var req = requisiciones.getRequisicion(pRequisiciones.IdRequisicion);
                req.FechaRequisicion = DateTime.Now;
                req.IdUsuarioRegistro = (int)a.id2;
                req.ObservacionesRechazo = pRequisiciones.IdEstatusRequisicion==10?"": "Rechazado por solicitante, segunda vuelta";
                req.Observaciones = pRequisiciones.IdEstatusRequisicion == 10 ? "" : "Rechazado por solicitante, segunda vuelta";
                req.IdEstatusRequisicion = pRequisiciones.IdEstatusRequisicion;
                requisiciones.saveEditRequisicion(req);
                var objeto = requisiciones.getRequisicion(pRequisiciones.IdRequisicion);
                return Json(new { success = true, objeto = objeto }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}

//requisiciones.getAllRequisicionLotes_x_IdRequisicion(IdRequisicion);