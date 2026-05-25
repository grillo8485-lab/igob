using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beFrecuencias {

	public int IdFrecuencia { get; set;}
	public string Frecuencia { get; set;}
	public bool Activo { get; set;}

	public beFrecuencias()
	{
		
	}

	public beFrecuencias( int pIdFrecuencia, string pFrecuencia, bool pActivo)
	{
		this.IdFrecuencia = pIdFrecuencia;
		this.Frecuencia = pFrecuencia;
		this.Activo = pActivo;
	}


}
}
