using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class bePeriodicidad {

	public int IdPeriodicidad { get; set;}
	public string Periodicidad { get; set;}
	public int Dias { get; set;}
	public int Meses { get; set;}
	public bool Activo { get; set;}

	public bePeriodicidad()
	{
		
	}

	public bePeriodicidad( int pIdPeriodicidad, string pPeriodicidad, int pDias, int pMeses, bool pActivo)
	{
		this.IdPeriodicidad = pIdPeriodicidad;
		this.Periodicidad = pPeriodicidad;
		this.Dias = pDias;
		this.Meses = pMeses;
		this.Activo = pActivo;
	}


}
}
