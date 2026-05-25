using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beRequisicionesCondicionesPagos {

	public int IdRequisicionCondicionPago { get; set;}
	public int IdRequisicion { get; set;}
	public bool Anticipo { get; set;}
	public int IdAnticipo { get; set;}
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
	public int IdUsuarioRegistro { get; set;}
	public DateTime FechaRegistro { get; set;}

	public beRequisicionesCondicionesPagos()
	{
		
	}

	public beRequisicionesCondicionesPagos( int pIdRequisicionCondicionPago, int pIdRequisicion, bool pAnticipo, int pIdAnticipo, decimal pPorcentajeAnticipo, decimal pImporteAnticipo, int pIdPeriodicidad, DateTime pFechaInicioPago, int pNumeroPagos, decimal pImporteTotalPagos, int pIdEstatus, string pObservaciones, int pIdTipoCondicionPago, int pIdTipoDia, int pIdPlazoTiempo, int pIdLugarFirma, int pPlazoPagoCantidad, int pIdUsuarioRegistro, DateTime pFechaRegistro)
	{
		this.IdRequisicionCondicionPago = pIdRequisicionCondicionPago;
		this.IdRequisicion = pIdRequisicion;
		this.Anticipo = pAnticipo;
		this.IdAnticipo = pIdAnticipo;
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
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
		this.FechaRegistro = pFechaRegistro;
	}


}
}
