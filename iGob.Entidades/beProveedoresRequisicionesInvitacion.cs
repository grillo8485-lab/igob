using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beProveedoresRequisicionesInvitacion {

	public int IdProveedorRqInvitacion { get; set;}
	public int IdInvitacion { get; set;}
	public int IdRequisicion { get; set;}
	public int IdEstatusEnvioPropuestaTecnica { get; set;}
	public int IdUsuaroEnviaPropuestaTecnica { get; set;}
	public DateTime FechaEnvioPropuestaTecnica { get; set;}
	public int IdEstatusEnvioPropuestaEconomica { get; set;}
	public int IdUsuaroEnviaPropuestaEconomica { get; set;}
	public DateTime FechaEnvioPropuestaEconomica { get; set;}
	public bool CartasDependenciaCumple { get; set;}
	public string CartaFundamento { get; set;}
	public bool CartaAdquisicionCumple { get; set;}
	public string CartasAdqObservacion { get; set;}
	public bool CondicionEntregaDependenciaCumple { get; set;}
	public string CondicionEntregaFundamento { get; set;}
	public bool CondicionEntregaAdquisicionCumple { get; set;}
	public string CondicionEntregaAdqObservacion { get; set;}
	public bool CondicionPagoDependenciaCumple { get; set;}
	public string CondicionPagoFundamento { get; set;}
	public bool CondicionPagoAdquisicionCumple { get; set;}
	public string CondicionPagoAdqObservacion { get; set;}
	public bool ManifiestoDependenciaCumple { get; set;}
	public string ManifiestoFundamento { get; set;}
	public bool ManifiestoAdquisicionCumple { get; set;}
	public string ManifiestoAdqObservacion { get; set;}
	public int IdUsuarioRegistro { get; set;}
	public DateTime FechaRegistro { get; set;}

	public beProveedoresRequisicionesInvitacion()
	{
		
	}

	public beProveedoresRequisicionesInvitacion( int pIdProveedorRqInvitacion, int pIdInvitacion, int pIdRequisicion, int pIdEstatusEnvioPropuestaTecnica, int pIdUsuaroEnviaPropuestaTecnica, DateTime pFechaEnvioPropuestaTecnica, int pIdEstatusEnvioPropuestaEconomica, int pIdUsuaroEnviaPropuestaEconomica, DateTime pFechaEnvioPropuestaEconomica, bool pCartasDependenciaCumple, string pCartaFundamento, bool pCartaAdquisicionCumple, string pCartasAdqObservacion, bool pCondicionEntregaDependenciaCumple, string pCondicionEntregaFundamento, bool pCondicionEntregaAdquisicionCumple, string pCondicionEntregaAdqObservacion, bool pCondicionPagoDependenciaCumple, string pCondicionPagoFundamento, bool pCondicionPagoAdquisicionCumple, string pCondicionPagoAdqObservacion, bool pManifiestoDependenciaCumple, string pManifiestoFundamento, bool pManifiestoAdquisicionCumple, string pManifiestoAdqObservacion, int pIdUsuarioRegistro, DateTime pFechaRegistro)
	{
		this.IdProveedorRqInvitacion = pIdProveedorRqInvitacion;
		this.IdInvitacion = pIdInvitacion;
		this.IdRequisicion = pIdRequisicion;
		this.IdEstatusEnvioPropuestaTecnica = pIdEstatusEnvioPropuestaTecnica;
		this.IdUsuaroEnviaPropuestaTecnica = pIdUsuaroEnviaPropuestaTecnica;
		this.FechaEnvioPropuestaTecnica = pFechaEnvioPropuestaTecnica;
		this.IdEstatusEnvioPropuestaEconomica = pIdEstatusEnvioPropuestaEconomica;
		this.IdUsuaroEnviaPropuestaEconomica = pIdUsuaroEnviaPropuestaEconomica;
		this.FechaEnvioPropuestaEconomica = pFechaEnvioPropuestaEconomica;
		this.CartasDependenciaCumple = pCartasDependenciaCumple;
		this.CartaFundamento = pCartaFundamento;
		this.CartaAdquisicionCumple = pCartaAdquisicionCumple;
		this.CartasAdqObservacion = pCartasAdqObservacion;
		this.CondicionEntregaDependenciaCumple = pCondicionEntregaDependenciaCumple;
		this.CondicionEntregaFundamento = pCondicionEntregaFundamento;
		this.CondicionEntregaAdquisicionCumple = pCondicionEntregaAdquisicionCumple;
		this.CondicionEntregaAdqObservacion = pCondicionEntregaAdqObservacion;
		this.CondicionPagoDependenciaCumple = pCondicionPagoDependenciaCumple;
		this.CondicionPagoFundamento = pCondicionPagoFundamento;
		this.CondicionPagoAdquisicionCumple = pCondicionPagoAdquisicionCumple;
		this.CondicionPagoAdqObservacion = pCondicionPagoAdqObservacion;
		this.ManifiestoDependenciaCumple = pManifiestoDependenciaCumple;
		this.ManifiestoFundamento = pManifiestoFundamento;
		this.ManifiestoAdquisicionCumple = pManifiestoAdquisicionCumple;
		this.ManifiestoAdqObservacion = pManifiestoAdqObservacion;
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
		this.FechaRegistro = pFechaRegistro;
	}


}
}
