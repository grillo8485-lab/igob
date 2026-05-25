using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class bePoliticas {

	public int IdPolitica { get; set;}
	public int IdEntidad { get; set;}
	public int Ordenamiento { get; set;}
	public string Politica { get; set;}
	public string Descripcion { get; set;}

	public bePoliticas()
	{
		
	}

	public bePoliticas( int pIdPolitica, int pIdEntidad, int pOrdenamiento, string pPolitica, string pDescripcion)
	{
		this.IdPolitica = pIdPolitica;
		this.IdEntidad = pIdEntidad;
		this.Ordenamiento = pOrdenamiento;
		this.Politica = pPolitica;
		this.Descripcion = pDescripcion;
	}


}
}
