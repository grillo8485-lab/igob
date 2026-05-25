using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beModificadorProducto {

	public int IdModificador { get; set;}
	public string Modificador { get; set;}
	public string ImagenPdf { get; set;}
	public string Codigo { get; set;}
	public string Descripcion { get; set;}
	public bool Activo { get; set;}

	public beModificadorProducto()
	{
		
	}

	public beModificadorProducto( int pIdModificador, string pModificador, string pImagenPdf, string pCodigo, string pDescripcion, bool pActivo)
	{
		this.IdModificador = pIdModificador;
		this.Modificador = pModificador;
		this.ImagenPdf = pImagenPdf;
		this.Codigo = pCodigo;
		this.Descripcion = pDescripcion;
		this.Activo = pActivo;
	}


}
}
