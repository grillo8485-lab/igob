using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beTiposAdjudicacion {

	public int IdTipoAdjudicacion { get; set;}
	public string TipoAdjudicacion { get; set;}
	public string Abreviatura { get; set;}
	public decimal MontoMinimo { get; set;}
	public decimal MontoMaximo { get; set;}

	public beTiposAdjudicacion()
	{
		
	}

	public beTiposAdjudicacion( int pIdTipoAdjudicacion, string pTipoAdjudicacion, string pAbreviatura, decimal pMontoMinimo, decimal pMontoMaximo)
	{
		this.IdTipoAdjudicacion = pIdTipoAdjudicacion;
		this.TipoAdjudicacion = pTipoAdjudicacion;
		this.Abreviatura = pAbreviatura;
		this.MontoMinimo = pMontoMinimo;
		this.MontoMaximo = pMontoMaximo;
	}


}
}
