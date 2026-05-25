using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beTiposRequisiciones {

	public int IdTipoRequisicion { get; set;}
	public string TipoRequisicion { get; set;}
	public string Abreviacion { get; set;}
	public bool Activo { get; set;}

	public beTiposRequisiciones()
	{
		
	}

	public beTiposRequisiciones( int pIdTipoRequisicion, string pTipoRequisicion, string pAbreviacion, bool pActivo)
	{
		this.IdTipoRequisicion = pIdTipoRequisicion;
		this.TipoRequisicion = pTipoRequisicion;
		this.Abreviacion = pAbreviacion;
		this.Activo = pActivo;
	}


}
}
