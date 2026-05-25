using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beAdjudicacionesLugaresFirmas {

	public int IdAdjudicacionLugarFirma { get; set;}
	public int IdAdjudicacion { get; set;}
	public int IdLugarFirma { get; set;}

	public beAdjudicacionesLugaresFirmas()
	{
		
	}

	public beAdjudicacionesLugaresFirmas( int pIdAdjudicacionLugarFirma, int pIdAdjudicacion, int pIdLugarFirma)
	{
		this.IdAdjudicacionLugarFirma = pIdAdjudicacionLugarFirma;
		this.IdAdjudicacion = pIdAdjudicacion;
		this.IdLugarFirma = pIdLugarFirma;
	}


}
}
