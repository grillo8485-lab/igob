using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beMuestras {

	public int IdMuestra { get; set;}
	public string Muestra { get; set;}
	public bool Activo { get; set;}

	public beMuestras()
	{
		
	}

	public beMuestras( int pIdMuestra, string pMuestra, bool pActivo)
	{
		this.IdMuestra = pIdMuestra;
		this.Muestra = pMuestra;
		this.Activo = pActivo;
	}


}
}
