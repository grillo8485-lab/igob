using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beTiposSolicitud {

	public int IdTipoSolicitud { get; set;}
	public string TipoSolicitud { get; set;}
	public string Descripcion { get; set;}
	public string Abreviatura { get; set;}
	public bool Activo { get; set;}

	public beTiposSolicitud()
	{
		
	}

	public beTiposSolicitud( int pIdTipoSolicitud, string pTipoSolicitud, string pDescripcion, string pAbreviatura, bool pActivo)
	{
		this.IdTipoSolicitud = pIdTipoSolicitud;
		this.TipoSolicitud = pTipoSolicitud;
		this.Descripcion = pDescripcion;
		this.Abreviatura = pAbreviatura;
		this.Activo = pActivo;
	}


}
}
