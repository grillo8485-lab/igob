using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;
using IGOB.Models;

namespace IGOB.Controllers
{
    public class AdjudicacionListadoPedidosRecepcionController : ValidaSession
    {
        // GET: AdjudicacionListadoPedidosRecepcion
        public ActionResult Index()//int id=0
        {
            var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            var listadoPedidos = new brAdjudicacionListadoPedidos().ListadoAdjudicacionesLotesPedidos(a.id4);//id, 
            return View(listadoPedidos);
        }
        public ActionResult EntregaPedido(int id)
        {
            var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            var adjudicacion = new brAdjudicaciones().traerAdjudicaciones_x_IdAdjudicacion(id);
            ViewBag.adjudicacionpedido = new brAdjudicacionesPedidos().listarTodos_AdjudicacionesPedidos().FirstOrDefault(x => x.IdAdjudicacion == id);
            ViewBag.Titulo = "Liberación de pedido: " + ViewBag.adjudicacionpedido.Folio + " adjudicación " + adjudicacion.AdjudicacionFolio + " - " + (new brDependencias().traerDependencias_x_IdDependencia(adjudicacion.IdDependencia).Dependencia) + " liberar pedido";
            ViewBag.LugaresEntregaFirma = (new brLugaresEntregaFirma()).listarTodos_LugaresEntregaFirma().Where(s => s.IdTipoLugar == 1).ToList();
            var ListadoLotesAdjudicacionesLiberarPedido = new brAdjudicacionLiberarPedido().ListadoAdjudicacionPedidoEntrega(ViewBag.adjudicacionpedido.IdAdjudicacionPedido);
            return View(ListadoLotesAdjudicacionesLiberarPedido);
        }
        public ActionResult EntregaPedidoDetalle(int id)
        {
            var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            ViewBag.adjudicacion = new brAdjudicaciones().traerAdjudicaciones_x_IdAdjudicacion(id);
            ViewBag.adjudicacionpedido = new brAdjudicacionesPedidos().listarTodos_AdjudicacionesPedidos().FirstOrDefault(x => x.IdAdjudicacion == id);
            ViewBag.dependencia = new brDependencias().traerDependencias_x_IdDependencia(ViewBag.adjudicacion.IdDependencia);
            ViewBag.Titulo = "Liberación de pedido: " + ViewBag.adjudicacionpedido.Folio + " adjudicación " + ViewBag.adjudicacion.AdjudicacionFolio + " - " + ViewBag.dependencia.Dependencia + " liberar pedido";
            ViewBag.adjudicacionproveedor = new brAdjudicacionesProveedores().traerAdjudicacionesProveedores_x_IdAdjudicacionProveedor(ViewBag.adjudicacionpedido.IdAdjudicacionProveedor);
            ViewBag.proveedor = new brProveedores().traerProveedores_x_IdProveedor(ViewBag.adjudicacionproveedor.IdProveedor);
            ViewBag.Partida = new ClsAdquisicion().GetPartida_x_Id(ViewBag.adjudicacion.IdPartida);
            ViewBag.estatus = new brEstatusPedidos().traerEstatusPedidos_x_IdEstatusPedido(ViewBag.adjudicacionpedido.IdEstatusPedido);
            var ListadoLotesAdjudicacionesLiberarPedido = new brAdjudicacionLiberarPedido().ListadoAdjudicacionPedidoDetalle(ViewBag.adjudicacionpedido.IdAdjudicacionPedido);
            return View(ListadoLotesAdjudicacionesLiberarPedido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult RecepcionesAdjudicacionesPedidosDetalles(beRecepcionesAdjudicacionesPedidosDetalles OrecAdPed)
        {
            var mensaje = "";
            var suc = false;
            var Obj = new brRecepcionesAdjudicacionesPedidosDetalles();
            try
            {
                var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                OrecAdPed.FechaRegistro = DateTime.Now;
                OrecAdPed.IdUsuarioRegistro = (int)a.id2;
                OrecAdPed.Observaciones = (OrecAdPed.Observaciones != null ? OrecAdPed.Observaciones : "Sin Observaciones");
                if (ModelState.IsValid)
                {
                    if (Obj.guardarRecepcionesAdjudicacionesPedidosDetalles(OrecAdPed)>0)
                    {
                        suc = true;
                        mensaje = "Se registro correctamente la recepción";
                    }
                    else
                    {
                        suc = false;
                        mensaje = "No se pudo agregar la recepción del pedido faltan datos";
                    }
                }
                else
                {
                    suc = false;
                    mensaje = "No se pudo agregar la recepción del pedido faltan datos";
                }
                var ListadoLotesAdjudicacionesLiberarPedido = new brAdjudicacionLiberarPedido().ListadoAdjudicacionPedidoEntrega(OrecAdPed.IdAdjudicacionPedido);
                var AdjudicacionesPedidos = new brAdjudicacionesPedidos();
                var objetoAP = AdjudicacionesPedidos.traerAdjudicacionesPedidos_x_IdAdjudicacionPedido(OrecAdPed.IdAdjudicacionPedido);
                var sumaTotalxRecibida = ListadoLotesAdjudicacionesLiberarPedido.Sum(x => x.CantidadxRecibir);
                objetoAP.IdEstatusPedido = (sumaTotalxRecibida == 0 ? 5 : 4);
                AdjudicacionesPedidos.actualizarAdjudicacionesPedidos(objetoAP);
            }
            catch(Exception e)
            {
                suc = false;
                mensaje = e.Message;
            }
            return Json(new { success = suc, message = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}