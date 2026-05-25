using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beDispercionMuestraUE {

	public int IdDispercionMuestraUE { get; set;}
	public int IdDeterminaPrecioBienServicio { get; set;}
	public string UnidadEconomica { get; set;}
	public string Direccion { get; set;}
	public decimal PrecioSinImpuesto { get; set;}
	public decimal Precio { get; set;}

	public beDispercionMuestraUE()
	{
		
	}

	public beDispercionMuestraUE( int pIdDispercionMuestraUE, int pIdDeterminaPrecioBienServicio, string pUnidadEconomica, string pDireccion, decimal pPrecioSinImpuesto, decimal pPrecio)
	{
		this.IdDispercionMuestraUE = pIdDispercionMuestraUE;
		this.IdDeterminaPrecioBienServicio = pIdDeterminaPrecioBienServicio;
		this.UnidadEconomica = pUnidadEconomica;
		this.Direccion = pDireccion;
		this.PrecioSinImpuesto = pPrecioSinImpuesto;
		this.Precio = pPrecio;
	}


}
}
