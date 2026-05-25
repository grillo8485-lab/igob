using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beHistotialPreciosBienServicio {

	public int IdHistorialPrecioBienServicio { get; set;}
	public int IdBienServicio { get; set;}
	public decimal PrecioUnitarioActual { get; set;}
	public decimal PrecioUnitarioAnterior { get; set;}
	public DateTime FechaActualizacion { get; set;}
	public int IdDatoEstudioMercado { get; set;}

	public beHistotialPreciosBienServicio()
	{
		
	}

	public beHistotialPreciosBienServicio( int pIdHistorialPrecioBienServicio, int pIdBienServicio, decimal pPrecioUnitarioActual, decimal pPrecioUnitarioAnterior, DateTime pFechaActualizacion, int pIdDatoEstudioMercado)
	{
		this.IdHistorialPrecioBienServicio = pIdHistorialPrecioBienServicio;
		this.IdBienServicio = pIdBienServicio;
		this.PrecioUnitarioActual = pPrecioUnitarioActual;
		this.PrecioUnitarioAnterior = pPrecioUnitarioAnterior;
		this.FechaActualizacion = pFechaActualizacion;
		this.IdDatoEstudioMercado = pIdDatoEstudioMercado;
	}


}
}
