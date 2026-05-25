using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beDiasInhabiles {

	public int IdDiaInhabil { get; set;}
	public DateTime Fecha { get; set;}
	public string Evento { get; set;}
	public bool Activo { get; set;}

	public beDiasInhabiles()
	{
		
	}

	public beDiasInhabiles( int pIdDiaInhabil, DateTime pFecha, string pEvento, bool pActivo)
	{
		this.IdDiaInhabil = pIdDiaInhabil;
		this.Fecha = pFecha;
		this.Evento = pEvento;
		this.Activo = pActivo;
	}


}
}
