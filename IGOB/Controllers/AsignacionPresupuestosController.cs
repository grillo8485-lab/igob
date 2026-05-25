using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IGOB.Models;
using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;

namespace IGOB.Controllers
{
    public class AsignacionPresupuestosController : ValidaSession
    {
        // GET: AsignacionPresupuestos
        ClsAsignacionRequisicion a = new ClsAsignacionRequisicion();
        public ActionResult Index(int id)
        {
            var c = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            ViewBag.Idperfil = c.id;

            var idRequisicion = a.requisicion(id);
            ViewBag.Requision = idRequisicion;

            ViewBag.totalMontoComprometido = a.Sum_MontoComprometido_x_IdRequisicion(idRequisicion.IdRequisicion);

            ViewBag.Dependencia = a.GetDependencia_x_IdDependencia(ViewBag.Requision.IdDependencia);

            ViewBag.MontoPresupuestadoAutorizado = a.GetMontoPresupuestadoAutorizado_x_IdRequisicion(idRequisicion.IdRequisicion);

            /* PRESUPUESTO */
            ViewBag.Partida = a.GetPartida_x_Id(idRequisicion.IdPartida);
            ViewBag.MontoSolicitado = a.Monto_Solicitado(id);
            ViewBag.SaldoPartida = a.Saldo_Presupuestado_Autorizado(idRequisicion.IdPartida, idRequisicion.IdDependencia);
            ViewBag.MontoAutorizado = a.Monto_Aproximado_Autorizado(id);
            ViewBag.OrigenRecurso = a.GetOrigenRecurso_x_Id(idRequisicion.IdOrigenRecurso);

            /* CLAVES PRESUPUESTALES */
            var IdPartida = a.GetIdPartida_x_idRequisicion(idRequisicion.IdRequisicion);
            var PresupuestosPartidas = new bePresupuestosPartidas();
            if ((int)c.id != 3)
            {
                PresupuestosPartidas = a.GetPresupuestoPartida_x_idPartida_IdDependencia_IdEjercicioFiscal(IdPartida, idRequisicion.IdDependencia, idRequisicion.IdEjercicioFiscal);
            }
            else
            {
                PresupuestosPartidas = a.GetPresupuestoPartida_x_idPartida_IdDependencia_IdEjercicioFiscal(IdPartida, c.id4, idRequisicion.IdEjercicioFiscal);
            }


            ViewBag.ODetalles = a.OClavesPresupuestalesDetalles(PresupuestosPartidas.IdPresupuestoPartida);

            ViewBag.Noministracion = PresupuestosPartidas.NumeroMinistracion;

            /* LIQUIDEZ */
            var ORList = a.listarTodos_OrigenRecurso().ToList();
            ViewBag.ORList = new SelectList(ORList, "IdOrigenRecurso", "OrigenRecurso");

            ViewBag.IdRequisicion = idRequisicion.IdRequisicion;



            ViewBag.Licitaciones = a.TraerLiquidez_x_IdRequisicion(ViewBag.IdRequisicion);
            if ((ViewBag.Licitaciones as List<beRequisicionesLiquidez>).Count() > 0)
            {
                ViewBag.MontoPresupuestadoAutorizado = (ViewBag.Licitaciones as List<beRequisicionesLiquidez>).Sum(s => s.MontoComprometido);
            }

            ViewBag.IdEstatusRequisicion = idRequisicion.IdEstatusRequisicion;
            ViewBag.FechaDeposito = DateTime.Now;

            return View();
        }

