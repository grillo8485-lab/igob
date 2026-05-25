using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beSysModulos {

	public int IdModulo { get; set;}
	public string Modulo { get; set;}
	public string Descripcion { get; set;}
	public string Clave { get; set;}
	public int Orden { get; set;}
	public string Icono { get; set;}
	public bool Activo { get; set;}

	public beSysModulos()
	{
		
	}

	public beSysModulos( int pIdModulo, string pModulo, string pDescripcion, string pClave, int pOrden, string pIcono, bool pActivo)
	{
		this.IdModulo = pIdModulo;
		this.Modulo = pModulo;
		this.Descripcion = pDescripcion;
		this.Clave = pClave;
		this.Orden = pOrden;
		this.Icono = pIcono;
		this.Activo = pActivo;
	}


}
}
