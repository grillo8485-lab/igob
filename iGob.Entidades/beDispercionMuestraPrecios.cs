using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
    public class beDispercionMuestraPrecios {

	    public int IdDispercionMuestraPrecio { get; set;}
	    public int IdDeterminaPrecioBienServicio { get; set;}
	    public int IdUnidadEconomica { get; set;}
	    public decimal PrecioSinImpuesto { get; set;}
	    public decimal Precio { get; set;}
        public string NombreUnidadEconomica { get; set; }

        public beDispercionMuestraPrecios(){}

	    public beDispercionMuestraPrecios( int pIdDispercionMuestraPrecio, int pIdDeterminaPrecioBienServicio, int pIdUnidadEconomica, decimal pPrecioSinImpuesto, decimal pPrecio)
	    {
		    this.IdDispercionMuestraPrecio = pIdDispercionMuestraPrecio;
		    this.IdDeterminaPrecioBienServicio = pIdDeterminaPrecioBienServicio;
		    this.IdUnidadEconomica = pIdUnidadEconomica;
		    this.PrecioSinImpuesto = pPrecioSinImpuesto;
		    this.Precio = pPrecio;
	    }
    }
}
