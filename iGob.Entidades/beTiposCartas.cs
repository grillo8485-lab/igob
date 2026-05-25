using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beTiposCartas {

	public int IdTipoCarta { get; set;}
	public string TipoCarta { get; set;}
	public bool Activo { get; set;}

	public beTiposCartas()
	{
		
	}

	public beTiposCartas( int pIdTipoCarta, string pTipoCarta, bool pActivo)
	{
		this.IdTipoCarta = pIdTipoCarta;
		this.TipoCarta = pTipoCarta;
		this.Activo = pActivo;
	}


}
}
