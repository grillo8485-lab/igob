using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beTiposRepresentacion {

	public int IdTipoRepresentacion { get; set;}
	public string TipoRepresentacion { get; set;}
	public bool Activo { get; set;}

	public beTiposRepresentacion()
	{
		
	}

	public beTiposRepresentacion( int pIdTipoRepresentacion, string pTipoRepresentacion, bool pActivo)
	{
		this.IdTipoRepresentacion = pIdTipoRepresentacion;
		this.TipoRepresentacion = pTipoRepresentacion;
		this.Activo = pActivo;
	}


}
}
