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
    public class RequisicionesComprasMenoresController : ValidaSession
    {

        public ActionResult Index(int IdCompramenor = 0)
        {
            ClsRequisicionesComprasMenores RequisicionesComprasMenores = new ClsRequisicionesComprasMenores();

            //obtenemos la dependencia
            var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            int IdDependencia = usuario.id4;
            int IdGobierno = usuario.id5;

            ViewBag.lstSolicitud = new SelectList(RequisicionesComprasMenores.GetAllTiposSolicitud(), "IdTipoSolicitud", "TipoSolicitud");
            ViewBag.lstCapitulos = new SelectList(RequisicionesComprasMenores.GetAllCapitulos(), "IdCapitulo", "Capitulo");
            ViewBag.lstPartidas = new SelectList(new List<bePartidas>(), "IdPartida", "Partida");
            ViewBag.lstProveedores = new SelectList(RequisicionesComprasMenores.GetAllProveedores(IdGobierno), "IdProveedor", "RazonSocial");
            ViewBag.ejercicioActual = RequisicionesComprasMenores.GetEjercicioFiscal();
            ViewBag.origenRecurso = RequisicionesComprasMenores.GetOrigenRecurso();

            ViewBag.lstDepartamentos = new SelectList(RequisicionesComprasMenores.GetDepartamentos_x_IdDependencia(IdDependencia), "IdDepartamento", "Departamento");
            ViewBag.lstLugaresEntrega = new SelectList(RequisicionesComprasMenores.GetLugaresEntregasCM_x_IdDependencia(IdDependencia), "IdLugarEntregaPago", "Lugar");
            ViewBag.lstLugaresPago = new SelectList(RequisicionesComprasMenores.GetLugaresPagosCM_x_IdDependencia(IdDependencia), "IdLugarEntregaPago", "Lugar");

            ViewBag.IdCompramenor = IdCompramenor;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult GetAllPartidas_x_IdCapitulo(int pIdCapitulo)
        {
            try
            {
                ClsRequisicionesComprasMenores requisicionescm = new ClsRequisicionesComprasMenores();
                return Json(new { success = true, objeto = requisicionescm.GetAllPartidas_x_IdCapitulo(pIdCapitulo) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult GetMonto(int id)
        {
            try
            {
                brPresupuestosPartidas ObrPresupuestosPartidas = new brPresupuestosPartidas();
                var c = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                var b = ObrPresupuestosPartidas.listarTodos_PresupuestosPartidas().Where(x => x.IdPartida == id && x.IdDependencia == c.id4).FirstOrDefault().MontoSaldo;
                return Json(new { success = true, mensaje = b }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult GuardarRequisicionesCM(beRequisicionesComprasMenores pRequisicionesCM)
        {
            try
            {
                ClsRequisicionesComprasMenores requisicionescm = new ClsRequisicionesComprasMenores();

                var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];

                pRequisicionesCM.IdDependencia = usuario.id4;
                pRequisicionesCM.FechaRequisicion = DateTime.Now;
                pRequisicionesCM.FechaEntrega = DateTime.Now;
                pRequisicionesCM.FechaPago = DateTime.Now;
                pRequisicionesCM.IdUsuarioRegistro = (int)usuario.id2;
                pRequisicionesCM.FechaRegistro = DateTime.Now;
                pRequisicionesCM.IdEstatusCM = 10;
                pRequisicionesCM.IdPresupuesto = 2;
                pRequisicionesCM.RequisicionFolio = "";
                pRequisicionesCM.ConsecutivoRequisicion = 0;
                pRequisicionesCM.MontoAproximado = 0; // monto aproximado real 
                pRequisicionesCM.CantidadLotes = 0;
                pRequisicionesCM.ImporteTotalLotes = 0;
                pRequisicionesCM.IdLugarEntrega = 0;
                pRequisicionesCM.IdLugarPago = 0;
                pRequisicionesCM.MontoPresupuestado = 0;
                pRequisicionesCM.IdUsuarioAutoriza = 0;
                pRequisicionesCM.Economia = 0;
                pRequisicionesCM.Ejercido = 0;

                if (pRequisicionesCM.Observaciones == null)
                    pRequisicionesCM.Observaciones = "";

                var b = requisicionescm.GuardaRequisicionCM(pRequisicionesCM);
                beRequisicionesComprasMenores obeReqCM = requisicionescm.TraerRequisicionCM(b);
                return Json(new { success = true, idComprasMenores = b, folio = obeReqCM.RequisicionFolio }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult EditarRequisicionesCM(beRequisicionesComprasMenores pRequisicionesCM)
        {
            try
            {
                //cargamos los datos guardados

                ClsRequisicionesComprasMenores reqcm = new ClsRequisicionesComprasMenores();

                beRequisicionesComprasMenores obeReqCM = new beRequisicionesComprasMenores();
                obeReqCM = reqcm.TraerRequisicionCM(pRequisicionesCM.IdRequisicionCompraMenor);

                var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];

                pRequisicionesCM.IdRequisicionCompraMenor = obeReqCM.IdRequisicionCompraMenor;
                pRequisicionesCM.IdDependencia = obeReqCM.IdDependencia;
                pRequisicionesCM.IdDepartamento = pRequisicionesCM.IdDepartamento; //Departamento
                pRequisicionesCM.IdOrigenRecurso = pRequisicionesCM.IdOrigenRecurso; //origen recurso
                pRequisicionesCM.IdEstatusCM = obeReqCM.IdEstatusCM;
                pRequisicionesCM.IdPartida = pRequisicionesCM.IdPartida; //id partida
                pRequisicionesCM.IdEjercicioFiscal = pRequisicionesCM.IdEjercicioFiscal; // ejercicio fiscal
                pRequisicionesCM.IdTipoSolicitud = pRequisicionesCM.IdTipoSolicitud;
                pRequisicionesCM.IdPresupuesto = obeReqCM.IdPresupuesto;
                pRequisicionesCM.FechaRequisicion = obeReqCM.FechaRequisicion;
                pRequisicionesCM.RequisicionFolio = obeReqCM.RequisicionFolio;
                pRequisicionesCM.ConsecutivoRequisicion = obeReqCM.ConsecutivoRequisicion;
                pRequisicionesCM.MontoAproximado = obeReqCM.MontoAproximado;
                pRequisicionesCM.CantidadLotes = obeReqCM.CantidadLotes;
                pRequisicionesCM.ImporteTotalLotes = obeReqCM.ImporteTotalLotes;
                pRequisicionesCM.Observaciones = pRequisicionesCM.Observaciones; //observaciones
                pRequisicionesCM.Justificacion = pRequisicionesCM.Justificacion; //justificacion
                pRequisicionesCM.FechaEntrega = obeReqCM.FechaEntrega;
                pRequisicionesCM.IdLugarEntrega = obeReqCM.IdLugarEntrega;
                pRequisicionesCM.FechaPago = obeReqCM.FechaPago;
                pRequisicionesCM.IdLugarPago = obeReqCM.IdLugarPago;
                pRequisicionesCM.SaldoPartida = obeReqCM.SaldoPartida;
                pRequisicionesCM.MontoPresupuestado = obeReqCM.MontoPresupuestado;
                pRequisicionesCM.IdUsuarioAutoriza = obeReqCM.IdUsuarioAutoriza;
                pRequisicionesCM.IdProveedor = pRequisicionesCM.IdProveedor; //id proveedor
                pRequisicionesCM.Economia = obeReqCM.Economia;
                pRequisicionesCM.Ejercido = obeReqCM.Ejercido;
                pRequisicionesCM.IdUsuarioRegistro = (int)usuario.id2;
                pRequisicionesCM.FechaRegistro = obeReqCM.FechaRegistro;

                var b = reqcm.ActualizarRequisicionCM(pRequisicionesCM);

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult EditarReqCMEntrega(beRequisicionesComprasMenores pRequisicionesCM)
        {
            try
            {
                //cargamos los datos guardados

                ClsRequisicionesComprasMenores reqcm = new ClsRequisicionesComprasMenores();

                beRequisicionesComprasMenores obeReqCM = new beRequisicionesComprasMenores();
                obeReqCM = reqcm.TraerRequisicionCM(pRequisicionesCM.IdRequisicionCompraMenor);

                var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];

                pRequisicionesCM.IdRequisicionCompraMenor = obeReqCM.IdRequisicionCompraMenor;
                pRequisicionesCM.IdDependencia = obeReqCM.IdDependencia;
                pRequisicionesCM.IdDepartamento = obeReqCM.IdDepartamento;
                pRequisicionesCM.IdOrigenRecurso = obeReqCM.IdOrigenRecurso;
                pRequisicionesCM.IdEstatusCM = obeReqCM.IdEstatusCM;
                pRequisicionesCM.IdPartida = obeReqCM.IdPartida;
                pRequisicionesCM.IdEjercicioFiscal = obeReqCM.IdEjercicioFiscal;
                pRequisicionesCM.IdTipoSolicitud = obeReqCM.IdTipoSolicitud;
                pRequisicionesCM.IdPresupuesto = obeReqCM.IdPresupuesto;
                pRequisicionesCM.FechaRequisicion = obeReqCM.FechaRequisicion;
                pRequisicionesCM.RequisicionFolio = obeReqCM.RequisicionFolio;
                pRequisicionesCM.ConsecutivoRequisicion = obeReqCM.ConsecutivoRequisicion;
                pRequisicionesCM.MontoAproximado = obeReqCM.MontoAproximado;
                pRequisicionesCM.CantidadLotes = obeReqCM.CantidadLotes;
                pRequisicionesCM.ImporteTotalLotes = obeReqCM.ImporteTotalLotes;
                pRequisicionesCM.Observaciones = obeReqCM.Observaciones;
                pRequisicionesCM.Justificacion = obeReqCM.Justificacion;
                pRequisicionesCM.FechaEntrega = pRequisicionesCM.FechaEntrega; //fecha entrega
                pRequisicionesCM.IdLugarEntrega = pRequisicionesCM.IdLugarEntrega; //lugar entrega
                pRequisicionesCM.FechaPago = pRequisicionesCM.FechaPago; //fecha pago
                pRequisicionesCM.IdLugarPago = pRequisicionesCM.IdLugarPago; //lugar pago
                pRequisicionesCM.SaldoPartida = obeReqCM.SaldoPartida;
                pRequisicionesCM.MontoPresupuestado = obeReqCM.MontoPresupuestado;
                pRequisicionesCM.IdUsuarioAutoriza = obeReqCM.IdUsuarioAutoriza;
                pRequisicionesCM.IdProveedor = obeReqCM.IdProveedor;
                pRequisicionesCM.Economia = obeReqCM.Economia;
                pRequisicionesCM.Ejercido = obeReqCM.Ejercido;
                pRequisicionesCM.IdUsuarioRegistro = (int)usuario.id2;
                pRequisicionesCM.FechaRegistro = obeReqCM.FechaRegistro;

                var b = reqcm.ActualizarRequisicionCM(pRequisicionesCM);

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult TerminarReqCM(beRequisicionesComprasMenores pRequisicionesCM)
        {
            try
            {
                //cargamos los datos guardados

                ClsRequisicionesComprasMenores reqcm = new ClsRequisicionesComprasMenores();

                beRequisicionesComprasMenores obeReqCM = new beRequisicionesComprasMenores();
                obeReqCM = reqcm.TraerRequisicionCM(pRequisicionesCM.IdRequisicionCompraMenor);

                var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];

                pRequisicionesCM.IdRequisicionCompraMenor = obeReqCM.IdRequisicionCompraMenor;
                pRequisicionesCM.IdDependencia = obeReqCM.IdDependencia;
                pRequisicionesCM.IdDepartamento = obeReqCM.IdDepartamento;
                pRequisicionesCM.IdOrigenRecurso = obeReqCM.IdOrigenRecurso;
                pRequisicionesCM.IdEstatusCM = pRequisicionesCM.IdEstatusCM;
                pRequisicionesCM.IdPartida = obeReqCM.IdPartida;
                pRequisicionesCM.IdEjercicioFiscal = obeReqCM.IdEjercicioFiscal;
                pRequisicionesCM.IdTipoSolicitud = obeReqCM.IdTipoSolicitud;
                pRequisicionesCM.IdPresupuesto = obeReqCM.IdPresupuesto;
                pRequisicionesCM.FechaRequisicion = obeReqCM.FechaRequisicion;
                pRequisicionesCM.RequisicionFolio = obeReqCM.RequisicionFolio;
                pRequisicionesCM.ConsecutivoRequisicion = obeReqCM.ConsecutivoRequisicion;
                pRequisicionesCM.MontoAproximado = obeReqCM.MontoAproximado;
                pRequisicionesCM.CantidadLotes = obeReqCM.CantidadLotes;
                pRequisicionesCM.ImporteTotalLotes = obeReqCM.ImporteTotalLotes;
                pRequisicionesCM.Observaciones = obeReqCM.Observaciones;
                pRequisicionesCM.Justificacion = obeReqCM.Justificacion;
                pRequisicionesCM.FechaEntrega = obeReqCM.FechaEntrega;
                pRequisicionesCM.IdLugarEntrega = obeReqCM.IdLugarEntrega;
                pRequisicionesCM.FechaPago = obeReqCM.FechaPago;
                pRequisicionesCM.IdLugarPago = obeReqCM.IdLugarPago;
                pRequisicionesCM.SaldoPartida = obeReqCM.SaldoPartida;
                pRequisicionesCM.MontoPresupuestado = obeReqCM.MontoPresupuestado;
                pRequisicionesCM.IdUsuarioAutoriza = obeReqCM.IdUsuarioAutoriza;
                pRequisicionesCM.IdProveedor = obeReqCM.IdProveedor;
                pRequisicionesCM.Economia = obeReqCM.Economia;
                pRequisicionesCM.Ejercido = obeReqCM.Ejercido;
                pRequisicionesCM.IdUsuarioRegistro = (int)usuario.id2;
                pRequisicionesCM.FechaRegistro = obeReqCM.FechaRegistro;

                var b = reqcm.ActualizarRequisicionCM(pRequisicionesCM);

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult TraerRequisicionesCM(int pIdReqCM)
        {
            try
            {
                ClsRequisicionesComprasMenores ReqCM = new ClsRequisicionesComprasMenores();
                beRequisicionesComprasMenores obeReqCM = ReqCM.TraerRequisicionCM(pIdReqCM);
                //obeReqCM.FechaEntrega = DateTime.Parse(String.Format("{0:s}", obeReqCM.FechaEntrega));
                

                return Json(new { success = true, objeto = obeReqCM }, JsonRequestBehavior.AllowGet); ;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult GuardarReqCMLote(beRequisicionesComprasMenoresLotes pReqCMLote)
        {
            try
            {
                ClsRequisicionesComprasMenores reqcm = new ClsRequisicionesComprasMenores();
                var ListaRequisicionesCM = reqcm.GetAllLotes_x_IdReqCM(pReqCMLote.IdRequisicionCompraMenor);
                if (ListaRequisicionesCM.Count == 0)
                {
                     var ImporteImpuesto = ((pReqCMLote.Cantidad * pReqCMLote.PrecioUnitario) * 16) / 100;
                      var Total = (pReqCMLote.Cantidad * pReqCMLote.PrecioUnitario) + ImporteImpuesto;
                    if (Total <= 5000)
                    {
                        var b = saveLoteRequisiconCompramenor(pReqCMLote);
                        return Json(new { success = true, idComprasMenoresLotes = b }, JsonRequestBehavior.AllowGet);
                    }
                    
                    else{
                        return Json(new { success = false, mensaje = "El monto final no debe sobrepasar $5,000" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    var suma = ListaRequisicionesCM.Sum(s => s.Total);
                    var ImporteImpuesto = ((pReqCMLote.Cantidad * pReqCMLote.PrecioUnitario) * 16) / 100;
                    var Total = (pReqCMLote.Cantidad * pReqCMLote.PrecioUnitario) + ImporteImpuesto;
                    if ((Total + suma) <= 5000)
                    {
                        var b = saveLoteRequisiconCompramenor(pReqCMLote);
                        return Json(new { success = true, idComprasMenoresLotes = b }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, mensaje = "El monto final no debe sobrepasar $5,000" }, JsonRequestBehavior.AllowGet);
                    }
                }
                //if ((pReqCMLote.PrecioUnitario * pReqCMLote.Cantidad) - pReqCMLote.TotalFinal <= 5000)
                //{


                //    var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];

                //    pReqCMLote.FechaRegistro = DateTime.Now;
                //    pReqCMLote.IdUsuarioRegistro = (int)usuario.id2;
                //    pReqCMLote.NoLote = reqcm.GetLastLote(pReqCMLote.IdRequisicionCompraMenor);
                //    pReqCMLote.IdLoteCompraMenor = 0;

                //    pReqCMLote.Importe = pReqCMLote.Cantidad * pReqCMLote.PrecioUnitario;
                //    pReqCMLote.PorcentajeImpuesto = 16;
                //    pReqCMLote.ImporteImpuesto = (pReqCMLote.Importe * pReqCMLote.PorcentajeImpuesto) / 100;
                //    pReqCMLote.Total = pReqCMLote.Importe + pReqCMLote.ImporteImpuesto;
                //    var b = reqcm.GuardaReqCMLote(pReqCMLote);

                //    return Json(new { success = true, idComprasMenoresLotes = b }, JsonRequestBehavior.AllowGet);
                //}
                //else
                   
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        protected int saveLoteRequisiconCompramenor(beRequisicionesComprasMenoresLotes pReqCMLote)
        {
            ClsRequisicionesComprasMenores reqcm = new ClsRequisicionesComprasMenores();
            var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];

            pReqCMLote.FechaRegistro = DateTime.Now;
            pReqCMLote.IdUsuarioRegistro = (int)usuario.id2;
            pReqCMLote.NoLote = reqcm.GetLastLote(pReqCMLote.IdRequisicionCompraMenor);
            pReqCMLote.IdLoteCompraMenor = 0;

            pReqCMLote.Importe = pReqCMLote.Cantidad * pReqCMLote.PrecioUnitario;
            pReqCMLote.PorcentajeImpuesto = 16;
            pReqCMLote.ImporteImpuesto = (pReqCMLote.Importe * pReqCMLote.PorcentajeImpuesto) / 100;
            pReqCMLote.Total = pReqCMLote.Importe + pReqCMLote.ImporteImpuesto;
            var b = reqcm.GuardaReqCMLote(pReqCMLote);
            return b;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult EditarReqCMLote(beRequisicionesComprasMenoresLotes pReqCMLote)
        {
            try
            {
                //cargamos los datos guardados de ese lote

                ClsRequisicionesComprasMenores reqcml = new ClsRequisicionesComprasMenores();

                beRequisicionesComprasMenoresLotes obeReqCML = new beRequisicionesComprasMenoresLotes();
                obeReqCML = reqcml.TraerReqCMLote(pReqCMLote.IdLoteCompraMenor);

                var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];

                pReqCMLote.IdLoteCompraMenor = obeReqCML.IdLoteCompraMenor;
                pReqCMLote.IdRequisicionCompraMenor = obeReqCML.IdRequisicionCompraMenor;
                pReqCMLote.NoLote = obeReqCML.NoLote;
                pReqCMLote.IdBienServicio = obeReqCML.IdBienServicio;
                pReqCMLote.Concepto = pReqCMLote.Concepto; //concepto
                pReqCMLote.IdTipoBienServicio = pReqCMLote.IdTipoBienServicio;
                pReqCMLote.Cantidad = pReqCMLote.Cantidad; //cantidad
                pReqCMLote.PrecioUnitario = pReqCMLote.PrecioUnitario; //precio unitario
                pReqCMLote.Importe = pReqCMLote.Cantidad * pReqCMLote.PrecioUnitario;
                pReqCMLote.PorcentajeImpuesto = obeReqCML.PorcentajeImpuesto;
                pReqCMLote.ImporteImpuesto = (pReqCMLote.Importe * pReqCMLote.PorcentajeImpuesto) / 100;
                pReqCMLote.Total = pReqCMLote.Importe + pReqCMLote.ImporteImpuesto;
                pReqCMLote.FechaRegistro = obeReqCML.FechaRegistro;
                pReqCMLote.IdUsuarioRegistro = (int)usuario.id2;

                var b = reqcml.ActualizaReqCMLote(pReqCMLote);

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult GetAllLotes_xIdLoteCompraMenor(int pIdLoteCompraMenor)
        {
            try
            {
                ClsRequisicionesComprasMenores requisicionescm = new ClsRequisicionesComprasMenores();
                var ListaRequisicionesCM = requisicionescm.GetAllLotes_x_IdReqCM(pIdLoteCompraMenor);

                return Json(new { success = true, data = ListaRequisicionesCM }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult TraerLotesCM(int pIdLoteCM)
        {
            try
            {
                ClsRequisicionesComprasMenores ReqCM = new ClsRequisicionesComprasMenores();
                beRequisicionesComprasMenoresLotes obeReqCMLote = ReqCM.TraerReqCMLote(pIdLoteCM);

                return Json(new { success = true, objeto = obeReqCMLote }, JsonRequestBehavior.AllowGet); ;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult EliminarLote(int IdLote)
        {
            try
            {
                ClsRequisicionesComprasMenores requisicionescm = new ClsRequisicionesComprasMenores();
                var lotecm = requisicionescm.BorraReqCMLote(IdLote);

                return Json(new { success = true }, JsonRequestBehavior.AllowGet); ;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}