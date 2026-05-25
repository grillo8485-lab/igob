using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beTiposLugar {

	public int IdTipoLugar { get; set;}
	public string TipoLugar { get; set;}
	public bool Activo { get; set;}

	public beTiposLugar()
	{
		
	}

	public beTiposLugar( int pIdTipoLugar, string pTipoLugar, bool pActivo)
	{
		this.IdTipoLugar = pIdTipoLugar;
		this.TipoLugar = pTipoLugar;
		this.Activo = pActivo;
	}


}
}
