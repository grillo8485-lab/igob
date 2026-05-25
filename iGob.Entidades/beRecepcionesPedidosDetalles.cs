using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
    public class beRecepcionesPedidosDetalles
    {

        public int IdRecepcionDetalle { get; set; }
        public int IdPedidoDetalle { get; set; }
        public int IdCondicionEntregaDetalle { get; set; }
        public decimal CantidadRecibida { get; set; }
        public string Observaciones { get; set; }
        public int IdLugarEntrega { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public decimal CantidadxRecibir { get; set; }

        public beRecepcionesPedidosDetalles()
        {

        }

        public beRecepcionesPedidosDetalles(int pIdRecepcionDetalle, int pIdPedidoDetalle, int pIdCondicionEntregaDetalle, decimal pCantidadRecibida, string pObservaciones, int pIdLugarEntrega, DateTime pFechaRegistro, int pIdUsuarioRegistro)
        {
            this.IdRecepcionDetalle = pIdRecepcionDetalle;
            this.IdPedidoDetalle = pIdPedidoDetalle;
            this.IdCondicionEntregaDetalle = pIdCondicionEntregaDetalle;
            this.CantidadRecibida = pCantidadRecibida;
            this.Observaciones = pObservaciones;
            this.IdLugarEntrega = pIdLugarEntrega;
            this.FechaRegistro = pFechaRegistro;
            this.IdUsuarioRegistro = pIdUsuarioRegistro;
        }


    }
}
