using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beAdjudicacionesFirmantes {

	public int IdAdjudicacionFirmante { get; set;}
	public int IdAdjudicacion { get; set;}
	public int IdEstatusAdjudicacion { get; set;}
	public int IdUsuarioSolicitante { get; set;}
	public int IdUsuarioAutoriza { get; set;}
	public bool ValidaLotes { get; set;}
	public string ObservacionLotes { get; set;}
	public bool ValidaCondicionEntrega { get; set;}
	public string OnservacionCondicionEntrega { get; set;}
	public bool ValidaCondicionPago { get; set;}
	public string ObservacionCondicionPago { get; set;}
	public string ObservacionLotesRevisor { get; set;}
	public bool ValidaLotesRevisor { get; set;}
	public string ObservacionConEntregaRevisor { get; set;}
	public bool ValidaCondicionEntregaRevisor { get; set;}
	public string ObservacionCondPagoRevisor { get; set;}
	public bool ValidaCondicionPagoRevisor { get; set;}
	public string ObservacionDoctosRevisor { get; set;}
	public bool ValidaDocumentosRevisor { get; set;}

	public beAdjudicacionesFirmantes()
	{
		
	}

	public beAdjudicacionesFirmantes( int pIdAdjudicacionFirmante, int pIdAdjudicacion, int pIdEstatusAdjudicacion, int pIdUsuarioSolicitante, int pIdUsuarioAutoriza, bool pValidaLotes, string pObservacionLotes, bool pValidaCondicionEntrega, string pOnservacionCondicionEntrega, bool pValidaCondicionPago, string pObservacionCondicionPago, string pObservacionLotesRevisor, bool pValidaLotesRevisor, string pObservacionConEntregaRevisor, bool pValidaCondicionEntregaRevisor, string pObservacionCondPagoRevisor, bool pValidaCondicionPagoRevisor, string pObservacionDoctosRevisor, bool pValidaDocumentosRevisor)
	{
		this.IdAdjudicacionFirmante = pIdAdjudicacionFirmante;
		this.IdAdjudicacion = pIdAdjudicacion;
		this.IdEstatusAdjudicacion = pIdEstatusAdjudicacion;
		this.IdUsuarioSolicitante = pIdUsuarioSolicitante;
		this.IdUsuarioAutoriza = pIdUsuarioAutoriza;
		this.ValidaLotes = pValidaLotes;
		this.ObservacionLotes = pObservacionLotes;
		this.ValidaCondicionEntrega = pValidaCondicionEntrega;
		this.OnservacionCondicionEntrega = pOnservacionCondicionEntrega;
		this.ValidaCondicionPago = pValidaCondicionPago;
		this.ObservacionCondicionPago = pObservacionCondicionPago;
		this.ObservacionLotesRevisor = pObservacionLotesRevisor;
		this.ValidaLotesRevisor = pValidaLotesRevisor;
		this.ObservacionConEntregaRevisor = pObservacionConEntregaRevisor;
		this.ValidaCondicionEntregaRevisor = pValidaCondicionEntregaRevisor;
		this.ObservacionCondPagoRevisor = pObservacionCondPagoRevisor;
		this.ValidaCondicionPagoRevisor = pValidaCondicionPagoRevisor;
		this.ObservacionDoctosRevisor = pObservacionDoctosRevisor;
		this.ValidaDocumentosRevisor = pValidaDocumentosRevisor;
	}


}
}
