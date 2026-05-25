using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beLicitaciones {

	public int IdLicitacion { get; set;}
	public int IdConfiguracionModalidad { get; set;}
	public int IdModalidadLicitacion { get; set;}
	public int IdEtapaLicitacion { get; set;}
	public string FolioOficial { get; set;}
	public decimal MontoBases { get; set;}
	public int NumeroLicitacion { get; set;}
	public DateTime FechaAutorizacion { get; set;}
	public TimeSpan HoraAutorizacion { get; set;}
	public DateTime FechaPublicacion { get; set;}
	public DateTime FechaDisposicionBases { get; set;}
	public DateTime FechaLimitePreguntas { get; set;}
	public DateTime FechaLimiteRespuestas { get; set;}
	public DateTime FechaHoraAclaracionDudas { get; set;}
	public DateTime FechaEnvioPropuestasTecEco { get; set;}
	public DateTime FechaLimiteDictamen { get; set;}
	public DateTime FechaFallo { get; set;}
	public TimeSpan HoraFallo { get; set;}
	public int IdTipoLicitacion { get; set;}
	public int IdTiempo { get; set;}
	public int IdEjercicioFiscal { get; set;}
	public int IdUnidadLicitadora { get; set;}
	public int IdUsuarioRevisor { get; set;}
	public int IdEstatusLicitacion { get; set;}
	public int IdUsuarioRegistro { get; set;}
	public DateTime FechaRegistro { get; set;}
	public int TiempoPeriodoPujasHrs { get; set;}
	public int TiempoAdicionalPujasMin { get; set;}
	public int TiempoEtapaFinalMin { get; set;}
	public bool AplicaNomenclaturaInvolucrados { get; set;}
	public bool MostrarMontoPropuestaGanando { get; set;}
	public bool MostrarLugarProveedor { get; set;}
        public string Modalidad = string.Empty;
        public int EjercicioFiscal = int.MinValue;
        public string Tiempo = string.Empty;



        public beLicitaciones()
	{
		
	}

	public beLicitaciones( int pIdLicitacion, int pIdConfiguracionModalidad, int pIdModalidadLicitacion, int pIdEtapaLicitacion, string pFolioOficial, decimal pMontoBases, int pNumeroLicitacion, DateTime pFechaAutorizacion, TimeSpan pHoraAutorizacion, DateTime pFechaPublicacion, DateTime pFechaDisposicionBases, DateTime pFechaLimitePreguntas, DateTime pFechaLimiteRespuestas, DateTime pFechaHoraAclaracionDudas, DateTime pFechaEnvioPropuestasTecEco, DateTime pFechaLimiteDictamen, DateTime pFechaFallo, TimeSpan pHoraFallo, int pIdTipoLicitacion, int pIdTiempo, int pIdEjercicioFiscal, int pIdUnidadLicitadora, int pIdUsuarioRevisor, int pIdEstatusLicitacion, int pIdUsuarioRegistro, DateTime pFechaRegistro, int pTiempoPeriodoPujasHrs, int pTiempoAdicionalPujasMin, int pTiempoEtapaFinalMin, bool pAplicaNomenclaturaInvolucrados, bool pMostrarMontoPropuestaGanando, bool pMostrarLugarProveedor)
	{
		this.IdLicitacion = pIdLicitacion;
		this.IdConfiguracionModalidad = pIdConfiguracionModalidad;
		this.IdModalidadLicitacion = pIdModalidadLicitacion;
		this.IdEtapaLicitacion = pIdEtapaLicitacion;
		this.FolioOficial = pFolioOficial;
		this.MontoBases = pMontoBases;
		this.NumeroLicitacion = pNumeroLicitacion;
		this.FechaAutorizacion = pFechaAutorizacion;
		this.HoraAutorizacion = pHoraAutorizacion;
		this.FechaPublicacion = pFechaPublicacion;
		this.FechaDisposicionBases = pFechaDisposicionBases;
		this.FechaLimitePreguntas = pFechaLimitePreguntas;
		this.FechaLimiteRespuestas = pFechaLimiteRespuestas;
		this.FechaHoraAclaracionDudas = pFechaHoraAclaracionDudas;
		this.FechaEnvioPropuestasTecEco = pFechaEnvioPropuestasTecEco;
		this.FechaLimiteDictamen = pFechaLimiteDictamen;
		this.FechaFallo = pFechaFallo;
		this.HoraFallo = pHoraFallo;
		this.IdTipoLicitacion = pIdTipoLicitacion;
		this.IdTiempo = pIdTiempo;
		this.IdEjercicioFiscal = pIdEjercicioFiscal;
		this.IdUnidadLicitadora = pIdUnidadLicitadora;
		this.IdUsuarioRevisor = pIdUsuarioRevisor;
		this.IdEstatusLicitacion = pIdEstatusLicitacion;
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
		this.FechaRegistro = pFechaRegistro;
		this.TiempoPeriodoPujasHrs = pTiempoPeriodoPujasHrs;
		this.TiempoAdicionalPujasMin = pTiempoAdicionalPujasMin;
		this.TiempoEtapaFinalMin = pTiempoEtapaFinalMin;
		this.AplicaNomenclaturaInvolucrados = pAplicaNomenclaturaInvolucrados;
		this.MostrarMontoPropuestaGanando = pMostrarMontoPropuestaGanando;
		this.MostrarLugarProveedor = pMostrarLugarProveedor;
	}


}
}
