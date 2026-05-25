using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beSysFunciones {

	public int IdFuncion { get; set;}
	public int IdModulo { get; set;}
	public string Funcion { get; set;}
	public string Descripcion { get; set;}
	public string Formulario { get; set;}
	public int Orden { get; set;}
	public bool Activo { get; set;}
	public string Icono { get; set;}

	public beSysFunciones()
	{
		
	}

	public beSysFunciones( int pIdFuncion, int pIdModulo, string pFuncion, string pDescripcion, string pFormulario, int pOrden, bool pActivo, string pIcono)
	{
		this.IdFuncion = pIdFuncion;
		this.IdModulo = pIdModulo;
		this.Funcion = pFuncion;
		this.Descripcion = pDescripcion;
		this.Formulario = pFormulario;
		this.Orden = pOrden;
		this.Activo = pActivo;
		this.Icono = pIcono;
	}


}
}
