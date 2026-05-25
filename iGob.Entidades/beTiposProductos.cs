using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beTiposProductos {

	public int IdTipoProducto { get; set;}
	public string TipoProducto { get; set;}
	public bool Activo { get; set;}

	public beTiposProductos()
	{
		
	}

	public beTiposProductos( int pIdTipoProducto, string pTipoProducto, bool pActivo)
	{
		this.IdTipoProducto = pIdTipoProducto;
		this.TipoProducto = pTipoProducto;
		this.Activo = pActivo;
	}


}
}
