using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beAnticipos {

	public int IdAnticipo { get; set;}
	public string AnticipoPorcentaje { get; set;}
	public decimal PorcentajeValor { get; set;}

	public beAnticipos()
	{
		
	}

	public beAnticipos( int pIdAnticipo, string pAnticipoPorcentaje, decimal pPorcentajeValor)
	{
		this.IdAnticipo = pIdAnticipo;
		this.AnticipoPorcentaje = pAnticipoPorcentaje;
		this.PorcentajeValor = pPorcentajeValor;
	}


}
}
