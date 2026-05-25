using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beProductosScian {

	public int IdCodigoScian { get; set;}
	public int CodigoScian { get; set;}
	public string Titulo { get; set;}
	public string Descripcion { get; set;}
	public string Incluye { get; set;}
	public string Excluye { get; set;}
	public string Productos { get; set;}

	public beProductosScian()
	{
		
	}

	public beProductosScian( int pIdCodigoScian, int pCodigoScian, string pTitulo, string pDescripcion, string pIncluye, string pExcluye, string pProductos)
	{
		this.IdCodigoScian = pIdCodigoScian;
		this.CodigoScian = pCodigoScian;
		this.Titulo = pTitulo;
		this.Descripcion = pDescripcion;
		this.Incluye = pIncluye;
		this.Excluye = pExcluye;
		this.Productos = pProductos;
	}


}
}
