using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beAdjudicacionesCondicionesPagos {

	public int IdAdjudicacionCondicionPago { get; set;}
	public int IdAdjudicacion { get; set;}
	public int Anticipo { get; set;}
	public decimal PorcentajeAnticipo { get; set;}
	public decimal ImporteAnticipo { get; set;}
	public int IdPeriodicidad { get; set;}
	public DateTime FechaInicioPago { get; set;}
	public int NumeroPagos { get; set;}
	public decimal ImporteTotalPagos { get; set;}
	public int IdEstatus { get; set;}
	public string Observaciones { get; set;}
	public int IdTipoCondicionPago { get; set;}
	public int IdTipoDia { get; set;}
	public int IdPlazoTiempo { get; set;}
	public int IdLugarFirma { get; set;}
	public int PlazoPagoCantidad { get; set;}
	public DateTime FechaRegistro { get; set;}
	public int IdUsuarioRegistro { get; set;}

	public beAdjudicacionesCondicionesPagos()
	{
		
	}

	public beAdjudicacionesCondicionesPagos( int pIdAdjudicacionCondicionPago, int pIdAdjudicacion, int pAnticipo, decimal pPorcentajeAnticipo, decimal pImporteAnticipo, int pIdPeriodicidad, DateTime pFechaInicioPago, int pNumeroPagos, decimal pImporteTotalPagos, int pIdEstatus, string pObservaciones, int pIdTipoCondicionPago, int pIdTipoDia, int pIdPlazoTiempo, int pIdLugarFirma, int pPlazoPagoCantidad, DateTime pFechaRegistro, int pIdUsuarioRegistro)
	{
		this.IdAdjudicacionCondicionPago = pIdAdjudicacionCondicionPago;
		this.IdAdjudicacion = pIdAdjudicacion;
		this.Anticipo = pAnticipo;
		this.PorcentajeAnticipo = pPorcentajeAnticipo;
		this.ImporteAnticipo = pImporteAnticipo;
		this.IdPeriodicidad = pIdPeriodicidad;
		this.FechaInicioPago = pFechaInicioPago;
		this.NumeroPagos = pNumeroPagos;
		this.ImporteTotalPagos = pImporteTotalPagos;
		this.IdEstatus = pIdEstatus;
		this.Observaciones = pObservaciones;
		this.IdTipoCondicionPago = pIdTipoCondicionPago;
		this.IdTipoDia = pIdTipoDia;
		this.IdPlazoTiempo = pIdPlazoTiempo;
		this.IdLugarFirma = pIdLugarFirma;
		this.PlazoPagoCantidad = pPlazoPagoCantidad;
		this.FechaRegistro = pFechaRegistro;
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
	}


}
}
