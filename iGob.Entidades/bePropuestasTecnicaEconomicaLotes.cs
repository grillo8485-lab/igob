using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class bePropuestasTecnicaEconomicaLotes {

	public int IdPropuestaTecnicaEconomica { get; set;}
	public int IdProveedorRqInvitacion { get; set;}
	public bool LoteOfertado { get; set;}
	public int IdLote { get; set;}
	public string Mejora { get; set;}
	public int EstatusMejora { get; set;}
	public decimal PrecioUnitarioRefencia { get; set;}
	public decimal PrecioUnitarioOfertado { get; set;}
	public decimal ImporteOfertado { get; set;}
	public decimal ImpuestoPorcentaje { get; set;}
	public decimal ImpuestoImporte { get; set;}
	public decimal TotalOfertado { get; set;}
	public string URLFileMuestraCatalogo { get; set;}
	public string URLFileCertificacion { get; set;}
	public bool DependenciaCumple { get; set;}
	public string FundamentoLegal { get; set;}
	public bool AdquisicionCumple { get; set;}
	public string AdquisicionObserva { get; set;}
	public int ValidaEconomica { get; set;}
	public decimal ImportePeriodo { get; set;}
	public decimal ImpuestoPeriodo { get; set;}
	public decimal TotalPeriodo { get; set;}
	public int IdMesInicial { get; set;}
	public int IdMesFinal { get; set;}
	public int IdEstatusPropuesta { get; set;}
	public int PropuestaGanadora { get; set;}
        public int IdRequisicion { get; set; }

        public bePropuestasTecnicaEconomicaLotes()
	{
		
	}

	public bePropuestasTecnicaEconomicaLotes( int pIdPropuestaTecnicaEconomica, int pIdProveedorRqInvitacion, bool pLoteOfertado, int pIdLote, string pMejora, int pEstatusMejora, decimal pPrecioUnitarioRefencia, decimal pPrecioUnitarioOfertado, decimal pImporteOfertado, decimal pImpuestoPorcentaje, decimal pImpuestoImporte, decimal pTotalOfertado, string pURLFileMuestraCatalogo, string pURLFileCertificacion, bool pDependenciaCumple, string pFundamentoLegal, bool pAdquisicionCumple, string pAdquisicionObserva, int pValidaEconomica, decimal pImportePeriodo, decimal pImpuestoPeriodo, decimal pTotalPeriodo, int pIdMesInicial, int pIdMesFinal, int pIdEstatusPropuesta, int pPropuestaGanadora)
	{
		this.IdPropuestaTecnicaEconomica = pIdPropuestaTecnicaEconomica;
		this.IdProveedorRqInvitacion = pIdProveedorRqInvitacion;
		this.LoteOfertado = pLoteOfertado;
		this.IdLote = pIdLote;
		this.Mejora = pMejora;
		this.EstatusMejora = pEstatusMejora;
		this.PrecioUnitarioRefencia = pPrecioUnitarioRefencia;
		this.PrecioUnitarioOfertado = pPrecioUnitarioOfertado;
		this.ImporteOfertado = pImporteOfertado;
		this.ImpuestoPorcentaje = pImpuestoPorcentaje;
		this.ImpuestoImporte = pImpuestoImporte;
		this.TotalOfertado = pTotalOfertado;
		this.URLFileMuestraCatalogo = pURLFileMuestraCatalogo;
		this.URLFileCertificacion = pURLFileCertificacion;
		this.DependenciaCumple = pDependenciaCumple;
		this.FundamentoLegal = pFundamentoLegal;
		this.AdquisicionCumple = pAdquisicionCumple;
		this.AdquisicionObserva = pAdquisicionObserva;
		this.ValidaEconomica = pValidaEconomica;
		this.ImportePeriodo = pImportePeriodo;
		this.ImpuestoPeriodo = pImpuestoPeriodo;
		this.TotalPeriodo = pTotalPeriodo;
		this.IdMesInicial = pIdMesInicial;
		this.IdMesFinal = pIdMesFinal;
		this.IdEstatusPropuesta = pIdEstatusPropuesta;
		this.PropuestaGanadora = pPropuestaGanadora;
	}


}
}
