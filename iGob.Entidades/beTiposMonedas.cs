using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beTiposMonedas {

	public int IdTipoMoneda { get; set;}
	public string Moneda { get; set;}
	public decimal TipoCambio { get; set;}
	public bool Activo { get; set;}

	public beTiposMonedas()
	{
		
	}

	public beTiposMonedas( int pIdTipoMoneda, string pMoneda, decimal pTipoCambio, bool pActivo)
	{
		this.IdTipoMoneda = pIdTipoMoneda;
		this.Moneda = pMoneda;
		this.TipoCambio = pTipoCambio;
		this.Activo = pActivo;
	}


}
}
