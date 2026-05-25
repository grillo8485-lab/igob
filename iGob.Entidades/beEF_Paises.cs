using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beEF_Paises {

	public int IdPais { get; set;}
	public string Pais { get; set;}
	public string AbreviacionPais { get; set;}

	public beEF_Paises()
	{
		
	}

	public beEF_Paises( int pIdPais, string pPais, string pAbreviacionPais)
	{
		this.IdPais = pIdPais;
		this.Pais = pPais;
		this.AbreviacionPais = pAbreviacionPais;
	}


}
}
