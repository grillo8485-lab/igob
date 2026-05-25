using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beConfiguracionModalidad {

	public int IdConfiguracionModalidad { get; set;}
	public int IdGobierno { get; set;}
	public int IdModalidad { get; set;}
	public decimal MontoMinimo { get; set;}
	public decimal MontoMaximo { get; set;}
    
    /* Gobierno 24/08/2018 */
    public string Gobierno { get; set;}

	public beConfiguracionModalidad()
	{
		
	}

	public beConfiguracionModalidad( int pIdConfiguracionModalidad, int pIdGobierno, int pIdModalidad, decimal pMontoMinimo, decimal pMontoMaximo)
	{
		this.IdConfiguracionModalidad = pIdConfiguracionModalidad;
		this.IdGobierno = pIdGobierno;
		this.IdModalidad = pIdModalidad;
		this.MontoMinimo = pMontoMinimo;
		this.MontoMaximo = pMontoMaximo;
	}


}
}
