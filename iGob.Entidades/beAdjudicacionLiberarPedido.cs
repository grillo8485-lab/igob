using System;
using System.Data;

namespace iGob.Entidades
{
    public class beAdjudicacionLiberarPedido
    {
        public int IdAdjudicacionPedido { get; set; }
        public string BienServicio { get; set; }
        public int NoLote { get; set; }
        public decimal Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public decimal PrecioUnitarioOfertado { get; set; }
        public decimal ImporteOfertado { get; set; }
        public decimal ImpuestoImporte { get; set; }
        public decimal TotalPeriodo { get; set; }
        public string Lugar { get; set; }
        public string HorarioEntrega { get; set; }
        public string DiasEntrega { get; set; }

        //tabla recepcion pedidos
        public string Folio { get; set; }
        public int FolioNumero { get; set; }
        public int IdEstatusPedido { get; set; }
        public int IdLote { get; set; }
        public int IdRecepcionAdjudicacionDetalle { get; set; }
        public decimal CantidadRecibida { get; set; }
        public string LugarEntrega { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string NombreResponsable { get; set; }
        public string Observaciones { get; set; }
        public decimal CantidadxRecibir { get; set; }
        public int IdLugarEntrega { get; set; }
        public int IdAdjudicacionPedidoDetalle { get; set; }
        public decimal CantidadRecepcionar { get; set; }
        public int IdAdCondicionEntregaDetalle { get; set; }
        //tabla detalles entrega
        public int IdLugarEntregado { get; set; }
        public string LugarEntregado { get; set; }




        public beAdjudicacionLiberarPedido() { }
    }
}
