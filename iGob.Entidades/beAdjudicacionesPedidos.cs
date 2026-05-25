using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beAdjudicacionesPedidos {

	public int IdAdjudicacionPedido { get; set;}
	public int IdAdjudicacionProveedor { get; set;}
	public int FolioNumero { get; set;}
	public string Folio { get; set;}
	public DateTime FechaPedido { get; set;}
	public int IdProveedor { get; set;}
	public int IdAdjudicacion { get; set;}
	public decimal Importe { get; set;}
	public decimal ImporteIva { get; set;}
	public decimal Total { get; set;}
	public int IdUsuarioRegistro { get; set;}
	public DateTime FechaRegistro { get; set;}
	public int IdEstatusPedido { get; set;}

	public beAdjudicacionesPedidos()
	{
		
	}

	public beAdjudicacionesPedidos( int pIdAdjudicacionPedido, int pIdAdjudicacionProveedor, int pFolioNumero, string pFolio, DateTime pFechaPedido, int pIdProveedor, int pIdAdjudicacion, decimal pImporte, decimal pImporteIva, decimal pTotal, int pIdUsuarioRegistro, DateTime pFechaRegistro, int pIdEstatusPedido)
	{
		this.IdAdjudicacionPedido = pIdAdjudicacionPedido;
		this.IdAdjudicacionProveedor = pIdAdjudicacionProveedor;
		this.FolioNumero = pFolioNumero;
		this.Folio = pFolio;
		this.FechaPedido = pFechaPedido;
		this.IdProveedor = pIdProveedor;
		this.IdAdjudicacion = pIdAdjudicacion;
		this.Importe = pImporte;
		this.ImporteIva = pImporteIva;
		this.Total = pTotal;
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
		this.FechaRegistro = pFechaRegistro;
		this.IdEstatusPedido = pIdEstatusPedido;
	}


}
}
