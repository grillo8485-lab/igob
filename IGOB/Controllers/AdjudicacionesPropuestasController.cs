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
    public class AdjudicacionesPropuestasController : ValidaSession
    {
        ClsAdquisicion adquisicion = new ClsAdquisicion();
        brAdjudicacionesPropuestasTecnicaEconomica tecnicaEconomica = new brAdjudicacionesPropuestasTecnicaEconomica();
        brAdjudicacionesProveedores a = new brAdjudicacionesProveedores();
        brAdjudicaciones adjudicaciones = new brAdjudicaciones();
        brAdjudicacionesProveedores adjudicacionesProveedores = new brAdjudicacionesProveedores();

        // GET: AdjudicacionesPropuestas
        public ActionResult Index(int Id)
        {
            var c = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            ViewBag.IdPerfil = c.id;

            return View((int)c.id == 3 ? adquisicion.getAllProveedoresAdjudicacion_x_IdAdjudicacion(Id, 15) : adjudicacionesProveedores.getAllProveedoresAdjudicacion_x_IdAdjudicacion(Id, 20));
        }

        [HttpGet]
        public ActionResult RecibirPropuestaTecnica(int id)
        {
            var tec = tecnicaEconomica.traerAdjudicacionesPropuestasTecnicaEconomica_x_IdAdjudicionProveedor(id);
            var hasStatusTec = a.traerAdjudicacionesProveedores_x_IdAdjudicacionProveedor(tec.FirstOrDefault().IdAdjudicacionProveedor).IdEstatusEnvioPropuestaTecnica;

            ViewBag.hasAConfirm = hasStatusTec == 10 ? false: true;
            ViewBag.Adjudicacion = tec.FirstOrDefault();
            ViewBag.AdjudicacionFolio = adjudicaciones.traerAdjudicaciones_x_IdAdjudicacion(tec.FirstOrDefault().IdAdjudicacion).AdjudicacionFolio;

            return View(tec);
        }

        [HttpGet]
        public ActionResult RecibirPropuestaEconomica(int id)
        {
            var Eco = tecnicaEconomica.traerAdjudicacionesPropuestasTecnicaEconomica_x_IdAdjudicionProveedor(id);
            var hasStatusEco = a.traerAdjudicacionesProveedores_x_IdAdjudicacionProveedor(Eco.FirstOrDefault().IdAdjudicacionProveedor).IdEstatusEnvioPropuestaEconomica;

            ViewBag.hasAConfirm = hasStatusEco == 10 ? false : true;                
            ViewBag.Adjudicacion = Eco.FirstOrDefault();
            ViewBag.AdjudicacionFolio = adjudicaciones.traerAdjudicaciones_x_IdAdjudicacion(Eco.FirstOrDefault().IdAdjudicacion).AdjudicacionFolio;

            return View(Eco);
        }

        [HttpGet]
        public ActionResult AutorizarPropuestaTecnica(int id)
        {
            var tec = tecnicaEconomica.traerAdjudicacionesPropuestasTecnicaEconomica_x_IdAdjudicionProveedor(id);
            var lstAcept = a.listarTodos_AdjudicacionesProveedores().Where(x => x.IdAdjudicacion == tec.FirstOrDefault().IdAdjudicacion && x.IdEstatusEnvioPropuestaTecnica == 30);

            ViewBag.lstAcept = lstAcept.Count() >= 1 ? true : false;
            ViewBag.Adjudicacion = tec.FirstOrDefault();
            ViewBag.AdjudicacionFolio = adjudicaciones.traerAdjudicaciones_x_IdAdjudicacion(tec.FirstOrDefault().IdAdjudicacion).AdjudicacionFolio;

            return View(tec);
        }

        [HttpGet]
        public ActionResult AutorizarPropuestaEconomica(int id)
        {
            var Eco = tecnicaEconomica.traerAdjudicacionesPropuestasTecnicaEconomica_x_IdAdjudicionProveedor(id);
            var lstAcept = a.listarTodos_AdjudicacionesProveedores().Where(x => x.IdAdjudicacion == Eco.FirstOrDefault().IdAdjudicacion && x.IdEstatusEnvioPropuestaEconomica == 30);

            ViewBag.lstAcept = lstAcept.Count() >= 1 ? true : false;
            ViewBag.Adjudicacion = Eco.FirstOrDefault();
            ViewBag.AdjudicacionFolio = adjudicaciones.traerAdjudicaciones_x_IdAdjudicacion(Eco.FirstOrDefault().IdAdjudicacion).AdjudicacionFolio;

            return View(Eco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult detallesPropuesta(int IdAdjudicionPropuestaTecEco)
        {
            var checkAdjProp = tecnicaEconomica.traerAdjudicacionesPropuestasTecnicaEconomica_x_IdAdjudicionPropuestaTecEco(IdAdjudicionPropuestaTecEco);

            if (checkAdjProp != null)
                return Json(new { success = true, m = checkAdjProp }, JsonRequestBehavior.AllowGet);

            return Json(new { success = false, m = "Ocurrio un error al procesar la solicitud" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Confirmar(beAdjudicacionesProveedores adjudicacionesProveedores)
        {
            try
            {
                var c = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];

                switch ((int)c.id) {
                    case 3:

                        var checkAdjudicacionProveedor = a.traerAdjudicacionesProveedores_x_IdAdjudicacionProveedor(adjudicacionesProveedores.IdAdjudicacionProveedor);
                        if (checkAdjudicacionProveedor != null)
                        {
                            if (checkAdjudicacionProveedor.IdEstatusEnvioPropuestaTecnica == 10)
                            {
                                if (!adjudicacionesProveedores.isApprove)
                                {
                                    checkAdjudicacionProveedor.IdEstatusEnvioPropuestaTecnica = 40;
                                    checkAdjudicacionProveedor.IdEstatusEnvioPropuestaEconomica = 40;
                                    checkAdjudicacionProveedor.IdEstatusAdjudicacionProveedor = 40;
                                }else
                                    checkAdjudicacionProveedor.IdEstatusEnvioPropuestaTecnica = 20;

                                a.actualizarAdjudicacionesProveedores(checkAdjudicacionProveedor);
                            }
                            else if (checkAdjudicacionProveedor.IdEstatusEnvioPropuestaEconomica == 10)
                            {
                                checkAdjudicacionProveedor.IdEstatusEnvioPropuestaEconomica = 20;
                                checkAdjudicacionProveedor.IdEstatusAdjudicacionProveedor = 20;

                                a.actualizarAdjudicacionesProveedores(checkAdjudicacionProveedor);

                            }
                            var countTotalProv = a.listarTodos_AdjudicacionesProveedores().Where(x => x.IdAdjudicacion == checkAdjudicacionProveedor.IdAdjudicacion).Count();
                            var countRevProv = a.listarTodos_AdjudicacionesProveedores().Where(x => x.IdAdjudicacion == checkAdjudicacionProveedor.IdAdjudicacion && x.IdEstatusAdjudicacionProveedor == 20).Count();

                            if ((countTotalProv - countRevProv) == 0)
                            {
                                var AdjHoney = adjudicaciones.traerAdjudicaciones_x_IdAdjudicacion(checkAdjudicacionProveedor.IdAdjudicacion);
                                AdjHoney.IdEstatusAdjudicacion = 120;

                                adjudicaciones.actualizarAdjudicaciones(AdjHoney);
                            }

                            return Json(new { success = true, mensaje = "Guardado correctamente" }, JsonRequestBehavior.AllowGet);
                        }
                        break;
                    case 4:

                        checkAdjudicacionProveedor = a.traerAdjudicacionesProveedores_x_IdAdjudicacionProveedor(adjudicacionesProveedores.IdAdjudicacionProveedor);
                        if (checkAdjudicacionProveedor != null)
                        {
                            if (checkAdjudicacionProveedor.IdEstatusEnvioPropuestaTecnica == 20)
                            {
                                checkAdjudicacionProveedor.IdEstatusEnvioPropuestaTecnica = 40;

                                if (adjudicacionesProveedores.isApprove)
                                    checkAdjudicacionProveedor.IdEstatusEnvioPropuestaTecnica = 30;

                                a.actualizarAdjudicacionesProveedores(checkAdjudicacionProveedor);
                            }
                            else if (checkAdjudicacionProveedor.IdEstatusEnvioPropuestaEconomica == 20)
                            {
                                checkAdjudicacionProveedor.IdEstatusEnvioPropuestaEconomica = 40;
                                checkAdjudicacionProveedor.IdEstatusAdjudicacionProveedor = 40;

                                if (adjudicacionesProveedores.isApprove)
                                {
                                    checkAdjudicacionProveedor.IdEstatusEnvioPropuestaEconomica = 30;
                                    checkAdjudicacionProveedor.IdEstatusAdjudicacionProveedor = 30;
                                }

                                a.actualizarAdjudicacionesProveedores(checkAdjudicacionProveedor);
                            }
                            var countTotalProv = a.listarTodos_AdjudicacionesProveedores().Where(x => x.IdAdjudicacion == checkAdjudicacionProveedor.IdAdjudicacion && x.IdEstatusAdjudicacionProveedor == 30).Count();
                            var countRevProv = a.listarTodos_AdjudicacionesProveedores().Where(x => x.IdAdjudicacion == checkAdjudicacionProveedor.IdAdjudicacion && x.IdEstatusAdjudicacionProveedor == 30).Count();

                            if ((countTotalProv - countRevProv) == 0)
                            {
                                var AdjHoney = adjudicaciones.traerAdjudicaciones_x_IdAdjudicacion(checkAdjudicacionProveedor.IdAdjudicacion);
                                AdjHoney.IdEstatusAdjudicacion = 130;
                                if (AdjHoney.IdTipoAdjudicacion == 1)
                                    AdjHoney.IdEstatusAdjudicacion = 100;

                                var tablapedido = new brAdjudicacionesPedidos().listarTodos_AdjudicacionesPedidos().FirstOrDefault(x => x.IdAdjudicacion == checkAdjudicacionProveedor.IdAdjudicacion);
                                if (tablapedido == null)
                                {
                                    var estate = new brAdjudicacionLiberarPedido().GenerarPedidosAdjudicaciones_x_IdAdjudicacion(checkAdjudicacionProveedor.IdAdjudicacion);
                                }
                                adjudicaciones.actualizarAdjudicaciones(AdjHoney);
                            }

                            return Json(new { success = true, mensaje = "Guardado correctamente" }, JsonRequestBehavior.AllowGet);
                        }

                        break;
                }

                return Json(new { success = false, mensaje = "Ocurrio un problema durante el envió de la petición" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}