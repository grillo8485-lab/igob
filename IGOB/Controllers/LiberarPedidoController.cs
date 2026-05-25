using IGOB.Areas.Catalogos.Models;
using IGOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Controllers
{
    public class LiberarPedidoController : ValidaSession
    {
        // GET: LiberarPedido
        public ActionResult Index()
        {
            var f = (ClsGenerica)Session["ClsGenerico"];
            ClsLiberarPedido pedido = new ClsLiberarPedido();
            
            var listado = pedido.getListadoPedidosLicitaciones(f.id4);
            pedido.generarEstusPedidos(listado, (int)f.id2);
            listado = pedido.getListadoPedidosLicitaciones(f.id4);
            
            return View(listado);
        }
        [HttpGet]
        public ActionResult PedidoDetalle(int IdPedido)
        {
            TempData["IdPedido"] = IdPedido;
            return RedirectToAction("Index", "RecepcionarPedidoDetalle");
        }
        [HttpGet]
        public ActionResult PedidoDetalleRecepcion(int IdPedido)
        {
            TempData["IdPedido"] = IdPedido;
            return RedirectToAction("Index", "DetalleRecepcionPedido");
        }
    }
}