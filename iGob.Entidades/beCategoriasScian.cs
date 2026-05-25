using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beCategoriasScian {

	public int CodigoScian { get; set;}
	public string Titulo { get; set;}
	public string Descripcion { get; set;}
	public string Incluye { get; set;}
	public string Excluye { get; set;}

	public beCategoriasScian()
	{
		
	}

	public beCategoriasScian( int pCodigoScian, string pTitulo, string pDescripcion, string pIncluye, string pExcluye)
	{
		this.CodigoScian = pCodigoScian;
		this.Titulo = pTitulo;
		this.Descripcion = pDescripcion;
		this.Incluye = pIncluye;
		this.Excluye = pExcluye;
	}


}
}
