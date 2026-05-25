using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beTiempos {

	public int IdTiempo { get; set;}
	public string Tiempo { get; set;}
	public bool Activo { get; set;}

	public beTiempos()
	{
		
	}

	public beTiempos( int pIdTiempo, string pTiempo, bool pActivo)
	{
		this.IdTiempo = pIdTiempo;
		this.Tiempo = pTiempo;
		this.Activo = pActivo;
	}


}
}
