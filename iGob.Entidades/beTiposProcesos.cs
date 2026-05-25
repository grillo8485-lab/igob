using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beTiposProcesos {

	public int IdTipoProceso { get; set;}
	public string TipoProceso { get; set;}
	public bool Activo { get; set;}

	public beTiposProcesos()
	{
		
	}

	public beTiposProcesos( int pIdTipoProceso, string pTipoProceso, bool pActivo)
	{
		this.IdTipoProceso = pIdTipoProceso;
		this.TipoProceso = pTipoProceso;
		this.Activo = pActivo;
	}


}
}
