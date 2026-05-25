using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beSysPerfilesFunciones {

	public int IdPerfilFuncion { get; set;}
	public int IdPerfil { get; set;}
	public int IdFuncion { get; set;}
	public bool btnNuevo { get; set;}
	public bool btnEditar { get; set;}
	public bool btnEliminar { get; set;}
	public bool btnConsultar { get; set;}

	public beSysPerfilesFunciones()
	{
		
	}

	public beSysPerfilesFunciones( int pIdPerfilFuncion, int pIdPerfil, int pIdFuncion, bool pbtnNuevo, bool pbtnEditar, bool pbtnEliminar, bool pbtnConsultar)
	{
		this.IdPerfilFuncion = pIdPerfilFuncion;
		this.IdPerfil = pIdPerfil;
		this.IdFuncion = pIdFuncion;
		this.btnNuevo = pbtnNuevo;
		this.btnEditar = pbtnEditar;
		this.btnEliminar = pbtnEliminar;
		this.btnConsultar = pbtnConsultar;
	}


}
}
