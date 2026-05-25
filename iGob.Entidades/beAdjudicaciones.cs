using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beAdjudicaciones {

	public int IdAdjudicacion { get; set;}
	public int IdDependencia { get; set;}
	public int IdTipoAdjudicacion { get; set;}
	public int IdTipoSolicitud { get; set;}
	public int IdOrigenRecurso { get; set;}
	public int IdOrigenRecursoAutorizado { get; set;}
	public int IdEstatus { get; set;}
	public int IdEstatusAdjudicacion { get; set;}
	public int IdPartida { get; set;}
	public int IdEjercicioFiscal { get; set;}
	public int IdPresupuestoPartida { get; set;}
	public DateTime FechaAdjudicacion { get; set;}
	public string AdjudicacionFolio { get; set;}
	public int ConsecutivoAdjudicacion { get; set;}
	public string NumeroOficioSolicitud { get; set;}
	public string NumeroOficioCertificacion { get; set;}
	public decimal MontoAproximado { get; set;}
	public decimal MontoAproximadoAutorizado { get; set;}
	public int CantidadLotes { get; set;}
	public decimal ImporteTotalLotes { get; set;}
	public string Observaciones { get; set;}
	public string Justificacion { get; set;}
	public decimal SaldoPartida { get; set;}
	public decimal MontoPresupuestado { get; set;}
	public int IdUsuarioAsignante { get; set;}
	public int Acepta2daLicitacion { get; set;}
	public int IdUsuarioRevisor { get; set;}
	public DateTime FechaAsignaRevisor { get; set;}
	public DateTime FechaAutorizacion { get; set;}
	public decimal Economia { get; set;}
	public decimal Ejercido { get; set;}
	public int IdUsuarioRegistro { get; set;}
	public DateTime FechaRegistro { get; set;}
    public string AcuerdoAutorizacionComite { get; set; }
    public decimal TotalLiquidez { get; set; }
        public bool isApprove { get; set; }

    public beAdjudicaciones()
	{
		
	}

	public beAdjudicaciones( int pIdAdjudicacion, int pIdDependencia, int pIdTipoAdjudicacion, int pIdTipoSolicitud, int pIdOrigenRecurso, int pIdOrigenRecursoAutorizado, int pIdEstatus, int pIdEstatusAdjudicacion, int pIdPartida, int pIdEjercicioFiscal, int pIdPresupuestoPartida, DateTime pFechaAdjudicacion, string pAdjudicacionFolio, int pConsecutivoAdjudicacion, string pNumeroOficioSolicitud, string pNumeroOficioCertificacion, decimal pMontoAproximado, decimal pMontoAproximadoAutorizado, int pCantidadLotes, decimal pImporteTotalLotes, string pObservaciones, string pJustificacion, decimal pSaldoPartida, decimal pMontoPresupuestado, int pIdUsuarioAsignante, int pAcepta2daLicitacion, int pIdUsuarioRevisor, DateTime pFechaAsignaRevisor, DateTime pFechaAutorizacion, decimal pEconomia, decimal pEjercido, int pIdUsuarioRegistro, DateTime pFechaRegistro, string pAcuerdoAutorizacionComite, decimal pTotalLiquidez, bool pisApprove)
	{
		this.IdAdjudicacion = pIdAdjudicacion;
		this.IdDependencia = pIdDependencia;
		this.IdTipoAdjudicacion = pIdTipoAdjudicacion;
		this.IdTipoSolicitud = pIdTipoSolicitud;
		this.IdOrigenRecurso = pIdOrigenRecurso;
		this.IdOrigenRecursoAutorizado = pIdOrigenRecursoAutorizado;
		this.IdEstatus = pIdEstatus;
		this.IdEstatusAdjudicacion = pIdEstatusAdjudicacion;
		this.IdPartida = pIdPartida;
		this.IdEjercicioFiscal = pIdEjercicioFiscal;
		this.IdPresupuestoPartida = pIdPresupuestoPartida;
		this.FechaAdjudicacion = pFechaAdjudicacion;
		this.AdjudicacionFolio = pAdjudicacionFolio;
		this.ConsecutivoAdjudicacion = pConsecutivoAdjudicacion;
		this.NumeroOficioSolicitud = pNumeroOficioSolicitud;
		this.NumeroOficioCertificacion = pNumeroOficioCertificacion;
		this.MontoAproximado = pMontoAproximado;
		this.MontoAproximadoAutorizado = pMontoAproximadoAutorizado;
		this.CantidadLotes = pCantidadLotes;
		this.ImporteTotalLotes = pImporteTotalLotes;
		this.Observaciones = pObservaciones;
		this.Justificacion = pJustificacion;
		this.SaldoPartida = pSaldoPartida;
		this.MontoPresupuestado = pMontoPresupuestado;
		this.IdUsuarioAsignante = pIdUsuarioAsignante;
		this.Acepta2daLicitacion = pAcepta2daLicitacion;
		this.IdUsuarioRevisor = pIdUsuarioRevisor;
		this.FechaAsignaRevisor = pFechaAsignaRevisor;
		this.FechaAutorizacion = pFechaAutorizacion;
		this.Economia = pEconomia;
		this.Ejercido = pEjercido;
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
		this.FechaRegistro = pFechaRegistro;
        this.AcuerdoAutorizacionComite = pAcuerdoAutorizacionComite;
        this.TotalLiquidez = pTotalLiquidez;
        this.isApprove = pisApprove;

    }


}
}
