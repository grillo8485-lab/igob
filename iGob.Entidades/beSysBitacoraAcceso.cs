using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beSysBitacoraAcceso {

	public int IdAcceso { get; set;}
	public int IdUsuario { get; set;}
	public DateTime Fecha { get; set;}
	public bool Acceso { get; set;}
	public string LlaveAcceso { get; set;}

	public beSysBitacoraAcceso()
	{
		
	}

	public beSysBitacoraAcceso( int pIdAcceso, int pIdUsuario, DateTime pFecha, bool pAcceso, string pllaveAcceso)
	{
		this.IdAcceso = pIdAcceso;
		this.IdUsuario = pIdUsuario;
		this.Fecha = pFecha;
		this.Acceso = pAcceso;
		this.LlaveAcceso = pllaveAcceso;
	}


}
}
