using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
    public class beRecepcionesAdjudicacionesPedidosDetalles
    {

        public int IdRecepcionAdjudicacionDetalle { get; set; }
        public int IdAdjudicacionPedidoDetalle { get; set; }
        public int IdAdjCondicionEntregaDetalle { get; set; }
        public decimal CantidadRecibida { get; set; }
        public string Observaciones { get; set; }
        public int IdLugarEntrega { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioRegistro { get; set; }

        //util RecepcionesAdjudicacionesPedidosDetalles
        public int IdAdjudicacionPedido { set; get; }

        public beRecepcionesAdjudicacionesPedidosDetalles()
        {

        }

        public beRecepcionesAdjudicacionesPedidosDetalles(int pIdRecepcionAdjudicacionDetalle, int pIdAdjudicacionPedidoDetalle, int pIdAdjCondicionEntregaDetalle, decimal pCantidadRecibida, string pObservaciones, int pIdLugarEntrega, DateTime pFechaRegistro, int pIdUsuarioRegistro)
        {
            this.IdRecepcionAdjudicacionDetalle = pIdRecepcionAdjudicacionDetalle;
            this.IdAdjudicacionPedidoDetalle = pIdAdjudicacionPedidoDetalle;
            this.IdAdjCondicionEntregaDetalle = pIdAdjCondicionEntregaDetalle;
            this.CantidadRecibida = pCantidadRecibida;
            this.Observaciones = pObservaciones;
            this.IdLugarEntrega = pIdLugarEntrega;
            this.FechaRegistro = pFechaRegistro;
            this.IdUsuarioRegistro = pIdUsuarioRegistro;
        }


    }
}
