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
    public class LiberarPedidoLicitacionRequisicionController : ValidaSession
    {
        // GET: LiberarPedidoLicitacionRequisicion
        public ActionResult Index()
        {
            var IdLicitacion = (int)TempData["IdLicitacion"];
            var IdPedido = (int)TempData["IdPedido"];
            var licitacionFolio = TempData["TituloPorProceso"];
            ClsRequisiciones requisicion = new ClsRequisiciones();
            LiberarPedidoLicitacionRequisicion liberarPedido = new LiberarPedidoLicitacionRequisicion();
            var f = (ClsGenerica)Session["ClsGenerico"];
            ClsLiberarPedidoLicitacionRequisicion clsPedido = new ClsLiberarPedidoLicitacionRequisicion();
            ViewBag.IdPerfil = (int)f.id;
            liberarPedido.Pedido = clsPedido.getPedido(IdPedido, IdLicitacion, (int)ViewBag.IdPerfil);

            var r = requisicion.getRequisicion(liberarPedido.Pedido.IdRequisicion);
            liberarPedido.Partida= clsPedido.GetPartida_x_Id(r.IdPartida);
            liberarPedido.Dependencia = clsPedido.getDependencias(r.IdDependencia).Dependencia;
            liberarPedido.Proveedor = clsPedido.getProveedores(liberarPedido.Pedido.IdProveedor);
            var Municipio = clsPedido.getMunicipios(liberarPedido.Proveedor.IdMunicipio);
            var Estado = clsPedido.getEntidadesFederativas(Municipio.ClaveEstado);
            

            liberarPedido.Estado = Estado.Estado;
            liberarPedido.Municipio = Municipio.Municipio;
            liberarPedido.Pais = clsPedido.getPais(Estado.IdPais).Pais;
            var condicionesEntrega = clsPedido.getRequisicionesCondicionesEntregas(r.IdRequisicion);
            
            var RequisicionesCondicionesPagos = clsPedido.getRequisicionesCondicionesPagos(r.IdRequisicion);
            var condiconPago = clsPedido.getCondiconPago(RequisicionesCondicionesPagos.IdTipoCondicionPago);
            var tipoEntrega = clsPedido.getTipoEntrega(condicionesEntrega.IdTipoEntrega);
            var plazoTiempo = clsPedido.getPlazosTiempos(RequisicionesCondicionesPagos.IdPlazoTiempo);
            liberarPedido.CondicionesEntrega = tipoEntrega.TipoEntrega;
            liberarPedido.Titulo = licitacionFolio + " - " + liberarPedido.Pedido.RequisicionFolio + " - " + liberarPedido.Partida;
            liberarPedido.CondicionesPago = condiconPago.Condicion;
            liberarPedido.PlazosTiempos = plazoTiempo.PlazozTiempo;
            liberarPedido.lstManifiesto = clsPedido.getManifiestoProveedoresDeclaratorias(IdPedido);
            liberarPedido.lstPedidosFirmantes = clsPedido.getListadoLicitacionesInvitacionProveedores(IdPedido, (int)f.id, (String)Session["Usuario"]);
            liberarPedido.lstPedidoDetallesLotesEntregas = clsPedido.getPedidoDetallesLotesEntregas_x_IdPedido(IdPedido);
            liberarPedido.SutTotal = liberarPedido.lstPedidoDetallesLotesEntregas.Sum(s => s.Importe);
            liberarPedido.Impuesto = liberarPedido.lstPedidoDetallesLotesEntregas.Sum(s => s.ImporteIva);
            liberarPedido.Total = liberarPedido.SutTotal + liberarPedido.Impuesto;
            liberarPedido.Fecha = DateTime.Now;
            var condicionesDeEntrega = clsPedido.getAllRequisicionCondiconesDeEntrega_x_IdRequisicion(r.IdRequisicion);
            var PlazoEntrega = clsPedido.getAllPlazoEntrega(condicionesDeEntrega.IdPlazoEntegra);
            liberarPedido.PlazoEntrega = PlazoEntrega.PlazoEntrega;
            Enletras letra = new Enletras();
            liberarPedido.TotalLetras = letra.enletras(liberarPedido.Total.ToString());
            liberarPedido.IdPerfil = (int)f.id;
            TempData["IdLicitacion"] = IdLicitacion;
            TempData["IdPedido"] = IdPedido;
            TempData["TituloPorProceso"] = licitacionFolio;
            if (liberarPedido.lstPedidosFirmantes.Where(s => s.IdEstatusFirmaPedido == 2).ToList().Count == liberarPedido.lstPedidosFirmantes.Count)
            {
                var pedido = clsPedido.getPedido(IdPedido);
                pedido.IdEstatusPedido = 2;
                pedido.FechaRegistro = DateTime.Now;
                clsPedido.savePedido(pedido);
            }
            return View(liberarPedido);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveFirmateLiberarPedido(int IdFirmantePedido)
        {
            var IdPedido = (int)TempData["IdPedido"];
            try
            {
                var f = (ClsGenerica)Session["ClsGenerico"];
                
                ClsLiberarPedidoLicitacionRequisicion liberarPedido = new ClsLiberarPedidoLicitacionRequisicion();
                var b = liberarPedido.getPedidoFirmantes(IdFirmantePedido);
                b.IdEstatusFirmaPedido = 2;
                b.IdUsuarioFirmante = (int)f.id2;
                b.FechaFirma = DateTime.Now;
                liberarPedido.savePedidoFirmantes(b);
                var listado = liberarPedido.getListadoLicitacionesInvitacionProveedores(IdPedido, (int)f.id, (String)Session["Usuario"]);
                if(listado.Where(s=> s.IdEstatusFirmaPedido==2).ToList().Count== listado.Count)
                {
                    var pedido = liberarPedido.getPedido(IdPedido);
                    pedido.IdEstatusPedido = 2;
                    pedido.FechaRegistro = DateTime.Now;
                    liberarPedido.savePedido(pedido);
                }
                TempData["IdPedido"] = IdPedido;
                return Json(new { success = true, objeto = b }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                TempData["IdPedido"] = IdPedido;
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ImprimirSolicitud(int pIdPedido)
        {
            try
            {
                ClsLicitacionesImprimirPedido ReqSol = new ClsLicitacionesImprimirPedido(Server.MapPath("~/Files/Reportes/"), Server.MapPath("~/Files/Plantillas/"));

                //obtenemos el gobierno
                var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                int IdGobierno = usuario.id5;

                string Archivo = ReqSol.ImprimeArchivo(pIdPedido, IdGobierno);

                return Json(new { success = true, Descarga = Archivo }, JsonRequestBehavior.AllowGet); ;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}