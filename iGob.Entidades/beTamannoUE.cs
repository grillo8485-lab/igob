using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beTamannoUE {

	public int IdTamannoUE { get; set;}
	public string TamanoUE { get; set;}

	public beTamannoUE()
	{
		
	}

	public beTamannoUE( int pIdTamannoUE, string pTamanoUE)
	{
		this.IdTamannoUE = pIdTamannoUE;
		this.TamanoUE = pTamanoUE;
	}


}
}
