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
    public class RecepcionarPedidoDetalleController : ValidaSession
    {
        // GET: RecepcionarPedidoDetalle
        int IdPedido=0;
        public ActionResult Index()
        {
            var f = (ClsGenerica)Session["ClsGenerico"];
            var IdPedido = (int)TempData["IdPedido"];
            ClsLiberarPedido pedido = new ClsLiberarPedido();
            var listado = pedido.getListadoPedidosLicitaciones_IdPedido(IdPedido);
            ViewBag.lstLugarEntregaFirma = pedido.getAllLugaresEntregaFirma(1);// new SelectList(pedido.getAllLugaresEntregaFirma(1), "IdLugarEntregaFirma", "Lugar");
            if (listado.Count > 0)
            {
                ViewBag.Titulo = listado.First().RequisicionFolio;
            }
            TempData["IdPedido"] = IdPedido;
            return View(listado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveRecepcionPedido(List<beRecepcionesPedidosDetalles> lstrecepcionPedido)
        {
            try
            {
                var f = (ClsGenerica)Session["ClsGenerico"];
                var success_ = true;
                var mensaje_ = "<div class='alert alert-danger col-12' role='alert'>";
                IdPedido = (int)TempData["IdPedido"];
                ClsLiberarPedido pedido = new ClsLiberarPedido();
                var listado = pedido.getListadoPedidosLicitaciones_IdPedido(IdPedido);
                // validar campos

                // validar montos
                var cantidad = lstrecepcionPedido.Where(s => s.CantidadRecibida == 0 && s.CantidadxRecibir>0).ToList().Count();
                var cantidadReal = listado.Where(s => s.CantidadxRecibir > 0).ToList().Count();

                if (cantidad == cantidadReal)
                {
                    
                    success_ = false;
                    mensaje_ += "<div class='row col-12 text-justify'><i class='fa fa-exclamation-triangle fa-1x'></i><strong>&nbsp;Cantidad a recibir!&nbsp;</strong> intenta recepcionar valores en ceros, favor de capturar al menos una cantidad mayor a cero.</div>";
                }

                foreach(var item in lstrecepcionPedido.Where(s=> s.CantidadRecibida > 0).ToList())
                {
                    var lote = listado.Where(s => s.IdPedidoDetalle == item.IdPedidoDetalle && s.IdCondicionEntregaDetalle== item.IdCondicionEntregaDetalle).FirstOrDefault();
                    if(lote.IdLugarEntrega != item.IdLugarEntrega)
                    {
                        if (item.Observaciones == null || item.Observaciones.Trim() == "")
                        {
                            success_ = false;
                            mensaje_ += "<div class='row col-12 text-justify'><i class='fa fa-exclamation-triangle fa-1x'></i><strong>&nbsp;Lote No-" + lote.NoLote + "!&nbsp;</strong> falta capturar motivo de cambio de entrega.</div>";
                        }
                        
                    }
                    if(item.CantidadRecibida>lote.CantidadxRecibir)
                    {
                        success_ = false;
                        mensaje_ += "<div class='row col-12 text-justify'><i class='fa fa-exclamation-triangle fa-1x'></i><strong>&nbsp;Lote No-" + lote.NoLote + "!&nbsp;</strong> intenta captutar un valor mayor a lo pendiente a recepcionar.</div>";
                    }
                }
                if(success_)
                {
                    foreach (var item in lstrecepcionPedido.Where(s=>s.CantidadRecibida>0).ToList())
                    {
                        item.Observaciones = item.Observaciones == null?"": item.Observaciones;
                        item.IdUsuarioRegistro = (int)f.id2;
                        item.FechaRegistro = DateTime.Now;
                        pedido.saveDetalleRecepcionPedido(item);
                        var sumCantidadRecibida = pedido.getAllPedidosDetalleXIdPedidoDetalle(item.IdPedidoDetalle).Where(s=> s.IdCondicionEntregaDetalle== item.IdCondicionEntregaDetalle).ToList().Sum(s=>s.CantidadRecibida);
                        var PedidosDetalles = pedido.getPedidosDetalles(item.IdPedidoDetalle);
                        PedidosDetalles.CantidadRecibida = sumCantidadRecibida;
                        pedido.actualizarRecepcionPedido(PedidosDetalles);
                    }

                    listado = pedido.getListadoPedidosLicitaciones_IdPedido(IdPedido);
                    cantidad = listado.Where(s => s.CantidadxRecibir == 0).ToList().Count();
                    cantidadReal = listado.Count();
                    if (cantidad == cantidadReal)
                    {
                        var p = pedido.getPedido(IdPedido);
                        p.IdEstatusPedido = 5;
                        p.IdUsuarioRegistro = (int)f.id2;
                        p.FechaRegistro = DateTime.Now;
                        pedido.savePedido(p);
                    }
                    else {
                        var p = pedido.getPedido(IdPedido);
                        p.IdEstatusPedido = 4;
                        p.IdUsuarioRegistro = (int)f.id2;
                        p.FechaRegistro = DateTime.Now;
                        pedido.savePedido(p);
                    }
                        mensaje_ = " <div class='row'><div class='col-lg-12'><div class='alert alert-success' role='alert'><div class='row vertical-align'>" +
                                "<div class='col-1 text-center'><i class='fa fa-exclamation-triangle fa-0x'></i>&nbsp;</div>" +
                                "<div class='col-11'>" +
                                "<strong>&nbsp;Datos actualizados:</strong> se generó el detalle correctamente." +
                                "</div></div></div></div></div> ";
                }
                else
                {
                    mensaje_ += "</div> ";
                }
               
                TempData["IdPedido"] = IdPedido;
                return Json(new { success = success_, mensaje=mensaje_ }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                TempData["IdPedido"] = IdPedido;
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}