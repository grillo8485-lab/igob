using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beAdjudicacionesCondicionesPagosDetalles {

	public int IdAdCondicionPagoDetalle { get; set;}
	public int IdAdjudicacionCondicionPago { get; set;}
	public DateTime FechaPago { get; set;}
	public decimal PorcentajePago { get; set;}
	public int NumeroPago { get; set;}
	public decimal ImportePago { get; set;}

	public beAdjudicacionesCondicionesPagosDetalles()
	{
		
	}

	public beAdjudicacionesCondicionesPagosDetalles( int pIdAdCondicionPagoDetalle, int pIdAdjudicacionCondicionPago, DateTime pFechaPago, decimal pPorcentajePago, int pNumeroPago, decimal pImportePago)
	{
		this.IdAdCondicionPagoDetalle = pIdAdCondicionPagoDetalle;
		this.IdAdjudicacionCondicionPago = pIdAdjudicacionCondicionPago;
		this.FechaPago = pFechaPago;
		this.PorcentajePago = pPorcentajePago;
		this.NumeroPago = pNumeroPago;
		this.ImportePago = pImportePago;
	}


}
}
