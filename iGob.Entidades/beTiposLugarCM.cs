using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beTiposLugarCM {

	public int IdTipoLugarCM { get; set;}
	public string TipoLugar { get; set;}
	public bool Activo { get; set;}

	public beTiposLugarCM()
	{
		
	}

	public beTiposLugarCM( int pIdTipoLugarCM, string pTipoLugar, bool pActivo)
	{
		this.IdTipoLugarCM = pIdTipoLugarCM;
		this.TipoLugar = pTipoLugar;
		this.Activo = pActivo;
	}


}
}
