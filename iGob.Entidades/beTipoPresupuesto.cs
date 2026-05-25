using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beTipoPresupuesto {

	public int IdTipoPresuesto { get; set;}
	public string TipoPresuesto { get; set;}
	public bool  Activo { get; set;}

	public beTipoPresupuesto()
	{
		
	}

	public beTipoPresupuesto( int pIdTipoPresuesto, string pTipoPresuesto, bool pActivo)
	{
		this.IdTipoPresuesto = pIdTipoPresuesto;
		this.TipoPresuesto = pTipoPresuesto;
		this.Activo = pActivo;
	}


}
}
