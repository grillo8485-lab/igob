using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beGobierno {

	public int IdGobierno { get; set;}
	public string Gobierno { get; set;}
	public bool RepertirAccionistas { get; set;}
	public int LimiteGirosProveedor { get; set;}
	public bool Cobrobases { get; set;}
	public decimal MontoBases { get; set;}
	public TimeSpan HorarioLaboralInicio { get; set;}
	public TimeSpan HorarioLaboralFin { get; set;}
	public TimeSpan AlertaVerde { get; set;}
	public TimeSpan AlertaAmarilla { get; set;}
	public TimeSpan AlertaRoja { get; set;}
	public int DiasEnvioCorreo2daVuelta { get; set;}
	public int DiasCancelarNoAtendida { get; set;}
	public TimeSpan TiempoValidaPago { get; set;}
	public TimeSpan TiempoExtraValidaPago { get; set;}
	public int AplicarRestriccionCedula { get; set;}
	public string UrlBanner { get; set;}
	public string UrlLogo { get; set;}
	public bool AplicarFechasCedula { get; set;}
	public int IdUsuarioRegistro { get; set;}
	public DateTime FechaRegistro { get; set;}
        public string Banner { get; set; }
        public string Logo { get; set; }


    public beGobierno()
	{
		
	}

	public beGobierno( int pIdGobierno, string pGobierno, bool pRepertirAccionistas, int pLimiteGirosProveedor, bool pCobrobases, decimal pMontoBases, TimeSpan pHorarioLaboralInicio, TimeSpan pHorarioLaboralFin, TimeSpan pAlertaVerde, TimeSpan pAlertaAmarilla, TimeSpan pAlertaRoja, int pDiasEnvioCorreo2daVuelta, int pDiasCancelarNoAtendida, TimeSpan pTiempoValidaPago, TimeSpan pTiempoExtraValidaPago, int pAplicarRestriccionCedula, string pUrlBanner, string pUrlLogo, bool pAplicarFechasCedula, int pIdUsuarioRegistro, DateTime pFechaRegistro, string pBanner,string pLogo)
	{
		this.IdGobierno = pIdGobierno;
		this.Gobierno = pGobierno;
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
		this.AplicarFechasCedula = pAplicarFechasCedula;
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
		this.FechaRegistro = pFechaRegistro;
            this.Logo = pLogo;
            this.Banner = pBanner;
	}


}
}
