using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beTiposPersonas {

	public int IdTipoPersona { get; set;}
	public string TipoPersona { get; set;}
	public bool Activo { get; set;}

	public beTiposPersonas()
	{
		
	}

	public beTiposPersonas( int pIdTipoPersona, string pTipoPersona, bool pActivo)
	{
		this.IdTipoPersona = pIdTipoPersona;
		this.TipoPersona = pTipoPersona;
		this.Activo = pActivo;
	}


}
}
