using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beEjerciciosFiscales {

	public int IdEjercicioFiscal { get; set;}
	public int Ejercicio { get; set;}
	public DateTime FechaInicial { get; set;}
	public DateTime FechaFinal { get; set;}
	public bool Activo { get; set;}

	public beEjerciciosFiscales()
	{
		
	}

	public beEjerciciosFiscales( int pIdEjercicioFiscal, int pEjercicio, DateTime pFechaInicial, DateTime pFechaFinal, bool pActivo)
	{
		this.IdEjercicioFiscal = pIdEjercicioFiscal;
		this.Ejercicio = pEjercicio;
		this.FechaInicial = pFechaInicial;
		this.FechaFinal = pFechaFinal;
		this.Activo = pActivo;
	}


}
}
