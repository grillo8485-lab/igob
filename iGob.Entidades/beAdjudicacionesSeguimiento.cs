using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beAdjudicacionesSeguimiento {

	public int IdAdjudicacionSeguimiento { get; set;}
	public int IdAdjudicacion { get; set;}
	public int IdEstatusAdjudicacion { get; set;}
	public DateTime Fecha { get; set;}
	public string Token { get; set;}
	public int IdUsarioRegistro { get; set;}

	public beAdjudicacionesSeguimiento()
	{
		
	}

	public beAdjudicacionesSeguimiento( int pIdAdjudicacionSeguimiento, int pIdAdjudicacion, int pIdEstatusAdjudicacion, DateTime pFecha, string pToken, int pIdUsarioRegistro)
	{
		this.IdAdjudicacionSeguimiento = pIdAdjudicacionSeguimiento;
		this.IdAdjudicacion = pIdAdjudicacion;
		this.IdEstatusAdjudicacion = pIdEstatusAdjudicacion;
		this.Fecha = pFecha;
		this.Token = pToken;
		this.IdUsarioRegistro = pIdUsarioRegistro;
	}


}
}
