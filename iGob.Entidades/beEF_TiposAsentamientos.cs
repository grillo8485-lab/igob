using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace igob.Entidades
{
public class beEF_TiposAsentamientos {

	public string IdTipoAsenta { get; set;}
	public string Descripcion { get; set;}
	public string Abreviacion { get; set;}

	public beEF_TiposAsentamientos()
	{
		
	}

	public beEF_TiposAsentamientos( string pIdTipoAsenta, string pDescripcion, string pAbreviacion)
	{
		this.IdTipoAsenta = pIdTipoAsenta;
		this.Descripcion = pDescripcion;
		this.Abreviacion = pAbreviacion;
	}


}
}
