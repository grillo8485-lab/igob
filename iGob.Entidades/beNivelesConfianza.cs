using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beNivelesConfianza {

	public int IdNivelConfianza { get; set;}
	public decimal NivelConfianza { get; set;}
	public decimal ValorConfianza { get; set;}

	public beNivelesConfianza()
	{
		
	}

	public beNivelesConfianza( int pIdNivelConfianza, decimal pNivelConfianza, decimal pValorConfianza)
	{
		this.IdNivelConfianza = pIdNivelConfianza;
		this.NivelConfianza = pNivelConfianza;
		this.ValorConfianza = pValorConfianza;
	}


}
}
