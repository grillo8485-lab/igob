using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beTiposDias {

	public int IdTipoDia { get; set;}
	public string TipoDia { get; set;}

	public beTiposDias()
	{
		
	}

	public beTiposDias( int pIdTipoDia, string pTipoDia)
	{
		this.IdTipoDia = pIdTipoDia;
		this.TipoDia = pTipoDia;
	}


}
}
