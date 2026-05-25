using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class bePlazosTiempos {

	public int IdPlazoTiempo { get; set;}
	public string PlazozTiempo { get; set;}
	public bool Activo { get; set;}

	public bePlazosTiempos()
	{
		
	}

	public bePlazosTiempos( int pIdPlazoTiempo, string pPlazozTiempo, bool pActivo)
	{
		this.IdPlazoTiempo = pIdPlazoTiempo;
		this.PlazozTiempo = pPlazozTiempo;
		this.Activo = pActivo;
	}


}
}
