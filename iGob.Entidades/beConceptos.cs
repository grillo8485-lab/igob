using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace igob.Entidades
{
public class beConceptos {

	public int IdConcepto { get; set;}
	public int IdCapitulo { get; set;}
	public string ConceptoNumero { get; set;}
	public string Concepto { get; set;}
	public string Descripcion { get; set;}
	public int Activo { get; set;}

	public beConceptos()
	{
		
	}

	public beConceptos( int pIdConcepto, int pIdCapitulo, string pConceptoNumero, string pConcepto, string pDescripcion, int pActivo)
	{
		this.IdConcepto = pIdConcepto;
		this.IdCapitulo = pIdCapitulo;
		this.ConceptoNumero = pConceptoNumero;
		this.Concepto = pConcepto;
		this.Descripcion = pDescripcion;
		this.Activo = pActivo;
	}


}
}
