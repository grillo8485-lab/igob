using IGOB.Areas.Catalogos.Models;
using IGOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Controllers
{
    public class DetalleRecepcionPedidoController : ValidaSession
    {
        // GET: DetalleRecepcionPedido
        public ActionResult Index()
        {
            var f = (ClsGenerica)Session["ClsGenerico"];
            var IdPedido = (int)TempData["IdPedido"];
            ClsLiberarPedido pedido = new ClsLiberarPedido();
            PedidoDetalleLotes model = new PedidoDetalleLotes();
            model.oCabezera = pedido.getCabezeraPedidoDetalles(IdPedido);
            model.Detalle = pedido.getDetallePedidoLotes(IdPedido);
            var listado = pedido.getListadoPedidosLicitaciones_IdPedido(IdPedido);
            ViewBag.lstLugarEntregaFirma = pedido.getAllLugaresEntregaFirma(1);// new SelectList(pedido.getAllLugaresEntregaFirma(1), "IdLugarEntregaFirma", "Lugar");
            ViewBag.IdPedido = IdPedido;
            TempData["IdPedido"] = IdPedido;
            return View(model);
            
        }

        public ActionResult DescargaRecepcion(int IdPedido)
        {
            ClsImprimirRepRecepcionPedidos Print = new ClsImprimirRepRecepcionPedidos();
            byte[] abytes = Print.PrepararReporte(IdPedido);
            return File(abytes, "application/pdf");
        }
    }
}