using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beSysPerfiles {

	public int IdPerfil { get; set;}
	public string Perfil { get; set;}
	public string Descripcion { get; set;}
	public string CodigoPerfil { get; set;}
	public bool Activo { get; set;}

	public beSysPerfiles()
	{
		
	}

	public beSysPerfiles( int pIdPerfil, string pPerfil, string pDescripcion, string pCodigoPerfil, bool pActivo)
	{
		this.IdPerfil = pIdPerfil;
		this.Perfil = pPerfil;
		this.Descripcion = pDescripcion;
		this.CodigoPerfil = pCodigoPerfil;
		this.Activo = pActivo;
	}


}
}
