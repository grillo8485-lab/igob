using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beRequisicionesCondicionesPagosDetalles {

	public int IdRqCondicionPagoDetalle { get; set;}
	public int IdRequiscionCondicionPago { get; set;}
	public DateTime FechaPago { get; set;}
	public decimal PorcentajePago { get; set;}
	public int NumeroPago { get; set;}
	public decimal ImportePago { get; set;}

	public beRequisicionesCondicionesPagosDetalles()
	{
		
	}

	public beRequisicionesCondicionesPagosDetalles( int pIdRqCondicionPagoDetalle, int pIdRequiscionCondicionPago, DateTime pFechaPago, decimal pPorcentajePago, int pNumeroPago, decimal pImportePago)
	{
		this.IdRqCondicionPagoDetalle = pIdRqCondicionPagoDetalle;
		this.IdRequiscionCondicionPago = pIdRequiscionCondicionPago;
		this.FechaPago = pFechaPago;
		this.PorcentajePago = pPorcentajePago;
		this.NumeroPago = pNumeroPago;
		this.ImportePago = pImportePago;
	}


}
}
