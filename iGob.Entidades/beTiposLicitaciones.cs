using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beTiposLicitaciones {

	public int IdTipoLicitacion { get; set;}
	public string TipoLicitacion { get; set;}

	public beTiposLicitaciones()
	{
		
	}

	public beTiposLicitaciones( int pIdTipoLicitacion, string pTipoLicitacion)
	{
		this.IdTipoLicitacion = pIdTipoLicitacion;
		this.TipoLicitacion = pTipoLicitacion;
	}


}
}
