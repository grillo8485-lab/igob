using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beConfiguracionModalidadTipoProceso {

	public int IdConfiguracionModalidadTipoProceso { get; set;}
	public int IdTipoProceso { get; set;}
	public int IdModalidadLicitacion { get; set;}
	public decimal MontoMinimo { get; set;}
	public decimal MontoMaximo { get; set;}



	public beConfiguracionModalidadTipoProceso()
	{
		
	}

	public beConfiguracionModalidadTipoProceso( int pIdConfiguracionModalidadTipoProceso, int pIdTipoProceso, int pIdModalidadLicitacion, decimal pMontoMinimo, decimal pMontoMaximo)
	{
		this.IdConfiguracionModalidadTipoProceso = pIdConfiguracionModalidadTipoProceso;
		this.IdTipoProceso = pIdTipoProceso;
		this.IdModalidadLicitacion = pIdModalidadLicitacion;
		this.MontoMinimo = pMontoMinimo;
		this.MontoMaximo = pMontoMaximo;
	}


}
}
