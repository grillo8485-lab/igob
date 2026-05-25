using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beTiposCondiciones {

	public int IdTipoCondicion { get; set;}
	public string TipoCondicion { get; set;}
	public bool Activo { get; set;}

	public beTiposCondiciones()
	{
		
	}

	public beTiposCondiciones( int pIdTipoCondicion, string pTipoCondicion, bool pActivo)
	{
		this.IdTipoCondicion = pIdTipoCondicion;
		this.TipoCondicion = pTipoCondicion;
		this.Activo = pActivo;
	}


}
}
