using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beAdjudicacionesPedidosDetalles {

	public int IdAdjudicacionPedidoDetalle { get; set;}
	public int IdAdjudicacionPedido { get; set;}
	public int IdBienServicio { get; set;}
	public decimal Cantidad { get; set;}
	public decimal CantidadRecibida { get; set;}
	public decimal PrecioUnitario { get; set;}
	public decimal Importe { get; set;}
	public decimal ImporteIva { get; set;}
	public decimal Total { get; set;}
	public int IdCondicionEntregaDetalle { get; set;}
	public int IdAdjudicacionLote { get; set;}

	public beAdjudicacionesPedidosDetalles()
	{
		
	}

	public beAdjudicacionesPedidosDetalles( int pIdAdjudicacionPedidoDetalle, int pIdAdjudicacionPedido, int pIdBienServicio, decimal pCantidad, decimal pCantidadRecibida, decimal pPrecioUnitario, decimal pImporte, decimal pImporteIva, decimal pTotal, int pIdCondicionEntregaDetalle, int pIdAdjudicacionLote)
	{
		this.IdAdjudicacionPedidoDetalle = pIdAdjudicacionPedidoDetalle;
		this.IdAdjudicacionPedido = pIdAdjudicacionPedido;
		this.IdBienServicio = pIdBienServicio;
		this.Cantidad = pCantidad;
		this.CantidadRecibida = pCantidadRecibida;
		this.PrecioUnitario = pPrecioUnitario;
		this.Importe = pImporte;
		this.ImporteIva = pImporteIva;
		this.Total = pTotal;
		this.IdCondicionEntregaDetalle = pIdCondicionEntregaDetalle;
		this.IdAdjudicacionLote = pIdAdjudicacionLote;
	}


}
}
