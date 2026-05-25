using iGob.Entidades;
using iGob.ReglasNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class ClsLiberarPedido
    {
        public List<beListadoPedidosLicitaciones> getListadoPedidosLicitaciones(int pIdDependencia)
        {
            return (new brRecepcionesPedidosDetalles()).listarTodos_RecepcionesPedidos_Licitacion(pIdDependencia);
        }
        public List<beListadoPedidosLicitaciones> getListadoPedidosLicitaciones_IdPedido(int pIdPedido)
        {
            return (new brRecepcionesPedidosDetalles()).ListadoPedidosLicitaciones_IdPedido(pIdPedido);
        }
        public List<beLugaresEntregaFirma> getAllLugaresEntregaFirma(int IdTipoLugar)
        {
            var LugaresEntregaFirma = (new brLugaresEntregaFirma()).listarTodos_LugaresEntregaFirma().Where(s => s.IdTipoLugar == IdTipoLugar).ToList();

            return LugaresEntregaFirma;
        }
        public int saveDetalleRecepcionPedido(beRecepcionesPedidosDetalles oDetalleRecepcionPedido)
        {
            return (new brRecepcionesPedidosDetalles()).guardarRecepcionesPedidosDetalles(oDetalleRecepcionPedido);
        }
        public List<beRecepcionesPedidosDetalles> getAllPedidosDetalleXIdPedidoDetalle(int pIdPedidoDetalle)
        {
            return (new brRecepcionesPedidosDetalles()).listarTodos_RecepcionesPedidosDetalles().Where(s=>s.IdPedidoDetalle== pIdPedidoDetalle).ToList();
        }
        public int actualizarRecepcionPedido(bePedidosDetalles oPedidosDetalles)
        {
            return (new brPedidosDetalles()).actualizarPedidosDetalles(oPedidosDetalles);
        }
        public bePedidosDetalles getPedidosDetalles(int pIdPedidoDetalle)
        {
            return (new brPedidosDetalles()).traerPedidosDetalles_x_IdPedidoDetalle(pIdPedidoDetalle);
        }
        public bePedidos getPedido(int pIdPedido)
        {
            return (new brPedidos()).traerPedidos_x_IdPedido(pIdPedido);
        }
        public int savePedido(bePedidos oPedido)
        {
            return (new brPedidos()).actualizarPedidos(oPedido);
        }
        public bePedidoDetalleCabezera getCabezeraPedidoDetalles(int pIdPedido)
        {
            return (new brRecepcionesPedidosDetalles()).getCabezeraPedidoDetalles(pIdPedido);
        }
        public List<beListadoPedidosLicitaciones> getDetallePedidoLotes(int pIdPedido)
        {
            return (new brRecepcionesPedidosDetalles()).getDetallePedidoLotes(pIdPedido);
        }
        public beLicitaciones getLicitacion(int pIdLicitacion)
        {
            return (new brLicitaciones()).traerLicitaciones_x_IdLicitacion(pIdLicitacion);
        }
        public int saveLicitacion(beLicitaciones oLicitacion)
        {
            return (new brLicitaciones()).actualizarLicitaciones(oLicitacion);
        }
        public void generarEstusPedidos(List<beListadoPedidosLicitaciones> pLstPedidos,int pIdUsuario)
        {
            foreach(var item in pLstPedidos)
            {
                var listado = getListadoPedidosLicitaciones_IdPedido(item.IdPedido);
                var cantidad = listado.Where(s => s.CantidadxRecibir == 0).ToList().Count();
                var cantidadReal = listado.Count();
                if (cantidad == cantidadReal)
                {
                    var p = getPedido(item.IdPedido);
                    p.IdEstatusPedido = 5;
                    p.IdUsuarioRegistro = pIdUsuario; //(int)f.id2;
                    p.FechaRegistro = DateTime.Now;
                    savePedido(p);
                }
                else
                {
                    var suma = listado.Sum(s=> s.CantidadRecibida);
                    var idEstatus = 4;
                    if (suma == 0)
                    {
                        idEstatus = 1;
                    }
                    var p = getPedido(item.IdPedido);
                    p.IdEstatusPedido = idEstatus;
                    p.IdUsuarioRegistro = pIdUsuario;//(int)f.id2;
                    p.FechaRegistro = DateTime.Now;
                    savePedido(p);
                }
            }
            
        }
    }
}