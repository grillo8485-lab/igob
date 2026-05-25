using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beMarcas {

	public int IdMarca { get; set;}
	public string Marca { get; set;}
	public string Abreviatura { get; set;}
	public bool Activo { get; set;}

	public beMarcas()
	{
		
	}

	public beMarcas( int pIdMarca, string pMarca, string pAbreviatura, bool pActivo)
	{
		this.IdMarca = pIdMarca;
		this.Marca = pMarca;
		this.Abreviatura = pAbreviatura;
		this.Activo = pActivo;
	}


}
}
