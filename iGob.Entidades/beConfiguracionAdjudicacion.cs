using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace SoftHomeDeco.Entidades
{
public class beConfiguracionAdjudicacion {

	public int IdConfiguracionAdjudicacion { get; set;}
	public string ConfiguracionAdjudicacion { get; set;}
	public decimal MontoMinimo { get; set;}
	public decimal MontoMaximo { get; set;}
	public int IdModalidadRequisicion { get; set;}

	public beConfiguracionAdjudicacion()
	{
		
	}

	public beConfiguracionAdjudicacion( int pIdConfiguracionAdjudicacion, string pConfiguracionAdjudicacion, decimal pMontoMinimo, decimal pMontoMaximo, int pIdModalidadRequisicion)
	{
		this.IdConfiguracionAdjudicacion = pIdConfiguracionAdjudicacion;
		this.ConfiguracionAdjudicacion = pConfiguracionAdjudicacion;
		this.MontoMinimo = pMontoMinimo;
		this.MontoMaximo = pMontoMaximo;
		this.IdModalidadRequisicion = pIdModalidadRequisicion;
	}


}
}