        public JsonResult GetCuentas_x_IdOrigenRecurso(int idOrigenRecurso)
        {
            var CuentasList = a.GetCuentas_x_IdOrigenRecurso(idOrigenRecurso);

            return Json(CuentasList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetNombreCuenta_x_IdCuenta(int idCuenta)
        {
            ViewBag.Cuenta = a.GetNombreCuenta_x_IdCuenta(idCuenta);

            return Json(ViewBag.Cuenta, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetNombreBanco_x_IdBanco(int idBanco)
        {
            var Banco = a.GetNombreBanco_x_IdBanco(idBanco);

            return Json(Banco.NombreCorto, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetNombreBanco_x_IdCuentaBancaria(int IdCuentaBancaria)
        {
            var NombreBanco = a.GetNombreBanco_x_IdCuentaBancaria(IdCuentaBancaria);

            return Json(NombreBanco, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveLiquidez(beRequisicionesLiquidez requisicionesLiquidez)
        {
            var NoOperacionBancaria = a.CheckNumeroOperacion(requisicionesLiquidez.NumeroOperacion);

            if (NoOperacionBancaria == null)
            {
                try
                {
                    var c = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];

                    requisicionesLiquidez.FechaRegistro = DateTime.Now;
                    requisicionesLiquidez.IdUsuarioRegistro = (int)c.id2;

                    var b = a.saveLiquidez(requisicionesLiquidez);

                    return Json(new { success = true, objeto = b }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new { success = false, objeto = "Número de operación bancaria existente" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Confirmar(beRequisiciones requisiciones)
        {
            var c = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            try
            {
                if (TempData["keyAcceso"] == null)
                {
                    return Json(new { success = false, mensaje = "<span class='fa fa-exclamation-triangle fa-1x'></span><strong>Debe intorducir token antes de poder guardar.</strong>" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    if (TempData["keyAcceso"].ToString().Trim() != c.string6.Trim())
                    {
                        return Json(new { success = false, mensaje = "<span class='fa fa-exclamation-triangle fa-1x'></span><strong>Debe intorducir token antes de poder guardar.</strong>" }, JsonRequestBehavior.AllowGet);
                    }
                }
                var r = new beRequisiciones();
                var b = 0;
                switch (c.id)
                {
                    case 2:
                        r = a.GetRequisiciones_x_IdRequisicion(requisiciones.IdRequisicion);

                        if (requisiciones.IdEstatusRequisicion == 30)
                        {
                            r.MontoAproximadoAutorizado = requisiciones.MontoAproximadoAutorizado;
                            r.SaldoPartida = requisiciones.SaldoPartida;
                        }

                        r.IdEstatusRequisicion = requisiciones.IdEstatusRequisicion;

                        b = a.Autorizar(r);

                        break;
                    case 6:
                        r = a.GetRequisiciones_x_IdRequisicion(requisiciones.IdRequisicion);

                        r.IdEstatusRequisicion = requisiciones.IdEstatusRequisicion;

                        b = a.Autorizar(r);

                        break;
                    case 4:
                         r = a.GetRequisiciones_x_IdRequisicion(requisiciones.IdRequisicion);

                        r.IdEstatusRequisicion = requisiciones.IdEstatusRequisicion;

                        b = a.Autorizar(r);

                        break;
                    default:
                        break;
                }
                return Json(new { success = true, objeto = b }, JsonRequestBehavior.AllowGet);

                //var r = a.GetRequisiciones_x_IdRequisicion(requisiciones.IdRequisicion);

                //if (requisiciones.IdEstatusRequisicion == 30){
                //    r.MontoAproximadoAutorizado = requisiciones.MontoAproximadoAutorizado;
                //    r.SaldoPartida = requisiciones.SaldoPartida;
                //}

                //r.IdEstatusRequisicion = requisiciones.IdEstatusRequisicion;                

                //var b = a.Autorizar(r);

                //return Json(new { success = true, objeto = b }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet); ;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteRequisicionLiquidez(int idRequisicionLiquidez)
        {
            try
            {
                var d = a.DeleteRequisicionLiquidez(idRequisicionLiquidez);

                return Json(new { success = true, mensaje = d }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult TraerRequisicionLiquidez(int idRequisicionLiquidez)
        {
            try
            {
                var t = a.GetRequisicionesLiquidez_x_IdRequisicionLiquidez(idRequisicionLiquidez);

                return Json(new { success = true, mensaje = t }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = true, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateRequisicionLiquidez(beRequisicionesLiquidez requisicionesLiquidez)
        {
            var NoOperacionBancaria = a.CheckNumeroOperacion(requisicionesLiquidez.NumeroOperacion);

            if (NoOperacionBancaria == null || requisicionesLiquidez.NumeroOperacion == NoOperacionBancaria.NumeroOperacion)
            {
                try
                {
                    var r = a.GetRequisicionesLiquidez_x_IdRequisicionLiquidez(requisicionesLiquidez.IdRequisicionLiquidez);

                    r.IdOrigenRecurso = requisicionesLiquidez.IdOrigenRecurso;
                    r.IdCuentaBancaria = requisicionesLiquidez.IdCuentaBancaria;
                    r.NumeroOperacion = requisicionesLiquidez.NumeroOperacion;
                    r.SaldoIgob = requisicionesLiquidez.SaldoIgob;
                    r.MontoComprometido = requisicionesLiquidez.MontoComprometido;
                    r.FechaDeposito = requisicionesLiquidez.FechaDeposito;

                    var u = a.UpdateRequisicionLiquidez(r);

                    return Json(new { success = true, mensaje = u }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(new { success = true, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new { success = false, objeto = "Número de operación bancaria existente" }, JsonRequestBehavior.AllowGet);
        }

    }
}
