using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class bePlazosEntregas {

	public int IdPlazoEntrega { get; set;}
	public string PlazoEntrega { get; set;}
	public bool Activo { get; set;}

	public bePlazosEntregas()
	{
		
	}

	public bePlazosEntregas( int pIdPlazoEntrega, string pPlazoEntrega, bool pActivo)
	{
		this.IdPlazoEntrega = pIdPlazoEntrega;
		this.PlazoEntrega = pPlazoEntrega;
		this.Activo = pActivo;
	}


}
}
