using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beImpuestos {

	public int IdImpuesto { get; set;}
	public string Clave { get; set;}
	public string Descripcion { get; set;}
	public decimal Tasa { get; set;}
	public string Retencion { get; set;}
	public string Traslado { get; set;}
	public string TipoImpuesto { get; set;}
	public string Entidad { get; set;}
	public DateTime FechaVigencia { get; set;}
	public string Version { get; set;}

	public beImpuestos()
	{
		
	}

	public beImpuestos( int pIdImpuesto, string pClave, string pDescripcion, decimal pTasa, string pRetencion, string pTraslado, string pTipoImpuesto, string pEntidad, DateTime pFechaVigencia, string pVersion)
	{
		this.IdImpuesto = pIdImpuesto;
		this.Clave = pClave;
		this.Descripcion = pDescripcion;
		this.Tasa = pTasa;
		this.Retencion = pRetencion;
		this.Traslado = pTraslado;
		this.TipoImpuesto = pTipoImpuesto;
		this.Entidad = pEntidad;
		this.FechaVigencia = pFechaVigencia;
		this.Version = pVersion;
	}


}
}
