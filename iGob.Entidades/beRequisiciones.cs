using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beRequisiciones {

	public int IdRequisicion { get; set;}
	public int IdRequisicionOrigen { get; set;}
	public int IdDependencia { get; set;}
	public int IdTipoRequisicion { get; set;}
	public int IdTipoSolicitud { get; set;}
	public int IdOrigenRecurso { get; set;}
	public int IdOrigenRecursoAutorizado { get; set;}
	public int IdEstatus { get; set;}
	public int IdEstatusRequisicion { get; set;}
	public int NumeroLicitacion { get; set;}
	public int IdTiempo { get; set;}
	public int IdFormaAbastecimiento { get; set;}
	public int IdPartida { get; set;}
	public int IdEjercicioFiscal { get; set;}
	public int IdPresupuestoPartida { get; set;}
	public DateTime FechaRequisicion { get; set;}
	public string RequisicionFolio { get; set;}
	public int ConsecutivoRequisicion { get; set;}
	public string NumeroOficioSolicitud { get; set;}
	public string NumeroOficioCertificacion { get; set;}
	public decimal MontoAproximado { get; set;}
	public decimal MontoAproximadoAutorizado { get; set;}
	public int CantidadLotes { get; set;}
	public decimal ImporteTotalLotes { get; set;}
	public string Observaciones { get; set;}
	public string ObservacionesRechazo { get; set;}
	public TimeSpan TiempoRestante { get; set;}
	public string ColorTiempoRestante { get; set;}
	public decimal SaldoPartida { get; set;}
	public decimal MontoPresupuestado { get; set;}
    public decimal TotalLiquidez { get; set; }
    public int IdUsuarioAsignante { get; set;}
	public int Acepta2daLicitacion { get; set;}
	public int IdUsuarioRevisor { get; set;}
	public DateTime FechaAsignaRevisor { get; set;}
	public DateTime FechaAutorizacion { get; set;}
	public decimal Economia { get; set;}
	public decimal Ejercido { get; set;}
	public int IdUsuarioRegistro { get; set;}
	public DateTime FechaRegistro { get; set;}

	public beRequisiciones()
	{
		
	}

	public beRequisiciones( int pIdRequisicion, int pIdRequisicionOrigen, int pIdDependencia, int pIdTipoRequisicion, int pIdTipoSolicitud, int pIdOrigenRecurso, int pIdOrigenRecursoAutorizado, int pIdEstatus, int pIdEstatusRequisicion, int pNumeroLicitacion, int pIdTiempo, int pIdFormaAbastecimiento, int pIdPartida, int pIdEjercicioFiscal, int pIdPresupuestoPartida, DateTime pFechaRequisicion, string pRequisicionFolio, int pConsecutivoRequisicion, string pNumeroOficioSolicitud, string pNumeroOficioCertificacion, decimal pMontoAproximado, decimal pMontoAproximadoAutorizado, int pCantidadLotes, decimal pImporteTotalLotes, string pObservaciones, string pObservacionesRechazo, TimeSpan pTiempoRestante, string pColorTiempoRestante, decimal pSaldoPartida, decimal pMontoPresupuestado, decimal pTotalLiquidez, int pIdUsuarioAsignante, int pAcepta2daLicitacion, int pIdUsuarioRevisor, DateTime pFechaAsignaRevisor, DateTime pFechaAutorizacion, decimal pEconomia, decimal pEjercido, int pIdUsuarioRegistro, DateTime pFechaRegistro)
	{
		this.IdRequisicion = pIdRequisicion;
		this.IdRequisicionOrigen = pIdRequisicionOrigen;
		this.IdDependencia = pIdDependencia;
		this.IdTipoRequisicion = pIdTipoRequisicion;
		this.IdTipoSolicitud = pIdTipoSolicitud;
		this.IdOrigenRecurso = pIdOrigenRecurso;
		this.IdOrigenRecursoAutorizado = pIdOrigenRecursoAutorizado;
		this.IdEstatus = pIdEstatus;
		this.IdEstatusRequisicion = pIdEstatusRequisicion;
		this.NumeroLicitacion = pNumeroLicitacion;
		this.IdTiempo = pIdTiempo;
		this.IdFormaAbastecimiento = pIdFormaAbastecimiento;
		this.IdPartida = pIdPartida;
		this.IdEjercicioFiscal = pIdEjercicioFiscal;
		this.IdPresupuestoPartida = pIdPresupuestoPartida;
		this.FechaRequisicion = pFechaRequisicion;
		this.RequisicionFolio = pRequisicionFolio;
		this.ConsecutivoRequisicion = pConsecutivoRequisicion;
		this.NumeroOficioSolicitud = pNumeroOficioSolicitud;
		this.NumeroOficioCertificacion = pNumeroOficioCertificacion;
		this.MontoAproximado = pMontoAproximado;
		this.MontoAproximadoAutorizado = pMontoAproximadoAutorizado;
		this.CantidadLotes = pCantidadLotes;
		this.ImporteTotalLotes = pImporteTotalLotes;
		this.Observaciones = pObservaciones;
		this.ObservacionesRechazo = pObservacionesRechazo;
		this.TiempoRestante = pTiempoRestante;
		this.ColorTiempoRestante = pColorTiempoRestante;
		this.SaldoPartida = pSaldoPartida;
		this.MontoPresupuestado = pMontoPresupuestado;
        this.TotalLiquidez = pTotalLiquidez;
		this.IdUsuarioAsignante = pIdUsuarioAsignante;
		this.Acepta2daLicitacion = pAcepta2daLicitacion;
		this.IdUsuarioRevisor = pIdUsuarioRevisor;
		this.FechaAsignaRevisor = pFechaAsignaRevisor;
		this.FechaAutorizacion = pFechaAutorizacion;
		this.Economia = pEconomia;
		this.Ejercido = pEjercido;
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
		this.FechaRegistro = pFechaRegistro;
	}


}
}
