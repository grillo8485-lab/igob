using System;
using System.Data;

namespace iGob.Entidades
{
    public class beRepAdjudicacionPedido
    {
        //AdjudicacionPedido
        public string Folio { get; set; }
        public string AdjudicacionFolio { get; set; }
        public string Partida { get; set; }
        public string RazonSocial { get; set; }
        public string Rfc { get; set; }
        public string Calle { get; set; }
        public string NoExterior { get; set; }
        public string NoInterior { get; set; }
        public string Colonia { get; set; }
        public string CodigoPostal { get; set; }
        public string Email { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public DateTime FechaLimite { get; set; }
        public string Dependencia { get; set; }
        public string TipoEntrega { get; set; }

        public int PlazoPagoCantidad { get; set; }
        public string PlazozTiempoPago { get; set; }
        public string TipoDiaPago { get; set; }
        public string Condicion { get; set; }
        public int PlazoEntregaCantidad { get; set; }
        public string PlazozTiempoEntrega { get; set; }
        public string TipoDiaEntrega { get; set; }
        public string PlazoEntrega { get; set; }


        //AdjudicacionPedidoDetalles
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

        public beRepAdjudicacionPedido()
        {

        }
    }
}
