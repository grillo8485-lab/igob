using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beDeterminacionPrecios {

	public int IdDeterminaPrecioBienServicio { get; set;}
	public int IdBienServicio { get; set;}
	public int IdDatoEstudioMercado { get; set;}
	public int Poblacion { get; set;}
	public decimal NivelConfianza { get; set;}
	public decimal ConstanteNivelConfianza { get; set;}
	public decimal Varianza { get; set;}
	public decimal MargenError { get; set;}
	public decimal Muestra { get; set;}
	public int MuestraRedondeada { get; set;}
	public DateTime FechaCalculoMuestra { get; set;}
	public decimal Promedio { get; set;}
	public decimal Maximo { get; set;}
	public decimal Minimo { get; set;}
	public decimal Moda { get; set;}
	public decimal Mediana { get; set;}
	public DateTime FechaCalculoPrecio { get; set;}
	public decimal PrecioAplicado { get; set;}

	public beDeterminacionPrecios()
	{
		
	}

	public beDeterminacionPrecios( int pIdDeterminaPrecioBienServicio, int pIdBienServicio, int pIdDatoEstudioMercado, int pPoblacion, decimal pNivelConfianza, decimal pConstanteNivelConfianza, decimal pVarianza, decimal pMargenError, decimal pMuestra, int pMuestraRedondeada, DateTime pFechaCalculoMuestra, decimal pPromedio, decimal pMaximo, decimal pMinimo, decimal pModa, decimal pMediana, DateTime pFechaCalculoPrecio, decimal pPrecioAplicado)
	{
		this.IdDeterminaPrecioBienServicio = pIdDeterminaPrecioBienServicio;
		this.IdBienServicio = pIdBienServicio;
		this.IdDatoEstudioMercado = pIdDatoEstudioMercado;
		this.Poblacion = pPoblacion;
		this.NivelConfianza = pNivelConfianza;
		this.ConstanteNivelConfianza = pConstanteNivelConfianza;
		this.Varianza = pVarianza;
		this.MargenError = pMargenError;
		this.Muestra = pMuestra;
		this.MuestraRedondeada = pMuestraRedondeada;
		this.FechaCalculoMuestra = pFechaCalculoMuestra;
		this.Promedio = pPromedio;
		this.Maximo = pMaximo;
		this.Minimo = pMinimo;
		this.Moda = pModa;
		this.Mediana = pMediana;
		this.FechaCalculoPrecio = pFechaCalculoPrecio;
		this.PrecioAplicado = pPrecioAplicado;
	}


}
}
