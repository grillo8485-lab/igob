using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beTiposEntregas {

	public int IdTipoEntrega { get; set;}
	public string TipoEntrega { get; set;}
	public bool Activo { get; set;}

	public beTiposEntregas()
	{
		
	}

	public beTiposEntregas( int pIdTipoEntrega, string pTipoEntrega, bool pActivo)
	{
		this.IdTipoEntrega = pIdTipoEntrega;
		this.TipoEntrega = pTipoEntrega;
		this.Activo = pActivo;
	}


}
}
