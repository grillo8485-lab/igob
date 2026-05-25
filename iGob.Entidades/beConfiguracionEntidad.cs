using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beConfiguracionEntidad {

	public int IdConfiguraEntidad { get; set;}
	public int IdEntidad { get; set;}
	public int RepertirAccionistas { get; set;}
	public int LimiteGirosProveedor { get; set;}
	public int Cobrobases { get; set;}
	public decimal MontoBases { get; set;}
	public string HorarioLaboralInicio { get; set;}
	public string HorarioLaboralFin { get; set;}
	public string AlertaVerde { get; set;}
	public string AlertaAmarilla { get; set;}
	public string AlertaRoja { get; set;}
	public int DiasEnvioCorreo2daVuelta { get; set;}
	public int DiasCancelarNoAtendida { get; set;}
	public string TiempoValidaPago { get; set;}
	public string TiempoExtraValidaPago { get; set;}
	public int AplicarRestriccionCedula { get; set;}
	public string UrlBanner { get; set;}
	public string UrlLogo { get; set;}
	public int IdUsuarioRegistro { get; set;}
	public DateTime FechaRegistro { get; set;}

	public beConfiguracionEntidad()
	{
		
	}

	public beConfiguracionEntidad( int pIdConfiguraEntidad, int pIdEntidad, int pRepertirAccionistas, int pLimiteGirosProveedor, int pCobrobases, decimal pMontoBases, string pHorarioLaboralInicio, string pHorarioLaboralFin, string pAlertaVerde, string pAlertaAmarilla, string pAlertaRoja, int pDiasEnvioCorreo2daVuelta, int pDiasCancelarNoAtendida, string pTiempoValidaPago, string pTiempoExtraValidaPago, int pAplicarRestriccionCedula, string pUrlBanner, string pUrlLogo, int pIdUsuarioRegistro, DateTime pFechaRegistro)
	{
		this.IdConfiguraEntidad = pIdConfiguraEntidad;
		this.IdEntidad = pIdEntidad;
		this.RepertirAccionistas = pRepertirAccionistas;
		this.LimiteGirosProveedor = pLimiteGirosProveedor;
		this.Cobrobases = pCobrobases;
		this.MontoBases = pMontoBases;
		this.HorarioLaboralInicio = pHorarioLaboralInicio;
		this.HorarioLaboralFin = pHorarioLaboralFin;
		this.AlertaVerde = pAlertaVerde;
		this.AlertaAmarilla = pAlertaAmarilla;
		this.AlertaRoja = pAlertaRoja;
		this.DiasEnvioCorreo2daVuelta = pDiasEnvioCorreo2daVuelta;
		this.DiasCancelarNoAtendida = pDiasCancelarNoAtendida;
		this.TiempoValidaPago = pTiempoValidaPago;
		this.TiempoExtraValidaPago = pTiempoExtraValidaPago;
		this.AplicarRestriccionCedula = pAplicarRestriccionCedula;
		this.UrlBanner = pUrlBanner;
		this.UrlLogo = pUrlLogo;
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
		this.FechaRegistro = pFechaRegistro;
	}


}
}
